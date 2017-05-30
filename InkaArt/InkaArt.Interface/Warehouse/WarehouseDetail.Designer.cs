namespace InkaArt.Interface.Warehouse
{
    partial class WarehouseDetail
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
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_idWarehouse = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockVirtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.borrar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_nameRawMaterial = new System.Windows.Forms.TextBox();
            this.textBox_idRawMaterial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_address
            // 
            this.textBox_address.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_address.Location = new System.Drawing.Point(17, 262);
            this.textBox_address.Multiline = true;
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(214, 110);
            this.textBox_address.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 23);
            this.label4.TabIndex = 24;
            this.label4.Text = "Dirección";
            // 
            // textBox_description
            // 
            this.textBox_description.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_description.Location = new System.Drawing.Point(17, 152);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.Size = new System.Drawing.Size(214, 74);
            this.textBox_description.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "Descripción";
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(17, 98);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(214, 29);
            this.textBox_name.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nombre";
            // 
            // textBox_idWarehouse
            // 
            this.textBox_idWarehouse.Enabled = false;
            this.textBox_idWarehouse.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_idWarehouse.Location = new System.Drawing.Point(17, 42);
            this.textBox_idWarehouse.Name = "textBox_idWarehouse";
            this.textBox_idWarehouse.ReadOnly = true;
            this.textBox_idWarehouse.Size = new System.Drawing.Size(214, 29);
            this.textBox_idWarehouse.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Id";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(17, 386);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(107, 42);
            this.buttonSave.TabIndex = 26;
            this.buttonSave.Text = "🖫 Guardar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.BackColor = System.Drawing.Color.Gray;
            this.buttonReturn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReturn.ForeColor = System.Drawing.Color.White;
            this.buttonReturn.Location = new System.Drawing.Point(127, 386);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(104, 42);
            this.buttonReturn.TabIndex = 47;
            this.buttonReturn.Text = "⟲ Regresar";
            this.buttonReturn.UseVisualStyleBackColor = false;
            this.buttonReturn.Click += new System.EventHandler(this.button_return_click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.nombre,
            this.stockActual,
            this.stockVirtual,
            this.stockMinimo,
            this.stockMaximo,
            this.estado,
            this.borrar});
            this.dataGridView1.Location = new System.Drawing.Point(6, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(730, 259);
            this.dataGridView1.TabIndex = 48;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 75;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.Width = 150;
            // 
            // stockActual
            // 
            this.stockActual.HeaderText = "Stock Actual";
            this.stockActual.Name = "stockActual";
            this.stockActual.Width = 80;
            // 
            // stockVirtual
            // 
            this.stockVirtual.HeaderText = "Stock Virtual";
            this.stockVirtual.Name = "stockVirtual";
            this.stockVirtual.Width = 80;
            // 
            // stockMinimo
            // 
            this.stockMinimo.HeaderText = "Stock Mínimo";
            this.stockMinimo.Name = "stockMinimo";
            this.stockMinimo.Width = 80;
            // 
            // stockMaximo
            // 
            this.stockMaximo.HeaderText = "Stock Máximo";
            this.stockMaximo.Name = "stockMaximo";
            this.stockMaximo.Width = 80;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Items.AddRange(new object[] {
            "Activo",
            "Eliminado"});
            this.estado.Name = "estado";
            this.estado.Width = 85;
            // 
            // borrar
            // 
            this.borrar.HeaderText = "Borrar";
            this.borrar.Name = "borrar";
            this.borrar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.borrar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.borrar.Width = 55;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.comboBox_status);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_nameRawMaterial);
            this.groupBox1.Controls.Add(this.textBox_idRawMaterial);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(249, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 422);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de materias primas";
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAdd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(235, 369);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(142, 39);
            this.buttonAdd.TabIndex = 54;
            this.buttonAdd.Text = "＋ Agregar";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(398, 369);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(151, 39);
            this.buttonDelete.TabIndex = 53;
            this.buttonDelete.Text = "🗑 Eliminar";
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Gray;
            this.buttonSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Location = new System.Drawing.Point(631, 34);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(88, 39);
            this.buttonSearch.TabIndex = 52;
            this.buttonSearch.Text = "🔎 Buscar";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // comboBox_status
            // 
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Items.AddRange(new object[] {
            "Activo",
            "Eliminado"});
            this.comboBox_status.Location = new System.Drawing.Point(478, 47);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(128, 29);
            this.comboBox_status.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(475, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 50;
            this.label7.Text = "Estado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(185, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 23);
            this.label6.TabIndex = 50;
            this.label6.Text = "Nombre Materia Prima";
            // 
            // textBox_nameRawMaterial
            // 
            this.textBox_nameRawMaterial.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nameRawMaterial.Location = new System.Drawing.Point(188, 49);
            this.textBox_nameRawMaterial.Name = "textBox_nameRawMaterial";
            this.textBox_nameRawMaterial.Size = new System.Drawing.Size(266, 29);
            this.textBox_nameRawMaterial.TabIndex = 50;
            // 
            // textBox_idRawMaterial
            // 
            this.textBox_idRawMaterial.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_idRawMaterial.Location = new System.Drawing.Point(26, 49);
            this.textBox_idRawMaterial.Name = "textBox_idRawMaterial";
            this.textBox_idRawMaterial.Size = new System.Drawing.Size(138, 29);
            this.textBox_idRawMaterial.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 23);
            this.label5.TabIndex = 50;
            this.label5.Text = "Id Materia Prima";
            // 
            // WarehouseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1003, 455);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_idWarehouse);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WarehouseDetail";
            this.Text = "Detalle de almacén";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_idWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockVirtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMaximo;
        private System.Windows.Forms.DataGridViewComboBoxColumn estado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn borrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_nameRawMaterial;
        private System.Windows.Forms.TextBox textBox_idRawMaterial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
    }
}