namespace InkaArt.Interface.Production
{
    partial class SimulationAssignment
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
            this.button_config = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.label_select = new System.Windows.Forms.Label();
            this.combo_simulations = new System.Windows.Forms.ComboBox();
            this.button_report = new System.Windows.Forms.Button();
            this.simulation_grid = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.worker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulation_tab_control = new System.Windows.Forms.TabControl();
            this.simulation_tab_assignment = new System.Windows.Forms.TabPage();
            this.button_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.simulation_grid)).BeginInit();
            this.simulation_tab_control.SuspendLayout();
            this.simulation_tab_assignment.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_config
            // 
            this.button_config.BackColor = System.Drawing.Color.SteelBlue;
            this.button_config.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_config.ForeColor = System.Drawing.Color.White;
            this.button_config.Location = new System.Drawing.Point(24, 468);
            this.button_config.Name = "button_config";
            this.button_config.Size = new System.Drawing.Size(200, 43);
            this.button_config.TabIndex = 32;
            this.button_config.Text = "+ Nueva simulación";
            this.button_config.UseVisualStyleBackColor = false;
            this.button_config.Click += new System.EventHandler(this.ButtonConfigClick);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.Enabled = false;
            this.button_delete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(757, 468);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(188, 43);
            this.button_delete.TabIndex = 39;
            this.button_delete.Text = "🗑 Eliminar simulación";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.ButtonDeleteClick);
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
            this.combo_simulations.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_simulations.FormattingEnabled = true;
            this.combo_simulations.Location = new System.Drawing.Point(200, 17);
            this.combo_simulations.Name = "combo_simulations";
            this.combo_simulations.Size = new System.Drawing.Size(212, 25);
            this.combo_simulations.TabIndex = 44;
            this.combo_simulations.SelectedIndexChanged += new System.EventHandler(this.ComboSimulationsSelectedIndexChanged);
            this.combo_simulations.MouseClick += new System.Windows.Forms.MouseEventHandler(this.combo_simulations_MouseClick);
            // 
            // button_report
            // 
            this.button_report.BackColor = System.Drawing.Color.Gray;
            this.button_report.Enabled = false;
            this.button_report.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_report.ForeColor = System.Drawing.Color.White;
            this.button_report.Location = new System.Drawing.Point(527, 468);
            this.button_report.Name = "button_report";
            this.button_report.Size = new System.Drawing.Size(187, 43);
            this.button_report.TabIndex = 45;
            this.button_report.Text = "🗀 Generar Reporte";
            this.button_report.UseVisualStyleBackColor = false;
            this.button_report.Click += new System.EventHandler(this.ButtonReportClick);
            // 
            // simulation_grid
            // 
            this.simulation_grid.AllowUserToOrderColumns = true;
            this.simulation_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.simulation_grid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.simulation_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.simulation_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.simulation_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.worker,
            this.job,
            this.recipe,
            this.quantity,
            this.index});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.simulation_grid.DefaultCellStyle = dataGridViewCellStyle1;
            this.simulation_grid.Location = new System.Drawing.Point(24, 23);
            this.simulation_grid.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.simulation_grid.Name = "simulation_grid";
            this.simulation_grid.RowHeadersVisible = false;
            this.simulation_grid.Size = new System.Drawing.Size(860, 309);
            this.simulation_grid.TabIndex = 1;
            this.simulation_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.simulation_grid_CellContentClick);
            // 
            // date
            // 
            this.date.HeaderText = "Fecha";
            this.date.Name = "date";
            // 
            // worker
            // 
            this.worker.HeaderText = "Trabajador";
            this.worker.Name = "worker";
            // 
            // job
            // 
            this.job.HeaderText = "Proceso y Producto";
            this.job.Name = "job";
            // 
            // recipe
            // 
            this.recipe.HeaderText = "Receta";
            this.recipe.Name = "recipe";
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Cantidad";
            this.quantity.Name = "quantity";
            // 
            // index
            // 
            this.index.HeaderText = "Índice de Pérdida";
            this.index.Name = "index";
            // 
            // simulation_tab_control
            // 
            this.simulation_tab_control.Controls.Add(this.simulation_tab_assignment);
            this.simulation_tab_control.Location = new System.Drawing.Point(24, 59);
            this.simulation_tab_control.Name = "simulation_tab_control";
            this.simulation_tab_control.SelectedIndex = 0;
            this.simulation_tab_control.Size = new System.Drawing.Size(921, 393);
            this.simulation_tab_control.TabIndex = 46;
            // 
            // simulation_tab_assignment
            // 
            this.simulation_tab_assignment.Controls.Add(this.simulation_grid);
            this.simulation_tab_assignment.Location = new System.Drawing.Point(4, 27);
            this.simulation_tab_assignment.Name = "simulation_tab_assignment";
            this.simulation_tab_assignment.Padding = new System.Windows.Forms.Padding(3);
            this.simulation_tab_assignment.Size = new System.Drawing.Size(913, 362);
            this.simulation_tab_assignment.TabIndex = 1;
            this.simulation_tab_assignment.Text = "Asignaciones";
            this.simulation_tab_assignment.UseVisualStyleBackColor = true;
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.SteelBlue;
            this.button_save.Enabled = false;
            this.button_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(271, 468);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(209, 43);
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
            this.ClientSize = new System.Drawing.Size(968, 536);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.simulation_tab_control);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_report);
            this.Controls.Add(this.combo_simulations);
            this.Controls.Add(this.label_select);
            this.Controls.Add(this.button_config);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WorkersAssignment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de trabajadores";
            this.Load += new System.EventHandler(this.WorkersAssignment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.simulation_grid)).EndInit();
            this.simulation_tab_control.ResumeLayout(false);
            this.simulation_tab_assignment.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_config;
        private System.Windows.Forms.Label label_select;
        private System.Windows.Forms.ComboBox combo_simulations;
        private System.Windows.Forms.Button button_report;
        private System.Windows.Forms.DataGridView simulation_grid;
        private System.Windows.Forms.TabControl simulation_tab_control;
        private System.Windows.Forms.TabPage simulation_tab_assignment;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn worker;
        private System.Windows.Forms.DataGridViewTextBoxColumn job;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
    }
}