namespace InkaArt.Interface.Warehouse
{
    partial class MovementIndex
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
            this.data_grid_movements = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Almacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datetime_movement = new System.Windows.Forms.DateTimePicker();
            this.combobox_reason = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.combobox_status = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.combobox_type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combobox_warehouse = new System.Windows.Forms.ComboBox();
            this.textbox_id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_movements)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(398, 469);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(151, 39);
            this.buttonDelete.TabIndex = 51;
            this.buttonDelete.Text = "🗑 Eliminar";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAdd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(233, 469);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(151, 39);
            this.buttonAdd.TabIndex = 50;
            this.buttonAdd.Text = "+ Crear";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonCreateClick);
            // 
            // data_grid_movements
            // 
            this.data_grid_movements.AllowUserToAddRows = false;
            this.data_grid_movements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_grid_movements.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.data_grid_movements.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.data_grid_movements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid_movements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.type,
            this.reason,
            this.Almacen,
            this.Fecha,
            this.Eliminar});
            this.data_grid_movements.Location = new System.Drawing.Point(24, 254);
            this.data_grid_movements.Name = "data_grid_movements";
            this.data_grid_movements.Size = new System.Drawing.Size(680, 199);
            this.data_grid_movements.TabIndex = 49;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // type
            // 
            this.type.HeaderText = "Tipo";
            this.type.Name = "type";
            // 
            // reason
            // 
            this.reason.HeaderText = "Razón";
            this.reason.Name = "reason";
            // 
            // Almacen
            // 
            this.Almacen.HeaderText = "Almacén";
            this.Almacen.Name = "Almacen";
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datetime_movement);
            this.groupBox1.Controls.Add(this.combobox_reason);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.combobox_status);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.combobox_type);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.combobox_warehouse);
            this.groupBox1.Controls.Add(this.textbox_id);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox1.Location = new System.Drawing.Point(24, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 210);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // datetime_movement
            // 
            this.datetime_movement.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetime_movement.Location = new System.Drawing.Point(240, 109);
            this.datetime_movement.Name = "datetime_movement";
            this.datetime_movement.ShowCheckBox = true;
            this.datetime_movement.Size = new System.Drawing.Size(200, 26);
            this.datetime_movement.TabIndex = 37;
            this.datetime_movement.ValueChanged += new System.EventHandler(this.datetimeMovementValueChanged);
            // 
            // combobox_reason
            // 
            this.combobox_reason.Font = new System.Drawing.Font("Arial", 11F);
            this.combobox_reason.FormattingEnabled = true;
            this.combobox_reason.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.combobox_reason.Location = new System.Drawing.Point(456, 49);
            this.combobox_reason.Name = "combobox_reason";
            this.combobox_reason.Size = new System.Drawing.Size(193, 25);
            this.combobox_reason.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "Razón";
            // 
            // combobox_status
            // 
            this.combobox_status.Font = new System.Drawing.Font("Arial", 11F);
            this.combobox_status.FormattingEnabled = true;
            this.combobox_status.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.combobox_status.Location = new System.Drawing.Point(456, 110);
            this.combobox_status.Name = "combobox_status";
            this.combobox_status.Size = new System.Drawing.Size(193, 25);
            this.combobox_status.TabIndex = 34;
            this.combobox_status.SelectedIndexChanged += new System.EventHandler(this.combobox_status_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 33;
            this.label1.Text = "Estado";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // combobox_type
            // 
            this.combobox_type.Font = new System.Drawing.Font("Arial", 11F);
            this.combobox_type.FormattingEnabled = true;
            this.combobox_type.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.combobox_type.Location = new System.Drawing.Point(240, 49);
            this.combobox_type.Name = "combobox_type";
            this.combobox_type.Size = new System.Drawing.Size(193, 25);
            this.combobox_type.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 29;
            this.label2.Text = "Tipo";
            // 
            // combobox_warehouse
            // 
            this.combobox_warehouse.Font = new System.Drawing.Font("Arial", 11F);
            this.combobox_warehouse.FormattingEnabled = true;
            this.combobox_warehouse.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.combobox_warehouse.Location = new System.Drawing.Point(25, 110);
            this.combobox_warehouse.Name = "combobox_warehouse";
            this.combobox_warehouse.Size = new System.Drawing.Size(192, 25);
            this.combobox_warehouse.TabIndex = 27;
            // 
            // textbox_id
            // 
            this.textbox_id.BackColor = System.Drawing.Color.White;
            this.textbox_id.Font = new System.Drawing.Font("Arial", 11F);
            this.textbox_id.Location = new System.Drawing.Point(25, 50);
            this.textbox_id.Name = "textbox_id";
            this.textbox_id.Size = new System.Drawing.Size(192, 24);
            this.textbox_id.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "Almacén";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Gray;
            this.buttonSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Location = new System.Drawing.Point(291, 155);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(123, 39);
            this.buttonSearch.TabIndex = 15;
            this.buttonSearch.Text = "🔎 Buscar";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearchClick);
            // 
            // MovementIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(781, 523);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.data_grid_movements);
            this.Controls.Add(this.groupBox1);
            this.Name = "MovementIndex";
            this.Text = "MovementIndex";
            this.Load += new System.EventHandler(this.MovementIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_movements)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView data_grid_movements;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combobox_warehouse;
        private System.Windows.Forms.TextBox textbox_id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox combobox_type;
        private System.Windows.Forms.ComboBox combobox_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combobox_reason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn Almacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.DateTimePicker datetime_movement;
    }
}