namespace InkaArt.Interface.Warehouse
{
    partial class KardexReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_export = new System.Windows.Forms.Button();
            this.dataGridView_movements = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombAlm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_todaydate = new System.Windows.Forms.Label();
            this.button_pdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_movements)).BeginInit();
            this.SuspendLayout();
            // 
            // button_export
            // 
            this.button_export.BackColor = System.Drawing.Color.SteelBlue;
            this.button_export.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_export.ForeColor = System.Drawing.Color.White;
            this.button_export.Location = new System.Drawing.Point(466, 535);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(249, 51);
            this.button_export.TabIndex = 18;
            this.button_export.Text = "Exportar a Excel";
            this.button_export.UseVisualStyleBackColor = false;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // dataGridView_movements
            // 
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_movements.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView_movements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_movements.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_movements.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_movements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridView_movements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_movements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.idMov,
            this.TipoMov,
            this.Reason,
            this.nombAlm,
            this.Item,
            this.cant});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_movements.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridView_movements.Location = new System.Drawing.Point(50, 96);
            this.dataGridView_movements.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.dataGridView_movements.Name = "dataGridView_movements";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_movements.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_movements.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView_movements.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_movements.Size = new System.Drawing.Size(1315, 372);
            this.dataGridView_movements.TabIndex = 25;
            // 
            // Producto
            // 
            this.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Producto.FillWeight = 568.528F;
            this.Producto.HeaderText = "Fecha";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Producto.Width = 200;
            // 
            // idMov
            // 
            this.idMov.FillWeight = 21.912F;
            this.idMov.HeaderText = "ID Movimiento";
            this.idMov.Name = "idMov";
            // 
            // TipoMov
            // 
            this.TipoMov.FillWeight = 21.912F;
            this.TipoMov.HeaderText = "Tipo de Movimiento";
            this.TipoMov.Name = "TipoMov";
            // 
            // Reason
            // 
            this.Reason.FillWeight = 21.912F;
            this.Reason.HeaderText = "Razón";
            this.Reason.Name = "Reason";
            // 
            // nombAlm
            // 
            this.nombAlm.FillWeight = 21.912F;
            this.nombAlm.HeaderText = "Almacén";
            this.nombAlm.Name = "nombAlm";
            // 
            // Item
            // 
            this.Item.FillWeight = 21.912F;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            // 
            // cant
            // 
            this.cant.FillWeight = 21.912F;
            this.cant.HeaderText = "Cantidad";
            this.cant.Name = "cant";
            // 
            // label_todaydate
            // 
            this.label_todaydate.AutoSize = true;
            this.label_todaydate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_todaydate.Location = new System.Drawing.Point(1299, 9);
            this.label_todaydate.Name = "label_todaydate";
            this.label_todaydate.Size = new System.Drawing.Size(0, 23);
            this.label_todaydate.TabIndex = 26;
            // 
            // button_pdf
            // 
            this.button_pdf.BackColor = System.Drawing.Color.SteelBlue;
            this.button_pdf.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pdf.ForeColor = System.Drawing.Color.White;
            this.button_pdf.Location = new System.Drawing.Point(741, 535);
            this.button_pdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_pdf.Name = "button_pdf";
            this.button_pdf.Size = new System.Drawing.Size(249, 50);
            this.button_pdf.TabIndex = 40;
            this.button_pdf.Text = "Exportar a PDF";
            this.button_pdf.UseVisualStyleBackColor = false;
            this.button_pdf.Click += new System.EventHandler(this.button_pdf_Click);
            // 
            // KardexReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1430, 615);
            this.Controls.Add(this.button_pdf);
            this.Controls.Add(this.label_todaydate);
            this.Controls.Add(this.dataGridView_movements);
            this.Controls.Add(this.button_export);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KardexReport";
            this.Text = "Reporte Kardex";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_movements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.DataGridView dataGridView_movements;
        public System.Windows.Forms.Label label_todaydate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombAlm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn cant;
        private System.Windows.Forms.Button button_pdf;
    }
}