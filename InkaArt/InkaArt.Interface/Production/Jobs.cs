using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using InkaArt.Business.Production;

namespace InkaArt.Interface.Production
{
    public partial class Jobs : Form
    {
        private int maxRow=0;
        public Jobs()
        {
            InitializeComponent();
            ProcessController control = new ProcessController();
            DataTable processList = control.getData();
            maxRow = processList.Rows.Count;

            for(int i = 0; i < processList.Rows.Count; i++)
            {
                dataGridView_process.Rows.Add(processList.Rows[i]["id_process"],
                    processList.Rows[i]["description"],
                    processList.Rows[i]["number_of_jobs"]);
            }
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void Jobs_Load(object sender, EventArgs e)
        {

        }


        private void button_refresh_Click(object sender, EventArgs e)
        {
            dataGridView_process.Rows.Clear();

            ProcessController control = new ProcessController();
            DataTable processList = control.getData();

            for (int i = 0; i < processList.Rows.Count; i++)
            {
                dataGridView_process.Rows.Add(processList.Rows[i]["id_process"],
                    processList.Rows[i]["description"],
                    processList.Rows[i]["number_of_jobs"]);
            }
        }

        private void dataGridView_process_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, name, count;
            id = name = count = "";

            if (e.RowIndex >= 0 && e.RowIndex < maxRow && e.ColumnIndex ==3)
            {
                DataGridViewRow row = dataGridView_process.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                name = row.Cells[1].Value.ToString();
                count = row.Cells[2].Value.ToString();

                Form job_details = new JobDetails(id, name, count);
                job_details.MdiParent = this.MdiParent;
                job_details.Show();
            }
        }
    }
}
