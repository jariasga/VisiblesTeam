using InkaArt.Business.Algorithm;
using InkaArt.Data.Algorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Production
{
    public partial class SimulationConfig : Form
    {
        private SimulationController simulations;
        private Simulation simulation;
        private ComboBox combo_simulations;
        private WorkerController workers;
        private OrderController orders;

        public SimulationConfig()
        {
            InitializeComponent();
        }

        public SimulationConfig(SimulationController simulations, Simulation simulation, ComboBox combo_simulations,
            WorkerController workers, OrderController orders)
        {
            InitializeComponent();

            this.workers = workers;
            this.checkbox_workers.Checked = true;
            this.list_workers.DataSource = workers.List();
            this.list_workers.DisplayMember = "FullName";
            this.list_workers.Enabled = false;

            this.orders = orders;
            this.checkbox_orders.Checked = true;
            this.list_orders.DataSource = orders.List();
            this.list_orders.DisplayMember = "Description";
            this.list_orders.Enabled = false;

            this.simulations = simulations;
            this.simulation = simulation;
            this.combo_simulations = combo_simulations;
        }

        private void SimulationConfig_Load(object sender, EventArgs e)
        {
            if (simulation != null) //Visualización de una simulación
            {
                this.textbox_name.Text = simulation.Name;
                this.date_picker_start.Value = simulation.StartDate;
                this.date_picker_end.Value = simulation.EndDate;
                this.numeric_breakage.Value = Convert.ToDecimal(simulation.BreakageWeight * 100);
                this.numeric_time.Value = Convert.ToDecimal(simulation.TimeWeight * 100);
                this.numeric_huacos.Value = Convert.ToDecimal(simulation.HuacoWeight * 100);
                this.numeric_stones.Value = Convert.ToDecimal(simulation.HuamangaStoneWeight * 100);
                this.numeric_altarpiece.Value = Convert.ToDecimal(simulation.RetableWeight * 100);

                for (int i = 0; (simulation.SelectedWorkers != null) && (i < list_workers.Items.Count); i++)
                {
                    Worker worker = (Worker)list_workers.Items[i];
                    if (simulation.SelectedWorkers.GetByID(worker.ID) != null)
                        list_workers.SetItemChecked(i, true);
                }
                for (int i = 0; (simulation.SelectedOrders != null) && (i < list_orders.Items.Count); i++)
                {
                    if (simulation.SelectedOrders.Contains((Order)list_orders.Items[i]))
                        list_orders.SetItemChecked(i, true);
                }

                this.Text = "Ver simulación de asignación de trabajadores";
                this.button_start.Text = "🖫 Guardar cambios";
            }
            else //Creación de una simulación
            {
                this.date_picker_start.Enabled = true;
                this.date_picker_end.Enabled = true;
                this.groupbox_weight.Enabled = true;
                this.groupbox_workers.Enabled = true;
                this.groupbox_orders.Enabled = true;

                this.Text = "Nueva simulación de asignación de trabajadores";
                this.button_start.Text = "▶ Iniciar simulación";

                for (int i = 0; i < list_workers.Items.Count; i++)
                    list_workers.SetItemChecked(i, true);
                for (int i = 0; i < list_orders.Items.Count; i++)
                    list_orders.SetItemChecked(i, true);
            }

        }

        private void ButtonStartClick(object sender, EventArgs e)
        {
            WorkerController selected_workers = new WorkerController();
            if (checkbox_workers.Checked) selected_workers.Workers = list_workers.Items.Cast<Worker>().ToList();
            else
            {
                foreach (object worker in list_workers.CheckedItems)
                    selected_workers.Add((Worker)worker);
            }            

            OrderController selected_orders = new OrderController();
            if (checkbox_workers.Checked) selected_orders.Orders = list_orders.Items.Cast<Order>().ToList();
            else
            {
                foreach (object order in list_orders.CheckedItems)
                    selected_orders.Add((Order)order);
            }

            if (simulation == null) //Crear una nueva simulación y ejecutar la asignación de trabajadores
            {
                try
                {
                    Simulation simulation = simulations.Validate(textbox_name.Text, date_picker_start.Value, date_picker_end.Value,
                        numeric_breakage.Value, numeric_time.Value, numeric_huacos.Value, numeric_stones.Value,
                        numeric_altarpiece.Value, workers, selected_workers, orders, selected_orders);

                    //Llegó la hora de la verdad: ejecutar la simulación de asignación de trabajadores
                    Form loading_screen = new SimulationExecution(simulations, simulation, workers);
                    DialogResult result = loading_screen.ShowDialog();
                    if (result == DialogResult.Cancel) return;

                    //Habiendo terminado la simulación sin cancelarse, añadirla a la lista y actualizar el combo
                    simulations.Add(simulation);
                    combo_simulations.DataSource = simulations.BindingList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //Actualizar *solo* el nombre
            {
                if (this.textbox_name.Text == null || this.textbox_name.Text == "")
                {
                    MessageBox.Show("Por favor, ingrese un nombre válido.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                simulation.Name = this.textbox_name.Text;
                if (simulation.ID > 0)
                {
                    string message = simulation.updateName();
                    if (message != null) MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Los datos de la simulación fueron actualizados correctamente.", "Inka Art",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }            
        }
        
        private void checkboxWorkersCheckedChanged(object sender, EventArgs e)
        {
            list_workers.Enabled = !checkbox_workers.Checked;
        }

        private void checkboxOrdersCheckedChanged(object sender, EventArgs e)
        {
            list_orders.Enabled = !checkbox_orders.Checked;
        }
    }
}
