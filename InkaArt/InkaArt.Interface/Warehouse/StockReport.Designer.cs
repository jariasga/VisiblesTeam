namespace InkaArt.Interface.Warehouse
{
    partial class StockReport
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
            this.dataGrid_stocks = new System.Windows.Forms.DataGridView();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_todayDate = new System.Windows.Forms.Label();
            this.button_export = new System.Windows.Forms.Button();
            this.button_pdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_stocks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid_stocks
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid_stocks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid_stocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid_stocks.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGrid_stocks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid_stocks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid_stocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_stocks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo,
            this.Producto,
            this.cost,
            this.warehouse,
            this.Cantidad,
            this.delete,
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid_stocks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGrid_stocks.Location = new System.Drawing.Point(28, 84);
            this.dataGrid_stocks.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.dataGrid_stocks.Name = "dataGrid_stocks";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid_stocks.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid_stocks.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGrid_stocks.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid_stocks.Size = new System.Drawing.Size(1269, 404);
            this.dataGrid_stocks.TabIndex = 25;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Código";
            this.Producto.Name = "Producto";
            // 
            // cost
            // 
            this.cost.HeaderText = "Descripción";
            this.cost.Name = "cost";
            // 
            // warehouse
            // 
            this.warehouse.HeaderText = "Almacén";
            this.warehouse.Name = "warehouse";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad física";
            this.Cantidad.Name = "Cantidad";
            // 
            // delete
            // 
            this.delete.HeaderText = "Cantidad lógica";
            this.delete.Name = "delete";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "U.M.";
            this.Column1.Name = "Column1";
            // 
            // label_todayDate
            // 
            this.label_todayDate.AutoSize = true;
            this.label_todayDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_todayDate.Location = new System.Drawing.Point(920, 9);
            this.label_todayDate.Name = "label_todayDate";
            this.label_todayDate.Size = new System.Drawing.Size(0, 23);
            this.label_todayDate.TabIndex = 28;
            // 
            // button_export
            // 
            this.button_export.BackColor = System.Drawing.Color.SteelBlue;
            this.button_export.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_export.ForeColor = System.Drawing.Color.White;
            this.button_export.Location = new System.Drawing.Point(437, 521);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(234, 51);
            this.button_export.TabIndex = 29;
            this.button_export.Text = "Exportar a Excel";
            this.button_export.UseVisualStyleBackColor = false;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // button_pdf
            // 
            this.button_pdf.BackColor = System.Drawing.Color.SteelBlue;
            this.button_pdf.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pdf.ForeColor = System.Drawing.Color.White;
            this.button_pdf.Location = new System.Drawing.Point(702, 522);
            this.button_pdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_pdf.Name = "button_pdf";
            this.button_pdf.Size = new System.Drawing.Size(198, 50);
            this.button_pdf.TabIndex = 40;
            this.button_pdf.Text = "Exportar a PDF";
            this.button_pdf.UseVisualStyleBackColor = false;
            this.button_pdf.Click += new System.EventHandler(this.button_pdf_Click);
            // 
            // StockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1349, 583);
            this.Controls.Add(this.button_pdf);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.label_todayDate);
            this.Controls.Add(this.dataGrid_stocks);
            this.Name = "StockReport";
            this.Text = "Reporte de Stocks";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_stocks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid_stocks;
        private System.Windows.Forms.Label label_todayDate;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button button_pdf;
    }
}