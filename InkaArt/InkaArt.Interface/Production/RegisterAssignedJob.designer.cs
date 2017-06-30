namespace InkaArt.Interface.Production
{
    partial class RegisterAssignedJob
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
            this.button_guardar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_fecha = new System.Windows.Forms.TextBox();
            this.dataGridView_turn = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraIni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rotos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_nombre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_producto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_proceso = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_agregar = new System.Windows.Forms.Button();
            this.textbox_horaIni = new System.Windows.Forms.TextBox();
            this.textBox_rotos = new System.Windows.Forms.TextBox();
            this.textBox_horaFin = new System.Windows.Forms.TextBox();
            this.textBox_terminados = new System.Windows.Forms.TextBox();
            this.button_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_turn)).BeginInit();
            this.SuspendLayout();
            // 
            // button_guardar
            // 
            this.button_guardar.BackColor = System.Drawing.Color.SteelBlue;
            this.button_guardar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_guardar.ForeColor = System.Drawing.Color.White;
            this.button_guardar.Location = new System.Drawing.Point(326, 421);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(135, 42);
            this.button_guardar.TabIndex = 28;
            this.button_guardar.Text = "🖫 Guardar";
            this.button_guardar.UseVisualStyleBackColor = false;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(233, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 18);
            this.label9.TabIndex = 25;
            this.label9.Text = "Fecha";
            // 
            // textBox_fecha
            // 
            this.textBox_fecha.Enabled = false;
            this.textBox_fecha.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_fecha.Location = new System.Drawing.Point(236, 66);
            this.textBox_fecha.Name = "textBox_fecha";
            this.textBox_fecha.ReadOnly = true;
            this.textBox_fecha.Size = new System.Drawing.Size(171, 24);
            this.textBox_fecha.TabIndex = 27;
            // 
            // dataGridView_turn
            // 
            this.dataGridView_turn.AllowUserToAddRows = false;
            this.dataGridView_turn.AllowUserToDeleteRows = false;
            this.dataGridView_turn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_turn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Producto,
            this.Proceso,
            this.HoraIni,
            this.HoraFin,
            this.Rotos,
            this.Terminados,
            this.Seleccionar});
            this.dataGridView_turn.Location = new System.Drawing.Point(34, 183);
            this.dataGridView_turn.Name = "dataGridView_turn";
            this.dataGridView_turn.Size = new System.Drawing.Size(814, 216);
            this.dataGridView_turn.TabIndex = 29;
            this.dataGridView_turn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_turn_CellContentClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Proceso
            // 
            this.Proceso.HeaderText = "Proceso";
            this.Proceso.Name = "Proceso";
            this.Proceso.ReadOnly = true;
            this.Proceso.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Proceso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // HoraIni
            // 
            this.HoraIni.HeaderText = "HoraIni";
            this.HoraIni.Name = "HoraIni";
            this.HoraIni.ReadOnly = true;
            // 
            // HoraFin
            // 
            this.HoraFin.HeaderText = "HoraFin";
            this.HoraFin.Name = "HoraFin";
            this.HoraFin.ReadOnly = true;
            // 
            // Rotos
            // 
            this.Rotos.HeaderText = "Rotos";
            this.Rotos.Name = "Rotos";
            this.Rotos.ReadOnly = true;
            // 
            // Terminados
            // 
            this.Terminados.HeaderText = "Terminados";
            this.Terminados.Name = "Terminados";
            this.Terminados.ReadOnly = true;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Eliminar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = "Nombre";
            // 
            // comboBox_nombre
            // 
            this.comboBox_nombre.FormattingEnabled = true;
            this.comboBox_nombre.Location = new System.Drawing.Point(34, 66);
            this.comboBox_nombre.Name = "comboBox_nombre";
            this.comboBox_nombre.Size = new System.Drawing.Size(171, 26);
            this.comboBox_nombre.TabIndex = 30;
            this.comboBox_nombre.SelectedIndexChanged += new System.EventHandler(this.comboBox_nombre_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 33;
            this.label1.Text = "Producto";
            // 
            // comboBox_producto
            // 
            this.comboBox_producto.FormattingEnabled = true;
            this.comboBox_producto.Location = new System.Drawing.Point(34, 127);
            this.comboBox_producto.Name = "comboBox_producto";
            this.comboBox_producto.Size = new System.Drawing.Size(171, 26);
            this.comboBox_producto.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(233, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 35;
            this.label2.Text = "Proceso";
            // 
            // comboBox_proceso
            // 
            this.comboBox_proceso.FormattingEnabled = true;
            this.comboBox_proceso.Location = new System.Drawing.Point(236, 127);
            this.comboBox_proceso.Name = "comboBox_proceso";
            this.comboBox_proceso.Size = new System.Drawing.Size(171, 26);
            this.comboBox_proceso.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(470, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 39;
            this.label3.Text = "Rotos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(470, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 18);
            this.label4.TabIndex = 37;
            this.label4.Text = "Hora Inicio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(673, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 18);
            this.label6.TabIndex = 43;
            this.label6.Text = "Terminados";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(673, 45);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 18);
            this.label7.TabIndex = 41;
            this.label7.Text = "Hora Fin";
            // 
            // button_agregar
            // 
            this.button_agregar.BackColor = System.Drawing.Color.SteelBlue;
            this.button_agregar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_agregar.ForeColor = System.Drawing.Color.White;
            this.button_agregar.Location = new System.Drawing.Point(196, 421);
            this.button_agregar.Name = "button_agregar";
            this.button_agregar.Size = new System.Drawing.Size(124, 42);
            this.button_agregar.TabIndex = 44;
            this.button_agregar.Text = "+ Agregar";
            this.button_agregar.UseVisualStyleBackColor = false;
            this.button_agregar.Click += new System.EventHandler(this.button_agregar_Click);
            // 
            // textbox_horaIni
            // 
            this.textbox_horaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_horaIni.Location = new System.Drawing.Point(473, 68);
            this.textbox_horaIni.Name = "textbox_horaIni";
            this.textbox_horaIni.Size = new System.Drawing.Size(172, 24);
            this.textbox_horaIni.TabIndex = 45;
            // 
            // textBox_rotos
            // 
            this.textBox_rotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_rotos.Location = new System.Drawing.Point(473, 129);
            this.textBox_rotos.Name = "textBox_rotos";
            this.textBox_rotos.Size = new System.Drawing.Size(172, 24);
            this.textBox_rotos.TabIndex = 46;
            // 
            // textBox_horaFin
            // 
            this.textBox_horaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_horaFin.Location = new System.Drawing.Point(676, 68);
            this.textBox_horaFin.Name = "textBox_horaFin";
            this.textBox_horaFin.Size = new System.Drawing.Size(172, 24);
            this.textBox_horaFin.TabIndex = 47;
            // 
            // textBox_terminados
            // 
            this.textBox_terminados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_terminados.Location = new System.Drawing.Point(676, 129);
            this.textBox_terminados.Name = "textBox_terminados";
            this.textBox_terminados.Size = new System.Drawing.Size(172, 24);
            this.textBox_terminados.TabIndex = 48;
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(467, 421);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(144, 42);
            this.button_delete.TabIndex = 49;
            this.button_delete.Text = "🗑 Eliminar Fila";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // RegisterAssignedJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 478);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.textBox_terminados);
            this.Controls.Add(this.textBox_horaFin);
            this.Controls.Add(this.textBox_rotos);
            this.Controls.Add(this.textbox_horaIni);
            this.Controls.Add(this.button_agregar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_proceso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_producto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_nombre);
            this.Controls.Add(this.dataGridView_turn);
            this.Controls.Add(this.textBox_fecha);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegisterAssignedJob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe de Turno";
            this.Load += new System.EventHandler(this.RegisterAssignedJob_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_turn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_fecha;
        private System.Windows.Forms.DataGridView dataGridView_turn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_producto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_proceso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_agregar;
        private System.Windows.Forms.TextBox textbox_horaIni;
        private System.Windows.Forms.TextBox textBox_rotos;
        private System.Windows.Forms.TextBox textBox_horaFin;
        private System.Windows.Forms.TextBox textBox_terminados;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraIni;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rotos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminados;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
    }
}