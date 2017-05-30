using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NpgsqlTypes;
using System.Diagnostics;
using InkaArt.Business.Production;

namespace InkaArt.Interface.Production
{
    public partial class Jobs : Form
    {
        public Jobs()
        {
            InitializeComponent();
            ProcessController control = new ProcessController();

            DataTable processList = control.getData();

            for(int i = 0; i < processList.Rows.Count; i++)
            {
                dataGridView_process.Rows.Add(processList.Rows[i]["idProcess"],
                    processList.Rows[i]["description"],
                    processList.Rows[i]["positionCount"]);
            }
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void Jobs_Load(object sender, EventArgs e)
        {

        }

        private void Button_processDetails_Click(object sender, EventArgs e)
        {
            string id, name, count;
            id = name = count = "";

            foreach(DataGridViewRow row in dataGridView_process.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[3].Value);

                if(s == true)
                {
                    id = row.Cells[0].Value.ToString();
                    name = row.Cells[1].Value.ToString();
                    count = row.Cells[2].Value.ToString();
                    break;
                }
            }

            Form job_details = new JobDetails(id,name,count);
            job_details.Show();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            dataGridView_process.Rows.Clear();

            ProcessController control = new ProcessController();
            DataTable processList = control.getData();

            for (int i = 0; i < processList.Rows.Count; i++)
            {
                dataGridView_process.Rows.Add(processList.Rows[i]["idProcess"],
                    processList.Rows[i]["description"],
                    processList.Rows[i]["positionCount"]);
            }
        }
    }
}
