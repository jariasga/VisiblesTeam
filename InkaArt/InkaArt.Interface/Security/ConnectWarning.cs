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
            timer.Start();
        }
        private void CloseForm(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            this.DialogResult = DialogResult.OK;
        }
    }
}
