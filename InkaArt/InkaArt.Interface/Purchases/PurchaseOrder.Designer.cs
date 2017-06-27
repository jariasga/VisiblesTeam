namespace InkaArt.Interface.Purchases
{
    partial class PurchaseOrder
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
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridView_purchaseOrder = new System.Windows.Forms.DataGridView();
            this.id_order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creation_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delivery_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_dateInclude = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_creationEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_creation = new System.Windows.Forms.DateTimePicker();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_purchaseOrder)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(415, 473);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(138, 39);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "🗑 Eliminar";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.button_delete);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAdd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(263, 473);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(138, 39);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "＋ Crear";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.button_add);
            // 
            // dataGridView_purchaseOrder
            // 
            this.dataGridView_purchaseOrder.AllowUserToAddRows = false;
            this.dataGridView_purchaseOrder.AllowUserToDeleteRows = false;
            this.dataGridView_purchaseOrder.AllowUserToResizeRows = false;
            this.dataGridView_purchaseOrder.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_purchaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_purchaseOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_purchaseOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_order,
            this.suppName,
            this.creation_date,
            this.delivery_date,
            this.total,
            this.status,
            this.id_supplier,
            this.Eliminar});
            this.dataGridView_purchaseOrder.Location = new System.Drawing.Point(23, 186);
            this.dataGridView_purchaseOrder.Name = "dataGridView_purchaseOrder";
            this.dataGridView_purchaseOrder.Size = new System.Drawing.Size(774, 272);
            this.dataGridView_purchaseOrder.TabIndex = 8;
            this.dataGridView_purchaseOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.editPurchaseOrder);
            // 
            // id_order
            // 
            this.id_order.HeaderText = "ID";
            this.id_order.Name = "id_order";
            this.id_order.ReadOnly = true;
            // 
            // suppName
            // 
            this.suppName.HeaderText = "Proveedor";
            this.suppName.Name = "suppName";
            this.suppName.ReadOnly = true;
            this.suppName.Width = 250;
            // 
            // creation_date
            // 
            this.creation_date.HeaderText = "Fecha de emisión";
            this.creation_date.Name = "creation_date";
            this.creation_date.ReadOnly = true;
            this.creation_date.Width = 140;
            // 
            // delivery_date
            // 
            this.delivery_date.HeaderText = "Fecha de entrega";
            this.delivery_date.Name = "delivery_date";
            this.delivery_date.ReadOnly = true;
            this.delivery_date.Visible = false;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Estado";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 80;
            // 
            // id_supplier
            // 
            this.id_supplier.HeaderText = "ID Prov";
            this.id_supplier.Name = "id_supplier";
            this.id_supplier.ReadOnly = true;
            this.id_supplier.Visible = false;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Eliminar.Width = 40;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_dateInclude);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker_creationEnd);
            this.groupBox1.Controls.Add(this.dateTimePicker_creation);
            this.groupBox1.Controls.Add(this.comboBox_status);
            this.groupBox1.Controls.Add(this.textBox_id);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox1.Location = new System.Drawing.Point(23, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 158);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // checkBox_dateInclude
            // 
            this.checkBox_dateInclude.AutoSize = true;
            this.checkBox_dateInclude.Location = new System.Drawing.Point(240, 87);
            this.checkBox_dateInclude.Name = "checkBox_dateInclude";
            this.checkBox_dateInclude.Size = new System.Drawing.Size(152, 22);
            this.checkBox_dateInclude.TabIndex = 32;
            this.checkBox_dateInclude.Text = "Fecha de emisión";
            this.checkBox_dateInclude.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 18);
            this.label6.TabIndex = 31;
            this.label6.Text = "Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 18);
            this.label2.TabIndex = 30;
            this.label2.Text = "Fin";
            // 
            // dateTimePicker_creationEnd
            // 
            this.dateTimePicker_creationEnd.Font = new System.Drawing.Font("Arial", 11F);
            this.dateTimePicker_creationEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_creationEnd.Location = new System.Drawing.Point(509, 110);
            this.dateTimePicker_creationEnd.Name = "dateTimePicker_creationEnd";
            this.dateTimePicker_creationEnd.Size = new System.Drawing.Size(146, 24);
            this.dateTimePicker_creationEnd.TabIndex = 29;
            this.dateTimePicker_creationEnd.ValueChanged += new System.EventHandler(this.activarCheckbox);
            // 
            // dateTimePicker_creation
            // 
            this.dateTimePicker_creation.Checked = false;
            this.dateTimePicker_creation.Font = new System.Drawing.Font("Arial", 11F);
            this.dateTimePicker_creation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_creation.Location = new System.Drawing.Point(306, 110);
            this.dateTimePicker_creation.Name = "dateTimePicker_creation";
            this.dateTimePicker_creation.Size = new System.Drawing.Size(146, 24);
            this.dateTimePicker_creation.TabIndex = 28;
            this.dateTimePicker_creation.ValueChanged += new System.EventHandler(this.activarCheckbox);
            // 
            // comboBox_status
            // 
            this.comboBox_status.BackColor = System.Drawing.Color.White;
            this.comboBox_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_status.Font = new System.Drawing.Font("Arial", 11F);
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Items.AddRange(new object[] {
            "",
            "Borrador",
            "Enviado",
            "Entregado",
            "Eliminado"});
            this.comboBox_status.Location = new System.Drawing.Point(25, 110);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(192, 25);
            this.comboBox_status.TabIndex = 27;
            // 
            // textBox_id
            // 
            this.textBox_id.BackColor = System.Drawing.Color.White;
            this.textBox_id.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox_id.Location = new System.Drawing.Point(25, 50);
            this.textBox_id.MaxLength = 9;
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(192, 24);
            this.textBox_id.TabIndex = 26;
            this.textBox_id.TextChanged += new System.EventHandler(this.validating_id);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "ID Orden";
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
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.Color.White;
            this.textBox_name.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox_name.Location = new System.Drawing.Point(240, 50);
            this.textBox_name.MaxLength = 280;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(515, 24);
            this.textBox_name.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre del proveedor";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Gray;
            this.buttonSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Location = new System.Drawing.Point(667, 97);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(88, 39);
            this.buttonSearch.TabIndex = 15;
            this.buttonSearch.Text = "🔎 Buscar";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.button_search);
            // 
            // PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 524);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView_purchaseOrder);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PurchaseOrder";
            this.Text = "Mantenimiento de orden de compra";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_purchaseOrder)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView dataGridView_purchaseOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker_creation;
        private System.Windows.Forms.DateTimePicker dateTimePicker_creationEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_dateInclude;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_order;
        private System.Windows.Forms.DataGridViewTextBoxColumn suppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn creation_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn delivery_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_supplier;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
    }
}