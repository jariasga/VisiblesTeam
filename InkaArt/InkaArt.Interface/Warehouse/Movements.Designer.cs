namespace InkaArt.Interface.Warehouse
{
    partial class Movements
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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.combobox_reason = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.combobox_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.text_warehouse_id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.text_warehouse = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_acept = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.combobox_reason);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.combobox_type);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 233);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(575, 141);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuración";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(362, 56);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(189, 66);
            this.textBox3.TabIndex = 33;
            this.textBox3.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(365, 35);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 18);
            this.label6.TabIndex = 32;
            this.label6.Text = "Comentario:";
            this.label6.Visible = false;
            // 
            // combobox_reason
            // 
            this.combobox_reason.BackColor = System.Drawing.Color.White;
            this.combobox_reason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_reason.FormattingEnabled = true;
            this.combobox_reason.Location = new System.Drawing.Point(193, 81);
            this.combobox_reason.Margin = new System.Windows.Forms.Padding(2);
            this.combobox_reason.Name = "combobox_reason";
            this.combobox_reason.Size = new System.Drawing.Size(138, 26);
            this.combobox_reason.Sorted = true;
            this.combobox_reason.TabIndex = 29;
            this.combobox_reason.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 28;
            this.label4.Text = "Razón:";
            // 
            // combobox_type
            // 
            this.combobox_type.BackColor = System.Drawing.Color.White;
            this.combobox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_type.FormattingEnabled = true;
            this.combobox_type.Location = new System.Drawing.Point(17, 81);
            this.combobox_type.Margin = new System.Windows.Forms.Padding(2);
            this.combobox_type.Name = "combobox_type";
            this.combobox_type.Size = new System.Drawing.Size(138, 26);
            this.combobox_type.Sorted = true;
            this.combobox_type.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tipo de Movimiento:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.text_warehouse_id);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.button_search);
            this.groupBox3.Controls.Add(this.text_warehouse);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(18, 32);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(575, 169);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Almacén";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // text_warehouse_id
            // 
            this.text_warehouse_id.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.text_warehouse_id.Location = new System.Drawing.Point(268, 115);
            this.text_warehouse_id.Margin = new System.Windows.Forms.Padding(2);
            this.text_warehouse_id.Name = "text_warehouse_id";
            this.text_warehouse_id.ReadOnly = true;
            this.text_warehouse_id.Size = new System.Drawing.Size(285, 26);
            this.text_warehouse_id.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 93);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 18);
            this.label5.TabIndex = 32;
            this.label5.Text = "Id";
            // 
            // button_search
            // 
            this.button_search.BackColor = System.Drawing.Color.Gray;
            this.button_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search.ForeColor = System.Drawing.Color.White;
            this.button_search.Location = new System.Drawing.Point(28, 69);
            this.button_search.Margin = new System.Windows.Forms.Padding(2);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(153, 39);
            this.button_search.TabIndex = 28;
            this.button_search.Text = "Buscar";
            this.button_search.UseVisualStyleBackColor = false;
            this.button_search.Click += new System.EventHandler(this.buttonSearchClick);
            // 
            // text_warehouse
            // 
            this.text_warehouse.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.text_warehouse.Location = new System.Drawing.Point(268, 54);
            this.text_warehouse.Margin = new System.Windows.Forms.Padding(2);
            this.text_warehouse.Name = "text_warehouse";
            this.text_warehouse.ReadOnly = true;
            this.text_warehouse.Size = new System.Drawing.Size(285, 26);
            this.text_warehouse.TabIndex = 29;
            this.text_warehouse.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(265, 33);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
            this.label9.TabIndex = 28;
            this.label9.Text = "Nombre";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // button_acept
            // 
            this.button_acept.BackColor = System.Drawing.Color.SteelBlue;
            this.button_acept.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_acept.ForeColor = System.Drawing.Color.White;
            this.button_acept.Location = new System.Drawing.Point(116, 406);
            this.button_acept.Name = "button_acept";
            this.button_acept.Size = new System.Drawing.Size(138, 39);
            this.button_acept.TabIndex = 45;
            this.button_acept.Text = "Aceptar";
            this.button_acept.UseVisualStyleBackColor = false;
            this.button_acept.Click += new System.EventHandler(this.buttonAceptClick);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(333, 406);
            this.button_delete.Margin = new System.Windows.Forms.Padding(2);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(138, 39);
            this.button_delete.TabIndex = 54;
            this.button_delete.Text = "Cancelar";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.buttonDeleteClick);
            // 
            // Movements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(614, 473);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_acept);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Movements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Movimientos";
            this.Load += new System.EventHandler(this.Movements_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combobox_reason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combobox_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_acept;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox text_warehouse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox text_warehouse_id;
        private System.Windows.Forms.Label label5;
    }
}