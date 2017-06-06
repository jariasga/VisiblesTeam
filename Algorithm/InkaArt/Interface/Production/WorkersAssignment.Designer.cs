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
            this.label_select = new System.Windows.Forms.Label();
            this.combo_simulations = new System.Windows.Forms.ComboBox();
            this.button_report = new System.Windows.Forms.Button();
            this.simulation_grid = new System.Windows.Forms.DataGridView();
            this.grid_assignment_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_worker_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_worker_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_worker_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_worker_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_worker_5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulation_tab_control = new System.Windows.Forms.TabControl();
            this.simulation_tab_general = new System.Windows.Forms.TabPage();
            this.general_grid = new System.Windows.Forms.DataGridView();
            this.grid_general_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_of_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_huacos_produced = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_huacos_left = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_stones_produced = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_stones_left = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_altarpiece_produced = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_altarpiece_left = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulation_tab_assignment = new System.Windows.Forms.TabPage();
            this.button_save = new System.Windows.Forms.Button();
            this.groupbox_summary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.summary_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simulation_grid)).BeginInit();
            this.simulation_tab_control.SuspendLayout();
            this.simulation_tab_general.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.general_grid)).BeginInit();
            this.simulation_tab_assignment.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_config
            // 
            this.button_config.BackColor = System.Drawing.Color.Gray;
            this.button_config.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_config.ForeColor = System.Drawing.Color.White;
            this.button_config.Location = new System.Drawing.Point(422, 469);
            this.button_config.Name = "button_config";
            this.button_config.Size = new System.Drawing.Size(143, 43);
            this.button_config.TabIndex = 32;
            this.button_config.Text = "+ Crear";
            this.button_config.UseVisualStyleBackColor = false;
            this.button_config.Click += new System.EventHandler(this.ButtonConfigClick);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(743, 469);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(193, 43);
            this.button_delete.TabIndex = 39;
            this.button_delete.Text = "🗑 Eliminar simulación";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.SteelBlue;
            this.button_start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.ForeColor = System.Drawing.Color.White;
            this.button_start.Location = new System.Drawing.Point(27, 469);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(171, 43);
            this.button_start.TabIndex = 40;
            this.button_start.Text = "Iniciar simulación";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.ButtonStartClick);
            // 
            // groupbox_summary
            // 
            this.groupbox_summary.Controls.Add(this.summary_grid);
            this.groupbox_summary.Location = new System.Drawing.Point(21, 342);
            this.groupbox_summary.Name = "groupbox_summary";
            this.groupbox_summary.Size = new System.Drawing.Size(924, 105);
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
            this.summary_grid.Size = new System.Drawing.Size(902, 61);
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
            // label_select
            // 
            this.label_select.AutoSize = true;
            this.label_select.Location = new System.Drawing.Point(21, 20);
            this.label_select.Name = "label_select";
            this.label_select.Size = new System.Drawing.Size(173, 18);
            this.label_select.TabIndex = 43;
            this.label_select.Text = "Seleccionar simulación:";
            // 
            // combo_simulations
            // 
            this.combo_simulations.FormattingEnabled = true;
            this.combo_simulations.Location = new System.Drawing.Point(200, 17);
            this.combo_simulations.Name = "combo_simulations";
            this.combo_simulations.Size = new System.Drawing.Size(212, 26);
            this.combo_simulations.TabIndex = 44;
            this.combo_simulations.SelectedIndexChanged += new System.EventHandler(this.ComboSimulationsSelectedIndexChanged);
            // 
            // button_report
            // 
            this.button_report.BackColor = System.Drawing.Color.Gray;
            this.button_report.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_report.ForeColor = System.Drawing.Color.White;
            this.button_report.Location = new System.Drawing.Point(582, 469);
            this.button_report.Name = "button_report";
            this.button_report.Size = new System.Drawing.Size(146, 43);
            this.button_report.TabIndex = 45;
            this.button_report.Text = "Generar reporte";
            this.button_report.UseVisualStyleBackColor = false;
            this.button_report.Click += new System.EventHandler(this.ButtonReportClick);
            // 
            // simulation_grid
            // 
            this.simulation_grid.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.simulation_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.simulation_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid_assignment_date,
            this.grid_worker_1,
            this.grid_worker_2,
            this.grid_worker_3,
            this.grid_worker_4,
            this.grid_worker_5});
            this.simulation_grid.Location = new System.Drawing.Point(9, 8);
            this.simulation_grid.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.simulation_grid.Name = "simulation_grid";
            this.simulation_grid.RowHeadersVisible = false;
            this.simulation_grid.Size = new System.Drawing.Size(873, 227);
            this.simulation_grid.TabIndex = 1;
            // 
            // grid_assignment_date
            // 
            this.grid_assignment_date.HeaderText = "Fecha";
            this.grid_assignment_date.Name = "grid_assignment_date";
            this.grid_assignment_date.ReadOnly = true;
            // 
            // grid_worker_1
            // 
            this.grid_worker_1.HeaderText = "Trabajador 1";
            this.grid_worker_1.Name = "grid_worker_1";
            this.grid_worker_1.ReadOnly = true;
            this.grid_worker_1.Width = 150;
            // 
            // grid_worker_2
            // 
            this.grid_worker_2.HeaderText = "Trabajador 2";
            this.grid_worker_2.Name = "grid_worker_2";
            this.grid_worker_2.ReadOnly = true;
            this.grid_worker_2.Width = 150;
            // 
            // grid_worker_3
            // 
            this.grid_worker_3.HeaderText = "Trabajador 3";
            this.grid_worker_3.Name = "grid_worker_3";
            this.grid_worker_3.ReadOnly = true;
            this.grid_worker_3.Width = 150;
            // 
            // grid_worker_4
            // 
            this.grid_worker_4.HeaderText = "Trabajador 4";
            this.grid_worker_4.Name = "grid_worker_4";
            this.grid_worker_4.ReadOnly = true;
            this.grid_worker_4.Width = 150;
            // 
            // grid_worker_5
            // 
            this.grid_worker_5.HeaderText = "Trabajador 5";
            this.grid_worker_5.Name = "grid_worker_5";
            this.grid_worker_5.ReadOnly = true;
            this.grid_worker_5.Width = 150;
            // 
            // simulation_tab_control
            // 
            this.simulation_tab_control.Controls.Add(this.simulation_tab_general);
            this.simulation_tab_control.Controls.Add(this.simulation_tab_assignment);
            this.simulation_tab_control.Location = new System.Drawing.Point(24, 59);
            this.simulation_tab_control.Name = "simulation_tab_control";
            this.simulation_tab_control.SelectedIndex = 0;
            this.simulation_tab_control.Size = new System.Drawing.Size(921, 277);
            this.simulation_tab_control.TabIndex = 46;
            // 
            // simulation_tab_general
            // 
            this.simulation_tab_general.Controls.Add(this.general_grid);
            this.simulation_tab_general.Location = new System.Drawing.Point(4, 27);
            this.simulation_tab_general.Name = "simulation_tab_general";
            this.simulation_tab_general.Padding = new System.Windows.Forms.Padding(3);
            this.simulation_tab_general.Size = new System.Drawing.Size(913, 246);
            this.simulation_tab_general.TabIndex = 0;
            this.simulation_tab_general.Text = "General";
            this.simulation_tab_general.UseVisualStyleBackColor = true;
            // 
            // general_grid
            // 
            this.general_grid.AllowUserToAddRows = false;
            this.general_grid.AllowUserToDeleteRows = false;
            this.general_grid.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.general_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.general_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid_general_date,
            this.grid_of_value,
            this.grid_huacos_produced,
            this.grid_huacos_left,
            this.grid_stones_produced,
            this.grid_stones_left,
            this.grid_altarpiece_produced,
            this.grid_altarpiece_left});
            this.general_grid.Location = new System.Drawing.Point(9, 8);
            this.general_grid.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.general_grid.Name = "general_grid";
            this.general_grid.ReadOnly = true;
            this.general_grid.RowHeadersVisible = false;
            this.general_grid.Size = new System.Drawing.Size(895, 230);
            this.general_grid.TabIndex = 3;
            // 
            // grid_general_date
            // 
            this.grid_general_date.HeaderText = "Fecha";
            this.grid_general_date.Name = "grid_general_date";
            this.grid_general_date.ReadOnly = true;
            // 
            // grid_of_value
            // 
            this.grid_of_value.HeaderText = "Valor F.O.";
            this.grid_of_value.Name = "grid_of_value";
            this.grid_of_value.ReadOnly = true;
            this.grid_of_value.Width = 110;
            // 
            // grid_huacos_produced
            // 
            this.grid_huacos_produced.HeaderText = "Huacos producidos";
            this.grid_huacos_produced.Name = "grid_huacos_produced";
            this.grid_huacos_produced.ReadOnly = true;
            // 
            // grid_huacos_left
            // 
            this.grid_huacos_left.HeaderText = "Huacos por producir";
            this.grid_huacos_left.Name = "grid_huacos_left";
            this.grid_huacos_left.ReadOnly = true;
            this.grid_huacos_left.Width = 120;
            // 
            // grid_stones_produced
            // 
            this.grid_stones_produced.HeaderText = "Piedras de Huamanga producidas";
            this.grid_stones_produced.Name = "grid_stones_produced";
            this.grid_stones_produced.ReadOnly = true;
            this.grid_stones_produced.Width = 200;
            // 
            // grid_stones_left
            // 
            this.grid_stones_left.HeaderText = "Piedras de Huamanga por producir";
            this.grid_stones_left.Name = "grid_stones_left";
            this.grid_stones_left.ReadOnly = true;
            this.grid_stones_left.Width = 200;
            // 
            // grid_altarpiece_produced
            // 
            this.grid_altarpiece_produced.HeaderText = "Retablos producidos";
            this.grid_altarpiece_produced.Name = "grid_altarpiece_produced";
            this.grid_altarpiece_produced.ReadOnly = true;
            this.grid_altarpiece_produced.Width = 120;
            // 
            // grid_altarpiece_left
            // 
            this.grid_altarpiece_left.HeaderText = "Retablos por producir";
            this.grid_altarpiece_left.Name = "grid_altarpiece_left";
            this.grid_altarpiece_left.ReadOnly = true;
            this.grid_altarpiece_left.Width = 120;
            // 
            // simulation_tab_assignment
            // 
            this.simulation_tab_assignment.Controls.Add(this.simulation_grid);
            this.simulation_tab_assignment.Location = new System.Drawing.Point(4, 27);
            this.simulation_tab_assignment.Name = "simulation_tab_assignment";
            this.simulation_tab_assignment.Padding = new System.Windows.Forms.Padding(3);
            this.simulation_tab_assignment.Size = new System.Drawing.Size(913, 246);
            this.simulation_tab_assignment.TabIndex = 1;
            this.simulation_tab_assignment.Text = "Asignaciones";
            this.simulation_tab_assignment.UseVisualStyleBackColor = true;
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.SteelBlue;
            this.button_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(212, 469);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(195, 43);
            this.button_save.TabIndex = 47;
            this.button_save.Text = "🖫 Guardar simulación";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.ButtonSaveClick);
            // 
            // WorkersAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(968, 537);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.simulation_tab_control);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_report);
            this.Controls.Add(this.combo_simulations);
            this.Controls.Add(this.label_select);
            this.Controls.Add(this.groupbox_summary);
            this.Controls.Add(this.button_config);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WorkersAssignment";
            this.Text = "Asignación de trabajadores";
            this.Load += new System.EventHandler(this.WorkersAssignment_Load);
            this.groupbox_summary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.summary_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simulation_grid)).EndInit();
            this.simulation_tab_control.ResumeLayout(false);
            this.simulation_tab_general.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.general_grid)).EndInit();
            this.simulation_tab_assignment.ResumeLayout(false);
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
        private System.Windows.Forms.Label label_select;
        private System.Windows.Forms.ComboBox combo_simulations;
        private System.Windows.Forms.Button button_report;
        private System.Windows.Forms.DataGridView simulation_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_assignment_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_worker_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_worker_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_worker_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_worker_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_worker_5;
        private System.Windows.Forms.TabControl simulation_tab_control;
        private System.Windows.Forms.TabPage simulation_tab_general;
        private System.Windows.Forms.DataGridView general_grid;
        private System.Windows.Forms.TabPage simulation_tab_assignment;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_general_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_of_value;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_huacos_produced;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_huacos_left;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_stones_produced;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_stones_left;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_altarpiece_produced;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_altarpiece_left;
        private System.Windows.Forms.Button button_save;
    }
}