﻿namespace InkaArt.Interface.Sales
{
    partial class ClientOrderShow
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button_calculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_amount_todoc = new System.Windows.Forms.TextBox();
            this.textbox_igv_todoc = new System.Windows.Forms.TextBox();
            this.textbox_total_todoc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textbox_amount = new System.Windows.Forms.TextBox();
            this.textbox_total = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textbox_igv = new System.Windows.Forms.TextBox();
            this.grid_orderline = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textbox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_ruc = new System.Windows.Forms.TextBox();
            this.label_doc = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.combo_doc = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.combo_orderstatus = new System.Windows.Forms.ComboBox();
            this.date_deliverydate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_seedoc = new System.Windows.Forms.Button();
            this.button_fac = new System.Windows.Forms.Button();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toFacColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_orderline)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.grid_orderline);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox2.Location = new System.Drawing.Point(304, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(685, 422);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Productos";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button_calculate);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.textbox_amount_todoc);
            this.groupBox5.Controls.Add(this.textbox_igv_todoc);
            this.groupBox5.Controls.Add(this.textbox_total_todoc);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(350, 201);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(310, 209);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "A Facturar";
            // 
            // button_calculate
            // 
            this.button_calculate.BackColor = System.Drawing.Color.Gray;
            this.button_calculate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_calculate.ForeColor = System.Drawing.Color.White;
            this.button_calculate.Location = new System.Drawing.Point(184, 23);
            this.button_calculate.Margin = new System.Windows.Forms.Padding(2);
            this.button_calculate.Name = "button_calculate";
            this.button_calculate.Size = new System.Drawing.Size(107, 39);
            this.button_calculate.TabIndex = 42;
            this.button_calculate.Text = "+ Calcular";
            this.button_calculate.UseVisualStyleBackColor = false;
            this.button_calculate.Click += new System.EventHandler(this.button_calculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "Venta";
            // 
            // textbox_amount_todoc
            // 
            this.textbox_amount_todoc.BackColor = System.Drawing.Color.White;
            this.textbox_amount_todoc.Enabled = false;
            this.textbox_amount_todoc.Font = new System.Drawing.Font("Arial", 11F);
            this.textbox_amount_todoc.Location = new System.Drawing.Point(19, 74);
            this.textbox_amount_todoc.Name = "textbox_amount_todoc";
            this.textbox_amount_todoc.Size = new System.Drawing.Size(271, 24);
            this.textbox_amount_todoc.TabIndex = 36;
            this.textbox_amount_todoc.Text = "S/.  0.00";
            // 
            // textbox_igv_todoc
            // 
            this.textbox_igv_todoc.BackColor = System.Drawing.Color.White;
            this.textbox_igv_todoc.Enabled = false;
            this.textbox_igv_todoc.Font = new System.Drawing.Font("Arial", 11F);
            this.textbox_igv_todoc.Location = new System.Drawing.Point(19, 122);
            this.textbox_igv_todoc.Name = "textbox_igv_todoc";
            this.textbox_igv_todoc.Size = new System.Drawing.Size(271, 24);
            this.textbox_igv_todoc.TabIndex = 38;
            this.textbox_igv_todoc.Text = "S/.  0.00";
            // 
            // textbox_total_todoc
            // 
            this.textbox_total_todoc.BackColor = System.Drawing.Color.White;
            this.textbox_total_todoc.Enabled = false;
            this.textbox_total_todoc.Font = new System.Drawing.Font("Arial", 11F);
            this.textbox_total_todoc.Location = new System.Drawing.Point(18, 171);
            this.textbox_total_todoc.Name = "textbox_total_todoc";
            this.textbox_total_todoc.Size = new System.Drawing.Size(273, 24);
            this.textbox_total_todoc.TabIndex = 40;
            this.textbox_total_todoc.Text = "S/.  0.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 18);
            this.label8.TabIndex = 39;
            this.label8.Text = "Monto Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 18);
            this.label5.TabIndex = 37;
            this.label5.Text = "IGV";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textbox_amount);
            this.groupBox4.Controls.Add(this.textbox_total);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textbox_igv);
            this.groupBox4.Location = new System.Drawing.Point(20, 201);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(310, 209);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pedido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "Venta";
            // 
            // textbox_amount
            // 
            this.textbox_amount.BackColor = System.Drawing.Color.White;
            this.textbox_amount.Enabled = false;
            this.textbox_amount.Font = new System.Drawing.Font("Arial", 11F);
            this.textbox_amount.Location = new System.Drawing.Point(19, 74);
            this.textbox_amount.Name = "textbox_amount";
            this.textbox_amount.Size = new System.Drawing.Size(272, 24);
            this.textbox_amount.TabIndex = 30;
            this.textbox_amount.Text = "S/.  0.00";
            // 
            // textbox_total
            // 
            this.textbox_total.BackColor = System.Drawing.Color.White;
            this.textbox_total.Enabled = false;
            this.textbox_total.Font = new System.Drawing.Font("Arial", 11F);
            this.textbox_total.Location = new System.Drawing.Point(20, 171);
            this.textbox_total.Name = "textbox_total";
            this.textbox_total.Size = new System.Drawing.Size(272, 24);
            this.textbox_total.TabIndex = 34;
            this.textbox_total.Text = "S/.  0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 18);
            this.label9.TabIndex = 31;
            this.label9.Text = "IGV";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 18);
            this.label10.TabIndex = 33;
            this.label10.Text = "Monto Total";
            // 
            // textbox_igv
            // 
            this.textbox_igv.BackColor = System.Drawing.Color.White;
            this.textbox_igv.Enabled = false;
            this.textbox_igv.Font = new System.Drawing.Font("Arial", 11F);
            this.textbox_igv.Location = new System.Drawing.Point(20, 122);
            this.textbox_igv.Name = "textbox_igv";
            this.textbox_igv.Size = new System.Drawing.Size(272, 24);
            this.textbox_igv.TabIndex = 32;
            this.textbox_igv.Text = "S/.  0.00";
            // 
            // grid_orderline
            // 
            this.grid_orderline.AllowUserToAddRows = false;
            this.grid_orderline.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_orderline.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grid_orderline.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_orderline.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_orderline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_orderline.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Producto,
            this.Column1,
            this.Column2,
            this.Cantidad,
            this.toFacColumn,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_orderline.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_orderline.Location = new System.Drawing.Point(10, 26);
            this.grid_orderline.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.grid_orderline.Name = "grid_orderline";
            this.grid_orderline.RowHeadersVisible = false;
            this.grid_orderline.Size = new System.Drawing.Size(667, 165);
            this.grid_orderline.TabIndex = 22;
            this.grid_orderline.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grid_orderline_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textbox_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textbox_ruc);
            this.groupBox1.Controls.Add(this.label_doc);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 308);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 177);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // textbox_name
            // 
            this.textbox_name.BackColor = System.Drawing.Color.White;
            this.textbox_name.Enabled = false;
            this.textbox_name.Font = new System.Drawing.Font("Arial", 11F);
            this.textbox_name.Location = new System.Drawing.Point(17, 124);
            this.textbox_name.Name = "textbox_name";
            this.textbox_name.Size = new System.Drawing.Size(243, 24);
            this.textbox_name.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nombre";
            // 
            // textbox_ruc
            // 
            this.textbox_ruc.BackColor = System.Drawing.Color.White;
            this.textbox_ruc.Enabled = false;
            this.textbox_ruc.Font = new System.Drawing.Font("Arial", 11F);
            this.textbox_ruc.Location = new System.Drawing.Point(18, 62);
            this.textbox_ruc.Name = "textbox_ruc";
            this.textbox_ruc.Size = new System.Drawing.Size(242, 24);
            this.textbox_ruc.TabIndex = 17;
            // 
            // label_doc
            // 
            this.label_doc.AutoSize = true;
            this.label_doc.Location = new System.Drawing.Point(14, 40);
            this.label_doc.Name = "label_doc";
            this.label_doc.Size = new System.Drawing.Size(88, 18);
            this.label_doc.TabIndex = 16;
            this.label_doc.Text = "Documento";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.combo_doc);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.combo_orderstatus);
            this.groupBox3.Controls.Add(this.date_deliverydate);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox3.Location = new System.Drawing.Point(12, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(277, 281);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pedido";
            // 
            // combo_doc
            // 
            this.combo_doc.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.combo_doc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_doc.Enabled = false;
            this.combo_doc.Font = new System.Drawing.Font("Arial", 11F);
            this.combo_doc.FormattingEnabled = true;
            this.combo_doc.Items.AddRange(new object[] {
            "Boleta",
            "Factura"});
            this.combo_doc.Location = new System.Drawing.Point(17, 136);
            this.combo_doc.Name = "combo_doc";
            this.combo_doc.Size = new System.Drawing.Size(243, 25);
            this.combo_doc.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Estado";
            // 
            // combo_orderstatus
            // 
            this.combo_orderstatus.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.combo_orderstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_orderstatus.Enabled = false;
            this.combo_orderstatus.Font = new System.Drawing.Font("Arial", 11F);
            this.combo_orderstatus.FormattingEnabled = true;
            this.combo_orderstatus.Items.AddRange(new object[] {
            "Registrado",
            "Entrega Parcial",
            "Entregado"});
            this.combo_orderstatus.Location = new System.Drawing.Point(18, 210);
            this.combo_orderstatus.Name = "combo_orderstatus";
            this.combo_orderstatus.Size = new System.Drawing.Size(242, 25);
            this.combo_orderstatus.TabIndex = 14;
            // 
            // date_deliverydate
            // 
            this.date_deliverydate.CalendarMonthBackground = System.Drawing.SystemColors.InactiveBorder;
            this.date_deliverydate.Enabled = false;
            this.date_deliverydate.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_deliverydate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_deliverydate.Location = new System.Drawing.Point(17, 63);
            this.date_deliverydate.Name = "date_deliverydate";
            this.date_deliverydate.Size = new System.Drawing.Size(243, 24);
            this.date_deliverydate.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F);
            this.label6.Location = new System.Drawing.Point(14, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha de entrega";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Documento de pago";
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(740, 451);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(107, 39);
            this.button_delete.TabIndex = 38;
            this.button_delete.Text = "🗑 Eliminar";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_seedoc
            // 
            this.button_seedoc.BackColor = System.Drawing.Color.Gray;
            this.button_seedoc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_seedoc.ForeColor = System.Drawing.Color.White;
            this.button_seedoc.Location = new System.Drawing.Point(552, 451);
            this.button_seedoc.Margin = new System.Windows.Forms.Padding(2);
            this.button_seedoc.Name = "button_seedoc";
            this.button_seedoc.Size = new System.Drawing.Size(183, 39);
            this.button_seedoc.TabIndex = 40;
            this.button_seedoc.Text = "🔍 Ver Documentos";
            this.button_seedoc.UseVisualStyleBackColor = false;
            this.button_seedoc.Click += new System.EventHandler(this.button_seedoc_Click);
            // 
            // button_fac
            // 
            this.button_fac.BackColor = System.Drawing.Color.Gray;
            this.button_fac.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_fac.ForeColor = System.Drawing.Color.White;
            this.button_fac.Location = new System.Drawing.Point(441, 451);
            this.button_fac.Margin = new System.Windows.Forms.Padding(2);
            this.button_fac.Name = "button_fac";
            this.button_fac.Size = new System.Drawing.Size(107, 39);
            this.button_fac.TabIndex = 41;
            this.button_fac.Text = "🗀 Facturar";
            this.button_fac.UseVisualStyleBackColor = false;
            this.button_fac.Click += new System.EventHandler(this.button_fac_Click);
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.FillWeight = 45F;
            this.Column5.HeaderText = "ID";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Producto
            // 
            this.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Producto.FillWeight = 130F;
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.FillWeight = 80F;
            this.Column1.HeaderText = "Versión";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 60F;
            this.Column2.HeaderText = "PU";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cantidad.FillWeight = 70F;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // toFacColumn
            // 
            this.toFacColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.toFacColumn.FillWeight = 70F;
            this.toFacColumn.HeaderText = "A facturar";
            this.toFacColumn.Name = "toFacColumn";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.FillWeight = 80F;
            this.Column3.HeaderText = "Disponible para entrega";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.FillWeight = 75F;
            this.Column4.HeaderText = "Facturado";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // ClientOrderShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1001, 515);
            this.Controls.Add(this.button_fac);
            this.Controls.Add(this.button_seedoc);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ClientOrderShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista de venta";
            this.Load += new System.EventHandler(this.ClientOrderShow_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_orderline)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grid_orderline;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textbox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_ruc;
        private System.Windows.Forms.Label label_doc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker date_deliverydate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox combo_orderstatus;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.ComboBox combo_doc;
        private System.Windows.Forms.TextBox textbox_total;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textbox_igv;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textbox_amount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_seedoc;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_amount_todoc;
        private System.Windows.Forms.TextBox textbox_igv_todoc;
        private System.Windows.Forms.TextBox textbox_total_todoc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_fac;
        private System.Windows.Forms.Button button_calculate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn toFacColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}