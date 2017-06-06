namespace InkaArt.Interface.Warehouse
{
    partial class AddRawMaterialWarehouse
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
            this.dataGridView_rawMaterialsList = new System.Windows.Forms.DataGridView();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agregar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rawMaterialsList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_rawMaterialsList
            // 
            this.dataGridView_rawMaterialsList.AllowUserToAddRows = false;
            this.dataGridView_rawMaterialsList.AllowUserToDeleteRows = false;
            this.dataGridView_rawMaterialsList.AllowUserToResizeRows = false;
            this.dataGridView_rawMaterialsList.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_rawMaterialsList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_rawMaterialsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_rawMaterialsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nombre,
            this.Descripción,
            this.Agregar});
            this.dataGridView_rawMaterialsList.Location = new System.Drawing.Point(24, 56);
            this.dataGridView_rawMaterialsList.MultiSelect = false;
            this.dataGridView_rawMaterialsList.Name = "dataGridView_rawMaterialsList";
            this.dataGridView_rawMaterialsList.Size = new System.Drawing.Size(533, 201);
            this.dataGridView_rawMaterialsList.TabIndex = 4;
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonCreate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.ForeColor = System.Drawing.Color.White;
            this.buttonCreate.Location = new System.Drawing.Point(219, 282);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(124, 39);
            this.buttonCreate.TabIndex = 46;
            this.buttonCreate.Text = "＋ Agregar";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Descripción
            // 
            this.Descripción.HeaderText = "Descripción";
            this.Descripción.Name = "Descripción";
            // 
            // Agregar
            // 
            this.Agregar.HeaderText = "Agregar";
            this.Agregar.Name = "Agregar";
            // 
            // AddRawMaterialWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(590, 343);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.dataGridView_rawMaterialsList);
            this.Name = "AddRawMaterialWarehouse";
            this.Text = "Agregar Materia Prima a Almacén";
            this.Load += new System.EventHandler(this.AddRawMaterialWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rawMaterialsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_rawMaterialsList;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Agregar;
    }
}