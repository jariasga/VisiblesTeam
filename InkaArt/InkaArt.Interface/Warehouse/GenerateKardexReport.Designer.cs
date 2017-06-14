namespace InkaArt.Interface.Warehouse
{
    partial class GenerateKardexReport
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
            this.button_generate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_fechaFin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_fechaIni = new System.Windows.Forms.DateTimePicker();
            this.comboBox_products = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_generate
            // 
            this.button_generate.BackColor = System.Drawing.Color.SteelBlue;
            this.button_generate.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_generate.ForeColor = System.Drawing.Color.White;
            this.button_generate.Location = new System.Drawing.Point(327, 301);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(138, 51);
            this.button_generate.TabIndex = 20;
            this.button_generate.Text = "Generar";
            this.button_generate.UseVisualStyleBackColor = false;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker_fechaFin);
            this.groupBox1.Controls.Add(this.dateTimePicker_fechaIni);
            this.groupBox1.Controls.Add(this.comboBox_products);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 249);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros para el reporte";
            // 
            // dateTimePicker_fechaFin
            // 
            this.dateTimePicker_fechaFin.CalendarFont = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaFin.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaFin.Location = new System.Drawing.Point(21, 171);
            this.dateTimePicker_fechaFin.Name = "dateTimePicker_fechaFin";
            this.dateTimePicker_fechaFin.Size = new System.Drawing.Size(334, 28);
            this.dateTimePicker_fechaFin.TabIndex = 32;
            // 
            // dateTimePicker_fechaIni
            // 
            this.dateTimePicker_fechaIni.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaIni.Location = new System.Drawing.Point(21, 78);
            this.dateTimePicker_fechaIni.Name = "dateTimePicker_fechaIni";
            this.dateTimePicker_fechaIni.Size = new System.Drawing.Size(334, 28);
            this.dateTimePicker_fechaIni.TabIndex = 31;
            // 
            // comboBox_products
            // 
            this.comboBox_products.FormattingEnabled = true;
            this.comboBox_products.Location = new System.Drawing.Point(451, 75);
            this.comboBox_products.Name = "comboBox_products";
            this.comboBox_products.Size = new System.Drawing.Size(212, 31);
            this.comboBox_products.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 22);
            this.label4.TabIndex = 28;
            this.label4.Text = "Fecha final del periodo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 22);
            this.label3.TabIndex = 27;
            this.label3.Text = "Fecha inicial del periodo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(449, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 22);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nombre del producto";
            // 
            // GenerateKardexReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(799, 364);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_generate);
            this.Name = "GenerateKardexReport";
            this.Text = "Generar Reporte Kardex";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaIni;
        private System.Windows.Forms.ComboBox comboBox_products;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaFin;
    }
}