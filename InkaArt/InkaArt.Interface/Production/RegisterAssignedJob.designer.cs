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
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Proceso = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.HoraIni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rotos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(347, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 42);
            this.button1.TabIndex = 28;
            this.button1.Text = "🖫 Guardar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 18);
            this.label9.TabIndex = 25;
            this.label9.Text = "Hora Inicio";
            // 
            // textBox10
            // 
            this.textBox10.Enabled = false;
            this.textBox10.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(34, 30);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(204, 24);
            this.textBox10.TabIndex = 27;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Producto,
            this.Proceso,
            this.HoraIni,
            this.HoraFin,
            this.Rotos,
            this.Terminados});
            this.dataGridView1.Location = new System.Drawing.Point(34, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 258);
            this.dataGridView1.TabIndex = 29;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Items.AddRange(new object[] {
            "Camila",
            "Javier",
            "Flor",
            "Ricardo",
            "Daniel",
            "Natalia",
            "Mauricio",
            "Anthony"});
            this.Nombre.Name = "Nombre";
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Items.AddRange(new object[] {
            "Huaco",
            "Piedra de Huamanga",
            "Retablo"});
            this.Producto.Name = "Producto";
            // 
            // Proceso
            // 
            this.Proceso.HeaderText = "Proceso";
            this.Proceso.Items.AddRange(new object[] {
            "PIntado",
            "Tallado",
            "Moldeado",
            "Horneado"});
            this.Proceso.Name = "Proceso";
            // 
            // HoraIni
            // 
            this.HoraIni.HeaderText = "HoraIni";
            this.HoraIni.Name = "HoraIni";
            // 
            // HoraFin
            // 
            this.HoraFin.HeaderText = "HoraFin";
            this.HoraFin.Name = "HoraFin";
            // 
            // Rotos
            // 
            this.Rotos.HeaderText = "Rotos";
            this.Rotos.Name = "Rotos";
            // 
            // Terminados
            // 
            this.Terminados.HeaderText = "Terminados";
            this.Terminados.Name = "Terminados";
            // 
            // RegisterAssignedJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(811, 416);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegisterAssignedJob";
            this.Text = "Informe de Turno";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewComboBoxColumn Producto;
        private System.Windows.Forms.DataGridViewComboBoxColumn Proceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraIni;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rotos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminados;
    }
}