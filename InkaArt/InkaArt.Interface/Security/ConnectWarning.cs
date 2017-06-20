using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Security
{
    public partial class ConnectWarning : Form
    {
        private Timer timer;
        public ConnectWarning(int interval)
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = interval;
            timer.Tick += CloseForm;
            timer.Start();  //  Perdón si se cae, pero es porque se crea muchas veces este form (Ver linea 345 en Menu.cs)
        }
        private void CloseForm(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            this.DialogResult = DialogResult.OK;
        }
    }
}
