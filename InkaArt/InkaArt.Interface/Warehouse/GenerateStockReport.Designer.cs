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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateStockReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_rawMaterial = new System.Windows.Forms.CheckBox();
            this.checkBox_product = new System.Windows.Forms.CheckBox();
            this.button_generate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_rawMaterial);
            this.groupBox1.Controls.Add(this.checkBox_product);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 188);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(254, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros para el reporte";
            // 
            // checkBox_rawMaterial
            // 
            this.checkBox_rawMaterial.AutoSize = true;
            this.checkBox_rawMaterial.Location = new System.Drawing.Point(33, 87);
            this.checkBox_rawMaterial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox_rawMaterial.Name = "checkBox_rawMaterial";
            this.checkBox_rawMaterial.Size = new System.Drawing.Size(140, 22);
            this.checkBox_rawMaterial.TabIndex = 1;
            this.checkBox_rawMaterial.Text = "Materias primas";
            this.checkBox_rawMaterial.UseVisualStyleBackColor = true;
            this.checkBox_rawMaterial.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox_product
            // 
            this.checkBox_product.AutoSize = true;
            this.checkBox_product.Location = new System.Drawing.Point(33, 39);
            this.checkBox_product.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox_product.Name = "checkBox_product";
            this.checkBox_product.Size = new System.Drawing.Size(98, 22);
            this.checkBox_product.TabIndex = 0;
            this.checkBox_product.Text = "Productos";
            this.checkBox_product.UseVisualStyleBackColor = true;
            // 
            // button_generate
            // 
            this.button_generate.BackColor = System.Drawing.Color.SteelBlue;
            this.button_generate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_generate.ForeColor = System.Drawing.Color.White;
            this.button_generate.Location = new System.Drawing.Point(100, 340);
            this.button_generate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(104, 41);
            this.button_generate.TabIndex = 22;
            this.button_generate.Text = "Generar";
            this.button_generate.UseVisualStyleBackColor = false;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(32, 27);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(254, 131);
            this.textBox1.TabIndex = 39;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GenerateStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 392);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_generate);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GenerateStockReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Reporte de Stocks";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_rawMaterial;
        private System.Windows.Forms.CheckBox checkBox_product;
        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.TextBox textBox1;
    }
}