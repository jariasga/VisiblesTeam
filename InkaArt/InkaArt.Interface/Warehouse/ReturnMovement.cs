using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Warehouse
{
    public partial class ReturnMovement : Form
    {
        string typeMovement = "";

        public ReturnMovement()
        {
            InitializeComponent();
        }

        public ReturnMovement(string idWarehouse, string nameWarehouse, string typeMovement)
        {
            this.typeMovement = typeMovement;
            InitializeComponent();
            textBox6.Text = nameWarehouse;
            textBox5.Text = idWarehouse;
        }

    }
}
