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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid_orders = new System.Windows.Forms.DataGridView();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button_create_dev = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
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
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_orders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.grid_orders.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.grid_orders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_orders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.grid_orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_orders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo,
            this.cost,
            this.Cantidad,
            this.Column1,
            this.Column3,
            this.Column2});
            this.grid_orders.Location = new System.Drawing.Point(34, 198);
            this.grid_orders.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.grid_orders.Name = "grid_orders";
            this.grid_orders.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid_orders.Size = new System.Drawing.Size(668, 207);
            this.grid_orders.TabIndex = 24;
            this.grid_orders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_orders_CellDoubleClick);
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // cost
            // 
            this.cost.HeaderText = "Nombre Cliente";
            this.cost.Name = "cost";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "RUC/DNI Cliente";
            this.Cantidad.Name = "Cantidad";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Estado";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Monto";
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Eliminar";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_search);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox1.Location = new System.Drawing.Point(34, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 158);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Pedido",
            "Devolución"});
            this.comboBox1.Location = new System.Drawing.Point(24, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 26);
            this.comboBox1.TabIndex = 27;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "Fecha de Entrega";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarMonthBackground = System.Drawing.SystemColors.InactiveBorder;
            this.dateTimePicker2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(237, 110);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(192, 26);
            this.dateTimePicker2.TabIndex = 23;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.White;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(24, 110);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(192, 26);
            this.comboBox2.TabIndex = 22;
            this.comboBox2.Text = "Producción";
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
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(452, 50);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(192, 26);
            this.textBox3.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nombre Cliente";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(237, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(192, 26);
            this.textBox2.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "RUC Cliente";
            // 
            // button_search
            // 
            this.button_search.BackColor = System.Drawing.Color.Gray;
            this.button_search.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search.ForeColor = System.Drawing.Color.White;
            this.button_search.Location = new System.Drawing.Point(508, 97);
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
            this.ClientSize = new System.Drawing.Size(736, 491);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grid_orders);
            this.Controls.Add(this.button_create_dev);
            this.Name = "ClientOrderIndex";
            this.Text = "Lista de Pedidos";
            ((System.ComponentModel.ISupportInitialize)(this.grid_orders)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView grid_orders;
        private System.Windows.Forms.Button button_create_dev;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}