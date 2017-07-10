namespace InkaArt.Interface.Production
{
    partial class RegisterRatioReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_save = new System.Windows.Forms.Button();
            this.grid_reports = new System.Windows.Forms.DataGridView();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.label_date = new System.Windows.Forms.Label();
            this.label_worker = new System.Windows.Forms.Label();
            this.combobox_worker = new System.Windows.Forms.ComboBox();
            this.label_job = new System.Windows.Forms.Label();
            this.combobox_job = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_recipe = new System.Windows.Forms.Label();
            this.combobox_recipe = new System.Windows.Forms.ComboBox();
            this.textbox_produced = new System.Windows.Forms.TextBox();
            this.textbox_end = new System.Windows.Forms.TextBox();
            this.textbox_broken = new System.Windows.Forms.TextBox();
            this.label_produced = new System.Windows.Forms.Label();
            this.label_end = new System.Windows.Forms.Label();
            this.label_broken = new System.Windows.Forms.Label();
            this.textbox_start = new System.Windows.Forms.TextBox();
            this.label_start = new System.Windows.Forms.Label();
            this.date_picker = new System.Windows.Forms.DateTimePicker();
            this.button_load = new System.Windows.Forms.Button();
            this.open_file_dialog = new System.Windows.Forms.OpenFileDialog();
            this.label_grid = new System.Windows.Forms.Label();
            this.grid_column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_column_worker = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grid_column_job = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grid_column_recipe = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grid_column_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_column_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_column_broken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_column_produced = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_reports)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.SteelBlue;
            this.button_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(293, 486);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(176, 42);
            this.button_save.TabIndex = 65;
            this.button_save.Text = "🖫 Guardar Jornada";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // grid_reports
            // 
            this.grid_reports.AllowUserToDeleteRows = false;
            this.grid_reports.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grid_reports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_reports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_reports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid_column_id,
            this.grid_column_worker,
            this.grid_column_job,
            this.grid_column_recipe,
            this.grid_column_start,
            this.grid_column_end,
            this.grid_column_broken,
            this.grid_column_produced});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_reports.DefaultCellStyle = dataGridViewCellStyle1;
            this.grid_reports.Location = new System.Drawing.Point(22, 245);
            this.grid_reports.Name = "grid_reports";
            this.grid_reports.Size = new System.Drawing.Size(939, 223);
            this.grid_reports.TabIndex = 50;
            this.grid_reports.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_reports_CellValueChanged);
            this.grid_reports.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_reports_EditingControlShowing);
            this.grid_reports.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_reports_RowsAdded);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(727, 486);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(185, 42);
            this.button_delete.TabIndex = 60;
            this.button_delete.Text = "🗑 Eliminar Registro";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.SteelBlue;
            this.button_add.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.ForeColor = System.Drawing.Color.White;
            this.button_add.Location = new System.Drawing.Point(67, 486);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(185, 42);
            this.button_add.TabIndex = 55;
            this.button_add.Text = "+ Agregar Registro";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_agregar_Click);
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_date.Location = new System.Drawing.Point(22, 17);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(130, 18);
            this.label_date.TabIndex = 25;
            this.label_date.Text = "Fecha de jornada";
            // 
            // label_worker
            // 
            this.label_worker.AutoSize = true;
            this.label_worker.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_worker.Location = new System.Drawing.Point(7, 29);
            this.label_worker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_worker.Name = "label_worker";
            this.label_worker.Size = new System.Drawing.Size(57, 18);
            this.label_worker.TabIndex = 31;
            this.label_worker.Text = "Obrero";
            // 
            // combobox_worker
            // 
            this.combobox_worker.FormattingEnabled = true;
            this.combobox_worker.ItemHeight = 18;
            this.combobox_worker.Location = new System.Drawing.Point(10, 50);
            this.combobox_worker.Name = "combobox_worker";
            this.combobox_worker.Size = new System.Drawing.Size(446, 26);
            this.combobox_worker.TabIndex = 10;
            // 
            // label_job
            // 
            this.label_job.AutoSize = true;
            this.label_job.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_job.Location = new System.Drawing.Point(7, 90);
            this.label_job.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_job.Name = "label_job";
            this.label_job.Size = new System.Drawing.Size(143, 18);
            this.label_job.TabIndex = 35;
            this.label_job.Text = "Proceso y producto";
            // 
            // combobox_job
            // 
            this.combobox_job.FormattingEnabled = true;
            this.combobox_job.Location = new System.Drawing.Point(10, 113);
            this.combobox_job.Name = "combobox_job";
            this.combobox_job.Size = new System.Drawing.Size(200, 26);
            this.combobox_job.TabIndex = 15;
            this.combobox_job.SelectedIndexChanged += new System.EventHandler(this.combobox_job_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_recipe);
            this.groupBox1.Controls.Add(this.combobox_recipe);
            this.groupBox1.Controls.Add(this.textbox_produced);
            this.groupBox1.Controls.Add(this.textbox_end);
            this.groupBox1.Controls.Add(this.textbox_broken);
            this.groupBox1.Controls.Add(this.label_produced);
            this.groupBox1.Controls.Add(this.label_end);
            this.groupBox1.Controls.Add(this.label_broken);
            this.groupBox1.Controls.Add(this.textbox_start);
            this.groupBox1.Controls.Add(this.label_start);
            this.groupBox1.Controls.Add(this.label_worker);
            this.groupBox1.Controls.Add(this.combobox_worker);
            this.groupBox1.Controls.Add(this.label_job);
            this.groupBox1.Controls.Add(this.combobox_job);
            this.groupBox1.Location = new System.Drawing.Point(22, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(939, 161);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar un registro";
            // 
            // label_recipe
            // 
            this.label_recipe.AutoSize = true;
            this.label_recipe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_recipe.Location = new System.Drawing.Point(253, 90);
            this.label_recipe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_recipe.Name = "label_recipe";
            this.label_recipe.Size = new System.Drawing.Size(58, 18);
            this.label_recipe.TabIndex = 56;
            this.label_recipe.Text = "Receta";
            // 
            // combobox_recipe
            // 
            this.combobox_recipe.FormattingEnabled = true;
            this.combobox_recipe.Location = new System.Drawing.Point(256, 111);
            this.combobox_recipe.Name = "combobox_recipe";
            this.combobox_recipe.Size = new System.Drawing.Size(200, 26);
            this.combobox_recipe.TabIndex = 20;
            // 
            // textbox_produced
            // 
            this.textbox_produced.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_produced.Location = new System.Drawing.Point(724, 111);
            this.textbox_produced.Name = "textbox_produced";
            this.textbox_produced.Size = new System.Drawing.Size(200, 24);
            this.textbox_produced.TabIndex = 40;
            this.textbox_produced.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_number_KeyPress);
            // 
            // textbox_end
            // 
            this.textbox_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_end.Location = new System.Drawing.Point(724, 50);
            this.textbox_end.Name = "textbox_end";
            this.textbox_end.Size = new System.Drawing.Size(200, 24);
            this.textbox_end.TabIndex = 30;
            this.textbox_end.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_hour_KeyPress);
            // 
            // textbox_broken
            // 
            this.textbox_broken.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_broken.Location = new System.Drawing.Point(495, 111);
            this.textbox_broken.Name = "textbox_broken";
            this.textbox_broken.Size = new System.Drawing.Size(200, 24);
            this.textbox_broken.TabIndex = 35;
            this.textbox_broken.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_number_KeyPress);
            // 
            // label_produced
            // 
            this.label_produced.AutoSize = true;
            this.label_produced.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_produced.Location = new System.Drawing.Point(721, 90);
            this.label_produced.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_produced.Name = "label_produced";
            this.label_produced.Size = new System.Drawing.Size(194, 18);
            this.label_produced.TabIndex = 51;
            this.label_produced.Text = "# de productos terminados";
            // 
            // label_end
            // 
            this.label_end.AutoSize = true;
            this.label_end.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_end.Location = new System.Drawing.Point(721, 29);
            this.label_end.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_end.Name = "label_end";
            this.label_end.Size = new System.Drawing.Size(74, 18);
            this.label_end.TabIndex = 50;
            this.label_end.Text = "Hora final";
            // 
            // label_broken
            // 
            this.label_broken.AutoSize = true;
            this.label_broken.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_broken.Location = new System.Drawing.Point(492, 90);
            this.label_broken.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_broken.Name = "label_broken";
            this.label_broken.Size = new System.Drawing.Size(151, 18);
            this.label_broken.TabIndex = 49;
            this.label_broken.Text = "# de productos rotos";
            // 
            // textbox_start
            // 
            this.textbox_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_start.Location = new System.Drawing.Point(495, 50);
            this.textbox_start.Name = "textbox_start";
            this.textbox_start.Size = new System.Drawing.Size(200, 24);
            this.textbox_start.TabIndex = 25;
            this.textbox_start.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_hour_KeyPress);
            // 
            // label_start
            // 
            this.label_start.AutoSize = true;
            this.label_start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_start.Location = new System.Drawing.Point(492, 29);
            this.label_start.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(86, 18);
            this.label_start.TabIndex = 38;
            this.label_start.Text = "Hora inicial";
            // 
            // date_picker
            // 
            this.date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_picker.Location = new System.Drawing.Point(198, 12);
            this.date_picker.Name = "date_picker";
            this.date_picker.Size = new System.Drawing.Size(216, 26);
            this.date_picker.TabIndex = 5;
            this.date_picker.Value = new System.DateTime(2017, 6, 4, 18, 31, 53, 0);
            this.date_picker.ValueChanged += new System.EventHandler(this.date_picker_ValueChanged);
            // 
            // button_load
            // 
            this.button_load.BackColor = System.Drawing.Color.Gray;
            this.button_load.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_load.ForeColor = System.Drawing.Color.White;
            this.button_load.Location = new System.Drawing.Point(517, 486);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(165, 42);
            this.button_load.TabIndex = 66;
            this.button_load.Text = "⬆ Carga Masiva";
            this.button_load.UseVisualStyleBackColor = false;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // open_file_dialog
            // 
            this.open_file_dialog.Filter = "Hojas de estilo en cascada|*.csv|Archivos de texto|*.txt|Todos los archivos|*.*";
            this.open_file_dialog.Title = "Seleccione un archivo...";
            // 
            // label_grid
            // 
            this.label_grid.AutoSize = true;
            this.label_grid.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_grid.Location = new System.Drawing.Point(22, 224);
            this.label_grid.Name = "label_grid";
            this.label_grid.Size = new System.Drawing.Size(230, 18);
            this.label_grid.TabIndex = 67;
            this.label_grid.Text = "Jornadas de trabajo registradas";
            // 
            // grid_column_id
            // 
            this.grid_column_id.HeaderText = "ID";
            this.grid_column_id.Name = "grid_column_id";
            this.grid_column_id.ReadOnly = true;
            this.grid_column_id.Visible = false;
            this.grid_column_id.Width = 50;
            // 
            // grid_column_worker
            // 
            this.grid_column_worker.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid_column_worker.FillWeight = 180F;
            this.grid_column_worker.HeaderText = "Trabajador";
            this.grid_column_worker.Name = "grid_column_worker";
            this.grid_column_worker.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_column_worker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // grid_column_job
            // 
            this.grid_column_job.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid_column_job.FillWeight = 180F;
            this.grid_column_job.HeaderText = "Puesto de trabajo";
            this.grid_column_job.Name = "grid_column_job";
            this.grid_column_job.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // grid_column_recipe
            // 
            this.grid_column_recipe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid_column_recipe.FillWeight = 150F;
            this.grid_column_recipe.HeaderText = "Receta";
            this.grid_column_recipe.Name = "grid_column_recipe";
            this.grid_column_recipe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_column_recipe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // grid_column_start
            // 
            this.grid_column_start.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid_column_start.FillWeight = 110F;
            this.grid_column_start.HeaderText = "Hora inicio";
            this.grid_column_start.Name = "grid_column_start";
            // 
            // grid_column_end
            // 
            this.grid_column_end.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid_column_end.HeaderText = "Hora fin";
            this.grid_column_end.Name = "grid_column_end";
            // 
            // grid_column_broken
            // 
            this.grid_column_broken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid_column_broken.FillWeight = 80F;
            this.grid_column_broken.HeaderText = "Rotos";
            this.grid_column_broken.Name = "grid_column_broken";
            // 
            // grid_column_produced
            // 
            this.grid_column_produced.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid_column_produced.FillWeight = 95F;
            this.grid_column_produced.HeaderText = "Terminados";
            this.grid_column_produced.Name = "grid_column_produced";
            // 
            // RegisterRatioReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 552);
            this.Controls.Add(this.label_grid);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.date_picker);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.grid_reports);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label_date);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegisterRatioReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Jornadas de Trabajo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterRatioReport_FormClosing);
            this.Load += new System.EventHandler(this.RegisterAssignedJob_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_reports)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.DataGridView grid_reports;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.Label label_worker;
        private System.Windows.Forms.ComboBox combobox_worker;
        private System.Windows.Forms.Label label_job;
        private System.Windows.Forms.ComboBox combobox_job;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker date_picker;
        private System.Windows.Forms.TextBox textbox_produced;
        private System.Windows.Forms.TextBox textbox_broken;
        private System.Windows.Forms.Label label_produced;
        private System.Windows.Forms.Label label_end;
        private System.Windows.Forms.Label label_broken;
        private System.Windows.Forms.Label label_start;
        private System.Windows.Forms.Label label_recipe;
        private System.Windows.Forms.ComboBox combobox_recipe;
        private System.Windows.Forms.TextBox textbox_end;
        private System.Windows.Forms.TextBox textbox_start;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.OpenFileDialog open_file_dialog;
        private System.Windows.Forms.Label label_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn grid_column_worker;
        private System.Windows.Forms.DataGridViewComboBoxColumn grid_column_job;
        private System.Windows.Forms.DataGridViewComboBoxColumn grid_column_recipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_broken;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_produced;
    }
}