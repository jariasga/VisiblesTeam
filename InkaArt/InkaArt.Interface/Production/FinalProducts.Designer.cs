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
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.productDetails = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_finalProductList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_finalProductList
            // 
            this.dataGridView_finalProductList.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_finalProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_finalProductList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.PrecioLocal,
            this.PrecioExportacion,
            this.Stock,
            this.Seleccionar});
            this.dataGridView_finalProductList.Location = new System.Drawing.Point(34, 57);
            this.dataGridView_finalProductList.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_finalProductList.Name = "dataGridView_finalProductList";
            this.dataGridView_finalProductList.Size = new System.Drawing.Size(644, 242);
            this.dataGridView_finalProductList.TabIndex = 0;
            this.dataGridView_finalProductList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // PrecioLocal
            // 
            this.PrecioLocal.HeaderText = "Precio Local";
            this.PrecioLocal.Name = "PrecioLocal";
            // 
            // PrecioExportacion
            // 
            this.PrecioExportacion.HeaderText = "Precio Exportación";
            this.PrecioExportacion.Name = "PrecioExportacion";
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // productDetails
            // 
            this.productDetails.BackColor = System.Drawing.Color.SteelBlue;
            this.productDetails.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productDetails.ForeColor = System.Drawing.Color.White;
            this.productDetails.Location = new System.Drawing.Point(178, 325);
            this.productDetails.Name = "productDetails";
            this.productDetails.Size = new System.Drawing.Size(103, 42);
            this.productDetails.TabIndex = 19;
            this.productDetails.Text = "Ver Detalles";
            this.productDetails.UseVisualStyleBackColor = false;
            this.productDetails.Click += new System.EventHandler(this.productDetail_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SteelBlue;
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(317, 325);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 42);
            this.button3.TabIndex = 20;
            this.button3.Text = "Ver Receta";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.productRecipe_Click);
            // 
            // FinalProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(716, 391);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.productDetails);
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
        private System.Windows.Forms.Button productDetails;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioExportacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
    }
}