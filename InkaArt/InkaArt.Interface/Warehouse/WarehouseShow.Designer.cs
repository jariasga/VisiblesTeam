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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_edit = new System.Windows.Forms.Button();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tab_items = new System.Windows.Forms.TabControl();
            this.tabPage_rawMaterial = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.num_rm_max = new System.Windows.Forms.NumericUpDown();
            this.num_rm_min = new System.Windows.Forms.NumericUpDown();
            this.button_add_rm = new System.Windows.Forms.Button();
            this.grid_rm = new System.Windows.Forms.DataGridView();
            this.button_delete_rm = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.combo_rm = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage_Products = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.num_product_max = new System.Windows.Forms.NumericUpDown();
            this.num_product_min = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Producto = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_add_product = new System.Windows.Forms.Button();
            this.grid_product = new System.Windows.Forms.DataGridView();
            this.button_delete_product = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pr_stock_min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pr_stock_max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idPW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockVirtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rm_stock_min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rm_stock_max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdRMW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_items.SuspendLayout();
            this.tabPage_rawMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_rm_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_rm_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_rm)).BeginInit();
            this.tabPage_Products.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_product_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_product_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_product)).BeginInit();
            this.SuspendLayout();
            // 
            // button_edit
            // 
            this.button_edit.BackColor = System.Drawing.Color.SteelBlue;
            this.button_edit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_edit.ForeColor = System.Drawing.Color.White;
            this.button_edit.Location = new System.Drawing.Point(74, 360);
            this.button_edit.Margin = new System.Windows.Forms.Padding(2);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(95, 39);
            this.button_edit.TabIndex = 56;
            this.button_edit.Text = "🖉 Editar";
            this.button_edit.UseVisualStyleBackColor = false;
            this.button_edit.Click += new System.EventHandler(this.buttonEditSaveClick);
            // 
            // textBox_address
            // 
            this.textBox_address.BackColor = System.Drawing.Color.White;
            this.textBox_address.Enabled = false;
            this.textBox_address.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_address.Location = new System.Drawing.Point(28, 182);
            this.textBox_address.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_address.Multiline = true;
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(197, 148);
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
            this.textBox_description.BackColor = System.Drawing.Color.White;
            this.textBox_description.Enabled = false;
            this.textBox_description.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_description.Location = new System.Drawing.Point(28, 92);
            this.textBox_description.Margin = new System.Windows.Forms.Padding(2);
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
            this.textBox_name.BackColor = System.Drawing.Color.White;
            this.textBox_name.Enabled = false;
            this.textBox_name.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(28, 38);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(2);
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
            // tab_items
            // 
            this.tab_items.Controls.Add(this.tabPage_rawMaterial);
            this.tab_items.Controls.Add(this.tabPage_Products);
            this.tab_items.Location = new System.Drawing.Point(249, 20);
            this.tab_items.Margin = new System.Windows.Forms.Padding(2);
            this.tab_items.Name = "tab_items";
            this.tab_items.SelectedIndex = 0;
            this.tab_items.Size = new System.Drawing.Size(630, 399);
            this.tab_items.TabIndex = 57;
            // 
            // tabPage_rawMaterial
            // 
            this.tabPage_rawMaterial.Controls.Add(this.label11);
            this.tabPage_rawMaterial.Controls.Add(this.num_rm_max);
            this.tabPage_rawMaterial.Controls.Add(this.num_rm_min);
            this.tabPage_rawMaterial.Controls.Add(this.button_add_rm);
            this.tabPage_rawMaterial.Controls.Add(this.grid_rm);
            this.tabPage_rawMaterial.Controls.Add(this.button_delete_rm);
            this.tabPage_rawMaterial.Controls.Add(this.label5);
            this.tabPage_rawMaterial.Controls.Add(this.combo_rm);
            this.tabPage_rawMaterial.Controls.Add(this.label7);
            this.tabPage_rawMaterial.Controls.Add(this.label6);
            this.tabPage_rawMaterial.Location = new System.Drawing.Point(4, 22);
            this.tabPage_rawMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_rawMaterial.Name = "tabPage_rawMaterial";
            this.tabPage_rawMaterial.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_rawMaterial.Size = new System.Drawing.Size(622, 373);
            this.tabPage_rawMaterial.TabIndex = 0;
            this.tabPage_rawMaterial.Text = "Materias Primas";
            this.tabPage_rawMaterial.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(28, 293);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(553, 18);
            this.label11.TabIndex = 83;
            this.label11.Text = "* El stock actual y virtual solo son editables mediante movimientos de almacén.";
            // 
            // num_rm_max
            // 
            this.num_rm_max.Enabled = false;
            this.num_rm_max.Font = new System.Drawing.Font("Arial", 11F);
            this.num_rm_max.Location = new System.Drawing.Point(394, 35);
            this.num_rm_max.Margin = new System.Windows.Forms.Padding(2);
            this.num_rm_max.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.num_rm_max.Name = "num_rm_max";
            this.num_rm_max.Size = new System.Drawing.Size(93, 24);
            this.num_rm_max.TabIndex = 65;
            // 
            // num_rm_min
            // 
            this.num_rm_min.Enabled = false;
            this.num_rm_min.Font = new System.Drawing.Font("Arial", 11F);
            this.num_rm_min.Location = new System.Drawing.Point(277, 35);
            this.num_rm_min.Margin = new System.Windows.Forms.Padding(2);
            this.num_rm_min.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.num_rm_min.Name = "num_rm_min";
            this.num_rm_min.Size = new System.Drawing.Size(95, 24);
            this.num_rm_min.TabIndex = 58;
            // 
            // button_add_rm
            // 
            this.button_add_rm.BackColor = System.Drawing.Color.SteelBlue;
            this.button_add_rm.Enabled = false;
            this.button_add_rm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add_rm.ForeColor = System.Drawing.Color.White;
            this.button_add_rm.Location = new System.Drawing.Point(508, 22);
            this.button_add_rm.Margin = new System.Windows.Forms.Padding(2);
            this.button_add_rm.Name = "button_add_rm";
            this.button_add_rm.Size = new System.Drawing.Size(98, 38);
            this.button_add_rm.TabIndex = 64;
            this.button_add_rm.Text = "＋ Agregar";
            this.button_add_rm.UseVisualStyleBackColor = false;
            this.button_add_rm.Click += new System.EventHandler(this.buttonAddRMClick);
            // 
            // grid_rm
            // 
            this.grid_rm.AllowUserToAddRows = false;
            this.grid_rm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_rm.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grid_rm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_rm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_rm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_rm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.nombre,
            this.stockActual,
            this.stockVirtual,
            this.rm_stock_min,
            this.rm_stock_max,
            this.borrar,
            this.IdRMW});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_rm.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_rm.Location = new System.Drawing.Point(22, 76);
            this.grid_rm.Margin = new System.Windows.Forms.Padding(2);
            this.grid_rm.Name = "grid_rm";
            this.grid_rm.Size = new System.Drawing.Size(584, 210);
            this.grid_rm.TabIndex = 55;
            this.grid_rm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RawMaterial_CellContentClick);
            // 
            // button_delete_rm
            // 
            this.button_delete_rm.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete_rm.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete_rm.ForeColor = System.Drawing.Color.White;
            this.button_delete_rm.Location = new System.Drawing.Point(270, 318);
            this.button_delete_rm.Margin = new System.Windows.Forms.Padding(2);
            this.button_delete_rm.Name = "button_delete_rm";
            this.button_delete_rm.Size = new System.Drawing.Size(106, 39);
            this.button_delete_rm.TabIndex = 63;
            this.button_delete_rm.Text = "🗑 Eliminar";
            this.button_delete_rm.UseVisualStyleBackColor = false;
            this.button_delete_rm.Click += new System.EventHandler(this.buttonDeleteRMClick);
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
            // combo_rm
            // 
            this.combo_rm.BackColor = System.Drawing.Color.White;
            this.combo_rm.Font = new System.Drawing.Font("Arial", 11F);
            this.combo_rm.FormattingEnabled = true;
            this.combo_rm.Location = new System.Drawing.Point(23, 34);
            this.combo_rm.Margin = new System.Windows.Forms.Padding(2);
            this.combo_rm.Name = "combo_rm";
            this.combo_rm.Size = new System.Drawing.Size(237, 25);
            this.combo_rm.TabIndex = 61;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(389, 15);
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
            this.label6.Location = new System.Drawing.Point(274, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 18);
            this.label6.TabIndex = 57;
            this.label6.Text = "Stock Mínimo";
            // 
            // tabPage_Products
            // 
            this.tabPage_Products.Controls.Add(this.label10);
            this.tabPage_Products.Controls.Add(this.num_product_max);
            this.tabPage_Products.Controls.Add(this.num_product_min);
            this.tabPage_Products.Controls.Add(this.label1);
            this.tabPage_Products.Controls.Add(this.comboBox_Producto);
            this.tabPage_Products.Controls.Add(this.label8);
            this.tabPage_Products.Controls.Add(this.label9);
            this.tabPage_Products.Controls.Add(this.button_add_product);
            this.tabPage_Products.Controls.Add(this.grid_product);
            this.tabPage_Products.Controls.Add(this.button_delete_product);
            this.tabPage_Products.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Products.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_Products.Name = "tabPage_Products";
            this.tabPage_Products.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_Products.Size = new System.Drawing.Size(622, 373);
            this.tabPage_Products.TabIndex = 1;
            this.tabPage_Products.Text = "Productos";
            this.tabPage_Products.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(28, 293);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(553, 18);
            this.label10.TabIndex = 82;
            this.label10.Text = "* El stock actual y virtual solo son editables mediante movimientos de almacén.";
            // 
            // num_product_max
            // 
            this.num_product_max.Enabled = false;
            this.num_product_max.Font = new System.Drawing.Font("Arial", 11F);
            this.num_product_max.Location = new System.Drawing.Point(393, 38);
            this.num_product_max.Margin = new System.Windows.Forms.Padding(2);
            this.num_product_max.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.num_product_max.Name = "num_product_max";
            this.num_product_max.Size = new System.Drawing.Size(93, 24);
            this.num_product_max.TabIndex = 80;
            // 
            // num_product_min
            // 
            this.num_product_min.Enabled = false;
            this.num_product_min.Font = new System.Drawing.Font("Arial", 11F);
            this.num_product_min.Location = new System.Drawing.Point(276, 38);
            this.num_product_min.Margin = new System.Windows.Forms.Padding(2);
            this.num_product_min.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.num_product_min.Name = "num_product_min";
            this.num_product_min.Size = new System.Drawing.Size(95, 24);
            this.num_product_min.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 78;
            this.label1.Text = "Producto";
            // 
            // comboBox_Producto
            // 
            this.comboBox_Producto.BackColor = System.Drawing.Color.White;
            this.comboBox_Producto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Producto.Enabled = false;
            this.comboBox_Producto.Font = new System.Drawing.Font("Arial", 11F);
            this.comboBox_Producto.FormattingEnabled = true;
            this.comboBox_Producto.Location = new System.Drawing.Point(22, 38);
            this.comboBox_Producto.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Producto.Name = "comboBox_Producto";
            this.comboBox_Producto.Size = new System.Drawing.Size(237, 25);
            this.comboBox_Producto.TabIndex = 79;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(390, 18);
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
            this.label9.Location = new System.Drawing.Point(273, 18);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 18);
            this.label9.TabIndex = 76;
            this.label9.Text = "Stock Mínimo";
            // 
            // button_add_product
            // 
            this.button_add_product.BackColor = System.Drawing.Color.SteelBlue;
            this.button_add_product.Enabled = false;
            this.button_add_product.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add_product.ForeColor = System.Drawing.Color.White;
            this.button_add_product.Location = new System.Drawing.Point(508, 25);
            this.button_add_product.Margin = new System.Windows.Forms.Padding(2);
            this.button_add_product.Name = "button_add_product";
            this.button_add_product.Size = new System.Drawing.Size(98, 38);
            this.button_add_product.TabIndex = 74;
            this.button_add_product.Text = "＋ Agregar";
            this.button_add_product.UseVisualStyleBackColor = false;
            this.button_add_product.Click += new System.EventHandler(this.buttonAddProductClick);
            // 
            // grid_product
            // 
            this.grid_product.AllowUserToAddRows = false;
            this.grid_product.AllowUserToDeleteRows = false;
            this.grid_product.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_product.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grid_product.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_product.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_product.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.pr_stock_min,
            this.pr_stock_max,
            this.dataGridViewCheckBoxColumn1,
            this.idPW});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_product.DefaultCellStyle = dataGridViewCellStyle4;
            this.grid_product.Location = new System.Drawing.Point(22, 76);
            this.grid_product.Margin = new System.Windows.Forms.Padding(2);
            this.grid_product.Name = "grid_product";
            this.grid_product.Size = new System.Drawing.Size(584, 210);
            this.grid_product.TabIndex = 65;
            // 
            // button_delete_product
            // 
            this.button_delete_product.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete_product.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete_product.ForeColor = System.Drawing.Color.White;
            this.button_delete_product.Location = new System.Drawing.Point(261, 318);
            this.button_delete_product.Margin = new System.Windows.Forms.Padding(2);
            this.button_delete_product.Name = "button_delete_product";
            this.button_delete_product.Size = new System.Drawing.Size(106, 39);
            this.button_delete_product.TabIndex = 73;
            this.button_delete_product.Text = "🗑 Eliminar";
            this.button_delete_product.UseVisualStyleBackColor = false;
            this.button_delete_product.Click += new System.EventHandler(this.buttonDeleteProductClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.FillWeight = 60F;
            this.dataGridViewTextBoxColumn2.HeaderText = "ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.FillWeight = 120F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.FillWeight = 70F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Stock Actual";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.FillWeight = 70F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Stock Virtual";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // pr_stock_min
            // 
            this.pr_stock_min.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pr_stock_min.FillWeight = 70F;
            this.pr_stock_min.HeaderText = "Stock Mínimo";
            this.pr_stock_min.Name = "pr_stock_min";
            // 
            // pr_stock_max
            // 
            this.pr_stock_max.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pr_stock_max.FillWeight = 70F;
            this.pr_stock_max.HeaderText = "Stock Máximo";
            this.pr_stock_max.Name = "pr_stock_max";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FillWeight = 80F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "Seleccionar";
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
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.FillWeight = 60F;
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.FillWeight = 120F;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // stockActual
            // 
            this.stockActual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stockActual.FillWeight = 70.08122F;
            this.stockActual.HeaderText = "Stock Actual";
            this.stockActual.Name = "stockActual";
            this.stockActual.ReadOnly = true;
            // 
            // stockVirtual
            // 
            this.stockVirtual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stockVirtual.FillWeight = 70F;
            this.stockVirtual.HeaderText = "Stock Virtual";
            this.stockVirtual.Name = "stockVirtual";
            this.stockVirtual.ReadOnly = true;
            this.stockVirtual.Visible = false;
            // 
            // rm_stock_min
            // 
            this.rm_stock_min.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rm_stock_min.FillWeight = 70.08122F;
            this.rm_stock_min.HeaderText = "Stock Mínimo";
            this.rm_stock_min.Name = "rm_stock_min";
            // 
            // rm_stock_max
            // 
            this.rm_stock_max.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rm_stock_max.FillWeight = 70.08122F;
            this.rm_stock_max.HeaderText = "Stock Máximo";
            this.rm_stock_max.Name = "rm_stock_max";
            // 
            // borrar
            // 
            this.borrar.FillWeight = 80.08122F;
            this.borrar.HeaderText = "Seleccionar";
            this.borrar.Name = "borrar";
            this.borrar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.borrar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IdRMW
            // 
            this.IdRMW.HeaderText = "IdRMW";
            this.IdRMW.Name = "IdRMW";
            this.IdRMW.ReadOnly = true;
            this.IdRMW.Visible = false;
            // 
            // WarehouseShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(914, 441);
            this.Controls.Add(this.tab_items);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WarehouseShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista Almacen";
            this.Load += new System.EventHandler(this.WarehouseShow_Load);
            this.tab_items.ResumeLayout(false);
            this.tabPage_rawMaterial.ResumeLayout(false);
            this.tabPage_rawMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_rm_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_rm_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_rm)).EndInit();
            this.tabPage_Products.ResumeLayout(false);
            this.tabPage_Products.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_product_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_product_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_product)).EndInit();
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
        private System.Windows.Forms.TabControl tab_items;
        private System.Windows.Forms.TabPage tabPage_rawMaterial;
        private System.Windows.Forms.Button button_add_rm;
        private System.Windows.Forms.DataGridView grid_rm;
        private System.Windows.Forms.Button button_delete_rm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combo_rm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage_Products;
        private System.Windows.Forms.Button button_add_product;
        private System.Windows.Forms.DataGridView grid_product;
        private System.Windows.Forms.Button button_delete_product;
        private System.Windows.Forms.NumericUpDown num_rm_max;
        private System.Windows.Forms.NumericUpDown num_rm_min;
        private System.Windows.Forms.NumericUpDown num_product_max;
        private System.Windows.Forms.NumericUpDown num_product_min;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Producto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockVirtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn rm_stock_min;
        private System.Windows.Forms.DataGridViewTextBoxColumn rm_stock_max;
        private System.Windows.Forms.DataGridViewCheckBoxColumn borrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRMW;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn pr_stock_min;
        private System.Windows.Forms.DataGridViewTextBoxColumn pr_stock_max;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPW;
    }
}