namespace InkaArt.Interface.Warehouse
{
    partial class ReturnMovement
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grid_devolution = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.current_stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min_stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.max_stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to_return = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_warehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockLogico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.grid_devolution_detail = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.combobox_dev = new System.Windows.Forms.ComboBox();
            this.date_dev = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_client = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_devolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_devolution_detail)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grid_devolution);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(31, 202);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(897, 218);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "En Almacén";
            // 
            // grid_devolution
            // 
            this.grid_devolution.AllowUserToAddRows = false;
            this.grid_devolution.AllowUserToDeleteRows = false;
            this.grid_devolution.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.grid_devolution.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_devolution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_devolution.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.current_stock,
            this.min_stock,
            this.max_stock,
            this.total_quantity,
            this.product_stock,
            this.to_return,
            this.id_product,
            this.id_line,
            this.id_warehouse,
            this.id_stock,
            this.StockLogico});
            this.grid_devolution.Location = new System.Drawing.Point(26, 41);
            this.grid_devolution.Margin = new System.Windows.Forms.Padding(2);
            this.grid_devolution.Name = "grid_devolution";
            this.grid_devolution.Size = new System.Drawing.Size(842, 156);
            this.grid_devolution.TabIndex = 57;
            this.grid_devolution.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDevolutionCellValueChanged);
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Producto";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // current_stock
            // 
            this.current_stock.DataPropertyName = "current_stock";
            this.current_stock.HeaderText = "Stock Actual";
            this.current_stock.Name = "current_stock";
            this.current_stock.ReadOnly = true;
            // 
            // min_stock
            // 
            this.min_stock.DataPropertyName = "min_stock";
            this.min_stock.HeaderText = "Stock Mínimo";
            this.min_stock.Name = "min_stock";
            this.min_stock.ReadOnly = true;
            // 
            // max_stock
            // 
            this.max_stock.DataPropertyName = "max_stock";
            this.max_stock.HeaderText = "Stock Máximo";
            this.max_stock.Name = "max_stock";
            this.max_stock.ReadOnly = true;
            // 
            // total_quantity
            // 
            this.total_quantity.DataPropertyName = "quantity";
            this.total_quantity.HeaderText = "Cantidad Devolución";
            this.total_quantity.Name = "total_quantity";
            this.total_quantity.ReadOnly = true;
            // 
            // product_stock
            // 
            this.product_stock.DataPropertyName = "product_stock";
            this.product_stock.HeaderText = "Cantidad Pendiente";
            this.product_stock.Name = "product_stock";
            this.product_stock.ReadOnly = true;
            // 
            // to_return
            // 
            this.to_return.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.to_return.HeaderText = "Cantidad Ingreso";
            this.to_return.Name = "to_return";
            // 
            // id_product
            // 
            this.id_product.DataPropertyName = "idProduct";
            this.id_product.HeaderText = "Producto";
            this.id_product.Name = "id_product";
            this.id_product.ReadOnly = true;
            this.id_product.Visible = false;
            // 
            // id_line
            // 
            this.id_line.DataPropertyName = "idLineItem";
            this.id_line.HeaderText = "Linea";
            this.id_line.Name = "id_line";
            this.id_line.Visible = false;
            // 
            // id_warehouse
            // 
            this.id_warehouse.DataPropertyName = "id_warehouse";
            this.id_warehouse.HeaderText = "Almacen";
            this.id_warehouse.Name = "id_warehouse";
            this.id_warehouse.Visible = false;
            // 
            // id_stock
            // 
            this.id_stock.DataPropertyName = "id_stock";
            this.id_stock.HeaderText = "Stock";
            this.id_stock.Name = "id_stock";
            this.id_stock.Visible = false;
            // 
            // StockLogico
            // 
            this.StockLogico.HeaderText = "Stock Logico";
            this.StockLogico.Name = "StockLogico";
            this.StockLogico.ReadOnly = true;
            this.StockLogico.Visible = false;
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.Firebrick;
            this.button_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.ForeColor = System.Drawing.Color.White;
            this.button_cancel.Location = new System.Drawing.Point(505, 443);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(138, 39);
            this.button_cancel.TabIndex = 58;
            this.button_cancel.Text = "🗙 Cancelar";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.buttonCancelClick);
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.SteelBlue;
            this.button_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(315, 443);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(138, 39);
            this.button_save.TabIndex = 57;
            this.button_save.Text = "🖫 Guardar";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.buttonSaveClick);
            // 
            // grid_devolution_detail
            // 
            this.grid_devolution_detail.AllowUserToAddRows = false;
            this.grid_devolution_detail.AllowUserToDeleteRows = false;
            this.grid_devolution_detail.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.grid_devolution_detail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_devolution_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_devolution_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product,
            this.quantity,
            this.status});
            this.grid_devolution_detail.Location = new System.Drawing.Point(402, 32);
            this.grid_devolution_detail.Margin = new System.Windows.Forms.Padding(2);
            this.grid_devolution_detail.Name = "grid_devolution_detail";
            this.grid_devolution_detail.Size = new System.Drawing.Size(466, 119);
            this.grid_devolution_detail.TabIndex = 56;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grid_devolution_detail);
            this.groupBox3.Controls.Add(this.combobox_dev);
            this.groupBox3.Controls.Add(this.date_dev);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textbox_client);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(31, 26);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(897, 172);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Devolución";
            // 
            // combobox_dev
            // 
            this.combobox_dev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_dev.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_dev.FormattingEnabled = true;
            this.combobox_dev.Location = new System.Drawing.Point(25, 54);
            this.combobox_dev.Margin = new System.Windows.Forms.Padding(2);
            this.combobox_dev.Name = "combobox_dev";
            this.combobox_dev.Size = new System.Drawing.Size(183, 25);
            this.combobox_dev.Sorted = true;
            this.combobox_dev.TabIndex = 31;
            this.combobox_dev.SelectedIndexChanged += new System.EventHandler(this.comboboxDevSelectedIndexChanged);
            // 
            // date_dev
            // 
            this.date_dev.Enabled = false;
            this.date_dev.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_dev.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_dev.Location = new System.Drawing.Point(235, 55);
            this.date_dev.Name = "date_dev";
            this.date_dev.Size = new System.Drawing.Size(138, 24);
            this.date_dev.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Fecha";
            // 
            // textbox_client
            // 
            this.textbox_client.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_client.Location = new System.Drawing.Point(25, 118);
            this.textbox_client.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_client.Name = "textbox_client";
            this.textbox_client.ReadOnly = true;
            this.textbox_client.Size = new System.Drawing.Size(348, 24);
            this.textbox_client.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "ID";
            // 
            // product
            // 
            this.product.DataPropertyName = "name";
            this.product.HeaderText = "Producto";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            this.product.Width = 150;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "Cantidad";
            this.quantity.Name = "quantity";
            // 
            // status
            // 
            this.status.DataPropertyName = "lineStatus";
            this.status.HeaderText = "Estado";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 150;
            // 
            // ReturnMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(958, 505);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReturnMovement";
            this.Text = "Movimiento de Devolución";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_devolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_devolution_detail)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grid_devolution;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.DataGridView grid_devolution_detail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox combobox_dev;
        private System.Windows.Forms.DateTimePicker date_dev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_client;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn current_stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn min_stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn max_stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn to_return;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_line;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_warehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockLogico;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}