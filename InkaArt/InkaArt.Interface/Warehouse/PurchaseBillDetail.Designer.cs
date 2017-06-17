namespace InkaArt.Interface.Warehouse
{
    partial class PurchaseBillDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_idsupplier = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_delivery = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_total = new System.Windows.Forms.TextBox();
            this.comboBox_supplier = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_factura = new System.Windows.Forms.TextBox();
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
            this.buttonDelete = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRawMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Igv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_pedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nro. de la factura";
            // 
            // textBox_id
            // 
            this.textBox_id.BackColor = System.Drawing.Color.White;
            this.textBox_id.Enabled = false;
            this.textBox_id.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_id.Location = new System.Drawing.Point(15, 55);
            this.textBox_id.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(243, 24);
            this.textBox_id.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Proveedor";
            // 
            // textBox_idsupplier
            // 
            this.textBox_idsupplier.BackColor = System.Drawing.Color.White;
            this.textBox_idsupplier.Enabled = false;
            this.textBox_idsupplier.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_idsupplier.Location = new System.Drawing.Point(18, 115);
            this.textBox_idsupplier.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_idsupplier.Multiline = true;
            this.textBox_idsupplier.Name = "textBox_idsupplier";
            this.textBox_idsupplier.Size = new System.Drawing.Size(72, 33);
            this.textBox_idsupplier.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha de entrega";
            // 
            // dateTimePicker_delivery
            // 
            this.dateTimePicker_delivery.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimePicker_delivery.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_delivery.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_delivery.Location = new System.Drawing.Point(18, 185);
            this.dateTimePicker_delivery.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker_delivery.Name = "dateTimePicker_delivery";
            this.dateTimePicker_delivery.Size = new System.Drawing.Size(243, 24);
            this.dateTimePicker_delivery.TabIndex = 5;
            this.dateTimePicker_delivery.Value = new System.DateTime(2017, 5, 8, 1, 26, 23, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 226);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Monto total";
            // 
            // textBox_total
            // 
            this.textBox_total.BackColor = System.Drawing.Color.White;
            this.textBox_total.Enabled = false;
            this.textBox_total.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_total.Location = new System.Drawing.Point(18, 248);
            this.textBox_total.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_total.Name = "textBox_total";
            this.textBox_total.ReadOnly = true;
            this.textBox_total.Size = new System.Drawing.Size(243, 24);
            this.textBox_total.TabIndex = 7;
            // 
            // comboBox_supplier
            // 
            this.comboBox_supplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_supplier.FormattingEnabled = true;
            this.comboBox_supplier.Location = new System.Drawing.Point(98, 119);
            this.comboBox_supplier.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_supplier.Name = "comboBox_supplier";
            this.comboBox_supplier.Size = new System.Drawing.Size(160, 26);
            this.comboBox_supplier.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_supplier);
            this.groupBox1.Controls.Add(this.textBox_total);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker_delivery);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_idsupplier);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(278, 293);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la orden";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBox_factura);
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
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox2.Location = new System.Drawing.Point(314, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(663, 487);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de materias primas pedidas";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(406, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 18);
            this.label12.TabIndex = 29;
            this.label12.Text = "Nro. Factura";
            // 
            // textBox_factura
            // 
            this.textBox_factura.BackColor = System.Drawing.Color.White;
            this.textBox_factura.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_factura.Location = new System.Drawing.Point(409, 111);
            this.textBox_factura.MaxLength = 9;
            this.textBox_factura.Name = "textBox_factura";
            this.textBox_factura.Size = new System.Drawing.Size(118, 24);
            this.textBox_factura.TabIndex = 28;
            this.textBox_factura.Text = "0";
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
            this.textBox_subtotal.Location = new System.Drawing.Point(265, 111);
            this.textBox_subtotal.Name = "textBox_subtotal";
            this.textBox_subtotal.Size = new System.Drawing.Size(118, 24);
            this.textBox_subtotal.TabIndex = 26;
            this.textBox_subtotal.Text = "0";
            this.textBox_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(260, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 18);
            this.label11.TabIndex = 25;
            this.label11.Text = "Subtotal";
            // 
            // idUnit
            // 
            this.idUnit.Enabled = false;
            this.idUnit.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idUnit.Location = new System.Drawing.Point(409, 55);
            this.idUnit.Name = "idUnit";
            this.idUnit.Size = new System.Drawing.Size(72, 24);
            this.idUnit.TabIndex = 24;
            // 
            // unitAbrev
            // 
            this.unitAbrev.Enabled = false;
            this.unitAbrev.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitAbrev.Location = new System.Drawing.Point(487, 54);
            this.unitAbrev.Name = "unitAbrev";
            this.unitAbrev.Size = new System.Drawing.Size(155, 24);
            this.unitAbrev.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(406, 33);
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
            this.textBox_price.Location = new System.Drawing.Point(138, 111);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.Size = new System.Drawing.Size(106, 24);
            this.textBox_price.TabIndex = 21;
            this.textBox_price.Text = "0";
            this.textBox_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(138, 90);
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
            this.textBox_cantidad.Size = new System.Drawing.Size(102, 24);
            this.textBox_cantidad.TabIndex = 19;
            this.textBox_cantidad.Text = "0";
            this.textBox_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxRawMaterialName
            // 
            this.comboBoxRawMaterialName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRawMaterialName.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRawMaterialName.FormattingEnabled = true;
            this.comboBoxRawMaterialName.Location = new System.Drawing.Point(94, 54);
            this.comboBoxRawMaterialName.Name = "comboBoxRawMaterialName";
            this.comboBoxRawMaterialName.Size = new System.Drawing.Size(289, 25);
            this.comboBoxRawMaterialName.TabIndex = 18;
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
            this.Eliminar,
            this.id_detail,
            this.idRawMat,
            this.Nombre,
            this.Cantidad,
            this.Precio,
            this.Igv,
            this.Subtotal,
            this.Factura,
            this.Estado});
            this.dataGridView_pedidos.Location = new System.Drawing.Point(16, 159);
            this.dataGridView_pedidos.Name = "dataGridView_pedidos";
            this.dataGridView_pedidos.Size = new System.Drawing.Size(626, 272);
            this.dataGridView_pedidos.TabIndex = 17;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(279, 437);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(104, 41);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "🗑 Eliminar";
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.SteelBlue;
            this.button_add.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.ForeColor = System.Drawing.Color.White;
            this.button_add.Location = new System.Drawing.Point(538, 98);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(104, 41);
            this.button_add.TabIndex = 14;
            this.button_add.Text = "+ Agregar";
            this.button_add.UseVisualStyleBackColor = false;
            // 
            // Eliminar
            // 
            this.Eliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Eliminar.FalseValue = "False";
            this.Eliminar.HeaderText = "";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Eliminar.TrueValue = "True";
            this.Eliminar.Width = 19;
            // 
            // id_detail
            // 
            this.id_detail.HeaderText = "ID Detail";
            this.id_detail.Name = "id_detail";
            this.id_detail.ReadOnly = true;
            this.id_detail.Visible = false;
            // 
            // idRawMat
            // 
            this.idRawMat.HeaderText = "ID Mat.";
            this.idRawMat.Name = "idRawMat";
            this.idRawMat.ReadOnly = true;
            this.idRawMat.Visible = false;
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
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // Igv
            // 
            this.Igv.HeaderText = "Igv";
            this.Igv.Name = "Igv";
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            // 
            // Factura
            // 
            this.Factura.HeaderText = "Factura";
            this.Factura.MaxInputLength = 9;
            this.Factura.Name = "Factura";
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Visible = false;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(81, 330);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(144, 42);
            this.buttonSave.TabIndex = 24;
            this.buttonSave.Text = "Editar";
            this.buttonSave.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(81, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 49);
            this.button1.TabIndex = 25;
            this.button1.Text = "Actualizar orden de compra";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // PurchaseBillDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(989, 518);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 11F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PurchaseBillDetail";
            this.Text = "PurchaseBillDetail";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_pedidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_idsupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_delivery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_total;
        private System.Windows.Forms.ComboBox comboBox_supplier;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_factura;
        private System.Windows.Forms.TextBox textBox_idrm;
        private System.Windows.Forms.TextBox textBox_subtotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox idUnit;
        private System.Windows.Forms.TextBox unitAbrev;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_price;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_cantidad;
        private System.Windows.Forms.ComboBox comboBoxRawMaterialName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView_pedidos;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRawMat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Igv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button button1;
    }
}