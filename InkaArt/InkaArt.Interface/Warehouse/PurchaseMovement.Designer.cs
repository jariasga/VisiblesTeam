namespace InkaArt.Interface.Warehouse
{
    partial class PurchaseMovement
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
            this.comboBox_OC = new System.Windows.Forms.ComboBox();
            this.dateTime_purchaseOrder = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_supplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_orders = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadPorMover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantMovement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_details = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_orders)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_details)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_OC);
            this.groupBox1.Controls.Add(this.dateTime_purchaseOrder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_supplier);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(504, 212);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pedido";
            // 
            // comboBox_OC
            // 
            this.comboBox_OC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OC.FormattingEnabled = true;
            this.comboBox_OC.Location = new System.Drawing.Point(21, 66);
            this.comboBox_OC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_OC.Name = "comboBox_OC";
            this.comboBox_OC.Size = new System.Drawing.Size(237, 31);
            this.comboBox_OC.Sorted = true;
            this.comboBox_OC.TabIndex = 31;
            this.comboBox_OC.SelectedIndexChanged += new System.EventHandler(this.comboBox_OC_SelectedIndexChanged);
            // 
            // dateTime_purchaseOrder
            // 
            this.dateTime_purchaseOrder.Enabled = false;
            this.dateTime_purchaseOrder.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime_purchaseOrder.Location = new System.Drawing.Point(300, 67);
            this.dateTime_purchaseOrder.Margin = new System.Windows.Forms.Padding(4);
            this.dateTime_purchaseOrder.Name = "dateTime_purchaseOrder";
            this.dateTime_purchaseOrder.Size = new System.Drawing.Size(161, 30);
            this.dateTime_purchaseOrder.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Fecha de entrega";
            // 
            // textBox_supplier
            // 
            this.textBox_supplier.Location = new System.Drawing.Point(21, 154);
            this.textBox_supplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_supplier.Name = "textBox_supplier";
            this.textBox_supplier.ReadOnly = true;
            this.textBox_supplier.Size = new System.Drawing.Size(237, 30);
            this.textBox_supplier.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Proveedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Orden de Compra";
            // 
            // dataGridView_orders
            // 
            this.dataGridView_orders.AllowUserToAddRows = false;
            this.dataGridView_orders.AllowUserToDeleteRows = false;
            this.dataGridView_orders.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_orders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_orders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Cantidad,
            this.CantidadPorMover,
            this.cantMovement,
            this.NroFactura,
            this.Seleccionar,
            this.idDetail});
            this.dataGridView_orders.Location = new System.Drawing.Point(8, 54);
            this.dataGridView_orders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_orders.Name = "dataGridView_orders";
            this.dataGridView_orders.Size = new System.Drawing.Size(1059, 210);
            this.dataGridView_orders.TabIndex = 45;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id Item";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 150;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // CantidadPorMover
            // 
            this.CantidadPorMover.HeaderText = "Cantidad por Mover";
            this.CantidadPorMover.Name = "CantidadPorMover";
            this.CantidadPorMover.ReadOnly = true;
            // 
            // cantMovement
            // 
            this.cantMovement.HeaderText = "Cantidad a Mover";
            this.cantMovement.Name = "cantMovement";
            // 
            // NroFactura
            // 
            this.NroFactura.HeaderText = "NroFactura";
            this.NroFactura.Name = "NroFactura";
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // idDetail
            // 
            this.idDetail.HeaderText = "idDetail";
            this.idDetail.Name = "idDetail";
            this.idDetail.ReadOnly = true;
            this.idDetail.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SteelBlue;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(211, 599);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(245, 59);
            this.button2.TabIndex = 46;
            this.button2.Text = "Aceptar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(549, 599);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(245, 59);
            this.buttonDelete.TabIndex = 55;
            this.buttonDelete.Text = "Cancelar";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_details);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(545, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(548, 212);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalles";
            // 
            // dataGridView_details
            // 
            this.dataGridView_details.AllowUserToAddRows = false;
            this.dataGridView_details.AllowUserToDeleteRows = false;
            this.dataGridView_details.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_details.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_details.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.dataGridViewTextBoxColumn3});
            this.dataGridView_details.Location = new System.Drawing.Point(40, 39);
            this.dataGridView_details.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_details.Name = "dataGridView_details";
            this.dataGridView_details.Size = new System.Drawing.Size(465, 162);
            this.dataGridView_details.TabIndex = 56;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_orders);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(23, 257);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(1075, 304);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pedido";
            // 
            // PurchaseMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1112, 710);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PurchaseMovement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimiento por Compras";
            this.Load += new System.EventHandler(this.PurchaseMovement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_orders)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_details)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_supplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_orders;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DateTimePicker dateTime_purchaseOrder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_details;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ComboBox comboBox_OC;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadPorMover;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantMovement;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroFactura;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetail;
    }
}