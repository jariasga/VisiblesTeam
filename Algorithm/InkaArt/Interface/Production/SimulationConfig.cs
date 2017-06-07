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

        public SimulationConfig()
        {
            InitializeComponent();
        }
        
        public SimulationConfig(SimulationController simulations, Simulation simulation, ComboBox combo_simulations,
            WorkerController workers)
        {
            InitializeComponent();

            this.workers = workers;
            this.list_workers.DataSource = workers.List();
            this.list_workers.DisplayMember = "FullName";
            
            this.simulations = simulations;
            this.simulation = simulation;
            this.combo_simulations = combo_simulations;

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

                this.Text = "Editar simulación de asignación de trabajadores";
            }
            else
            {
                this.Text = "Crear Simulación";
                this.textbox_days.Enabled = true;
                this.groupbox_weight.Enabled = true;
                this.list_orders.Enabled = true;
                this.list_workers.Enabled = true;
            }
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            string message;
            string action;
            List<Worker> workers = new List<Worker>();

            foreach (object item in list_workers.CheckedItems)
            {
                workers.Add((Worker)item);
            }
            // filtrar ordenes/pedidos

            if (simulation == null)
            {
                message = this.simulations.Insert(simulation, textbox_name.Text, textbox_days.Text, textbox_roture.Text,
                    textbox_time.Text, textbox_huacos.Text, textbox_stones.Text, textbox_altarpieces.Text, workers);
                action = "creada";
            }
            else
            {
                message = this.simulations.Update(simulation, textbox_name.Text, textbox_days.Text, textbox_roture.Text,
                    textbox_time.Text, textbox_huacos.Text, textbox_stones.Text, textbox_altarpieces.Text, workers);
                action = "actualizada";
            }

            if (message.Equals("OK")) { 
                MessageBox.Show(this, "La simulación ha sido " + action + " correctamente.", "Inka Art",
                    MessageBoxButtons.OK);
                Close();
            }
            else
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);            

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
