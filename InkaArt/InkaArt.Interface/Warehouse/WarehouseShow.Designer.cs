namespace InkaArt.Interface.Warehouse
{
    partial class WarehouseShow
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
            this.button_edit = new System.Windows.Forms.Button();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_rawMaterial = new System.Windows.Forms.TabPage();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonAdd_RawMaterial = new System.Windows.Forms.Button();
            this.dataGridView_RawMaterial = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockVirtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdRMW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDelete_RawMaterial = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_RM = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage_Products = new System.Windows.Forms.TabPage();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Producto = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonAdd_Product = new System.Windows.Forms.Button();
            this.dataGridView_Product = new System.Windows.Forms.DataGridView();
            this.buttonDelete_Product = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idPW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage_rawMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RawMaterial)).BeginInit();
            this.tabPage_Products.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Product)).BeginInit();
            this.SuspendLayout();
            // 
            // button_edit
            // 
            this.button_edit.BackColor = System.Drawing.Color.SteelBlue;
            this.button_edit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_edit.ForeColor = System.Drawing.Color.White;
            this.button_edit.Location = new System.Drawing.Point(78, 319);
            this.button_edit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(95, 34);
            this.button_edit.TabIndex = 56;
            this.button_edit.Text = "🖉 Editar";
            this.button_edit.UseVisualStyleBackColor = false;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // textBox_address
            // 
            this.textBox_address.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox_address.Enabled = false;
            this.textBox_address.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_address.Location = new System.Drawing.Point(28, 180);
            this.textBox_address.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_address.Multiline = true;
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(197, 127);
            this.textBox_address.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 54;
            this.label4.Text = "Dirección";
            // 
            // textBox_description
            // 
            this.textBox_description.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox_description.Enabled = false;
            this.textBox_description.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_description.Location = new System.Drawing.Point(28, 89);
            this.textBox_description.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.Size = new System.Drawing.Size(197, 61);
            this.textBox_description.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 52;
            this.label3.Text = "Descripción";
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox_name.Enabled = false;
            this.textBox_name.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(28, 36);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(197, 24);
            this.textBox_name.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 50;
            this.label2.Text = "Nombre";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_rawMaterial);
            this.tabControl1.Controls.Add(this.tabPage_Products);
            this.tabControl1.Location = new System.Drawing.Point(249, 20);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(630, 365);
            this.tabControl1.TabIndex = 57;
            // 
            // tabPage_rawMaterial
            // 
            this.tabPage_rawMaterial.Controls.Add(this.numericUpDown2);
            this.tabPage_rawMaterial.Controls.Add(this.numericUpDown1);
            this.tabPage_rawMaterial.Controls.Add(this.buttonAdd_RawMaterial);
            this.tabPage_rawMaterial.Controls.Add(this.dataGridView_RawMaterial);
            this.tabPage_rawMaterial.Controls.Add(this.buttonDelete_RawMaterial);
            this.tabPage_rawMaterial.Controls.Add(this.label5);
            this.tabPage_rawMaterial.Controls.Add(this.comboBox_RM);
            this.tabPage_rawMaterial.Controls.Add(this.label7);
            this.tabPage_rawMaterial.Controls.Add(this.label6);
            this.tabPage_rawMaterial.Location = new System.Drawing.Point(4, 22);
            this.tabPage_rawMaterial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage_rawMaterial.Name = "tabPage_rawMaterial";
            this.tabPage_rawMaterial.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage_rawMaterial.Size = new System.Drawing.Size(622, 339);
            this.tabPage_rawMaterial.TabIndex = 0;
            this.tabPage_rawMaterial.Text = "Materias Primas";
            this.tabPage_rawMaterial.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(320, 37);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown2.TabIndex = 65;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(175, 40);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown1.TabIndex = 58;
            // 
            // buttonAdd_RawMaterial
            // 
            this.buttonAdd_RawMaterial.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAdd_RawMaterial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd_RawMaterial.ForeColor = System.Drawing.Color.White;
            this.buttonAdd_RawMaterial.Location = new System.Drawing.Point(484, 28);
            this.buttonAdd_RawMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd_RawMaterial.Name = "buttonAdd_RawMaterial";
            this.buttonAdd_RawMaterial.Size = new System.Drawing.Size(106, 32);
            this.buttonAdd_RawMaterial.TabIndex = 64;
            this.buttonAdd_RawMaterial.Text = "＋ Agregar";
            this.buttonAdd_RawMaterial.UseVisualStyleBackColor = false;
            this.buttonAdd_RawMaterial.Click += new System.EventHandler(this.buttonAdd_RawMaterial_Click);
            // 
            // dataGridView_RawMaterial
            // 
            this.dataGridView_RawMaterial.AllowUserToAddRows = false;
            this.dataGridView_RawMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_RawMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RawMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.nombre,
            this.stockActual,
            this.stockVirtual,
            this.stockMinimo,
            this.stockMaximo,
            this.borrar,
            this.IdRMW});
            this.dataGridView_RawMaterial.Location = new System.Drawing.Point(22, 76);
            this.dataGridView_RawMaterial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_RawMaterial.Name = "dataGridView_RawMaterial";
            this.dataGridView_RawMaterial.Size = new System.Drawing.Size(584, 210);
            this.dataGridView_RawMaterial.TabIndex = 55;
            this.dataGridView_RawMaterial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RawMaterial_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // stockActual
            // 
            this.stockActual.HeaderText = "Stock Actual";
            this.stockActual.Name = "stockActual";
            // 
            // stockVirtual
            // 
            this.stockVirtual.HeaderText = "Stock Virtual";
            this.stockVirtual.Name = "stockVirtual";
            // 
            // stockMinimo
            // 
            this.stockMinimo.HeaderText = "Stock Mínimo";
            this.stockMinimo.Name = "stockMinimo";
            // 
            // stockMaximo
            // 
            this.stockMaximo.HeaderText = "Stock Máximo";
            this.stockMaximo.Name = "stockMaximo";
            // 
            // borrar
            // 
            this.borrar.HeaderText = "Borrar";
            this.borrar.Name = "borrar";
            this.borrar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.borrar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IdRMW
            // 
            this.IdRMW.HeaderText = "IdRMW";
            this.IdRMW.Name = "IdRMW";
            this.IdRMW.Visible = false;
            // 
            // buttonDelete_RawMaterial
            // 
            this.buttonDelete_RawMaterial.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDelete_RawMaterial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete_RawMaterial.ForeColor = System.Drawing.Color.White;
            this.buttonDelete_RawMaterial.Location = new System.Drawing.Point(264, 305);
            this.buttonDelete_RawMaterial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDelete_RawMaterial.Name = "buttonDelete_RawMaterial";
            this.buttonDelete_RawMaterial.Size = new System.Drawing.Size(106, 32);
            this.buttonDelete_RawMaterial.TabIndex = 63;
            this.buttonDelete_RawMaterial.Text = "🗑 Eliminar";
            this.buttonDelete_RawMaterial.UseVisualStyleBackColor = false;
            this.buttonDelete_RawMaterial.Click += new System.EventHandler(this.buttonDelete_RawMaterial_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 60;
            this.label5.Text = "Materia Prima";
            // 
            // comboBox_RM
            // 
            this.comboBox_RM.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.comboBox_RM.Enabled = false;
            this.comboBox_RM.FormattingEnabled = true;
            this.comboBox_RM.Location = new System.Drawing.Point(22, 39);
            this.comboBox_RM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_RM.Name = "comboBox_RM";
            this.comboBox_RM.Size = new System.Drawing.Size(128, 21);
            this.comboBox_RM.TabIndex = 61;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(316, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 18);
            this.label7.TabIndex = 56;
            this.label7.Text = "Stock Máximo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(172, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 18);
            this.label6.TabIndex = 57;
            this.label6.Text = "Stock Mínimo";
            // 
            // tabPage_Products
            // 
            this.tabPage_Products.Controls.Add(this.numericUpDown3);
            this.tabPage_Products.Controls.Add(this.numericUpDown4);
            this.tabPage_Products.Controls.Add(this.label1);
            this.tabPage_Products.Controls.Add(this.comboBox_Producto);
            this.tabPage_Products.Controls.Add(this.label8);
            this.tabPage_Products.Controls.Add(this.label9);
            this.tabPage_Products.Controls.Add(this.buttonAdd_Product);
            this.tabPage_Products.Controls.Add(this.dataGridView_Product);
            this.tabPage_Products.Controls.Add(this.buttonDelete_Product);
            this.tabPage_Products.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Products.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage_Products.Name = "tabPage_Products";
            this.tabPage_Products.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage_Products.Size = new System.Drawing.Size(622, 339);
            this.tabPage_Products.TabIndex = 1;
            this.tabPage_Products.Text = "Productos";
            this.tabPage_Products.UseVisualStyleBackColor = true;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(328, 42);
            this.numericUpDown3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown3.TabIndex = 80;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(183, 45);
            this.numericUpDown4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown4.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 78;
            this.label1.Text = "Producto";
            // 
            // comboBox_Producto
            // 
            this.comboBox_Producto.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.comboBox_Producto.Enabled = false;
            this.comboBox_Producto.FormattingEnabled = true;
            this.comboBox_Producto.Location = new System.Drawing.Point(31, 44);
            this.comboBox_Producto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Producto.Name = "comboBox_Producto";
            this.comboBox_Producto.Size = new System.Drawing.Size(128, 21);
            this.comboBox_Producto.TabIndex = 79;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(325, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 18);
            this.label8.TabIndex = 75;
            this.label8.Text = "Stock Máximo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(180, 20);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 18);
            this.label9.TabIndex = 76;
            this.label9.Text = "Stock Mínimo";
            // 
            // buttonAdd_Product
            // 
            this.buttonAdd_Product.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAdd_Product.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd_Product.ForeColor = System.Drawing.Color.White;
            this.buttonAdd_Product.Location = new System.Drawing.Point(482, 31);
            this.buttonAdd_Product.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd_Product.Name = "buttonAdd_Product";
            this.buttonAdd_Product.Size = new System.Drawing.Size(106, 32);
            this.buttonAdd_Product.TabIndex = 74;
            this.buttonAdd_Product.Text = "＋ Agregar";
            this.buttonAdd_Product.UseVisualStyleBackColor = false;
            this.buttonAdd_Product.Click += new System.EventHandler(this.buttonAdd_Product_Click);
            // 
            // dataGridView_Product
            // 
            this.dataGridView_Product.AllowUserToAddRows = false;
            this.dataGridView_Product.AllowUserToDeleteRows = false;
            this.dataGridView_Product.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Product.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewCheckBoxColumn1,
            this.idPW});
            this.dataGridView_Product.Location = new System.Drawing.Point(22, 76);
            this.dataGridView_Product.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_Product.Name = "dataGridView_Product";
            this.dataGridView_Product.Size = new System.Drawing.Size(584, 210);
            this.dataGridView_Product.TabIndex = 65;
            // 
            // buttonDelete_Product
            // 
            this.buttonDelete_Product.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDelete_Product.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete_Product.ForeColor = System.Drawing.Color.White;
            this.buttonDelete_Product.Location = new System.Drawing.Point(280, 305);
            this.buttonDelete_Product.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDelete_Product.Name = "buttonDelete_Product";
            this.buttonDelete_Product.Size = new System.Drawing.Size(106, 32);
            this.buttonDelete_Product.TabIndex = 73;
            this.buttonDelete_Product.Text = "🗑 Eliminar";
            this.buttonDelete_Product.UseVisualStyleBackColor = false;
            this.buttonDelete_Product.Click += new System.EventHandler(this.buttonDelete_Product_Click);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Stock Actual";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Stock Virtual";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Stock Mínimo";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Stock Máximo";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Borrar";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // idPW
            // 
            this.idPW.HeaderText = "idPW";
            this.idPW.Name = "idPW";
            this.idPW.ReadOnly = true;
            this.idPW.Visible = false;
            // 
            // WarehouseShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(914, 401);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "WarehouseShow";
            this.Text = "WarehouseShow";
            this.Load += new System.EventHandler(this.WarehouseShow_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_rawMaterial.ResumeLayout(false);
            this.tabPage_rawMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RawMaterial)).EndInit();
            this.tabPage_Products.ResumeLayout(false);
            this.tabPage_Products.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Product)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_rawMaterial;
        private System.Windows.Forms.Button buttonAdd_RawMaterial;
        private System.Windows.Forms.DataGridView dataGridView_RawMaterial;
        private System.Windows.Forms.Button buttonDelete_RawMaterial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_RM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage_Products;
        private System.Windows.Forms.Button buttonAdd_Product;
        private System.Windows.Forms.DataGridView dataGridView_Product;
        private System.Windows.Forms.Button buttonDelete_Product;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Producto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockVirtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMaximo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn borrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRMW;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPW;
    }
}