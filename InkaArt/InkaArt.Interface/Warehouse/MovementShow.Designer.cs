namespace InkaArt.Interface.Warehouse
{
    partial class MovementShow
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
            this.textbox_date = new System.Windows.Forms.TextBox();
            this.textbox_doc_number = new System.Windows.Forms.TextBox();
            this.combobox_type = new System.Windows.Forms.ComboBox();
            this.combobox_doc_type = new System.Windows.Forms.ComboBox();
            this.combobox_reason = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.combobox_status = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_item = new System.Windows.Forms.GroupBox();
            this.textbox_quantity = new System.Windows.Forms.TextBox();
            this.textbox_item_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox_origen = new System.Windows.Forms.GroupBox();
            this.textbox_warehouse_idO = new System.Windows.Forms.TextBox();
            this.textbox_warehouse_nameO = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox_destino = new System.Windows.Forms.GroupBox();
            this.textbox_warehouse_nameD = new System.Windows.Forms.TextBox();
            this.label_name_d = new System.Windows.Forms.Label();
            this.textbox_warehouse_idD = new System.Windows.Forms.TextBox();
            this.label_id_d = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox_item.SuspendLayout();
            this.groupBox_origen.SuspendLayout();
            this.groupBox_destino.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textbox_date);
            this.groupBox2.Controls.Add(this.textbox_doc_number);
            this.groupBox2.Controls.Add(this.combobox_type);
            this.groupBox2.Controls.Add(this.combobox_doc_type);
            this.groupBox2.Controls.Add(this.combobox_reason);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.combobox_status);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(33, 26);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(701, 222);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Movimiento";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textbox_date
            // 
            this.textbox_date.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textbox_date.Enabled = false;
            this.textbox_date.Location = new System.Drawing.Point(23, 113);
            this.textbox_date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_date.Name = "textbox_date";
            this.textbox_date.ReadOnly = true;
            this.textbox_date.Size = new System.Drawing.Size(315, 30);
            this.textbox_date.TabIndex = 49;
            // 
            // textbox_doc_number
            // 
            this.textbox_doc_number.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textbox_doc_number.Enabled = false;
            this.textbox_doc_number.Location = new System.Drawing.Point(360, 174);
            this.textbox_doc_number.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_doc_number.Name = "textbox_doc_number";
            this.textbox_doc_number.ReadOnly = true;
            this.textbox_doc_number.Size = new System.Drawing.Size(315, 30);
            this.textbox_doc_number.TabIndex = 46;
            // 
            // combobox_type
            // 
            this.combobox_type.Enabled = false;
            this.combobox_type.Font = new System.Drawing.Font("Arial", 11F);
            this.combobox_type.FormattingEnabled = true;
            this.combobox_type.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.combobox_type.Location = new System.Drawing.Point(23, 50);
            this.combobox_type.Margin = new System.Windows.Forms.Padding(4);
            this.combobox_type.Name = "combobox_type";
            this.combobox_type.Size = new System.Drawing.Size(315, 29);
            this.combobox_type.TabIndex = 43;
            // 
            // combobox_doc_type
            // 
            this.combobox_doc_type.Enabled = false;
            this.combobox_doc_type.Font = new System.Drawing.Font("Arial", 11F);
            this.combobox_doc_type.FormattingEnabled = true;
            this.combobox_doc_type.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.combobox_doc_type.Location = new System.Drawing.Point(23, 174);
            this.combobox_doc_type.Margin = new System.Windows.Forms.Padding(4);
            this.combobox_doc_type.Name = "combobox_doc_type";
            this.combobox_doc_type.Size = new System.Drawing.Size(315, 29);
            this.combobox_doc_type.TabIndex = 48;
            // 
            // combobox_reason
            // 
            this.combobox_reason.Enabled = false;
            this.combobox_reason.Font = new System.Drawing.Font("Arial", 11F);
            this.combobox_reason.FormattingEnabled = true;
            this.combobox_reason.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.combobox_reason.Location = new System.Drawing.Point(360, 50);
            this.combobox_reason.Margin = new System.Windows.Forms.Padding(4);
            this.combobox_reason.Name = "combobox_reason";
            this.combobox_reason.Size = new System.Drawing.Size(315, 29);
            this.combobox_reason.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(353, 149);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 23);
            this.label7.TabIndex = 47;
            this.label7.Text = "Número de Documento";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(180, 23);
            this.label11.TabIndex = 45;
            this.label11.Text = "Tipo de Documento";
            // 
            // combobox_status
            // 
            this.combobox_status.Enabled = false;
            this.combobox_status.Font = new System.Drawing.Font("Arial", 11F);
            this.combobox_status.FormattingEnabled = true;
            this.combobox_status.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.combobox_status.Location = new System.Drawing.Point(360, 112);
            this.combobox_status.Margin = new System.Windows.Forms.Padding(4);
            this.combobox_status.Name = "combobox_status";
            this.combobox_status.Size = new System.Drawing.Size(315, 29);
            this.combobox_status.TabIndex = 40;
            this.combobox_status.SelectedIndexChanged += new System.EventHandler(this.combobox_status_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 39;
            this.label1.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 23);
            this.label4.TabIndex = 28;
            this.label4.Text = "Razón";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tipo";
            // 
            // groupBox_item
            // 
            this.groupBox_item.Controls.Add(this.textbox_quantity);
            this.groupBox_item.Controls.Add(this.textbox_item_name);
            this.groupBox_item.Controls.Add(this.label6);
            this.groupBox_item.Controls.Add(this.label8);
            this.groupBox_item.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_item.Location = new System.Drawing.Point(33, 477);
            this.groupBox_item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_item.Name = "groupBox_item";
            this.groupBox_item.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_item.Size = new System.Drawing.Size(701, 110);
            this.groupBox_item.TabIndex = 56;
            this.groupBox_item.TabStop = false;
            this.groupBox_item.Text = "Producto";
            // 
            // textbox_quantity
            // 
            this.textbox_quantity.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textbox_quantity.Enabled = false;
            this.textbox_quantity.Location = new System.Drawing.Point(357, 58);
            this.textbox_quantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_quantity.Name = "textbox_quantity";
            this.textbox_quantity.ReadOnly = true;
            this.textbox_quantity.Size = new System.Drawing.Size(315, 30);
            this.textbox_quantity.TabIndex = 44;
            // 
            // textbox_item_name
            // 
            this.textbox_item_name.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textbox_item_name.Enabled = false;
            this.textbox_item_name.Location = new System.Drawing.Point(23, 58);
            this.textbox_item_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_item_name.Name = "textbox_item_name";
            this.textbox_item_name.ReadOnly = true;
            this.textbox_item_name.Size = new System.Drawing.Size(315, 30);
            this.textbox_item_name.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 34);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 23);
            this.label6.TabIndex = 39;
            this.label6.Text = "Nombre";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(356, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 23);
            this.label8.TabIndex = 28;
            this.label8.Text = "Cantidad";
            // 
            // groupBox_origen
            // 
            this.groupBox_origen.Controls.Add(this.label5);
            this.groupBox_origen.Controls.Add(this.label9);
            this.groupBox_origen.Controls.Add(this.textbox_warehouse_nameO);
            this.groupBox_origen.Controls.Add(this.textbox_warehouse_idO);
            this.groupBox_origen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_origen.Location = new System.Drawing.Point(33, 278);
            this.groupBox_origen.Name = "groupBox_origen";
            this.groupBox_origen.Size = new System.Drawing.Size(338, 164);
            this.groupBox_origen.TabIndex = 38;
            this.groupBox_origen.TabStop = false;
            this.groupBox_origen.Text = "Almacén origen";
            // 
            // textbox_warehouse_idO
            // 
            this.textbox_warehouse_idO.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textbox_warehouse_idO.Enabled = false;
            this.textbox_warehouse_idO.Location = new System.Drawing.Point(17, 53);
            this.textbox_warehouse_idO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_warehouse_idO.Name = "textbox_warehouse_idO";
            this.textbox_warehouse_idO.ReadOnly = true;
            this.textbox_warehouse_idO.Size = new System.Drawing.Size(304, 30);
            this.textbox_warehouse_idO.TabIndex = 33;
            // 
            // textbox_warehouse_nameO
            // 
            this.textbox_warehouse_nameO.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textbox_warehouse_nameO.Enabled = false;
            this.textbox_warehouse_nameO.Location = new System.Drawing.Point(17, 115);
            this.textbox_warehouse_nameO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_warehouse_nameO.Name = "textbox_warehouse_nameO";
            this.textbox_warehouse_nameO.ReadOnly = true;
            this.textbox_warehouse_nameO.Size = new System.Drawing.Size(304, 30);
            this.textbox_warehouse_nameO.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 23);
            this.label9.TabIndex = 28;
            this.label9.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 23);
            this.label5.TabIndex = 32;
            this.label5.Text = "ID";
            // 
            // groupBox_destino
            // 
            this.groupBox_destino.Controls.Add(this.label_id_d);
            this.groupBox_destino.Controls.Add(this.textbox_warehouse_idD);
            this.groupBox_destino.Controls.Add(this.label_name_d);
            this.groupBox_destino.Controls.Add(this.textbox_warehouse_nameD);
            this.groupBox_destino.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_destino.Location = new System.Drawing.Point(393, 278);
            this.groupBox_destino.Name = "groupBox_destino";
            this.groupBox_destino.Size = new System.Drawing.Size(341, 164);
            this.groupBox_destino.TabIndex = 39;
            this.groupBox_destino.TabStop = false;
            this.groupBox_destino.Text = "Almacén destino";
            // 
            // textbox_warehouse_nameD
            // 
            this.textbox_warehouse_nameD.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textbox_warehouse_nameD.Enabled = false;
            this.textbox_warehouse_nameD.Location = new System.Drawing.Point(18, 115);
            this.textbox_warehouse_nameD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_warehouse_nameD.Name = "textbox_warehouse_nameD";
            this.textbox_warehouse_nameD.ReadOnly = true;
            this.textbox_warehouse_nameD.Size = new System.Drawing.Size(294, 30);
            this.textbox_warehouse_nameD.TabIndex = 35;
            // 
            // label_name_d
            // 
            this.label_name_d.AutoSize = true;
            this.label_name_d.Location = new System.Drawing.Point(14, 89);
            this.label_name_d.Name = "label_name_d";
            this.label_name_d.Size = new System.Drawing.Size(79, 23);
            this.label_name_d.TabIndex = 34;
            this.label_name_d.Text = "Nombre";
            // 
            // textbox_warehouse_idD
            // 
            this.textbox_warehouse_idD.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textbox_warehouse_idD.Enabled = false;
            this.textbox_warehouse_idD.Location = new System.Drawing.Point(18, 53);
            this.textbox_warehouse_idD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_warehouse_idD.Name = "textbox_warehouse_idD";
            this.textbox_warehouse_idD.ReadOnly = true;
            this.textbox_warehouse_idD.Size = new System.Drawing.Size(297, 30);
            this.textbox_warehouse_idD.TabIndex = 37;
            // 
            // label_id_d
            // 
            this.label_id_d.AutoSize = true;
            this.label_id_d.Location = new System.Drawing.Point(14, 26);
            this.label_id_d.Name = "label_id_d";
            this.label_id_d.Size = new System.Drawing.Size(30, 23);
            this.label_id_d.TabIndex = 36;
            this.label_id_d.Text = "ID";
            // 
            // MovementShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(776, 613);
            this.Controls.Add(this.groupBox_destino);
            this.Controls.Add(this.groupBox_item);
            this.Controls.Add(this.groupBox_origen);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MovementShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimiento";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox_item.ResumeLayout(false);
            this.groupBox_item.PerformLayout();
            this.groupBox_origen.ResumeLayout(false);
            this.groupBox_origen.PerformLayout();
            this.groupBox_destino.ResumeLayout(false);
            this.groupBox_destino.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combobox_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combobox_type;
        private System.Windows.Forms.ComboBox combobox_reason;
        private System.Windows.Forms.TextBox textbox_doc_number;
        private System.Windows.Forms.ComboBox combobox_doc_type;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox_item;
        private System.Windows.Forms.TextBox textbox_quantity;
        private System.Windows.Forms.TextBox textbox_item_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textbox_date;
        private System.Windows.Forms.GroupBox groupBox_origen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textbox_warehouse_nameO;
        private System.Windows.Forms.TextBox textbox_warehouse_idO;
        private System.Windows.Forms.GroupBox groupBox_destino;
        private System.Windows.Forms.Label label_id_d;
        private System.Windows.Forms.TextBox textbox_warehouse_idD;
        private System.Windows.Forms.Label label_name_d;
        private System.Windows.Forms.TextBox textbox_warehouse_nameD;
    }
}