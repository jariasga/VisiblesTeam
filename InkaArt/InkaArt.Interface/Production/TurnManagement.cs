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
    public partial class TurnManagement : Form
    {
        public TurnManagement()
        {
            InitializeComponent();
            fillCombo();
        }

        private void fillCombo()
        {
            TurnController control = new TurnController();
            DataTable turnList = control.getData();
            comboBox_turn.Items.Clear();
            for (int i = 0; i < turnList.Rows.Count; i++)
                comboBox_turn.Items.Add(turnList.Rows[i]["idTurn"].ToString());
            comboBox_turn.SelectedIndex = 1;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_turn_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void fillGrid()
        {
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
                DateTime aux;
                if (DateTime.TryParse(textBox_horaIni.Text.ToString(), out aux) &&
                    DateTime.TryParse(textBox_horaFin.Text.ToString(), out aux))
                {
                    ini = textBox_horaIni.Text.ToString();
                    fin = textBox_horaFin.Text.ToString();
                    desc = textBox_desc.Text.ToString();

                    control.insertData(ini, fin, desc);
                    fillCombo();
                    MessageBox.Show("Nuevo turno creado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Formato de hora no válido, por favor verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //update
            {
                //validacion de date
                if (comboBox_turn.SelectedItem != null)
                {
                    TurnController control = new TurnController();

                    string id = "";
                    string ini, fin, desc;
                    DateTime aux;
                    if (DateTime.TryParse(textBox_horaIni.Text.ToString(), out aux)&&
                        DateTime.TryParse(textBox_horaFin.Text.ToString(), out aux))
                    {
                        id = comboBox_turn.SelectedItem.ToString();
                        ini = textBox_horaIni.Text.ToString();
                        fin = textBox_horaFin.Text.ToString();
                        desc = textBox_desc.Text.ToString();

                        control.updateData(id, ini, fin, desc);
                        MessageBox.Show("Turno actualizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Formato de hora no válido, por favor verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Por favor, elija un turno válido.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
