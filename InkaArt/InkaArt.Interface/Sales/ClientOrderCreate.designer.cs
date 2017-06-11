namespace InkaArt.Interface.Sales
{
    partial class ClientOrderCreate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.date_delivery = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_create = new System.Windows.Forms.Button();
            this.textbox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_doc = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.clientIdentifierLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.textbox_total = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textbox_igv = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.combo_quality = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_amount = new System.Windows.Forms.TextBox();
            this.grid_orderline = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
            this.combo_product = new System.Windows.Forms.ComboBox();
            this.numeric_quantity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textbox_doctype = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_orderline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.SteelBlue;
            this.button_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(541, 599);
            this.button_save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(143, 48);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "🖫 Guardar";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Documento de pago";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F);
            this.label6.Location = new System.Drawing.Point(29, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha de entrega";
            // 
            // date_delivery
            // 
            this.date_delivery.Font = new System.Drawing.Font("Arial", 11F);
            this.date_delivery.Location = new System.Drawing.Point(34, 81);
            this.date_delivery.Margin = new System.Windows.Forms.Padding(4);
            this.date_delivery.Name = "date_delivery";
            this.date_delivery.Size = new System.Drawing.Size(368, 29);
            this.date_delivery.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textbox_doctype);
            this.groupBox3.Controls.Add(this.date_delivery);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox3.Location = new System.Drawing.Point(33, 27);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(445, 231);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pedido";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_create);
            this.groupBox1.Controls.Add(this.textbox_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textbox_doc);
            this.groupBox1.Controls.Add(this.button_search);
            this.groupBox1.Controls.Add(this.clientIdentifierLabel);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox1.Location = new System.Drawing.Point(33, 322);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(445, 265);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // button_create
            // 
            this.button_create.BackColor = System.Drawing.Color.SteelBlue;
            this.button_create.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_create.ForeColor = System.Drawing.Color.White;
            this.button_create.Location = new System.Drawing.Point(77, 191);
            this.button_create.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(135, 48);
            this.button_create.TabIndex = 24;
            this.button_create.Text = "＋ Crear";
            this.button_create.UseVisualStyleBackColor = false;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // textbox_name
            // 
            this.textbox_name.BackColor = System.Drawing.Color.White;
            this.textbox_name.Enabled = false;
            this.textbox_name.Location = new System.Drawing.Point(33, 140);
            this.textbox_name.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_name.Name = "textbox_name";
            this.textbox_name.Size = new System.Drawing.Size(368, 30);
            this.textbox_name.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nombre";
            // 
            // textbox_doc
            // 
            this.textbox_doc.BackColor = System.Drawing.Color.White;
            this.textbox_doc.Enabled = false;
            this.textbox_doc.Location = new System.Drawing.Point(33, 66);
            this.textbox_doc.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_doc.Name = "textbox_doc";
            this.textbox_doc.Size = new System.Drawing.Size(368, 30);
            this.textbox_doc.TabIndex = 17;
            // 
            // button_search
            // 
            this.button_search.BackColor = System.Drawing.Color.Gray;
            this.button_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search.ForeColor = System.Drawing.Color.White;
            this.button_search.Location = new System.Drawing.Point(217, 191);
            this.button_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(135, 48);
            this.button_search.TabIndex = 15;
            this.button_search.Text = "🔎 Buscar";
            this.button_search.UseVisualStyleBackColor = false;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // clientIdentifierLabel
            // 
            this.clientIdentifierLabel.AutoSize = true;
            this.clientIdentifierLabel.Location = new System.Drawing.Point(28, 38);
            this.clientIdentifierLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clientIdentifierLabel.Name = "clientIdentifierLabel";
            this.clientIdentifierLabel.Size = new System.Drawing.Size(109, 23);
            this.clientIdentifierLabel.TabIndex = 16;
            this.clientIdentifierLabel.Text = "Documento";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_delete);
            this.groupBox2.Controls.Add(this.textbox_total);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textbox_igv);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.combo_quality);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textbox_amount);
            this.groupBox2.Controls.Add(this.grid_orderline);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button_add);
            this.groupBox2.Controls.Add(this.combo_product);
            this.groupBox2.Controls.Add(this.numeric_quantity);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox2.Location = new System.Drawing.Point(509, 27);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(620, 560);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Productos";
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(410, 103);
            this.button_delete.Margin = new System.Windows.Forms.Padding(4);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(161, 48);
            this.button_delete.TabIndex = 38;
            this.button_delete.Text = "🗑 Eliminar";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // textbox_total
            // 
            this.textbox_total.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textbox_total.Enabled = false;
            this.textbox_total.Location = new System.Drawing.Point(32, 503);
            this.textbox_total.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_total.Name = "textbox_total";
            this.textbox_total.Size = new System.Drawing.Size(219, 30);
            this.textbox_total.TabIndex = 28;
            this.textbox_total.Text = "S/.  0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 478);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 23);
            this.label10.TabIndex = 27;
            this.label10.Text = "Monto Total";
            // 
            // textbox_igv
            // 
            this.textbox_igv.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textbox_igv.Enabled = false;
            this.textbox_igv.Location = new System.Drawing.Point(33, 443);
            this.textbox_igv.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_igv.Name = "textbox_igv";
            this.textbox_igv.Size = new System.Drawing.Size(219, 30);
            this.textbox_igv.TabIndex = 26;
            this.textbox_igv.Text = "S/.  0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 417);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 23);
            this.label9.TabIndex = 25;
            this.label9.Text = "IGV";
            // 
            // combo_quality
            // 
            this.combo_quality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_quality.FormattingEnabled = true;
            this.combo_quality.Items.AddRange(new object[] {
            "Premium",
            "Estandar",
            "Económico"});
            this.combo_quality.Location = new System.Drawing.Point(261, 65);
            this.combo_quality.Margin = new System.Windows.Forms.Padding(4);
            this.combo_quality.Name = "combo_quality";
            this.combo_quality.Size = new System.Drawing.Size(219, 31);
            this.combo_quality.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "Calidad";
            // 
            // textbox_amount
            // 
            this.textbox_amount.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textbox_amount.Enabled = false;
            this.textbox_amount.Location = new System.Drawing.Point(33, 382);
            this.textbox_amount.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_amount.Name = "textbox_amount";
            this.textbox_amount.Size = new System.Drawing.Size(219, 30);
            this.textbox_amount.TabIndex = 21;
            this.textbox_amount.Text = "S/.  0.00";
            // 
            // grid_orderline
            // 
            this.grid_orderline.AllowUserToAddRows = false;
            this.grid_orderline.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_orderline.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.grid_orderline.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_orderline.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_orderline.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_orderline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_orderline.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Column1,
            this.cost,
            this.Cantidad,
            this.deleteColumn});
            this.grid_orderline.Location = new System.Drawing.Point(33, 172);
            this.grid_orderline.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.grid_orderline.Name = "grid_orderline";
            this.grid_orderline.Size = new System.Drawing.Size(560, 167);
            this.grid_orderline.TabIndex = 22;
            // 
            // Producto
            // 
            this.Producto.FillWeight = 141.1049F;
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 141.1049F;
            this.Column1.HeaderText = "Calidad";
            this.Column1.Name = "Column1";
            // 
            // cost
            // 
            this.cost.FillWeight = 77.87196F;
            this.cost.HeaderText = "PU";
            this.cost.Name = "cost";
            // 
            // Cantidad
            // 
            this.Cantidad.FillWeight = 76.14214F;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // deleteColumn
            // 
            this.deleteColumn.FillWeight = 63.7762F;
            this.deleteColumn.HeaderText = "Eliminar";
            this.deleteColumn.Name = "deleteColumn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 353);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 23);
            this.label7.TabIndex = 20;
            this.label7.Text = "Venta";
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.Gray;
            this.button_add.Enabled = false;
            this.button_add.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.ForeColor = System.Drawing.Color.White;
            this.button_add.Location = new System.Drawing.Point(260, 103);
            this.button_add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(143, 48);
            this.button_add.TabIndex = 21;
            this.button_add.Text = "＋ Agregar";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // combo_product
            // 
            this.combo_product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_product.FormattingEnabled = true;
            this.combo_product.Location = new System.Drawing.Point(33, 65);
            this.combo_product.Margin = new System.Windows.Forms.Padding(4);
            this.combo_product.Name = "combo_product";
            this.combo_product.Size = new System.Drawing.Size(219, 31);
            this.combo_product.TabIndex = 13;
            // 
            // numeric_quantity
            // 
            this.numeric_quantity.Location = new System.Drawing.Point(487, 66);
            this.numeric_quantity.Margin = new System.Windows.Forms.Padding(4);
            this.numeric_quantity.Name = "numeric_quantity";
            this.numeric_quantity.Size = new System.Drawing.Size(107, 30);
            this.numeric_quantity.TabIndex = 19;
            this.numeric_quantity.ValueChanged += new System.EventHandler(this.numeric_quantity_ValueChanged);
            this.numeric_quantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numeric_quantity_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(483, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "Cantidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "Producto";
            // 
            // textbox_doctype
            // 
            this.textbox_doctype.Enabled = false;
            this.textbox_doctype.Location = new System.Drawing.Point(34, 172);
            this.textbox_doctype.Name = "textbox_doctype";
            this.textbox_doctype.Size = new System.Drawing.Size(368, 30);
            this.textbox_doctype.TabIndex = 13;
            // 
            // ClientOrderCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1165, 661);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_save);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientOrderCreate";
            this.Text = "Registro de venta";
            this.Load += new System.EventHandler(this.ClientOrderCreate_Load);
            this.Shown += new System.EventHandler(this.ClientOrderCreate_Shown);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_orderline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_quantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker date_delivery;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textbox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_doc;
        private System.Windows.Forms.Label clientIdentifierLabel;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grid_orderline;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.ComboBox combo_product;
        private System.Windows.Forms.NumericUpDown numeric_quantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textbox_amount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.TextBox textbox_total;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textbox_igv;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox combo_quality;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn deleteColumn;
        private System.Windows.Forms.TextBox textbox_doctype;
    }
}