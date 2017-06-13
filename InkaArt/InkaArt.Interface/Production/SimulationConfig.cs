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
        SimulationController simulations;
        Simulation simulation;
        ComboBox combo_simulations;
        WorkerController workers;
        OrderController orders;

        public SimulationConfig()
        {
            InitializeComponent();
        }

        public SimulationConfig(SimulationController simulations, Simulation simulation, ComboBox combo, WorkerController workers, OrderController orders)
        {
            InitializeComponent();

            this.workers = workers;
            this.list_workers.DataSource = workers.List();
            this.list_workers.DisplayMember = "GetFullName";
            this.orders = orders;
            this.list_orders.DataSource = orders.List();
            this.list_orders.DisplayMember = "Description";

            this.simulations = simulations;
            this.simulation = simulation;
            this.combo_simulations = combo;

            if (simulation != null)
            {
                this.textbox_name.Text = simulation.Name;
                this.textbox_days.Text = simulation.Days.ToString();
                this.textbox_roture.Text = simulation.BreakageWeight.ToString();
                this.textbox_time.Text = simulation.TimeWeight.ToString();
                this.textbox_huacos.Text = simulation.HuacoWeight.ToString();
                this.textbox_stones.Text = simulation.HuamangaStoneWeight.ToString();
                this.textbox_altarpieces.Text = simulation.RetableWeight.ToString();

                for (int i = 0; i < list_workers.Items.Count; i++)
                {
                    if (simulation.Workers != null && simulation.Workers.Contains((Worker)list_workers.Items[i]))
                        list_workers.SetItemChecked(i, true);
                }
                for (int i = 0; i < list_orders.Items.Count; i++)
                {
                    if (simulation.Orders != null && simulation.Orders.Contains((Order)list_orders.Items[i]))
                        list_orders.SetItemChecked(i, true);
                }

                this.Text = "Editar Simulación";
                return;
            }

            this.Text = "Crear Simulación";
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            string message;
            string action;
            List<Worker> workers = new List<Worker>();
            List<Order> orders = new List<Order>();

            foreach (object item in list_workers.CheckedItems)
            {
                workers.Add((Worker)item);
            }
            foreach (object item in list_orders.CheckedItems)
            {
                orders.Add((Order)item);
            }

            if (simulation == null)
            {
                message = this.simulations.Insert(simulation, textbox_name.Text, textbox_days.Text, textbox_roture.Text, textbox_time.Text, textbox_huacos.Text, textbox_stones.Text, textbox_altarpieces.Text, workers, orders);
                action = "creada";
            }
            else
            {
                message = this.simulations.Update(simulation, textbox_name.Text, textbox_days.Text, textbox_roture.Text, textbox_time.Text, textbox_huacos.Text, textbox_stones.Text, textbox_altarpieces.Text, workers, orders);
                action = "actualizada";
            }

            if (message.Equals("OK"))
            {
                MessageBox.Show(this, "La simulación ha sido " + action + " correctamente.", "Éxito", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            combo_simulations.DataSource = simulations.BindingList();
        }

        private void textbox_huacos_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_time_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_roture_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
