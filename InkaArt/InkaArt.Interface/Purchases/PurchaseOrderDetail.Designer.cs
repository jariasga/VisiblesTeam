namespace InkaArt.Interface.Purchases
{
    partial class PurchaseOrderDetail
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_supplier = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_creation = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_total = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker_delivery = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_idsupplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_igv = new System.Windows.Forms.TextBox();
            this.textBox_idrm = new System.Windows.Forms.TextBox();
            this.textBox_subtotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.idUnit = new System.Windows.Forms.TextBox();
            this.unitAbrev = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_price = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_cantidad = new System.Windows.Forms.TextBox();
            this.comboBoxRawMaterialName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView_pedidos = new System.Windows.Forms.DataGridView();
            this.id_detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRawMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Igv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Actualizar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Eliminado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_pedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_supplier);
            this.groupBox1.Controls.Add(this.dateTimePicker_creation);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBox_status);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_total);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker_delivery);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_idsupplier);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 424);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la orden";
            // 
            // comboBox_supplier
            // 
            this.comboBox_supplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_supplier.FormattingEnabled = true;
            this.comboBox_supplier.Location = new System.Drawing.Point(74, 115);
            this.comboBox_supplier.Name = "comboBox_supplier";
            this.comboBox_supplier.Size = new System.Drawing.Size(121, 26);
            this.comboBox_supplier.TabIndex = 12;
            this.comboBox_supplier.SelectedIndexChanged += new System.EventHandler(this.cambiar_idsupplier);
            // 
            // dateTimePicker_creation
            // 
            this.dateTimePicker_creation.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimePicker_creation.CustomFormat = "";
            this.dateTimePicker_creation.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_creation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_creation.Location = new System.Drawing.Point(12, 184);
            this.dateTimePicker_creation.Name = "dateTimePicker_creation";
            this.dateTimePicker_creation.Size = new System.Drawing.Size(183, 24);
            this.dateTimePicker_creation.TabIndex = 11;
            this.dateTimePicker_creation.Value = new System.DateTime(2017, 5, 8, 1, 26, 23, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "Fecha de emisión";
            // 
            // comboBox_status
            // 
            this.comboBox_status.BackColor = System.Drawing.Color.White;
            this.comboBox_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_status.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Items.AddRange(new object[] {
            "Borrador",
            "Enviado",
            "Eliminado"});
            this.comboBox_status.Location = new System.Drawing.Point(13, 381);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(183, 25);
            this.comboBox_status.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Estado";
            // 
            // textBox_total
            // 
            this.textBox_total.BackColor = System.Drawing.Color.White;
            this.textBox_total.Enabled = false;
            this.textBox_total.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_total.Location = new System.Drawing.Point(13, 318);
            this.textBox_total.Name = "textBox_total";
            this.textBox_total.ReadOnly = true;
            this.textBox_total.Size = new System.Drawing.Size(183, 24);
            this.textBox_total.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Monto total";
            // 
            // dateTimePicker_delivery
            // 
            this.dateTimePicker_delivery.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimePicker_delivery.CustomFormat = "";
            this.dateTimePicker_delivery.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_delivery.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_delivery.Location = new System.Drawing.Point(13, 252);
            this.dateTimePicker_delivery.Name = "dateTimePicker_delivery";
            this.dateTimePicker_delivery.Size = new System.Drawing.Size(183, 24);
            this.dateTimePicker_delivery.TabIndex = 5;
            this.dateTimePicker_delivery.Value = new System.DateTime(2017, 5, 8, 1, 26, 23, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha de entrega estimada";
            // 
            // textBox_idsupplier
            // 
            this.textBox_idsupplier.BackColor = System.Drawing.Color.White;
            this.textBox_idsupplier.Enabled = false;
            this.textBox_idsupplier.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_idsupplier.Location = new System.Drawing.Point(13, 116);
            this.textBox_idsupplier.Multiline = true;
            this.textBox_idsupplier.Name = "textBox_idsupplier";
            this.textBox_idsupplier.Size = new System.Drawing.Size(55, 26);
            this.textBox_idsupplier.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Proveedor";
            // 
            // textBox_id
            // 
            this.textBox_id.BackColor = System.Drawing.Color.White;
            this.textBox_id.Enabled = false;
            this.textBox_id.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_id.Location = new System.Drawing.Point(13, 54);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(183, 24);
            this.textBox_id.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id de la orden";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBox_igv);
            this.groupBox2.Controls.Add(this.textBox_idrm);
            this.groupBox2.Controls.Add(this.textBox_subtotal);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.idUnit);
            this.groupBox2.Controls.Add(this.unitAbrev);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox_price);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox_cantidad);
            this.groupBox2.Controls.Add(this.comboBoxRawMaterialName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dataGridView_pedidos);
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Controls.Add(this.button_add);
            this.groupBox2.Location = new System.Drawing.Point(249, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(674, 487);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de materias primas pedidas";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(296, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 18);
            this.label12.TabIndex = 29;
            this.label12.Text = "IGV";
            // 
            // textBox_igv
            // 
            this.textBox_igv.Enabled = false;
            this.textBox_igv.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox_igv.Location = new System.Drawing.Point(295, 111);
            this.textBox_igv.Name = "textBox_igv";
            this.textBox_igv.Size = new System.Drawing.Size(100, 24);
            this.textBox_igv.TabIndex = 28;
            this.textBox_igv.Text = "0";
            this.textBox_igv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_idrm
            // 
            this.textBox_idrm.Enabled = false;
            this.textBox_idrm.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_idrm.Location = new System.Drawing.Point(16, 54);
            this.textBox_idrm.Name = "textBox_idrm";
            this.textBox_idrm.Size = new System.Drawing.Size(72, 24);
            this.textBox_idrm.TabIndex = 27;
            // 
            // textBox_subtotal
            // 
            this.textBox_subtotal.BackColor = System.Drawing.Color.White;
            this.textBox_subtotal.Enabled = false;
            this.textBox_subtotal.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_subtotal.Location = new System.Drawing.Point(427, 111);
            this.textBox_subtotal.Name = "textBox_subtotal";
            this.textBox_subtotal.Size = new System.Drawing.Size(118, 24);
            this.textBox_subtotal.TabIndex = 26;
            this.textBox_subtotal.Text = "0";
            this.textBox_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(424, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 18);
            this.label11.TabIndex = 25;
            this.label11.Text = "Subtotal";
            // 
            // idUnit
            // 
            this.idUnit.Enabled = false;
            this.idUnit.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idUnit.Location = new System.Drawing.Point(427, 54);
            this.idUnit.Name = "idUnit";
            this.idUnit.Size = new System.Drawing.Size(72, 24);
            this.idUnit.TabIndex = 24;
            // 
            // unitAbrev
            // 
            this.unitAbrev.Enabled = false;
            this.unitAbrev.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitAbrev.Location = new System.Drawing.Point(505, 54);
            this.unitAbrev.Name = "unitAbrev";
            this.unitAbrev.Size = new System.Drawing.Size(155, 24);
            this.unitAbrev.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(424, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 18);
            this.label10.TabIndex = 22;
            this.label10.Text = "Unidad";
            // 
            // textBox_price
            // 
            this.textBox_price.BackColor = System.Drawing.Color.White;
            this.textBox_price.Enabled = false;
            this.textBox_price.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_price.Location = new System.Drawing.Point(152, 111);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.Size = new System.Drawing.Size(106, 24);
            this.textBox_price.TabIndex = 21;
            this.textBox_price.Text = "0";
            this.textBox_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(149, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "Monto unitario";
            // 
            // textBox_cantidad
            // 
            this.textBox_cantidad.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_cantidad.Location = new System.Drawing.Point(16, 111);
            this.textBox_cantidad.Name = "textBox_cantidad";
            this.textBox_cantidad.Size = new System.Drawing.Size(106, 24);
            this.textBox_cantidad.TabIndex = 19;
            this.textBox_cantidad.Text = "0";
            this.textBox_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_cantidad.TextChanged += new System.EventHandler(this.verifying_quantity);
            // 
            // comboBoxRawMaterialName
            // 
            this.comboBoxRawMaterialName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRawMaterialName.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRawMaterialName.FormattingEnabled = true;
            this.comboBoxRawMaterialName.Location = new System.Drawing.Point(94, 54);
            this.comboBoxRawMaterialName.Name = "comboBoxRawMaterialName";
            this.comboBoxRawMaterialName.Size = new System.Drawing.Size(310, 25);
            this.comboBoxRawMaterialName.TabIndex = 18;
            this.comboBoxRawMaterialName.SelectedIndexChanged += new System.EventHandler(this.mostrarOtrosCampos);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "Cantidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Materia prima";
            // 
            // dataGridView_pedidos
            // 
            this.dataGridView_pedidos.AllowUserToAddRows = false;
            this.dataGridView_pedidos.AllowUserToDeleteRows = false;
            this.dataGridView_pedidos.AllowUserToResizeRows = false;
            this.dataGridView_pedidos.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_pedidos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_pedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_detail,
            this.idRawMat,
            this.Nombre,
            this.Cantidad,
            this.Subtotal,
            this.Igv,
            this.Factura,
            this.Estado,
            this.Eliminar,
            this.Actualizar,
            this.Eliminado});
            this.dataGridView_pedidos.Location = new System.Drawing.Point(13, 159);
            this.dataGridView_pedidos.Name = "dataGridView_pedidos";
            this.dataGridView_pedidos.Size = new System.Drawing.Size(647, 272);
            this.dataGridView_pedidos.TabIndex = 17;
            // 
            // id_detail
            // 
            this.id_detail.HeaderText = "ID Detail";
            this.id_detail.Name = "id_detail";
            this.id_detail.ReadOnly = true;
            this.id_detail.Visible = false;
            this.id_detail.Width = 70;
            // 
            // idRawMat
            // 
            this.idRawMat.HeaderText = "ID Mat.";
            this.idRawMat.Name = "idRawMat";
            this.idRawMat.ReadOnly = true;
            this.idRawMat.Width = 65;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 80;
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            this.Subtotal.Width = 75;
            // 
            // Igv
            // 
            this.Igv.HeaderText = "Igv";
            this.Igv.Name = "Igv";
            this.Igv.ReadOnly = true;
            this.Igv.Width = 75;
            // 
            // Factura
            // 
            this.Factura.HeaderText = "Factura";
            this.Factura.MaxInputLength = 9;
            this.Factura.Name = "Factura";
            this.Factura.Width = 75;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Width = 80;
            // 
            // Eliminar
            // 
            this.Eliminar.FalseValue = "False";
            this.Eliminar.HeaderText = "";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Eliminar.TrueValue = "True";
            this.Eliminar.Width = 50;
            // 
            // Actualizar
            // 
            this.Actualizar.HeaderText = "Actualizar";
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Visible = false;
            // 
            // Eliminado
            // 
            this.Eliminado.HeaderText = "Eliminado";
            this.Eliminado.Name = "Eliminado";
            this.Eliminado.Visible = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(214, 438);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(104, 41);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "🗑 Eliminar";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.button_delete);
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.SteelBlue;
            this.button_add.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.ForeColor = System.Drawing.Color.White;
            this.button_add.Location = new System.Drawing.Point(556, 100);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(104, 41);
            this.button_add.TabIndex = 14;
            this.button_add.Text = "+ Agregar";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.Gray;
            this.buttonExport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExport.ForeColor = System.Drawing.Color.White;
            this.buttonExport.Location = new System.Drawing.Point(129, 460);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(104, 42);
            this.buttonExport.TabIndex = 24;
            this.buttonExport.Text = "🗀 Exportar";
            this.buttonExport.UseVisualStyleBackColor = false;
            this.buttonExport.Click += new System.EventHandler(this.generarOrdenDoc);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(19, 460);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(104, 42);
            this.buttonSave.TabIndex = 23;
            this.buttonSave.Text = "Editar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.button_save);
            // 
            // PurchaseOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 518);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PurchaseOrderDetail";
            this.Text = "Detalle de orden de compra";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_pedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_total;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_delivery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_idsupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.DataGridView dataGridView_pedidos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker_creation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBox_price;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_cantidad;
        private System.Windows.Forms.ComboBox comboBoxRawMaterialName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox unitAbrev;
        private System.Windows.Forms.ComboBox comboBox_supplier;
        private System.Windows.Forms.TextBox idUnit;
        private System.Windows.Forms.TextBox textBox_idrm;
        private System.Windows.Forms.TextBox textBox_subtotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_igv;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRawMat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Igv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Actualizar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminado;
    }
}