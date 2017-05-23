namespace InkaArt.Interface.Production
{
    partial class GenerateSimulationReport
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
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worker1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worker2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.simulation_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tiempo total: 4:15 min.";
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
            this.Worker2});
            this.simulation_grid.Location = new System.Drawing.Point(36, 89);
            this.simulation_grid.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.simulation_grid.Name = "simulation_grid";
            this.simulation_grid.ReadOnly = true;
            this.simulation_grid.RowHeadersVisible = false;
            this.simulation_grid.Size = new System.Drawing.Size(463, 227);
            this.simulation_grid.TabIndex = 2;
            // 
            // Date
            // 
            this.Date.HeaderText = "Núm. de Iteraciones Tabu";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Worker1
            // 
            this.Worker1.HeaderText = "Valos F.O.";
            this.Worker1.Name = "Worker1";
            this.Worker1.ReadOnly = true;
            this.Worker1.Width = 150;
            // 
            // Worker2
            // 
            this.Worker2.HeaderText = "Producto producido";
            this.Worker2.Name = "Worker2";
            this.Worker2.ReadOnly = true;
            this.Worker2.Width = 150;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(179, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 51);
            this.button1.TabIndex = 32;
            this.button1.Text = "🖶 Imprimir";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // GenerateSimulationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 432);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.simulation_grid);
            this.Controls.Add(this.label1);
            this.Name = "GenerateSimulationReport";
            this.Text = "GenerateSimulationReport";
            ((System.ComponentModel.ISupportInitialize)(this.simulation_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView simulation_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worker2;
        private System.Windows.Forms.Button button1;
    }
}