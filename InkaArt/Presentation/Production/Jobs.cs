using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Presentation.Production
{
    public partial class Jobs : Form
    {
        public Jobs()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form job_details = new JobDetails();
            job_details.Show();

        }
    }
}
