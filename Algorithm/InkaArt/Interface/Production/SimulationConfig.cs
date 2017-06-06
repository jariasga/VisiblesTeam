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

        public SimulationConfig()
        {
            InitializeComponent();
        }
        
        public SimulationConfig(SimulationController simulations, Simulation simulation, ComboBox combo)
        {
            InitializeComponent();

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
            }
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            List<Worker> workers; // filtrar trabajadores y ordenes

            if (simulation == null)
            {
                this.simulation = new Simulation(textbox_name.Text, int.Parse(textbox_days.Text), double.Parse(textbox_roture.Text), double.Parse(textbox_time.Text), double.Parse(textbox_huacos.Text), double.Parse(textbox_stones.Text), double.Parse(textbox_altarpieces.Text));
                this.simulations.Add(simulation);                
            }
            else
                this.simulation.Update(simulation.Name, int.Parse(textbox_days.Text), double.Parse(textbox_roture.Text), double.Parse(textbox_time.Text), double.Parse(textbox_huacos.Text), double.Parse(textbox_stones.Text), double.Parse(textbox_altarpieces.Text), null);

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
