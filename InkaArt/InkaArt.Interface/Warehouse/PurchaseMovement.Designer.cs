﻿namespace InkaArt.Interface.Warehouse
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_supplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_orders = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadPorMover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantMovement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_details = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_orders)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_details)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_OC);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_supplier);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_search);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(368, 172);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pedido";
            // 
            // comboBox_OC
            // 
            this.comboBox_OC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OC.FormattingEnabled = true;
            this.comboBox_OC.Location = new System.Drawing.Point(16, 54);
            this.comboBox_OC.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_OC.Name = "comboBox_OC";
            this.comboBox_OC.Size = new System.Drawing.Size(179, 26);
            this.comboBox_OC.Sorted = true;
            this.comboBox_OC.TabIndex = 31;
            this.comboBox_OC.SelectedIndexChanged += new System.EventHandler(this.comboBox_OC_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(228, 125);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(119, 26);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Fecha";
            // 
            // textBox_supplier
            // 
            this.textBox_supplier.Location = new System.Drawing.Point(16, 125);
            this.textBox_supplier.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_supplier.Name = "textBox_supplier";
            this.textBox_supplier.ReadOnly = true;
            this.textBox_supplier.Size = new System.Drawing.Size(179, 26);
            this.textBox_supplier.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Proveedor";
            // 
            // button_search
            // 
            this.button_search.BackColor = System.Drawing.Color.Gray;
            this.button_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search.ForeColor = System.Drawing.Color.White;
            this.button_search.Location = new System.Drawing.Point(228, 42);
            this.button_search.Margin = new System.Windows.Forms.Padding(2);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(119, 38);
            this.button_search.TabIndex = 16;
            this.button_search.Text = "🔎 Buscar";
            this.button_search.UseVisualStyleBackColor = false;
            this.button_search.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
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
            this.Seleccionar,
            this.idDetail});
            this.dataGridView_orders.Location = new System.Drawing.Point(17, 210);
            this.dataGridView_orders.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_orders.Name = "dataGridView_orders";
            this.dataGridView_orders.Size = new System.Drawing.Size(803, 171);
            this.dataGridView_orders.TabIndex = 45;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id Item";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 150;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 200;
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
            this.button2.Location = new System.Drawing.Point(158, 487);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 48);
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
            this.buttonDelete.Location = new System.Drawing.Point(412, 487);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(184, 48);
            this.buttonDelete.TabIndex = 55;
            this.buttonDelete.Text = "Cancelar";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_details);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(409, 20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(411, 172);
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
            this.dataGridView_details.Location = new System.Drawing.Point(30, 32);
            this.dataGridView_details.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_details.Name = "dataGridView_details";
            this.dataGridView_details.Size = new System.Drawing.Size(349, 132);
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
            // PurchaseMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 577);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView_orders);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PurchaseMovement";
            this.Text = "Movimiento por Compras";
            this.Load += new System.EventHandler(this.PurchaseMovement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_orders)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_details)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_supplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_orders;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_details;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadPorMover;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantMovement;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetail;
        private System.Windows.Forms.ComboBox comboBox_OC;
    }
}