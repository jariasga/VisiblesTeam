namespace InkaArt.Interface.Production
{
    partial class Jobs
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
            this.dataGridView_process = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioExportacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalles = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button_refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_process)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_process
            // 
            this.dataGridView_process.AllowUserToAddRows = false;
            this.dataGridView_process.AllowUserToDeleteRows = false;
            this.dataGridView_process.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_process.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_process.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_process.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.PrecioLocal,
            this.PrecioExportacion,
            this.Detalles});
            this.dataGridView_process.Location = new System.Drawing.Point(26, 23);
            this.dataGridView_process.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_process.Name = "dataGridView_process";
            this.dataGridView_process.Size = new System.Drawing.Size(444, 246);
            this.dataGridView_process.TabIndex = 7;
            this.dataGridView_process.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_process_CellContentClick);
            this.dataGridView_process.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 80;
            // 
            // PrecioLocal
            // 
            this.PrecioLocal.HeaderText = "Proceso";
            this.PrecioLocal.Name = "PrecioLocal";
            this.PrecioLocal.ReadOnly = true;
            // 
            // PrecioExportacion
            // 
            this.PrecioExportacion.HeaderText = "Cantidad de puestos";
            this.PrecioExportacion.Name = "PrecioExportacion";
            this.PrecioExportacion.ReadOnly = true;
            this.PrecioExportacion.Width = 120;
            // 
            // Detalles
            // 
            this.Detalles.HeaderText = "Detalles";
            this.Detalles.Name = "Detalles";
            this.Detalles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Detalles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // button_refresh
            // 
            this.button_refresh.BackColor = System.Drawing.Color.SteelBlue;
            this.button_refresh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_refresh.ForeColor = System.Drawing.Color.White;
            this.button_refresh.Location = new System.Drawing.Point(198, 276);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(103, 42);
            this.button_refresh.TabIndex = 21;
            this.button_refresh.Text = "Actualizar";
            this.button_refresh.UseVisualStyleBackColor = false;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // Jobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(497, 327);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.dataGridView_process);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Jobs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesos de Producción";
            this.Load += new System.EventHandler(this.Jobs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_process)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_process;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioExportacion;
        private System.Windows.Forms.DataGridViewButtonColumn Detalles;
    }
}