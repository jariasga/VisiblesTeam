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
    public partial class TurnManagement : Form
    {
        public TurnManagement()
        {
            InitializeComponent();
            TurnController control = new TurnController();
            DataTable turnList = control.getData();

            for (int i= 0; i < turnList.Rows.Count; i++)
                comboBox_turn.Items.Add(turnList.Rows[i]["idTurn"].ToString());



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_turn_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox_turn.SelectedItem.ToString();
            TurnController control = new TurnController();
            DataTable turnList = control.getData();

            for (int i = 0; i < turnList.Rows.Count; i++)
            {
                if (String.Compare(turnList.Rows[i]["idTurn"].ToString(), comboBox_turn.SelectedItem.ToString()) == 0)
                {
                    textBox_horaIni.Text = turnList.Rows[i]["start"].ToString();
                    textBox_horaFin.Text = turnList.Rows[i]["end"].ToString();
                    textBox_desc.Text = turnList.Rows[i]["description"].ToString();
                    break;
                }
            }


        }

        private void TurnManagement_Load(object sender, EventArgs e)
        {

        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            //nuevo turno
            if (checkBox_nuevoTurno.Checked)
            {
                TurnController control = new TurnController();

                string ini, fin, desc;
                ini = textBox_horaIni.Text.ToString();
                fin = textBox_horaFin.Text.ToString();
                desc = textBox_desc.Text.ToString();

                control.insertData(ini,fin,desc);
            }
            else //update
            {
                if (comboBox_turn.SelectedItem != null)
                {
                    TurnController control = new TurnController();

                    string id = "";
                    string ini, fin, desc;
                    id = comboBox_turn.SelectedItem.ToString();
                    ini = textBox_horaIni.Text.ToString();
                    fin = textBox_horaFin.Text.ToString();
                    desc = textBox_desc.Text.ToString();

                    control.updateData(id, ini, fin, desc);
                }
            }
        }
    }
}
