namespace InkaArt.Interface.Production
{
    partial class RegisterRatio
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
            this.button_save = new System.Windows.Forms.Button();
            this.grid_reports = new System.Windows.Forms.DataGridView();
            this.grid_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_worker = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grid_job = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grid_recipe = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grid_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_broken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_produced = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.combobox_worker = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combobox_job = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_recipe = new System.Windows.Forms.Label();
            this.combobox_recipe = new System.Windows.Forms.ComboBox();
            this.textbox_produced = new System.Windows.Forms.TextBox();
            this.textbox_end = new System.Windows.Forms.TextBox();
            this.textbox_broken = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_broken = new System.Windows.Forms.Label();
            this.textbox_start = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date_picker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.grid_reports)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.SteelBlue;
            this.button_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(566, 424);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(185, 42);
            this.button_save.TabIndex = 28;
            this.button_save.Text = "🖫 Guardar registros";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // grid_reports
            // 
            this.grid_reports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_reports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid_id,
            this.grid_worker,
            this.grid_job,
            this.grid_recipe,
            this.grid_start,
            this.grid_end,
            this.grid_broken,
            this.grid_produced});
            this.grid_reports.Location = new System.Drawing.Point(12, 215);
            this.grid_reports.Name = "grid_reports";
            this.grid_reports.Size = new System.Drawing.Size(846, 198);
            this.grid_reports.TabIndex = 29;
            // 
            // grid_id
            // 
            this.grid_id.HeaderText = "ID";
            this.grid_id.Name = "grid_id";
            this.grid_id.ReadOnly = true;
            this.grid_id.Width = 50;
            // 
            // grid_worker
            // 
            this.grid_worker.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.grid_worker.HeaderText = "Trabajador";
            this.grid_worker.Name = "grid_worker";
            this.grid_worker.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_worker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.grid_worker.Width = 180;
            // 
            // grid_job
            // 
            this.grid_job.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.grid_job.HeaderText = "Puesto de trabajo";
            this.grid_job.Name = "grid_job";
            this.grid_job.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_job.Width = 180;
            // 
            // grid_recipe
            // 
            this.grid_recipe.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.grid_recipe.HeaderText = "Receta";
            this.grid_recipe.Name = "grid_recipe";
            this.grid_recipe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_recipe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // grid_start
            // 
            this.grid_start.HeaderText = "Hora inicio";
            this.grid_start.Name = "grid_start";
            this.grid_start.Width = 110;
            // 
            // grid_end
            // 
            this.grid_end.HeaderText = "Hora fin";
            this.grid_end.Name = "grid_end";
            // 
            // grid_broken
            // 
            this.grid_broken.HeaderText = "Rotos";
            this.grid_broken.Name = "grid_broken";
            this.grid_broken.Width = 80;
            // 
            // grid_produced
            // 
            this.grid_produced.HeaderText = "Terminados";
            this.grid_produced.Name = "grid_produced";
            this.grid_produced.Width = 95;
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(367, 424);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(151, 42);
            this.button_delete.TabIndex = 49;
            this.button_delete.Text = "🗑 Eliminar Fila";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.SteelBlue;
            this.button_add.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.ForeColor = System.Drawing.Color.White;
            this.button_add.Location = new System.Drawing.Point(97, 424);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(223, 42);
            this.button_add.TabIndex = 44;
            this.button_add.Text = "Agregar informe de turno";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_agregar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 18);
            this.label9.TabIndex = 25;
            this.label9.Text = "Fecha del informe de turno:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = "Trabajador";
            // 
            // combobox_worker
            // 
            this.combobox_worker.FormattingEnabled = true;
            this.combobox_worker.Location = new System.Drawing.Point(16, 50);
            this.combobox_worker.Name = "combobox_worker";
            this.combobox_worker.Size = new System.Drawing.Size(376, 26);
            this.combobox_worker.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 18);
            this.label2.TabIndex = 35;
            this.label2.Text = "Puesto de trabajo";
            // 
            // combobox_job
            // 
            this.combobox_job.FormattingEnabled = true;
            this.combobox_job.Location = new System.Drawing.Point(16, 111);
            this.combobox_job.Name = "combobox_job";
            this.combobox_job.Size = new System.Drawing.Size(171, 26);
            this.combobox_job.TabIndex = 34;
            this.combobox_job.SelectedIndexChanged += new System.EventHandler(this.combobox_job_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_recipe);
            this.groupBox1.Controls.Add(this.combobox_recipe);
            this.groupBox1.Controls.Add(this.textbox_produced);
            this.groupBox1.Controls.Add(this.textbox_end);
            this.groupBox1.Controls.Add(this.textbox_broken);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label_broken);
            this.groupBox1.Controls.Add(this.textbox_start);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.combobox_worker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.combobox_job);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 152);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar un informe de turno";
            // 
            // label_recipe
            // 
            this.label_recipe.AutoSize = true;
            this.label_recipe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_recipe.Location = new System.Drawing.Point(218, 90);
            this.label_recipe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_recipe.Name = "label_recipe";
            this.label_recipe.Size = new System.Drawing.Size(58, 18);
            this.label_recipe.TabIndex = 56;
            this.label_recipe.Text = "Receta";
            // 
            // combobox_recipe
            // 
            this.combobox_recipe.FormattingEnabled = true;
            this.combobox_recipe.Location = new System.Drawing.Point(221, 111);
            this.combobox_recipe.Name = "combobox_recipe";
            this.combobox_recipe.Size = new System.Drawing.Size(171, 26);
            this.combobox_recipe.TabIndex = 55;
            // 
            // textbox_produced
            // 
            this.textbox_produced.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_produced.Location = new System.Drawing.Point(629, 113);
            this.textbox_produced.Name = "textbox_produced";
            this.textbox_produced.Size = new System.Drawing.Size(172, 24);
            this.textbox_produced.TabIndex = 54;
            this.textbox_produced.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_number_KeyPress);
            // 
            // textbox_end
            // 
            this.textbox_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_end.Location = new System.Drawing.Point(629, 50);
            this.textbox_end.Name = "textbox_end";
            this.textbox_end.Size = new System.Drawing.Size(172, 24);
            this.textbox_end.TabIndex = 53;
            this.textbox_end.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_hour_KeyPress);
            // 
            // textbox_broken
            // 
            this.textbox_broken.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_broken.Location = new System.Drawing.Point(428, 113);
            this.textbox_broken.Name = "textbox_broken";
            this.textbox_broken.Size = new System.Drawing.Size(172, 24);
            this.textbox_broken.TabIndex = 52;
            this.textbox_broken.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_number_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(626, 90);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 18);
            this.label6.TabIndex = 51;
            this.label6.Text = "# de productos terminados";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(626, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 18);
            this.label7.TabIndex = 50;
            this.label7.Text = "Hora final";
            // 
            // label_broken
            // 
            this.label_broken.AutoSize = true;
            this.label_broken.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_broken.Location = new System.Drawing.Point(425, 90);
            this.label_broken.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_broken.Name = "label_broken";
            this.label_broken.Size = new System.Drawing.Size(151, 18);
            this.label_broken.TabIndex = 49;
            this.label_broken.Text = "# de productos rotos";
            // 
            // textbox_start
            // 
            this.textbox_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_start.Location = new System.Drawing.Point(428, 50);
            this.textbox_start.Name = "textbox_start";
            this.textbox_start.Size = new System.Drawing.Size(172, 24);
            this.textbox_start.TabIndex = 46;
            this.textbox_start.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_hour_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(425, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 38;
            this.label4.Text = "Hora inicial";
            // 
            // date_picker
            // 
            this.date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_picker.Location = new System.Drawing.Point(233, 12);
            this.date_picker.Name = "date_picker";
            this.date_picker.Size = new System.Drawing.Size(171, 26);
            this.date_picker.TabIndex = 51;
            this.date_picker.Value = new System.DateTime(2017, 6, 4, 18, 31, 53, 0);
            this.date_picker.ValueChanged += new System.EventHandler(this.date_picker_ValueChanged);
            // 
            // RegisterRatio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 478);
            this.Controls.Add(this.date_picker);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.grid_reports);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegisterRatio";
            this.Text = "Informe de Turno";
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combobox_worker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combobox_job;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker date_picker;
        private System.Windows.Forms.TextBox textbox_produced;
        private System.Windows.Forms.TextBox textbox_end;
        private System.Windows.Forms.TextBox textbox_broken;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_broken;
        private System.Windows.Forms.TextBox textbox_start;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_recipe;
        private System.Windows.Forms.ComboBox combobox_recipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn grid_worker;
        private System.Windows.Forms.DataGridViewComboBoxColumn grid_job;
        private System.Windows.Forms.DataGridViewComboBoxColumn grid_recipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_broken;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_produced;
    }
}