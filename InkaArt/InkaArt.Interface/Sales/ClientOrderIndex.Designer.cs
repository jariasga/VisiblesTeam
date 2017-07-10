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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid_orders = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button_create_dev = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.date_deliveryDate_ini = new System.Windows.Forms.DateTimePicker();
            this.date_deliveryDate_end = new System.Windows.Forms.DateTimePicker();
            this.checkbox_enabledate = new System.Windows.Forms.CheckBox();
            this.combo_type = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.combo_orderStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textbox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_doc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_create = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_orders)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_orders
            // 
            this.grid_orders.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F);
            this.grid_orders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_orders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_orders.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grid_orders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_orders.DefaultCellStyle = dataGridViewCellStyle3;
            this.grid_orders.Location = new System.Drawing.Point(34, 198);
            this.grid_orders.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.grid_orders.Name = "grid_orders";
            this.grid_orders.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid_orders.Size = new System.Drawing.Size(682, 207);
            this.grid_orders.TabIndex = 24;
            this.grid_orders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_orders_CellDoubleClick);
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
            this.deleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.deleteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // button_create_dev
            // 
            this.button_create_dev.BackColor = System.Drawing.Color.SteelBlue;
            this.button_create_dev.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_create_dev.ForeColor = System.Drawing.Color.White;
            this.button_create_dev.Location = new System.Drawing.Point(295, 424);
            this.button_create_dev.Margin = new System.Windows.Forms.Padding(2);
            this.button_create_dev.Name = "button_create_dev";
            this.button_create_dev.Size = new System.Drawing.Size(122, 39);
            this.button_create_dev.TabIndex = 23;
            this.button_create_dev.Text = "＋ Devolución";
            this.button_create_dev.UseVisualStyleBackColor = false;
            this.button_create_dev.Click += new System.EventHandler(this.button_create_dev_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.date_deliveryDate_ini);
            this.groupBox1.Controls.Add(this.date_deliveryDate_end);
            this.groupBox1.Controls.Add(this.checkbox_enabledate);
            this.groupBox1.Controls.Add(this.combo_type);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.combo_orderStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textbox_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textbox_doc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_search);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox1.Location = new System.Drawing.Point(34, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 158);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // date_deliveryDate_ini
            // 
            this.date_deliveryDate_ini.CalendarMonthBackground = System.Drawing.SystemColors.InactiveBorder;
            this.date_deliveryDate_ini.Enabled = false;
            this.date_deliveryDate_ini.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_deliveryDate_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_deliveryDate_ini.Location = new System.Drawing.Point(226, 111);
            this.date_deliveryDate_ini.Name = "date_deliveryDate_ini";
            this.date_deliveryDate_ini.Size = new System.Drawing.Size(104, 24);
            this.date_deliveryDate_ini.TabIndex = 23;
            // 
            // date_deliveryDate_end
            // 
            this.date_deliveryDate_end.Enabled = false;
            this.date_deliveryDate_end.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_deliveryDate_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_deliveryDate_end.Location = new System.Drawing.Point(335, 111);
            this.date_deliveryDate_end.Margin = new System.Windows.Forms.Padding(2);
            this.date_deliveryDate_end.Name = "date_deliveryDate_end";
            this.date_deliveryDate_end.Size = new System.Drawing.Size(102, 24);
            this.date_deliveryDate_end.TabIndex = 28;
            // 
            // checkbox_enabledate
            // 
            this.checkbox_enabledate.AutoSize = true;
            this.checkbox_enabledate.Location = new System.Drawing.Point(226, 88);
            this.checkbox_enabledate.Margin = new System.Windows.Forms.Padding(2);
            this.checkbox_enabledate.Name = "checkbox_enabledate";
            this.checkbox_enabledate.Size = new System.Drawing.Size(152, 22);
            this.checkbox_enabledate.TabIndex = 29;
            this.checkbox_enabledate.Text = "Fecha de Entrega";
            this.checkbox_enabledate.UseVisualStyleBackColor = true;
            this.checkbox_enabledate.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // combo_type
            // 
            this.combo_type.BackColor = System.Drawing.Color.White;
            this.combo_type.Font = new System.Drawing.Font("Arial", 11F);
            this.combo_type.FormattingEnabled = true;
            this.combo_type.Items.AddRange(new object[] {
            "Pedido",
            "Devolucion"});
            this.combo_type.Location = new System.Drawing.Point(24, 50);
            this.combo_type.Name = "combo_type";
            this.combo_type.Size = new System.Drawing.Size(174, 25);
            this.combo_type.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "Tipo";
            // 
            // combo_orderStatus
            // 
            this.combo_orderStatus.BackColor = System.Drawing.Color.White;
            this.combo_orderStatus.Font = new System.Drawing.Font("Arial", 11F);
            this.combo_orderStatus.FormattingEnabled = true;
            this.combo_orderStatus.Items.AddRange(new object[] {
            "Registrado",
            "Producción",
            "Despachado",
            "Entrega Parcial",
            "Entregado"});
            this.combo_orderStatus.Location = new System.Drawing.Point(24, 110);
            this.combo_orderStatus.Name = "combo_orderStatus";
            this.combo_orderStatus.Size = new System.Drawing.Size(174, 25);
            this.combo_orderStatus.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "Estado";
            // 
            // textbox_name
            // 
            this.textbox_name.BackColor = System.Drawing.Color.White;
            this.textbox_name.Font = new System.Drawing.Font("Arial", 11F);
            this.textbox_name.Location = new System.Drawing.Point(466, 50);
            this.textbox_name.Name = "textbox_name";
            this.textbox_name.Size = new System.Drawing.Size(192, 24);
            this.textbox_name.TabIndex = 19;
            this.textbox_name.TextChanged += new System.EventHandler(this.textbox_name_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(463, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nombre Cliente";
            // 
            // textbox_doc
            // 
            this.textbox_doc.BackColor = System.Drawing.Color.White;
            this.textbox_doc.Font = new System.Drawing.Font("Arial", 11F);
            this.textbox_doc.Location = new System.Drawing.Point(226, 50);
            this.textbox_doc.Name = "textbox_doc";
            this.textbox_doc.Size = new System.Drawing.Size(211, 24);
            this.textbox_doc.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Documento Cliente";
            // 
            // button_search
            // 
            this.button_search.BackColor = System.Drawing.Color.Gray;
            this.button_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search.ForeColor = System.Drawing.Color.White;
            this.button_search.Location = new System.Drawing.Point(520, 96);
            this.button_search.Margin = new System.Windows.Forms.Padding(2);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(88, 39);
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
            this.button_delete.Location = new System.Drawing.Point(442, 424);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(131, 39);
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
            this.button_create.Location = new System.Drawing.Point(149, 424);
            this.button_create.Margin = new System.Windows.Forms.Padding(2);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(122, 39);
            this.button_create.TabIndex = 38;
            this.button_create.Text = "＋ Pedido";
            this.button_create.UseVisualStyleBackColor = false;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // ClientOrderIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(753, 491);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grid_orders);
            this.Controls.Add(this.button_create_dev);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ClientOrderIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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