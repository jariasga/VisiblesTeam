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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label_today = new System.Windows.Forms.Label();
            this.grid_performance = new System.Windows.Forms.DataGridView();
            this.grid_column_worker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_column_recipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_column_job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_column_broken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_column_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_export = new System.Windows.Forms.Button();
            this.label_tprom = new System.Windows.Forms.Label();
            this.label_cant = new System.Windows.Forms.Label();
            this.label_rota = new System.Windows.Forms.Label();
            this.button_pdf = new System.Windows.Forms.Button();
            this.save_pdf_dialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grid_performance)).BeginInit();
            this.SuspendLayout();
            // 
            // label_today
            // 
            this.label_today.AutoSize = true;
            this.label_today.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_today.Location = new System.Drawing.Point(972, 22);
            this.label_today.Name = "label_today";
            this.label_today.Size = new System.Drawing.Size(64, 23);
            this.label_today.TabIndex = 29;
            this.label_today.Text = "Fecha";
            this.label_today.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grid_performance
            // 
            this.grid_performance.AllowUserToAddRows = false;
            this.grid_performance.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_performance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_performance.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grid_performance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_performance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_performance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_performance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid_column_worker,
            this.grid_column_recipe,
            this.grid_column_job,
            this.grid_column_broken,
            this.grid_column_time});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_performance.DefaultCellStyle = dataGridViewCellStyle3;
            this.grid_performance.Location = new System.Drawing.Point(23, 60);
            this.grid_performance.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.grid_performance.Name = "grid_performance";
            this.grid_performance.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_performance.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grid_performance.RowHeadersVisible = false;
            this.grid_performance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_performance.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grid_performance.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_performance.Size = new System.Drawing.Size(1131, 497);
            this.grid_performance.TabIndex = 30;
            // 
            // grid_column_worker
            // 
            this.grid_column_worker.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid_column_worker.FillWeight = 64.76126F;
            this.grid_column_worker.HeaderText = "Trabajador";
            this.grid_column_worker.Name = "grid_column_worker";
            this.grid_column_worker.ReadOnly = true;
            // 
            // grid_column_recipe
            // 
            this.grid_column_recipe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid_column_recipe.FillWeight = 44.76743F;
            this.grid_column_recipe.HeaderText = "Receta";
            this.grid_column_recipe.Name = "grid_column_recipe";
            this.grid_column_recipe.ReadOnly = true;
            // 
            // grid_column_job
            // 
            this.grid_column_job.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid_column_job.FillWeight = 44.76743F;
            this.grid_column_job.HeaderText = "Puesto de Trabajo";
            this.grid_column_job.Name = "grid_column_job";
            this.grid_column_job.ReadOnly = true;
            // 
            // grid_column_broken
            // 
            this.grid_column_broken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid_column_broken.FillWeight = 44.76743F;
            this.grid_column_broken.HeaderText = "% de rotura";
            this.grid_column_broken.Name = "grid_column_broken";
            this.grid_column_broken.ReadOnly = true;
            // 
            // grid_column_time
            // 
            this.grid_column_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid_column_time.FillWeight = 44.76743F;
            this.grid_column_time.HeaderText = "Tiempo promedio";
            this.grid_column_time.Name = "grid_column_time";
            this.grid_column_time.ReadOnly = true;
            // 
            // button_export
            // 
            this.button_export.BackColor = System.Drawing.Color.SteelBlue;
            this.button_export.Font = new System.Drawing.Font("Arial", 12F);
            this.button_export.ForeColor = System.Drawing.Color.White;
            this.button_export.Location = new System.Drawing.Point(339, 578);
            this.button_export.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(215, 50);
            this.button_export.TabIndex = 31;
            this.button_export.Text = "🗀 Exportar a Excel";
            this.button_export.UseVisualStyleBackColor = false;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // label_tprom
            // 
            this.label_tprom.AutoSize = true;
            this.label_tprom.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tprom.Location = new System.Drawing.Point(1184, 521);
            this.label_tprom.Name = "label_tprom";
            this.label_tprom.Size = new System.Drawing.Size(0, 22);
            this.label_tprom.TabIndex = 33;
            // 
            // label_cant
            // 
            this.label_cant.AutoSize = true;
            this.label_cant.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cant.Location = new System.Drawing.Point(1269, 562);
            this.label_cant.Name = "label_cant";
            this.label_cant.Size = new System.Drawing.Size(0, 22);
            this.label_cant.TabIndex = 35;
            // 
            // label_rota
            // 
            this.label_rota.AutoSize = true;
            this.label_rota.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rota.Location = new System.Drawing.Point(1219, 606);
            this.label_rota.Name = "label_rota";
            this.label_rota.Size = new System.Drawing.Size(0, 22);
            this.label_rota.TabIndex = 37;
            // 
            // button_pdf
            // 
            this.button_pdf.BackColor = System.Drawing.Color.SteelBlue;
            this.button_pdf.Font = new System.Drawing.Font("Arial", 12F);
            this.button_pdf.ForeColor = System.Drawing.Color.White;
            this.button_pdf.Location = new System.Drawing.Point(617, 578);
            this.button_pdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_pdf.Name = "button_pdf";
            this.button_pdf.Size = new System.Drawing.Size(197, 50);
            this.button_pdf.TabIndex = 38;
            this.button_pdf.Text = "🗀 Exportar a PDF";
            this.button_pdf.UseVisualStyleBackColor = false;
            this.button_pdf.Click += new System.EventHandler(this.button_pdf_Click);
            // 
            // save_pdf_dialog
            // 
            this.save_pdf_dialog.FileName = "ReporteProductividad";
            this.save_pdf_dialog.Filter = "Portable Document File|*.pdf";
            this.save_pdf_dialog.Title = "Exportar a un documento PDF...";
            // 
            // PerformanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1179, 642);
            this.Controls.Add(this.button_pdf);
            this.Controls.Add(this.label_rota);
            this.Controls.Add(this.label_cant);
            this.Controls.Add(this.label_tprom);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.grid_performance);
            this.Controls.Add(this.label_today);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.SaveFileDialog save_pdf_dialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_worker;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_recipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_job;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_broken;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_column_time;
    }
}