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
using InkaArt.Data.Algorithm;
using InkaArt.Classes;
using System.IO;

namespace InkaArt.Interface.Production
{
    public partial class RegisterRatioReport : Form
    {
        private WorkerController workers;
        private JobController jobs;
        private RecipeController recipes;
        private RatioController ratios;
        private List<int> grid_modified_items;

        public RegisterRatioReport()
        {
            InitializeComponent();

            workers = new WorkerController();
            jobs = new JobController();
            recipes = new RecipeController();
            ratios = new RatioController(workers, jobs, recipes);

            grid_modified_items = new List<int>();
        }

        private void RegisterAssignedJob_Load(object sender, EventArgs e)
        {
            try
            {
                workers.Load();
                combobox_worker.DataSource = workers.List();
                combobox_worker.DisplayMember = "FullName";
                combobox_worker.Text = "";
                grid_column_worker.DataSource = workers.List();
                grid_column_worker.DisplayMember = "FullName";

                jobs.Load();
                combobox_job.DataSource = jobs.List();
                combobox_job.DisplayMember = "Name";
                combobox_job.Text = "";
                grid_column_job.DataSource = jobs.List();
                grid_column_job.DisplayMember = "Name";

                recipes.Load();
                combobox_recipe.DisplayMember = "Version";
                grid_column_recipe.DataSource = recipes.List();
                grid_column_recipe.DisplayMember = "Version";

                date_picker.Value = DateTime.Today;
                grid_modified_items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió una excepción: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                LogHandler.WriteLine(ex.ToString());
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
                    parameters[1] = ratios[i].Worker.FullName;
                    parameters[2] = ratios[i].Job.Name;
                    parameters[3] = ratios[i].Recipe.Version;
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
                MessageBox.Show("Ocurrió una excepción: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                LogHandler.WriteLine(ex.ToString());
            }
        }

        private void combobox_job_SelectedIndexChanged(object sender, EventArgs e)
        {
            Job job = (Job)combobox_job.SelectedItem;
            if (job != null)
            {
                combobox_recipe.Items.Clear();
                for (int i = 0; i < recipes.NumberOfRecipes; i++)
                {
                    if (recipes[i].Product == job.Product)
                        combobox_recipe.Items.Add(recipes[i]);
                }
            }
            combobox_recipe.Text = "";
        }

        private void button_agregar_Click(object sender, EventArgs e)
        {
            //Verificar que los datos fueron ingresados correctamente
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
            grid_reports.Rows.Add("0", combobox_worker.Text, combobox_job.Text, combobox_recipe.Text,
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
                if (row >= grid_reports.RowCount - 1) continue;

                object grid_id_value = grid_reports[0, row].Value;
                int id_ratio = (grid_id_value != null) ? int.Parse(grid_id_value.ToString()) : 0;

                //Parámetros
                string worker = grid_reports[1, row].Value.ToString();
                string job = grid_reports[2, row].Value.ToString();
                string recipe = grid_reports[3, row].Value.ToString();
                string start = grid_reports[4, row].Value.ToString();
                string end = grid_reports[5, row].Value.ToString();
                string broken = grid_reports[6, row].Value.ToString();
                string produced = grid_reports[7, row].Value.ToString();

                string message = "Ok";
                int result = ratios.VerifyAndSave(id_ratio, date_picker.Value, worker, job, recipe, start, end,
                    broken, produced, workers, jobs, recipes, ref message);

                if (result <= 0)
                {
                    MessageBox.Show("Error en la fila " + (row + 1) + ": " + message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                grid_reports[0, row].Value = result;
            }

            MessageBox.Show("Datos ingresados correctamente.", "InkaArt", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //No se puede eliminar ni una fila no válida ni la última fila (fila de edición)
                if (row_index < 0 || row_index == grid_reports.RowCount - 1) continue;

                int id_ratio = int.Parse(grid_reports[0, row_index].Value.ToString());
                string message = "";

                if (id_ratio == 0 || ratios.Delete(id_ratio, ref message))
                {
                    grid_reports.Rows.RemoveAt(row_index);
                    LogHandler.WriteLine(message);
                    i--;
                }
                else
                {
                    MessageBox.Show("Error en la fila " + (row_index + 1) + ": " + message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Las filas seleccionadas fueron eliminadas correctamente.", "Inka Art", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /************************* EVENTOS PROPIOS DEL FORMULARIO *************************/

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
            //El índice de la fila debe estar entre [0, RowCount-1>, y no debe repetirse.
            if (e.RowIndex >= 0 && e.RowIndex < (grid_reports.RowCount - 1) && !grid_modified_items.Contains(e.RowIndex))
                grid_modified_items.Add(e.RowIndex);
        }

        private void grid_reports_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (this.grid_reports[0, e.RowIndex].Value == null)
                this.grid_reports[0, e.RowIndex].Value = "0";
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            DialogResult result = open_file_dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            bool success = true;

            try
            {
                //Leer los datos del archivo
                StreamReader reader = new StreamReader(open_file_dialog.FileName);
                if (!reader.EndOfStream) reader.ReadLine();
                for (int line_index = 2; !reader.EndOfStream; line_index++)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');
                    if (values == null || values.Count() != 8)
                    {
                        MessageBox.Show("No se pueden leer los datos de la línea " + line_index + ".", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        success = false;
                        continue;
                    }
                    //Formatear los datos a ingresar
                    DateTime date;
                    if (!DateTime.TryParse(values[0], out date))
                    {
                        MessageBox.Show("La fecha colocada en el ratio de la línea " + line_index + " no es válida.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        success = false;
                        continue;
                    }
                    string message = "";
                    int id_ratio = ratios.VerifyAndSave(0, date, values[1], values[2], values[3], values[4], values[5],
                        values[6], values[7], workers, jobs, recipes, ref message);
                    if (id_ratio <= 0)
                    {
                        result = MessageBox.Show("Error en el ratio leído en la línea " + line_index + ": " + message,
                            "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        success = false;
                        if (result == DialogResult.OK) continue;
                        if (result == DialogResult.Cancel) break;
                    }
                    else LogHandler.WriteLine(message);
                }
                reader.Close();

                //Actualizar la lista de ratios de la fecha seleccionada actualmente
                if (success) MessageBox.Show("Datos leídos correctamente.", "Inka Art", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                else MessageBox.Show("Hubieron errores al leer los datos.", "Inka Art", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                //Actualizar la lista de ratios de la fecha especificada
                date_picker_ValueChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió una excepción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHandler.WriteLine(ex.ToString());
            }
        }
    }
}