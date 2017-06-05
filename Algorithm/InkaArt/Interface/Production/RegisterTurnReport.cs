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

using InkaArt.Business.Algorithm;

namespace InkaArt.Interface.Production
{
    public partial class RegisterRatio : Form
    {
        private WorkerController workers;
        private JobController jobs;
        private RecipeController recipes;
        private RatioController turn_reports;

        private bool grid_modified;

        public RegisterRatio()
        {
            InitializeComponent();
            workers = new WorkerController();
            jobs = new JobController();
            recipes = new RecipeController();
            turn_reports = new RatioController();
        }

        private void RegisterAssignedJob_Load(object sender, EventArgs e)
        {
            try
            {
                workers.Load();
                for (int i = 0; i < workers.Count(); i++)
                {
                    combobox_worker.Items.Add(workers[i].FullName());
                    grid_worker.Items.Add(workers[i].FullName());
                }

                jobs.Load();
                for (int i = 0; i < jobs.Count(); i++)
                {
                    combobox_job.Items.Add(jobs[i].Name);
                    grid_job.Items.Add(jobs[i].Name);
                }

                recipes.Load();

                grid_modified = false;
                date_picker.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió una excepción " + ex.ToString(), "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void date_picker_ValueChanged(object sender, EventArgs e)
        {
            if (grid_modified)
            {
                DialogResult result = MessageBox.Show("Hay datos modificados en la grilla de informes de turno.\n" +
                    "\n¿Desea guardarlos antes de actualizar la grilla a la nueva fecha?", "Inka Art",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Cancel) return;
                if (result == DialogResult.Yes)
                {
                    //Guardar los resultados
                    int i = 0;
                    try
                    {
                        for (i = 0; i < grid_reports.Rows.Count; i++)
                        {
                            int id_report = int.Parse(grid_reports[0, i].Value.ToString());
                            int id_worker = workers.GetByFullName(grid_reports[1, i].Value.ToString()).ID;
                            int id_job = jobs.GetByName(grid_reports[2, i].Value.ToString()).ID;

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Algunos de los datos de la fila " + (i+1) + "grilla no fueron ingresados " +
                            "correctamente.\n\nPor favor corrija los datos de la fila " + (i+1) + ".", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            try
            {
                turn_reports.Load(date_picker.Value);
                grid_reports.Rows.Clear();
                for (int i = 0; i < turn_reports.Count(); i++)
                {
                    string[] parameters = new string[8];
                    parameters[0] = turn_reports[i].ID.ToString();
                    parameters[1] = workers.GetByID(turn_reports[i].Worker).FullName();
                    parameters[2] = jobs.GetByID(turn_reports[i].Job).Name;
                    parameters[3] = "";
                    //parameters[3] = recipes.GetByID(turn_reports[i].Recipe).Description;
                    parameters[4] = turn_reports[i].Start.ToString();
                    parameters[5] = turn_reports[i].End.ToString();
                    parameters[6] = turn_reports[i].Broken.ToString();
                    parameters[7] = turn_reports[i].Produced.ToString();
                    grid_reports.Rows.Add(parameters);
                }

                grid_modified = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió una excepción " + ex.ToString(), "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void combobox_job_SelectedIndexChanged(object sender, EventArgs e)
        {
            string job_name = combobox_job.SelectedItem.ToString();
            int product_id = jobs.GetByName(job_name).Product;
            combobox_recipe.Items.Clear();
            for (int i = 0; i < recipes.Count(); i++)
            {
                if (recipes[i].Product == product_id)
                    combobox_recipe.Items.Add(recipes[i].Description);
            }
            combobox_recipe.Text = "";
        }

        private void button_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificar los datos ingresados
                int id_worker = workers.GetByFullName(combobox_worker.Text).ID;
                int id_product_job = jobs.GetByName(combobox_job.Text).Product;
                int id_product_recipe = recipes.GetByDescription(combobox_recipe.Text).Product;
                if (id_product_job != id_product_recipe) throw new Exception();

                TimeSpan start = TimeSpan.Parse(textbox_start.Text);
                TimeSpan end = TimeSpan.Parse(textbox_end.Text);
                if (start.TotalMinutes > end.TotalMinutes) throw new Exception();

                int broken = int.Parse(textbox_broken.Text);
                int produced = int.Parse(textbox_produced.Text);
                if (broken > produced) throw new Exception();

                //Agregar los datos a la lista y limpiar los campos
                grid_reports.Rows.Add(0, combobox_worker.Text, combobox_job.Text, "", //combobox_recipe.Text,
                    textbox_start.Text, textbox_end.Text, textbox_broken.Text, textbox_produced.Text);
                grid_modified = true;
                ClearFields();
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor ingrese los datos correctamente.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            combobox_worker.Text = "";
            combobox_job.Text = "";
            combobox_recipe.Items.Clear();
            combobox_recipe.Text = "";
            textbox_start.Text = "";
            textbox_end.Text = "";
            textbox_broken.Text = "";
            textbox_produced.Text = "";
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Esta seguro de guardar los datos?", "Inka Art",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Cancel) return;

        }        

        private void button_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Esta seguro de eliminar estos informes de turno?", "Inka Art",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        private void textbox_hour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') return;
            if (e.KeyChar == ':' || char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }

        private void textbox_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') return;
            if (char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }
    }
}
