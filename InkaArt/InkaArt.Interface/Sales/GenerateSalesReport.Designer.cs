namespace InkaArt.Interface.Sales
{
    partial class GenerateSalesReport
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
            this.button_generateSalesResport = new System.Windows.Forms.Button();
            this.comboBox_products = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_fechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_fechaIni = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_generateSalesResport);
            this.groupBox1.Controls.Add(this.comboBox_products);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker_fechaFin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker_fechaIni);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 223);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros para el reporte";
            // 
            // button_generateSalesResport
            // 
            this.button_generateSalesResport.BackColor = System.Drawing.Color.SteelBlue;
            this.button_generateSalesResport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_generateSalesResport.ForeColor = System.Drawing.Color.White;
            this.button_generateSalesResport.Location = new System.Drawing.Point(505, 136);
            this.button_generateSalesResport.Name = "button_generateSalesResport";
            this.button_generateSalesResport.Size = new System.Drawing.Size(138, 51);
            this.button_generateSalesResport.TabIndex = 22;
            this.button_generateSalesResport.Text = "Generar";
            this.button_generateSalesResport.UseVisualStyleBackColor = false;
            this.button_generateSalesResport.Click += new System.EventHandler(this.button_generateSalesResport_Click);
            // 
            // comboBox_products
            // 
            this.comboBox_products.FormattingEnabled = true;
            this.comboBox_products.Location = new System.Drawing.Point(471, 77);
            this.comboBox_products.Name = "comboBox_products";
            this.comboBox_products.Size = new System.Drawing.Size(225, 31);
            this.comboBox_products.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(467, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Producto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha final:";
            // 
            // dateTimePicker_fechaFin
            // 
            this.dateTimePicker_fechaFin.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaFin.Location = new System.Drawing.Point(28, 159);
            this.dateTimePicker_fechaFin.Name = "dateTimePicker_fechaFin";
            this.dateTimePicker_fechaFin.Size = new System.Drawing.Size(340, 28);
            this.dateTimePicker_fechaFin.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha inicial:";
            // 
            // dateTimePicker_fechaIni
            // 
            this.dateTimePicker_fechaIni.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaIni.Location = new System.Drawing.Point(28, 77);
            this.dateTimePicker_fechaIni.Name = "dateTimePicker_fechaIni";
            this.dateTimePicker_fechaIni.Size = new System.Drawing.Size(340, 28);
            this.dateTimePicker_fechaIni.TabIndex = 4;
            // 
            // GenerateSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(811, 297);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenerateSalesReport";
            this.Text = "Generar Reporte de Ventas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaIni;
        private System.Windows.Forms.Button button_generateSalesResport;
        private System.Windows.Forms.ComboBox comboBox_products;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaFin;
    }
}