namespace InkaArt.Interface.Production
{
    partial class PerformanceReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label_today = new System.Windows.Forms.Label();
            this.grid_performance = new System.Windows.Forms.DataGridView();
            this.button_export = new System.Windows.Forms.Button();
            this.label_tprom = new System.Windows.Forms.Label();
            this.label_cant = new System.Windows.Forms.Label();
            this.label_rota = new System.Windows.Forms.Label();
            this.button_pdf = new System.Windows.Forms.Button();
            this.grid_column_worker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_column_recipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_column_job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_column_broken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_column_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.save_pdf_dialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grid_performance)).BeginInit();
            this.SuspendLayout();
            // 
            // label_today
            // 
            this.label_today.AutoSize = true;
            this.label_today.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_today.Location = new System.Drawing.Point(729, 18);
            this.label_today.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_today.Name = "label_today";
            this.label_today.Size = new System.Drawing.Size(52, 18);
            this.label_today.TabIndex = 29;
            this.label_today.Text = "Fecha";
            this.label_today.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grid_performance
            // 
            this.grid_performance.AllowUserToAddRows = false;
            this.grid_performance.AllowUserToDeleteRows = false;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_performance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.grid_performance.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.grid_performance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_performance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.grid_performance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_performance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid_column_worker,
            this.grid_column_recipe,
            this.grid_column_job,
            this.grid_column_broken,
            this.grid_column_time});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_performance.DefaultCellStyle = dataGridViewCellStyle23;
            this.grid_performance.Location = new System.Drawing.Point(17, 49);
            this.grid_performance.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.grid_performance.Name = "grid_performance";
            this.grid_performance.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_performance.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.grid_performance.RowHeadersVisible = false;
            this.grid_performance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_performance.RowsDefaultCellStyle = dataGridViewCellStyle25;
            this.grid_performance.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_performance.Size = new System.Drawing.Size(848, 404);
            this.grid_performance.TabIndex = 30;
            // 
            // button_export
            // 
            this.button_export.BackColor = System.Drawing.Color.SteelBlue;
            this.button_export.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_export.ForeColor = System.Drawing.Color.White;
            this.button_export.Location = new System.Drawing.Point(254, 470);
            this.button_export.Margin = new System.Windows.Forms.Padding(2);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(161, 41);
            this.button_export.TabIndex = 31;
            this.button_export.Text = "Exportar a Excel";
            this.button_export.UseVisualStyleBackColor = false;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // label_tprom
            // 
            this.label_tprom.AutoSize = true;
            this.label_tprom.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tprom.Location = new System.Drawing.Point(888, 423);
            this.label_tprom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_tprom.Name = "label_tprom";
            this.label_tprom.Size = new System.Drawing.Size(0, 17);
            this.label_tprom.TabIndex = 33;
            // 
            // label_cant
            // 
            this.label_cant.AutoSize = true;
            this.label_cant.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cant.Location = new System.Drawing.Point(952, 457);
            this.label_cant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_cant.Name = "label_cant";
            this.label_cant.Size = new System.Drawing.Size(0, 17);
            this.label_cant.TabIndex = 35;
            // 
            // label_rota
            // 
            this.label_rota.AutoSize = true;
            this.label_rota.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rota.Location = new System.Drawing.Point(914, 492);
            this.label_rota.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_rota.Name = "label_rota";
            this.label_rota.Size = new System.Drawing.Size(0, 17);
            this.label_rota.TabIndex = 37;
            // 
            // button_pdf
            // 
            this.button_pdf.BackColor = System.Drawing.Color.SteelBlue;
            this.button_pdf.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pdf.ForeColor = System.Drawing.Color.White;
            this.button_pdf.Location = new System.Drawing.Point(463, 470);
            this.button_pdf.Margin = new System.Windows.Forms.Padding(2);
            this.button_pdf.Name = "button_pdf";
            this.button_pdf.Size = new System.Drawing.Size(148, 41);
            this.button_pdf.TabIndex = 38;
            this.button_pdf.Text = "Exportar a PDF";
            this.button_pdf.UseVisualStyleBackColor = false;
            this.button_pdf.Click += new System.EventHandler(this.button_pdf_Click);
            // 
            // grid_column_worker
            // 
            this.grid_column_worker.FillWeight = 64.76126F;
            this.grid_column_worker.HeaderText = "Trabajador";
            this.grid_column_worker.Name = "grid_column_worker";
            this.grid_column_worker.ReadOnly = true;
            this.grid_column_worker.Width = 180;
            // 
            // grid_column_recipe
            // 
            this.grid_column_recipe.FillWeight = 44.76743F;
            this.grid_column_recipe.HeaderText = "Receta";
            this.grid_column_recipe.Name = "grid_column_recipe";
            this.grid_column_recipe.ReadOnly = true;
            this.grid_column_recipe.Width = 200;
            // 
            // grid_column_job
            // 
            this.grid_column_job.FillWeight = 44.76743F;
            this.grid_column_job.HeaderText = "Puesto de Trabajo";
            this.grid_column_job.Name = "grid_column_job";
            this.grid_column_job.ReadOnly = true;
            this.grid_column_job.Width = 180;
            // 
            // grid_column_broken
            // 
            this.grid_column_broken.FillWeight = 44.76743F;
            this.grid_column_broken.HeaderText = "% de rotura";
            this.grid_column_broken.Name = "grid_column_broken";
            this.grid_column_broken.ReadOnly = true;
            this.grid_column_broken.Width = 110;
            // 
            // grid_column_time
            // 
            this.grid_column_time.FillWeight = 44.76743F;
            this.grid_column_time.HeaderText = "Tiempo promedio";
            this.grid_column_time.Name = "grid_column_time";
            this.grid_column_time.ReadOnly = true;
            this.grid_column_time.Width = 150;
            // 
            // save_pdf_dialog
            // 
            this.save_pdf_dialog.FileName = "ReporteProductividad";
            this.save_pdf_dialog.Filter = "Portable Document File|*.pdf";
            this.save_pdf_dialog.Title = "Exportar a un documento PDF...";
            // 
            // PerformanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 522);
            this.Controls.Add(this.button_pdf);
            this.Controls.Add(this.label_rota);
            this.Controls.Add(this.label_cant);
            this.Controls.Add(this.label_tprom);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.grid_performance);
            this.Controls.Add(this.label_today);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PerformanceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Rendimiento";
            this.Load += new System.EventHandler(this.PerformanceReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_performance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_today;
        private System.Windows.Forms.DataGridView grid_performance;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.Label label_tprom;
        private System.Windows.Forms.Label label_cant;
        private System.Windows.Forms.Label label_rota;
        private System.Windows.Forms.Button button_pdf;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_worker;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_recipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_job;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_broken;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_time;
        private System.Windows.Forms.SaveFileDialog save_pdf_dialog;
    }
}