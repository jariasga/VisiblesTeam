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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label_today = new System.Windows.Forms.Label();
            this.dataGridView_performance = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_export = new System.Windows.Forms.Button();
            this.label_tprom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_cant = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_rota = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_pdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_performance)).BeginInit();
            this.SuspendLayout();
            // 
            // label_today
            // 
            this.label_today.AutoSize = true;
            this.label_today.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_today.Location = new System.Drawing.Point(1236, 9);
            this.label_today.Name = "label_today";
            this.label_today.Size = new System.Drawing.Size(0, 23);
            this.label_today.TabIndex = 29;
            // 
            // dataGridView_performance
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_performance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_performance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_performance.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_performance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_performance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_performance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_performance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Trabajador,
            this.Cantidad,
            this.delete,
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_performance.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_performance.Location = new System.Drawing.Point(38, 60);
            this.dataGridView_performance.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.dataGridView_performance.Name = "dataGridView_performance";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_performance.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_performance.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView_performance.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_performance.Size = new System.Drawing.Size(1309, 423);
            this.dataGridView_performance.TabIndex = 30;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Trabajador
            // 
            this.Trabajador.HeaderText = "Trabajador";
            this.Trabajador.Name = "Trabajador";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Puesto de Trabajo";
            this.Cantidad.Name = "Cantidad";
            // 
            // delete
            // 
            this.delete.HeaderText = "Receta";
            this.delete.Name = "delete";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cantidad rota";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cantidad producida";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tiempo (min)";
            this.Column3.Name = "Column3";
            // 
            // button_export
            // 
            this.button_export.BackColor = System.Drawing.Color.SteelBlue;
            this.button_export.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_export.ForeColor = System.Drawing.Color.White;
            this.button_export.Location = new System.Drawing.Point(459, 655);
            this.button_export.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(215, 50);
            this.button_export.TabIndex = 31;
            this.button_export.Text = "Exportar a Excel";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(972, 521);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 22);
            this.label1.TabIndex = 32;
            this.label1.Text = "Tiempo promedio (min):";
            // 
            // label_cant
            // 
            this.label_cant.AutoSize = true;
            this.label_cant.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cant.Location = new System.Drawing.Point(1270, 562);
            this.label_cant.Name = "label_cant";
            this.label_cant.Size = new System.Drawing.Size(0, 22);
            this.label_cant.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(972, 562);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 22);
            this.label3.TabIndex = 34;
            this.label3.Text = "Cantidad producida promedio (u):";
            // 
            // label_rota
            // 
            this.label_rota.AutoSize = true;
            this.label_rota.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rota.Location = new System.Drawing.Point(1218, 606);
            this.label_rota.Name = "label_rota";
            this.label_rota.Size = new System.Drawing.Size(0, 22);
            this.label_rota.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(972, 606);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 22);
            this.label4.TabIndex = 36;
            this.label4.Text = "Cantidad rota promedio (u):";
            // 
            // button_pdf
            // 
            this.button_pdf.BackColor = System.Drawing.Color.SteelBlue;
            this.button_pdf.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pdf.ForeColor = System.Drawing.Color.White;
            this.button_pdf.Location = new System.Drawing.Point(708, 655);
            this.button_pdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_pdf.Name = "button_pdf";
            this.button_pdf.Size = new System.Drawing.Size(198, 50);
            this.button_pdf.TabIndex = 38;
            this.button_pdf.Text = "Exportar a PDF";
            this.button_pdf.UseVisualStyleBackColor = false;
            this.button_pdf.Click += new System.EventHandler(this.button_pdf_Click);
            // 
            // PerformanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1384, 716);
            this.Controls.Add(this.button_pdf);
            this.Controls.Add(this.label_rota);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_cant);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_tprom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.dataGridView_performance);
            this.Controls.Add(this.label_today);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PerformanceReport";
            this.Text = "Reporte de Rendimiento";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_performance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_today;
        private System.Windows.Forms.DataGridView dataGridView_performance;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label_tprom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_cant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_rota;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_pdf;
    }
}