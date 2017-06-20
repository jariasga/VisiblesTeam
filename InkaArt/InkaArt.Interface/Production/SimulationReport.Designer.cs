namespace InkaArt.Interface.Production
{
    partial class SimulationReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.simulation_grid = new System.Windows.Forms.DataGridView();
            this.report_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iteraciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.report_huacos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.report_stones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.report_altarpieces = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.report_workers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_export = new System.Windows.Forms.Button();
            this.label_todaydate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_simulationName = new System.Windows.Forms.Label();
            this.label_simulationTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.simulation_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tiempo total de ejecución:";
            // 
            // simulation_grid
            // 
            this.simulation_grid.AllowUserToAddRows = false;
            this.simulation_grid.AllowUserToDeleteRows = false;
            this.simulation_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.simulation_grid.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.simulation_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.simulation_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.report_date,
            this.iteraciones,
            this.report_huacos,
            this.report_stones,
            this.report_altarpieces,
            this.report_workers});
            this.simulation_grid.Location = new System.Drawing.Point(68, 149);
            this.simulation_grid.Margin = new System.Windows.Forms.Padding(5);
            this.simulation_grid.Name = "simulation_grid";
            this.simulation_grid.ReadOnly = true;
            this.simulation_grid.RowHeadersVisible = false;
            this.simulation_grid.Size = new System.Drawing.Size(996, 335);
            this.simulation_grid.TabIndex = 2;
            // 
            // report_date
            // 
            this.report_date.HeaderText = "Fecha";
            this.report_date.Name = "report_date";
            this.report_date.ReadOnly = true;
            // 
            // iteraciones
            // 
            this.iteraciones.HeaderText = "N° iteraciones tabu";
            this.iteraciones.Name = "iteraciones";
            this.iteraciones.ReadOnly = true;
            // 
            // report_huacos
            // 
            this.report_huacos.HeaderText = "Huacos producidos";
            this.report_huacos.Name = "report_huacos";
            this.report_huacos.ReadOnly = true;
            // 
            // report_stones
            // 
            this.report_stones.HeaderText = "Piedras de Huamanga producidas";
            this.report_stones.Name = "report_stones";
            this.report_stones.ReadOnly = true;
            // 
            // report_altarpieces
            // 
            this.report_altarpieces.HeaderText = "Retablos producidos";
            this.report_altarpieces.Name = "report_altarpieces";
            this.report_altarpieces.ReadOnly = true;
            // 
            // report_workers
            // 
            this.report_workers.HeaderText = "# trabajadores asignados";
            this.report_workers.Name = "report_workers";
            this.report_workers.ReadOnly = true;
            // 
            // button_export
            // 
            this.button_export.BackColor = System.Drawing.Color.SteelBlue;
            this.button_export.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_export.ForeColor = System.Drawing.Color.White;
            this.button_export.Location = new System.Drawing.Point(491, 510);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(155, 44);
            this.button_export.TabIndex = 32;
            this.button_export.Text = "Exportar";
            this.button_export.UseVisualStyleBackColor = false;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // label_todaydate
            // 
            this.label_todaydate.AutoSize = true;
            this.label_todaydate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_todaydate.Location = new System.Drawing.Point(939, 18);
            this.label_todaydate.Name = "label_todaydate";
            this.label_todaydate.Size = new System.Drawing.Size(0, 23);
            this.label_todaydate.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 22);
            this.label2.TabIndex = 35;
            this.label2.Text = "Simulación:";
            // 
            // label_simulationName
            // 
            this.label_simulationName.AutoSize = true;
            this.label_simulationName.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_simulationName.Location = new System.Drawing.Point(177, 29);
            this.label_simulationName.Name = "label_simulationName";
            this.label_simulationName.Size = new System.Drawing.Size(0, 22);
            this.label_simulationName.TabIndex = 36;
            // 
            // label_simulationTime
            // 
            this.label_simulationTime.AutoSize = true;
            this.label_simulationTime.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_simulationTime.Location = new System.Drawing.Point(302, 86);
            this.label_simulationTime.Name = "label_simulationTime";
            this.label_simulationTime.Size = new System.Drawing.Size(0, 22);
            this.label_simulationTime.TabIndex = 37;
            // 
            // SimulationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1134, 579);
            this.Controls.Add(this.label_simulationTime);
            this.Controls.Add(this.label_simulationName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_todaydate);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.simulation_grid);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SimulationReport";
            this.Text = "Reporte de simulación de trabajadores";
            ((System.ComponentModel.ISupportInitialize)(this.simulation_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView simulation_grid;
        private System.Windows.Forms.Button button_export;
        public System.Windows.Forms.Label label_todaydate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_simulationName;
        private System.Windows.Forms.Label label_simulationTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn iteraciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_huacos;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_stones;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_altarpieces;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_workers;
    }
}