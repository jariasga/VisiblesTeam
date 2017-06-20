namespace InkaArt.Interface.Sales
{
    partial class ClientOrderIndex
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
            this.grid_orders = new System.Windows.Forms.DataGridView();
            this.button_create_dev = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkbox_enabledate = new System.Windows.Forms.CheckBox();
            this.date_deliveryDate_end = new System.Windows.Forms.DateTimePicker();
            this.combo_type = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.date_deliveryDate_ini = new System.Windows.Forms.DateTimePicker();
            this.combo_orderStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textbox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_doc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_create = new System.Windows.Forms.Button();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_orders)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_orders
            // 
            this.grid_orders.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_orders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_orders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_orders.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.grid_orders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_orders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_orders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Tipo,
            this.cost,
            this.Cantidad,
            this.Column1,
            this.Column3,
            this.deleteColumn});
            this.grid_orders.Location = new System.Drawing.Point(45, 244);
            this.grid_orders.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.grid_orders.Name = "grid_orders";
            this.grid_orders.ReadOnly = true;
            this.grid_orders.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid_orders.Size = new System.Drawing.Size(891, 255);
            this.grid_orders.TabIndex = 24;
            this.grid_orders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_orders_CellDoubleClick);
            // 
            // button_create_dev
            // 
            this.button_create_dev.BackColor = System.Drawing.Color.SteelBlue;
            this.button_create_dev.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_create_dev.ForeColor = System.Drawing.Color.White;
            this.button_create_dev.Location = new System.Drawing.Point(393, 522);
            this.button_create_dev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_create_dev.Name = "button_create_dev";
            this.button_create_dev.Size = new System.Drawing.Size(163, 48);
            this.button_create_dev.TabIndex = 23;
            this.button_create_dev.Text = "＋ Devolución";
            this.button_create_dev.UseVisualStyleBackColor = false;
            this.button_create_dev.Click += new System.EventHandler(this.button_create_dev_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkbox_enabledate);
            this.groupBox1.Controls.Add(this.date_deliveryDate_end);
            this.groupBox1.Controls.Add(this.combo_type);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.date_deliveryDate_ini);
            this.groupBox1.Controls.Add(this.combo_orderStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textbox_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textbox_doc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_search);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox1.Location = new System.Drawing.Point(45, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(891, 194);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // checkbox_enabledate
            // 
            this.checkbox_enabledate.AutoSize = true;
            this.checkbox_enabledate.Location = new System.Drawing.Point(316, 106);
            this.checkbox_enabledate.Name = "checkbox_enabledate";
            this.checkbox_enabledate.Size = new System.Drawing.Size(189, 27);
            this.checkbox_enabledate.TabIndex = 29;
            this.checkbox_enabledate.Text = "Fecha de Entrega";
            this.checkbox_enabledate.UseVisualStyleBackColor = true;
            this.checkbox_enabledate.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // date_deliveryDate_end
            // 
            this.date_deliveryDate_end.Enabled = false;
            this.date_deliveryDate_end.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_deliveryDate_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_deliveryDate_end.Location = new System.Drawing.Point(482, 135);
            this.date_deliveryDate_end.Name = "date_deliveryDate_end";
            this.date_deliveryDate_end.Size = new System.Drawing.Size(134, 30);
            this.date_deliveryDate_end.TabIndex = 28;
            // 
            // combo_type
            // 
            this.combo_type.BackColor = System.Drawing.Color.White;
            this.combo_type.FormattingEnabled = true;
            this.combo_type.Items.AddRange(new object[] {
            "Pedido",
            "Devolucion"});
            this.combo_type.Location = new System.Drawing.Point(32, 62);
            this.combo_type.Margin = new System.Windows.Forms.Padding(4);
            this.combo_type.Name = "combo_type";
            this.combo_type.Size = new System.Drawing.Size(255, 31);
            this.combo_type.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 23);
            this.label5.TabIndex = 25;
            this.label5.Text = "Tipo";
            // 
            // date_deliveryDate_ini
            // 
            this.date_deliveryDate_ini.CalendarMonthBackground = System.Drawing.SystemColors.InactiveBorder;
            this.date_deliveryDate_ini.Enabled = false;
            this.date_deliveryDate_ini.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_deliveryDate_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_deliveryDate_ini.Location = new System.Drawing.Point(316, 135);
            this.date_deliveryDate_ini.Margin = new System.Windows.Forms.Padding(4);
            this.date_deliveryDate_ini.Name = "date_deliveryDate_ini";
            this.date_deliveryDate_ini.Size = new System.Drawing.Size(138, 30);
            this.date_deliveryDate_ini.TabIndex = 23;
            // 
            // combo_orderStatus
            // 
            this.combo_orderStatus.BackColor = System.Drawing.Color.White;
            this.combo_orderStatus.FormattingEnabled = true;
            this.combo_orderStatus.Items.AddRange(new object[] {
            "Registrado",
            "Producción",
            "Despachado",
            "Entrega Parcial",
            "Entregado"});
            this.combo_orderStatus.Location = new System.Drawing.Point(32, 135);
            this.combo_orderStatus.Margin = new System.Windows.Forms.Padding(4);
            this.combo_orderStatus.Name = "combo_orderStatus";
            this.combo_orderStatus.Size = new System.Drawing.Size(255, 31);
            this.combo_orderStatus.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 20;
            this.label3.Text = "Estado";
            // 
            // textbox_name
            // 
            this.textbox_name.BackColor = System.Drawing.Color.White;
            this.textbox_name.Location = new System.Drawing.Point(603, 62);
            this.textbox_name.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_name.Name = "textbox_name";
            this.textbox_name.Size = new System.Drawing.Size(255, 30);
            this.textbox_name.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nombre Cliente";
            // 
            // textbox_doc
            // 
            this.textbox_doc.BackColor = System.Drawing.Color.White;
            this.textbox_doc.Location = new System.Drawing.Point(316, 62);
            this.textbox_doc.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_doc.Name = "textbox_doc";
            this.textbox_doc.Size = new System.Drawing.Size(255, 30);
            this.textbox_doc.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Documento Cliente";
            // 
            // button_search
            // 
            this.button_search.BackColor = System.Drawing.Color.Gray;
            this.button_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search.ForeColor = System.Drawing.Color.White;
            this.button_search.Location = new System.Drawing.Point(677, 119);
            this.button_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(117, 48);
            this.button_search.TabIndex = 15;
            this.button_search.Text = "🔎 Buscar";
            this.button_search.UseVisualStyleBackColor = false;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(589, 522);
            this.button_delete.Margin = new System.Windows.Forms.Padding(4);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(175, 48);
            this.button_delete.TabIndex = 37;
            this.button_delete.Text = "🗑 Eliminar";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_create
            // 
            this.button_create.BackColor = System.Drawing.Color.SteelBlue;
            this.button_create.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_create.ForeColor = System.Drawing.Color.White;
            this.button_create.Location = new System.Drawing.Point(199, 522);
            this.button_create.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(163, 48);
            this.button_create.TabIndex = 38;
            this.button_create.Text = "＋ Pedido";
            this.button_create.UseVisualStyleBackColor = false;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // Column4
            // 
            this.Column4.FillWeight = 40F;
            this.Column4.HeaderText = "ID";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // cost
            // 
            this.cost.FillWeight = 150F;
            this.cost.HeaderText = "Nombre Cliente";
            this.cost.Name = "cost";
            this.cost.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "RUC/DNI Cliente";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Estado";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Monto";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // deleteColumn
            // 
            this.deleteColumn.HeaderText = "Eliminar";
            this.deleteColumn.Name = "deleteColumn";
            this.deleteColumn.ReadOnly = true;
            this.deleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deleteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ClientOrderIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(981, 604);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grid_orders);
            this.Controls.Add(this.button_create_dev);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientOrderIndex";
            this.Text = "Lista de Pedidos";
            this.Load += new System.EventHandler(this.ClientOrderIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_orders)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView grid_orders;
        private System.Windows.Forms.Button button_create_dev;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textbox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_doc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker date_deliveryDate_ini;
        private System.Windows.Forms.ComboBox combo_orderStatus;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.ComboBox combo_type;
        private System.Windows.Forms.DateTimePicker date_deliveryDate_end;
        private System.Windows.Forms.CheckBox checkbox_enabledate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn deleteColumn;
    }
}