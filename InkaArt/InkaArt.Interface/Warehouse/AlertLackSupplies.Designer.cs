namespace InkaArt.Interface.Warehouse
{
    partial class AlertLackSupplies
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_create = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockLogico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockRequerido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NombreInsumo,
            this.StockLogico,
            this.StockRequerido,
            this.Estado});
            this.dataGridView1.Location = new System.Drawing.Point(16, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(674, 210);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad de insumos en alerta";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(16, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(217, 26);
            this.textBox1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 341);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de insumos en alerta";
            // 
            // button_create
            // 
            this.button_create.BackColor = System.Drawing.Color.SteelBlue;
            this.button_create.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_create.ForeColor = System.Drawing.Color.White;
            this.button_create.Location = new System.Drawing.Point(261, 369);
            this.button_create.Margin = new System.Windows.Forms.Padding(2);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(201, 39);
            this.button_create.TabIndex = 24;
            this.button_create.Text = "＋ Crear orden de compra";
            this.button_create.UseVisualStyleBackColor = false;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 80;
            // 
            // NombreInsumo
            // 
            this.NombreInsumo.HeaderText = "Nombre de insumo";
            this.NombreInsumo.Name = "NombreInsumo";
            this.NombreInsumo.Width = 220;
            // 
            // StockLogico
            // 
            this.StockLogico.HeaderText = "Stock físico";
            this.StockLogico.Name = "StockLogico";
            // 
            // StockRequerido
            // 
            this.StockRequerido.HeaderText = "Stock mín. requerido";
            this.StockRequerido.Name = "StockRequerido";
            this.StockRequerido.Width = 103;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Width = 127;
            // 
            // AlertLackSupplies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(733, 424);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AlertLackSupplies";
            this.Text = "Alerta por falta de insumos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockLogico;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockRequerido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Button button_create;
    }
}