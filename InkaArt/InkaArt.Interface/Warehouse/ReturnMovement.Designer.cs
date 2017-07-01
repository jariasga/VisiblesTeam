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
            this.id_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_return = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock_min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock_max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to_return = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StockLogico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.grid_dev_detail = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.combobox_dev = new System.Windows.Forms.ComboBox();
            this.date_dev = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_client = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_devolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_dev_detail)).BeginInit();
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
            this.grid_devolution.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.grid_devolution.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_devolution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_devolution.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_product,
            this.name_product,
            this.total_return,
            this.stock,
            this.stock_min,
            this.stock_max,
            this.to_return,
            this.returned,
            this.Modificar,
            this.StockLogico});
            this.grid_devolution.Location = new System.Drawing.Point(26, 41);
            this.grid_devolution.Margin = new System.Windows.Forms.Padding(2);
            this.grid_devolution.Name = "grid_devolution";
            this.grid_devolution.Size = new System.Drawing.Size(842, 156);
            this.grid_devolution.TabIndex = 57;
            this.grid_devolution.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDevolutionCellValueChanged);
            // 
            // id_product
            // 
            this.id_product.HeaderText = "Id Producto";
            this.id_product.Name = "id_product";
            this.id_product.ReadOnly = true;
            this.id_product.Visible = false;
            // 
            // name_product
            // 
            this.name_product.HeaderText = "Producto";
            this.name_product.Name = "name_product";
            this.name_product.ReadOnly = true;
            // 
            // total_return
            // 
            this.total_return.HeaderText = "Cantidad Total";
            this.total_return.Name = "total_return";
            this.total_return.ReadOnly = true;
            // 
            // stock
            // 
            this.stock.HeaderText = "Stock en almacén";
            this.stock.Name = "stock";
            this.stock.ReadOnly = true;
            // 
            // stock_min
            // 
            this.stock_min.HeaderText = "Stock Mínimo";
            this.stock_min.Name = "stock_min";
            this.stock_min.ReadOnly = true;
            // 
            // stock_max
            // 
            this.stock_max.HeaderText = "Stock Máximo";
            this.stock_max.Name = "stock_max";
            this.stock_max.ReadOnly = true;
            // 
            // to_return
            // 
            this.to_return.HeaderText = "Cantidad a devolver";
            this.to_return.Name = "to_return";
            // 
            // returned
            // 
            this.returned.HeaderText = "Cantidad por devolver";
            this.returned.Name = "returned";
            this.returned.ReadOnly = true;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
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
            this.button_cancel.Text = "Cancelar";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.buttonDelete_Click);
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
            this.button_save.Text = "Guardar";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.buttonSaveClick);
            // 
            // grid_dev_detail
            // 
            this.grid_dev_detail.AllowUserToAddRows = false;
            this.grid_dev_detail.AllowUserToDeleteRows = false;
            this.grid_dev_detail.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.grid_dev_detail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_dev_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_dev_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product,
            this.status});
            this.grid_dev_detail.Location = new System.Drawing.Point(474, 32);
            this.grid_dev_detail.Margin = new System.Windows.Forms.Padding(2);
            this.grid_dev_detail.Name = "grid_dev_detail";
            this.grid_dev_detail.Size = new System.Drawing.Size(394, 119);
            this.grid_dev_detail.TabIndex = 56;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grid_dev_detail);
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
            this.combobox_dev.FormattingEnabled = true;
            this.combobox_dev.Location = new System.Drawing.Point(25, 54);
            this.combobox_dev.Margin = new System.Windows.Forms.Padding(2);
            this.combobox_dev.Name = "combobox_dev";
            this.combobox_dev.Size = new System.Drawing.Size(194, 26);
            this.combobox_dev.Sorted = true;
            this.combobox_dev.TabIndex = 31;
            this.combobox_dev.SelectedIndexChanged += new System.EventHandler(this.comboboxDevSelectedIndexChanged);
            // 
            // date_dev
            // 
            this.date_dev.Enabled = false;
            this.date_dev.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_dev.Location = new System.Drawing.Point(235, 54);
            this.date_dev.Name = "date_dev";
            this.date_dev.Size = new System.Drawing.Size(194, 26);
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
            this.textbox_client.Location = new System.Drawing.Point(235, 125);
            this.textbox_client.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_client.Name = "textbox_client";
            this.textbox_client.ReadOnly = true;
            this.textbox_client.Size = new System.Drawing.Size(194, 26);
            this.textbox_client.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 105);
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
            this.product.HeaderText = "Producto";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            this.product.Width = 150;
            // 
            // status
            // 
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
            ((System.ComponentModel.ISupportInitialize)(this.grid_dev_detail)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grid_devolution;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_return;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock_min;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock_max;
        private System.Windows.Forms.DataGridViewTextBoxColumn to_return;
        private System.Windows.Forms.DataGridViewTextBoxColumn returned;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Modificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockLogico;
        private System.Windows.Forms.DataGridView grid_dev_detail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox combobox_dev;
        private System.Windows.Forms.DateTimePicker date_dev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_client;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}