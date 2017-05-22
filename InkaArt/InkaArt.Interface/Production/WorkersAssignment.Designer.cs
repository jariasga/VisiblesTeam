namespace InkaArt.Interface.Production
{
    partial class WorkersAssignment
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
            this.button_config = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.groupbox_summary = new System.Windows.Forms.GroupBox();
            this.summary_grid = new System.Windows.Forms.DataGridView();
            this.TotalHuacos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalStones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAltarpiece = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalProduced = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupbox_assignments = new System.Windows.Forms.GroupBox();
            this.simulation_grid = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worker1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worker2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worker3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worker4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worker5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_select = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupbox_summary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.summary_grid)).BeginInit();
            this.groupbox_assignments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simulation_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // button_config
            // 
            this.button_config.BackColor = System.Drawing.Color.Gray;
            this.button_config.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_config.ForeColor = System.Drawing.Color.White;
            this.button_config.Location = new System.Drawing.Point(43, 451);
            this.button_config.Name = "button_config";
            this.button_config.Size = new System.Drawing.Size(265, 43);
            this.button_config.TabIndex = 32;
            this.button_config.Text = "Configuración de datos previos";
            this.button_config.UseVisualStyleBackColor = false;
            this.button_config.Click += new System.EventHandler(this.ButtonSimulationConfig_Click);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(339, 451);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(193, 43);
            this.button_delete.TabIndex = 39;
            this.button_delete.Text = "🗑 Eliminar simulación";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.SteelBlue;
            this.button_start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.ForeColor = System.Drawing.Color.White;
            this.button_start.Location = new System.Drawing.Point(563, 451);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(145, 43);
            this.button_start.TabIndex = 40;
            this.button_start.Text = "Iniciar simulación";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // groupbox_summary
            // 
            this.groupbox_summary.Controls.Add(this.summary_grid);
            this.groupbox_summary.Location = new System.Drawing.Point(12, 342);
            this.groupbox_summary.Name = "groupbox_summary";
            this.groupbox_summary.Size = new System.Drawing.Size(792, 105);
            this.groupbox_summary.TabIndex = 42;
            this.groupbox_summary.TabStop = false;
            this.groupbox_summary.Text = "Resumen";
            // 
            // summary_grid
            // 
            this.summary_grid.AllowUserToAddRows = false;
            this.summary_grid.AllowUserToDeleteRows = false;
            this.summary_grid.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.summary_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.summary_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TotalHuacos,
            this.TotalStones,
            this.TotalAltarpiece,
            this.TotalProduced});
            this.summary_grid.Location = new System.Drawing.Point(9, 27);
            this.summary_grid.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.summary_grid.Name = "summary_grid";
            this.summary_grid.ReadOnly = true;
            this.summary_grid.RowHeadersVisible = false;
            this.summary_grid.Size = new System.Drawing.Size(774, 61);
            this.summary_grid.TabIndex = 2;
            // 
            // TotalHuacos
            // 
            this.TotalHuacos.HeaderText = "Total de Huacos";
            this.TotalHuacos.Name = "TotalHuacos";
            this.TotalHuacos.ReadOnly = true;
            this.TotalHuacos.Width = 150;
            // 
            // TotalStones
            // 
            this.TotalStones.HeaderText = "Total de Piedras de Huamanga";
            this.TotalStones.Name = "TotalStones";
            this.TotalStones.ReadOnly = true;
            this.TotalStones.Width = 250;
            // 
            // TotalAltarpiece
            // 
            this.TotalAltarpiece.HeaderText = "Total de Retablos";
            this.TotalAltarpiece.Name = "TotalAltarpiece";
            this.TotalAltarpiece.ReadOnly = true;
            this.TotalAltarpiece.Width = 200;
            // 
            // TotalProduced
            // 
            this.TotalProduced.HeaderText = "Total producido";
            this.TotalProduced.Name = "TotalProduced";
            this.TotalProduced.ReadOnly = true;
            this.TotalProduced.Width = 150;
            // 
            // groupbox_assignments
            // 
            this.groupbox_assignments.Controls.Add(this.simulation_grid);
            this.groupbox_assignments.Location = new System.Drawing.Point(12, 57);
            this.groupbox_assignments.Name = "groupbox_assignments";
            this.groupbox_assignments.Size = new System.Drawing.Size(792, 267);
            this.groupbox_assignments.TabIndex = 41;
            this.groupbox_assignments.TabStop = false;
            this.groupbox_assignments.Text = "Asignaciones";
            // 
            // simulation_grid
            // 
            this.simulation_grid.AllowUserToAddRows = false;
            this.simulation_grid.AllowUserToDeleteRows = false;
            this.simulation_grid.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.simulation_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.simulation_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Worker1,
            this.Worker2,
            this.Worker3,
            this.Worker4,
            this.Worker5});
            this.simulation_grid.Location = new System.Drawing.Point(9, 27);
            this.simulation_grid.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.simulation_grid.Name = "simulation_grid";
            this.simulation_grid.ReadOnly = true;
            this.simulation_grid.RowHeadersVisible = false;
            this.simulation_grid.Size = new System.Drawing.Size(774, 227);
            this.simulation_grid.TabIndex = 1;
            // 
            // Date
            // 
            this.Date.HeaderText = "Fecha";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Worker1
            // 
            this.Worker1.HeaderText = "Trabajador 1";
            this.Worker1.Name = "Worker1";
            this.Worker1.ReadOnly = true;
            this.Worker1.Width = 150;
            // 
            // Worker2
            // 
            this.Worker2.HeaderText = "Trabajador 2";
            this.Worker2.Name = "Worker2";
            this.Worker2.ReadOnly = true;
            this.Worker2.Width = 150;
            // 
            // Worker3
            // 
            this.Worker3.HeaderText = "Trabajador 3";
            this.Worker3.Name = "Worker3";
            this.Worker3.ReadOnly = true;
            this.Worker3.Width = 150;
            // 
            // Worker4
            // 
            this.Worker4.HeaderText = "Trabajador 4";
            this.Worker4.Name = "Worker4";
            this.Worker4.ReadOnly = true;
            this.Worker4.Width = 150;
            // 
            // Worker5
            // 
            this.Worker5.HeaderText = "Trabajador 5";
            this.Worker5.Name = "Worker5";
            this.Worker5.ReadOnly = true;
            this.Worker5.Width = 150;
            // 
            // label_select
            // 
            this.label_select.AutoSize = true;
            this.label_select.Location = new System.Drawing.Point(12, 20);
            this.label_select.Name = "label_select";
            this.label_select.Size = new System.Drawing.Size(173, 18);
            this.label_select.TabIndex = 43;
            this.label_select.Text = "Seleccionar simulación:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Simulación 1",
            "Simulación 2",
            "Simulación 3"});
            this.comboBox1.Location = new System.Drawing.Point(191, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(212, 26);
            this.comboBox1.TabIndex = 44;
            // 
            // WorkersAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(839, 516);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label_select);
            this.Controls.Add(this.groupbox_summary);
            this.Controls.Add(this.groupbox_assignments);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_config);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WorkersAssignment";
            this.Text = "Asignación de trabajadores";
            this.Load += new System.EventHandler(this.WorkersAssignment_Load);
            this.groupbox_summary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.summary_grid)).EndInit();
            this.groupbox_assignments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.simulation_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_config;
        private System.Windows.Forms.GroupBox groupbox_summary;
        private System.Windows.Forms.DataGridView summary_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHuacos;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalStones;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAltarpiece;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalProduced;
        private System.Windows.Forms.GroupBox groupbox_assignments;
        private System.Windows.Forms.DataGridView simulation_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worker2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worker3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worker4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worker5;
        private System.Windows.Forms.Label label_select;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}