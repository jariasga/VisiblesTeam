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
        private RatioController ratios;
        private List<int> grid_modified_items;

        public RegisterRatio()
        {
            InitializeComponent();
            workers = new WorkerController();
            jobs = new JobController();
            recipes = new RecipeController();
            ratios = new RatioController();
            grid_modified_items = new List<int>();
        }

        private void RegisterAssignedJob_Load(object sender, EventArgs e)
        {
            try
            {
                workers.Load();
                for (int i = 0; i < workers.Count(); i++)
                {
                    combobox_worker.Items.Add(workers[i].FullName());
                    grid_column_worker.Items.Add(workers[i].FullName());
                }

                jobs.Load();
                for (int i = 0; i < jobs.Count(); i++)
                {
                    combobox_job.Items.Add(jobs[i].Name);
                    grid_column_job.Items.Add(jobs[i].Name);
                }

                recipes.Load();
                for (int i = 0; i < recipes.Count(); i++)
                {
                    grid_column_recipe.Items.Add(recipes[i].Description);
                }
                
                date_picker.Value = DateTime.Today;
                grid_modified_items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió una excepción " + ex.ToString(), "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void date_picker_ValueChanged(object sender, EventArgs e)
        {
            if (grid_modified_items.Count > 0)
            {
                DialogResult result = MessageBox.Show("Hay datos modificados en la grilla de informes de turno.\n" +
                    "\n¿Desea guardarlos antes de actualizar la grilla a la nueva fecha?", "Inka Art",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Cancel) return;
                if (result == DialogResult.Yes)
                {
                    if (!SaveGridRows()) return;
                    grid_modified_items.Clear();
                }
            }

            try
            {
                ratios.Load(date_picker.Value);
                grid_reports.Rows.Clear();
                for (int i = 0; i < ratios.Count(); i++)
                {
                    string[] parameters = new string[8];
                    parameters[0] = ratios[i].ID.ToString();
                    parameters[1] = workers.GetByID(ratios[i].Worker).FullName();
                    parameters[2] = jobs.GetByID(ratios[i].Job).Name;
                    parameters[3] = recipes.GetByID(ratios[i].Recipe).Description;
                    parameters[4] = ratios[i].Start.ToString();
                    parameters[5] = ratios[i].End.ToString();
                    parameters[6] = ratios[i].Broken.ToString();
                    parameters[7] = ratios[i].Produced.ToString();
                    grid_reports.Rows.Add(parameters);
                }
                grid_modified_items.Clear();
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
            string message = "Ok";
            if (ratios.Verify(0, date_picker.Value, combobox_worker.Text, combobox_job.Text, combobox_recipe.Text,
                textbox_start.Text, textbox_end.Text, textbox_broken.Text, textbox_produced.Text, workers, jobs,
                recipes, ref message) == null)
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Agregar los datos a la lista y limpiar los campos
            grid_modified_items.Add(grid_reports.RowCount - 1);
            grid_reports.Rows.Add(0, combobox_worker.Text, combobox_job.Text, combobox_recipe.Text,
                textbox_start.Text, textbox_end.Text, textbox_broken.Text, textbox_produced.Text);
            ClearFields();
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
            if (grid_reports.RowCount <= 1 || grid_modified_items.Count == 0)
            {
                MessageBox.Show("Ingrese los datos para el registro de informes de turno en la grilla.", "Inka Art",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro de guardar los datos?", "Inka Art",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.No) return;
            
            if (SaveGridRows()) grid_modified_items.Clear();
        }

        private bool SaveGridRows()
        {
            foreach (int row in grid_modified_items)
            {
                int id_report = 0;
                object grid_id_value = grid_reports[0, row].Value;
                if (grid_id_value != null) id_report = int.Parse(grid_id_value.ToString());
                string worker = grid_reports[1, row].Value.ToString();
                string job = grid_reports[2, row].Value.ToString();
                string recipe = grid_reports[3, row].Value.ToString();
                string start = grid_reports[4, row].Value.ToString();
                string end = grid_reports[5, row].Value.ToString();
                string broken = grid_reports[6, row].Value.ToString();
                string produced = grid_reports[7, row].Value.ToString();

                string message = "Ok";
                int result = ratios.VerifyAndSave(id_report, date_picker.Value, worker, job, recipe, start, end,
                    broken, produced, workers, jobs, recipes, ref message);
                
                if (result <= 0)
                {
                    MessageBox.Show("Error en la fila " + (row + 1) + ": " + message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                grid_reports[0, row].Value = result;
            }

            return true;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            int selected_rows = grid_reports.SelectedRows.Count;
            if (selected_rows <= 0)
            {
                MessageBox.Show("Seleccione las filas que desee eliminar haciendo clic en la primera celda de cada fila.",
                    "Inka Art", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro de eliminar los informes de turno seleccionados?",
                "Inka Art", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.No) return;

            for (int i = 0; i < grid_reports.SelectedRows.Count; i++)
            {
                int row_index = grid_reports.SelectedRows[i].Index;
                int id_report = int.Parse(grid_reports[0, row_index].Value.ToString());
                string message = "Ok";
                if (!ratios.Delete(id_report, ref message))
                {
                    MessageBox.Show("Error en la fila " + (row_index + 1) + ": " + message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
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

        private void grid_reports_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += grid_reports_KeyPress;
        }
        private void grid_reports_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Control de los casilleros de tiempo
            if (grid_reports.CurrentCell.ColumnIndex == 4 || grid_reports.CurrentCell.ColumnIndex == 5)
            {
                textbox_hour_KeyPress(sender, e); 
            }
            //Control de los casilleros de números
            if (grid_reports.CurrentCell.ColumnIndex == 6 || grid_reports.CurrentCell.ColumnIndex == 7)
            {
                textbox_number_KeyPress(sender, e);
            }
        }

        private void grid_reports_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || grid_modified_items.Contains(e.RowIndex)) return;
            //MessageBox.Show("Item añadido a grid_modified_items: índice " + e.RowIndex);
            grid_modified_items.Add(e.RowIndex);
        }

        private void grid_reports_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }
    }
}
