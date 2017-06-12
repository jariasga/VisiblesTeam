namespace InkaArt.Interface.Warehouse
{
    partial class GenerateStockReport
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
            this.checkBox_rawMaterial = new System.Windows.Forms.CheckBox();
            this.checkBox_product = new System.Windows.Forms.CheckBox();
            this.button_generate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_rawMaterial);
            this.groupBox1.Controls.Add(this.checkBox_product);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(36, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros para el reporte";
            // 
            // checkBox_rawMaterial
            // 
            this.checkBox_rawMaterial.AutoSize = true;
            this.checkBox_rawMaterial.Location = new System.Drawing.Point(44, 107);
            this.checkBox_rawMaterial.Name = "checkBox_rawMaterial";
            this.checkBox_rawMaterial.Size = new System.Drawing.Size(174, 27);
            this.checkBox_rawMaterial.TabIndex = 1;
            this.checkBox_rawMaterial.Text = "Materias primas";
            this.checkBox_rawMaterial.UseVisualStyleBackColor = true;
            this.checkBox_rawMaterial.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox_product
            // 
            this.checkBox_product.AutoSize = true;
            this.checkBox_product.Location = new System.Drawing.Point(44, 48);
            this.checkBox_product.Name = "checkBox_product";
            this.checkBox_product.Size = new System.Drawing.Size(121, 27);
            this.checkBox_product.TabIndex = 0;
            this.checkBox_product.Text = "Productos";
            this.checkBox_product.UseVisualStyleBackColor = true;
            // 
            // button_generate
            // 
            this.button_generate.BackColor = System.Drawing.Color.SteelBlue;
            this.button_generate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_generate.ForeColor = System.Drawing.Color.White;
            this.button_generate.Location = new System.Drawing.Point(143, 211);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(138, 51);
            this.button_generate.TabIndex = 22;
            this.button_generate.Text = "Generar";
            this.button_generate.UseVisualStyleBackColor = false;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // GenerateStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 286);
            this.Controls.Add(this.button_generate);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenerateStockReport";
            this.Text = "Generar Reporte de Stocks";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_rawMaterial;
        private System.Windows.Forms.CheckBox checkBox_product;
        private System.Windows.Forms.Button button_generate;
    }
}