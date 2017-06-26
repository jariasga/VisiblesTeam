namespace InkaArt.Interface.Production
{
    partial class FinalProducts
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
            this.dataGridView_finalProductList = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioExportacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalles = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Receta = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button_batch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_finalProductList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_finalProductList
            // 
            this.dataGridView_finalProductList.AllowUserToAddRows = false;
            this.dataGridView_finalProductList.AllowUserToDeleteRows = false;
            this.dataGridView_finalProductList.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_finalProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_finalProductList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.PrecioLocal,
            this.PrecioExportacion,
            this.PrecioBase,
            this.Stock,
            this.Detalles,
            this.Receta});
            this.dataGridView_finalProductList.Location = new System.Drawing.Point(33, 36);
            this.dataGridView_finalProductList.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_finalProductList.Name = "dataGridView_finalProductList";
            this.dataGridView_finalProductList.Size = new System.Drawing.Size(836, 242);
            this.dataGridView_finalProductList.TabIndex = 0;
            this.dataGridView_finalProductList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // PrecioLocal
            // 
            this.PrecioLocal.HeaderText = "Precio Local";
            this.PrecioLocal.Name = "PrecioLocal";
            this.PrecioLocal.ReadOnly = true;
            // 
            // PrecioExportacion
            // 
            this.PrecioExportacion.HeaderText = "Precio Exportación";
            this.PrecioExportacion.Name = "PrecioExportacion";
            this.PrecioExportacion.ReadOnly = true;
            // 
            // PrecioBase
            // 
            this.PrecioBase.HeaderText = "Precio Base";
            this.PrecioBase.Name = "PrecioBase";
            this.PrecioBase.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // Detalles
            // 
            this.Detalles.HeaderText = "Detalles";
            this.Detalles.Name = "Detalles";
            this.Detalles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Receta
            // 
            this.Receta.HeaderText = "Receta";
            this.Receta.Name = "Receta";
            // 
            // button_batch
            // 
            this.button_batch.BackColor = System.Drawing.Color.SteelBlue;
            this.button_batch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_batch.ForeColor = System.Drawing.Color.White;
            this.button_batch.Location = new System.Drawing.Point(382, 285);
            this.button_batch.Name = "button_batch";
            this.button_batch.Size = new System.Drawing.Size(147, 42);
            this.button_batch.TabIndex = 22;
            this.button_batch.Text = "Carga Productos";
            this.button_batch.UseVisualStyleBackColor = false;
            this.button_batch.Click += new System.EventHandler(this.button_batch_Click);
            // 
            // FinalProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(905, 335);
            this.Controls.Add(this.button_batch);
            this.Controls.Add(this.dataGridView_finalProductList);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FinalProducts";
            this.Text = "Lista de Productos Finales";
            this.Load += new System.EventHandler(this.FinalProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_finalProductList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_finalProductList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioExportacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewButtonColumn Detalles;
        private System.Windows.Forms.DataGridViewButtonColumn Receta;
        private System.Windows.Forms.Button button_batch;
    }
}