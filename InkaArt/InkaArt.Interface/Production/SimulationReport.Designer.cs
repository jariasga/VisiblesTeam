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
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_export = new System.Windows.Forms.Button();
            this.label_todaydate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_simulationName = new System.Windows.Forms.Label();
            this.label_simulationTime = new System.Windows.Forms.Label();
            this.button_pdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.simulation_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tiempo total de ejecución:";
            // 
            // simulation_grid
            // 
            this.simulation_grid.AllowUserToDeleteRows = false;
            this.simulation_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.simulation_grid.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.simulation_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.simulation_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.simulation_grid.Location = new System.Drawing.Point(28, 107);
            this.simulation_grid.Margin = new System.Windows.Forms.Padding(5);
            this.simulation_grid.Name = "simulation_grid";
            this.simulation_grid.ReadOnly = true;
            this.simulation_grid.RowHeadersVisible = false;
            this.simulation_grid.Size = new System.Drawing.Size(996, 335);
            this.simulation_grid.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Fecha";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "N° iteraciones tabu";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Huacos producidos";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Piedras de Huamanga producidas";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Retablos producidos";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "# trabajadores asignados";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // button_export
            // 
            this.button_export.BackColor = System.Drawing.Color.SteelBlue;
            this.button_export.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_export.ForeColor = System.Drawing.Color.White;
            this.button_export.Location = new System.Drawing.Point(296, 466);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(218, 44);
            this.button_export.TabIndex = 32;
            this.button_export.Text = "🗀 Exportar a Excel";
            this.button_export.UseVisualStyleBackColor = false;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // label_todaydate
            // 
            this.label_todaydate.AutoSize = true;
            this.label_todaydate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_todaydate.Location = new System.Drawing.Point(939, 18);
            this.label_todaydate.Name = "label_todaydate";
            this.label_todaydate.Size = new System.Drawing.Size(0, 18);
            this.label_todaydate.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Simulación:";
            // 
            // label_simulationName
            // 
            this.label_simulationName.AutoSize = true;
            this.label_simulationName.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_simulationName.Location = new System.Drawing.Point(138, 29);
            this.label_simulationName.Name = "label_simulationName";
            this.label_simulationName.Size = new System.Drawing.Size(0, 17);
            this.label_simulationName.TabIndex = 36;
            // 
            // label_simulationTime
            // 
            this.label_simulationTime.AutoSize = true;
            this.label_simulationTime.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_simulationTime.Location = new System.Drawing.Point(263, 65);
            this.label_simulationTime.Name = "label_simulationTime";
            this.label_simulationTime.Size = new System.Drawing.Size(0, 17);
            this.label_simulationTime.TabIndex = 37;
            // 
            // button_pdf
            // 
            this.button_pdf.BackColor = System.Drawing.Color.SteelBlue;
            this.button_pdf.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pdf.ForeColor = System.Drawing.Color.White;
            this.button_pdf.Location = new System.Drawing.Point(541, 466);
            this.button_pdf.Margin = new System.Windows.Forms.Padding(2);
            this.button_pdf.Name = "button_pdf";
            this.button_pdf.Size = new System.Drawing.Size(218, 44);
            this.button_pdf.TabIndex = 41;
            this.button_pdf.Text = "🗀 Exportar a PDF";
            this.button_pdf.UseVisualStyleBackColor = false;
            this.button_pdf.Click += new System.EventHandler(this.button_pdf_Click);
            // 
            // SimulationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1053, 527);
            this.Controls.Add(this.button_pdf);
            this.Controls.Add(this.label_simulationTime);
            this.Controls.Add(this.label_simulationName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_todaydate);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.simulation_grid);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SimulationReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button button_pdf;
    }
}