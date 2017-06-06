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
            this.button_save = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_rawMaterial = new System.Windows.Forms.TabPage();
            this.buttonAdd_RawMaterial = new System.Windows.Forms.Button();
            this.dataGridView_RawMaterial = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockVirtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.borrar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonDelete_RawMaterial = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSearch_RawMaterial = new System.Windows.Forms.Button();
            this.textBox_idRawMaterial = new System.Windows.Forms.TextBox();
            this.comboBox_statusRM = new System.Windows.Forms.ComboBox();
            this.textBox_nameRawMaterial = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage_Products = new System.Windows.Forms.TabPage();
            this.buttonAdd_Product = new System.Windows.Forms.Button();
            this.dataGridView_Product = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonDelete_Product = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearch_Product = new System.Windows.Forms.Button();
            this.textBox_idProduct = new System.Windows.Forms.TextBox();
            this.comboBox_statusP = new System.Windows.Forms.ComboBox();
            this.textBox_nameProduct = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage_rawMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RawMaterial)).BeginInit();
            this.tabPage_Products.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Product)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_address
            // 
            this.textBox_address.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_address.Location = new System.Drawing.Point(30, 227);
            this.textBox_address.Multiline = true;
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(261, 185);
            this.textBox_address.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 23);
            this.label4.TabIndex = 24;
            this.label4.Text = "Dirección";
            // 
            // textBox_description
            // 
            this.textBox_description.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_description.Location = new System.Drawing.Point(31, 116);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.Size = new System.Drawing.Size(261, 74);
            this.textBox_description.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "Descripción";
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(30, 50);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(261, 29);
            this.textBox_name.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nombre";
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.SteelBlue;
            this.button_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(97, 431);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(127, 42);
            this.button_save.TabIndex = 26;
            this.button_save.Text = "🖫 Guardar";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_rawMaterial);
            this.tabControl1.Controls.Add(this.tabPage_Products);
            this.tabControl1.Location = new System.Drawing.Point(323, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 449);
            this.tabControl1.TabIndex = 50;
            // 
            // tabPage_rawMaterial
            // 
            this.tabPage_rawMaterial.Controls.Add(this.buttonAdd_RawMaterial);
            this.tabPage_rawMaterial.Controls.Add(this.dataGridView_RawMaterial);
            this.tabPage_rawMaterial.Controls.Add(this.buttonDelete_RawMaterial);
            this.tabPage_rawMaterial.Controls.Add(this.label5);
            this.tabPage_rawMaterial.Controls.Add(this.buttonSearch_RawMaterial);
            this.tabPage_rawMaterial.Controls.Add(this.textBox_idRawMaterial);
            this.tabPage_rawMaterial.Controls.Add(this.comboBox_statusRM);
            this.tabPage_rawMaterial.Controls.Add(this.textBox_nameRawMaterial);
            this.tabPage_rawMaterial.Controls.Add(this.label7);
            this.tabPage_rawMaterial.Controls.Add(this.label6);
            this.tabPage_rawMaterial.Location = new System.Drawing.Point(4, 31);
            this.tabPage_rawMaterial.Name = "tabPage_rawMaterial";
            this.tabPage_rawMaterial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_rawMaterial.Size = new System.Drawing.Size(832, 414);
            this.tabPage_rawMaterial.TabIndex = 0;
            this.tabPage_rawMaterial.Text = "Materias Primas";
            this.tabPage_rawMaterial.UseVisualStyleBackColor = true;
            // 
            // buttonAdd_RawMaterial
            // 
            this.buttonAdd_RawMaterial.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAdd_RawMaterial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd_RawMaterial.ForeColor = System.Drawing.Color.White;
            this.buttonAdd_RawMaterial.Location = new System.Drawing.Point(256, 358);
            this.buttonAdd_RawMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd_RawMaterial.Name = "buttonAdd_RawMaterial";
            this.buttonAdd_RawMaterial.Size = new System.Drawing.Size(142, 39);
            this.buttonAdd_RawMaterial.TabIndex = 64;
            this.buttonAdd_RawMaterial.Text = "＋ Agregar";
            this.buttonAdd_RawMaterial.UseVisualStyleBackColor = false;
            this.buttonAdd_RawMaterial.Click += new System.EventHandler(this.buttonAdd_RawMaterial_Click);
            // 
            // dataGridView_RawMaterial
            // 
            this.dataGridView_RawMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_RawMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RawMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.nombre,
            this.stockActual,
            this.stockVirtual,
            this.stockMinimo,
            this.stockMaximo,
            this.estado,
            this.borrar});
            this.dataGridView_RawMaterial.Location = new System.Drawing.Point(30, 94);
            this.dataGridView_RawMaterial.Name = "dataGridView_RawMaterial";
            this.dataGridView_RawMaterial.Size = new System.Drawing.Size(778, 259);
            this.dataGridView_RawMaterial.TabIndex = 55;
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
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Items.AddRange(new object[] {
            "Activo",
            "Eliminado"});
            this.estado.Name = "estado";
            // 
            // borrar
            // 
            this.borrar.HeaderText = "Borrar";
            this.borrar.Name = "borrar";
            this.borrar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.borrar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // buttonDelete_RawMaterial
            // 
            this.buttonDelete_RawMaterial.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDelete_RawMaterial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete_RawMaterial.ForeColor = System.Drawing.Color.White;
            this.buttonDelete_RawMaterial.Location = new System.Drawing.Point(426, 358);
            this.buttonDelete_RawMaterial.Name = "buttonDelete_RawMaterial";
            this.buttonDelete_RawMaterial.Size = new System.Drawing.Size(142, 39);
            this.buttonDelete_RawMaterial.TabIndex = 63;
            this.buttonDelete_RawMaterial.Text = "🗑 Eliminar";
            this.buttonDelete_RawMaterial.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 23);
            this.label5.TabIndex = 60;
            this.label5.Text = "ID";
            // 
            // buttonSearch_RawMaterial
            // 
            this.buttonSearch_RawMaterial.BackColor = System.Drawing.Color.Gray;
            this.buttonSearch_RawMaterial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch_RawMaterial.ForeColor = System.Drawing.Color.White;
            this.buttonSearch_RawMaterial.Location = new System.Drawing.Point(661, 37);
            this.buttonSearch_RawMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearch_RawMaterial.Name = "buttonSearch_RawMaterial";
            this.buttonSearch_RawMaterial.Size = new System.Drawing.Size(122, 39);
            this.buttonSearch_RawMaterial.TabIndex = 62;
            this.buttonSearch_RawMaterial.Text = "🔎 Buscar";
            this.buttonSearch_RawMaterial.UseVisualStyleBackColor = false;
            // 
            // textBox_idRawMaterial
            // 
            this.textBox_idRawMaterial.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_idRawMaterial.Location = new System.Drawing.Point(30, 44);
            this.textBox_idRawMaterial.Name = "textBox_idRawMaterial";
            this.textBox_idRawMaterial.Size = new System.Drawing.Size(154, 29);
            this.textBox_idRawMaterial.TabIndex = 59;
            // 
            // comboBox_statusRM
            // 
            this.comboBox_statusRM.FormattingEnabled = true;
            this.comboBox_statusRM.Items.AddRange(new object[] {
            "Activo",
            "Eliminado"});
            this.comboBox_statusRM.Location = new System.Drawing.Point(483, 44);
            this.comboBox_statusRM.Name = "comboBox_statusRM";
            this.comboBox_statusRM.Size = new System.Drawing.Size(135, 30);
            this.comboBox_statusRM.TabIndex = 61;
            // 
            // textBox_nameRawMaterial
            // 
            this.textBox_nameRawMaterial.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nameRawMaterial.Location = new System.Drawing.Point(193, 44);
            this.textBox_nameRawMaterial.Name = "textBox_nameRawMaterial";
            this.textBox_nameRawMaterial.Size = new System.Drawing.Size(266, 29);
            this.textBox_nameRawMaterial.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(479, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 56;
            this.label7.Text = "Estado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(189, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 23);
            this.label6.TabIndex = 57;
            this.label6.Text = "Nombre";
            // 
            // tabPage_Products
            // 
            this.tabPage_Products.Controls.Add(this.buttonAdd_Product);
            this.tabPage_Products.Controls.Add(this.dataGridView_Product);
            this.tabPage_Products.Controls.Add(this.buttonDelete_Product);
            this.tabPage_Products.Controls.Add(this.label1);
            this.tabPage_Products.Controls.Add(this.buttonSearch_Product);
            this.tabPage_Products.Controls.Add(this.textBox_idProduct);
            this.tabPage_Products.Controls.Add(this.comboBox_statusP);
            this.tabPage_Products.Controls.Add(this.textBox_nameProduct);
            this.tabPage_Products.Controls.Add(this.label8);
            this.tabPage_Products.Controls.Add(this.label9);
            this.tabPage_Products.Location = new System.Drawing.Point(4, 31);
            this.tabPage_Products.Name = "tabPage_Products";
            this.tabPage_Products.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Products.Size = new System.Drawing.Size(832, 414);
            this.tabPage_Products.TabIndex = 1;
            this.tabPage_Products.Text = "Productos";
            this.tabPage_Products.UseVisualStyleBackColor = true;
            // 
            // buttonAdd_Product
            // 
            this.buttonAdd_Product.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAdd_Product.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd_Product.ForeColor = System.Drawing.Color.White;
            this.buttonAdd_Product.Location = new System.Drawing.Point(255, 358);
            this.buttonAdd_Product.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd_Product.Name = "buttonAdd_Product";
            this.buttonAdd_Product.Size = new System.Drawing.Size(142, 39);
            this.buttonAdd_Product.TabIndex = 74;
            this.buttonAdd_Product.Text = "＋ Agregar";
            this.buttonAdd_Product.UseVisualStyleBackColor = false;
            // 
            // dataGridView_Product
            // 
            this.dataGridView_Product.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Product.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewCheckBoxColumn1});
            this.dataGridView_Product.Location = new System.Drawing.Point(29, 94);
            this.dataGridView_Product.Name = "dataGridView_Product";
            this.dataGridView_Product.Size = new System.Drawing.Size(778, 259);
            this.dataGridView_Product.TabIndex = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Stock Actual";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Stock Virtual";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Stock Mínimo";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Stock Máximo";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "Estado";
            this.dataGridViewComboBoxColumn1.Items.AddRange(new object[] {
            "Activo",
            "Eliminado"});
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Borrar";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // buttonDelete_Product
            // 
            this.buttonDelete_Product.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDelete_Product.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete_Product.ForeColor = System.Drawing.Color.White;
            this.buttonDelete_Product.Location = new System.Drawing.Point(425, 358);
            this.buttonDelete_Product.Name = "buttonDelete_Product";
            this.buttonDelete_Product.Size = new System.Drawing.Size(142, 39);
            this.buttonDelete_Product.TabIndex = 73;
            this.buttonDelete_Product.Text = "🗑 Eliminar";
            this.buttonDelete_Product.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 23);
            this.label1.TabIndex = 70;
            this.label1.Text = "ID";
            // 
            // buttonSearch_Product
            // 
            this.buttonSearch_Product.BackColor = System.Drawing.Color.Gray;
            this.buttonSearch_Product.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch_Product.ForeColor = System.Drawing.Color.White;
            this.buttonSearch_Product.Location = new System.Drawing.Point(660, 37);
            this.buttonSearch_Product.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearch_Product.Name = "buttonSearch_Product";
            this.buttonSearch_Product.Size = new System.Drawing.Size(122, 39);
            this.buttonSearch_Product.TabIndex = 72;
            this.buttonSearch_Product.Text = "🔎 Buscar";
            this.buttonSearch_Product.UseVisualStyleBackColor = false;
            // 
            // textBox_idProduct
            // 
            this.textBox_idProduct.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_idProduct.Location = new System.Drawing.Point(29, 44);
            this.textBox_idProduct.Name = "textBox_idProduct";
            this.textBox_idProduct.Size = new System.Drawing.Size(154, 29);
            this.textBox_idProduct.TabIndex = 69;
            // 
            // comboBox_statusP
            // 
            this.comboBox_statusP.FormattingEnabled = true;
            this.comboBox_statusP.Items.AddRange(new object[] {
            "Activo",
            "Eliminado"});
            this.comboBox_statusP.Location = new System.Drawing.Point(482, 44);
            this.comboBox_statusP.Name = "comboBox_statusP";
            this.comboBox_statusP.Size = new System.Drawing.Size(135, 30);
            this.comboBox_statusP.TabIndex = 71;
            // 
            // textBox_nameProduct
            // 
            this.textBox_nameProduct.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nameProduct.Location = new System.Drawing.Point(192, 44);
            this.textBox_nameProduct.Name = "textBox_nameProduct";
            this.textBox_nameProduct.Size = new System.Drawing.Size(266, 29);
            this.textBox_nameProduct.TabIndex = 68;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(478, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 23);
            this.label8.TabIndex = 66;
            this.label8.Text = "Estado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(188, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 23);
            this.label9.TabIndex = 67;
            this.label9.Text = "Nombre";
            // 
            // WarehouseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1175, 502);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WarehouseDetail";
            this.Text = "Detalle de almacén";
            this.tabControl1.ResumeLayout(false);
            this.tabPage_rawMaterial.ResumeLayout(false);
            this.tabPage_rawMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RawMaterial)).EndInit();
            this.tabPage_Products.ResumeLayout(false);
            this.tabPage_Products.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Product)).EndInit();
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
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_rawMaterial;
        private System.Windows.Forms.Button buttonAdd_RawMaterial;
        private System.Windows.Forms.DataGridView dataGridView_RawMaterial;
        private System.Windows.Forms.Button buttonDelete_RawMaterial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSearch_RawMaterial;
        private System.Windows.Forms.TextBox textBox_idRawMaterial;
        private System.Windows.Forms.ComboBox comboBox_statusRM;
        private System.Windows.Forms.TextBox textBox_nameRawMaterial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage_Products;
        private System.Windows.Forms.Button buttonAdd_Product;
        private System.Windows.Forms.DataGridView dataGridView_Product;
        private System.Windows.Forms.Button buttonDelete_Product;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearch_Product;
        private System.Windows.Forms.TextBox textBox_idProduct;
        private System.Windows.Forms.ComboBox comboBox_statusP;
        private System.Windows.Forms.TextBox textBox_nameProduct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockVirtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMaximo;
        private System.Windows.Forms.DataGridViewComboBoxColumn estado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn borrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}