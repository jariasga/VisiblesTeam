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
            fillForm();
        }

        private void fillForm()
        {
            TurnController control = new TurnController();
            DataTable turnList = control.getData();

            for (int i = 0; i < turnList.Rows.Count; i++)
            {
                textbox_id.Text = turnList.Rows[i]["idTurn"].ToString();
                textBox_horaIni.Text = turnList.Rows[i]["start"].ToString();
                textBox_horaFin.Text = turnList.Rows[i]["end"].ToString();
                textBox_desc.Text = turnList.Rows[i]["description"].ToString();
                break;
            }
        }
        
        private void TurnManagement_Load(object sender, EventArgs e)
        {            
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            TurnController control = new TurnController();

            string id = "";
            string ini, fin, desc;
            DateTime aux;
            if (DateTime.TryParse(textBox_horaIni.Text.ToString(), out aux) &&
                DateTime.TryParse(textBox_horaFin.Text.ToString(), out aux))
            {
                var tini = TimeSpan.Parse(textBox_horaIni.Text.ToString());
                var tfin = TimeSpan.Parse(textBox_horaFin.Text.ToString());
                if (tfin > tini)
                {

                    id = textbox_id.Text;
                    ini = textBox_horaIni.Text.ToString();
                    fin = textBox_horaFin.Text.ToString();
                    desc = textBox_desc.Text.ToString();
                    try
                    {
                        control.updateData(id, ini, fin, desc);
                        MessageBox.Show("Se guardaron los cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception m)
                    {
                        Console.WriteLine("{0} error", m);
                    }
                    fillForm();
                }
                else
                {
                    MessageBox.Show("La hora fin no puede ser menor a la de inicio, por favor verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fillForm();
                }
            }
            else
                MessageBox.Show("Formato de hora no válido, por favor verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
