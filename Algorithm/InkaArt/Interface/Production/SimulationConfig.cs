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
        Simulation simulation;

        public SimulationConfig()
        {
            InitializeComponent();
            this.simulation = new Simulation();
        }
        
        public SimulationConfig(Simulation simulation)
        {
            InitializeComponent();

            this.simulation = simulation;
            this.Text = simulation.Name;
            this.textbox_roture.Text = simulation.BreakageWeight.ToString();
            this.textbox_time.Text = simulation.TimeWeight.ToString();
            this.textbox_huacos.Text = simulation.HuacoWeight.ToString();
            this.textbox_stones.Text = simulation.HuamangaStoneWeight.ToString();
            this.textbox_altarpieces.Text = simulation.RetableWeight.ToString();
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            this.simulation.Update(simulation.Name, double.Parse(textbox_roture.Text), double.Parse(textbox_time.Text), double.Parse(textbox_huacos.Text), double.Parse(textbox_stones.Text), double.Parse(textbox_altarpieces.Text));
        }
    }
}
