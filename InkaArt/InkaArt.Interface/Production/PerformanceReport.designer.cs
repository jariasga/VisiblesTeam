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
            this.label_today = new System.Windows.Forms.Label();
            this.dataGridView_performance = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_export = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_nameWorker = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_performance)).BeginInit();
            this.SuspendLayout();
            // 
            // label_today
            // 
            this.label_today.AutoSize = true;
            this.label_today.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_today.Location = new System.Drawing.Point(557, 7);
            this.label_today.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_today.Name = "label_today";
            this.label_today.Size = new System.Drawing.Size(0, 18);
            this.label_today.TabIndex = 29;
            // 
            // dataGridView_performance
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_performance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_performance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_performance.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_performance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_performance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_performance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_performance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Cantidad,
            this.delete,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView_performance.Location = new System.Drawing.Point(22, 72);
            this.dataGridView_performance.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.dataGridView_performance.Name = "dataGridView_performance";
            this.dataGridView_performance.Size = new System.Drawing.Size(714, 223);
            this.dataGridView_performance.TabIndex = 30;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
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
            this.Column3.HeaderText = "Tiempo";
            this.Column3.Name = "Column3";
            // 
            // button_export
            // 
            this.button_export.BackColor = System.Drawing.Color.SteelBlue;
            this.button_export.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_export.ForeColor = System.Drawing.Color.White;
            this.button_export.Location = new System.Drawing.Point(319, 311);
            this.button_export.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(116, 41);
            this.button_export.TabIndex = 31;
            this.button_export.Text = "Exportar";
            this.button_export.UseVisualStyleBackColor = false;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 32;
            this.label1.Text = "Trabajador:";
            // 
            // label_nameWorker
            // 
            this.label_nameWorker.AutoSize = true;
            this.label_nameWorker.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nameWorker.Location = new System.Drawing.Point(107, 27);
            this.label_nameWorker.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_nameWorker.Name = "label_nameWorker";
            this.label_nameWorker.Size = new System.Drawing.Size(0, 18);
            this.label_nameWorker.TabIndex = 33;
            // 
            // PerformanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(758, 376);
            this.Controls.Add(this.label_nameWorker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.dataGridView_performance);
            this.Controls.Add(this.label_today);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_nameWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}