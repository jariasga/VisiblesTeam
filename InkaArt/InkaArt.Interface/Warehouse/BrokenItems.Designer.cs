namespace InkaArt.Interface.Warehouse
{
    partial class BrokenItems
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
            this.button_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label_item = new System.Windows.Forms.Label();
            this.combo_item = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_type = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.SteelBlue;
            this.button_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(82, 196);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(127, 42);
            this.button_save.TabIndex = 39;
            this.button_save.Text = "🖫 Guardar";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(37, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "Cantidad";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.White;
            this.textBox6.Font = new System.Drawing.Font("Arial", 12F);
            this.textBox6.Location = new System.Drawing.Point(40, 144);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(208, 26);
            this.textBox6.TabIndex = 37;
            // 
            // label_item
            // 
            this.label_item.AutoSize = true;
            this.label_item.Font = new System.Drawing.Font("Arial", 12F);
            this.label_item.Location = new System.Drawing.Point(37, 73);
            this.label_item.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_item.Name = "label_item";
            this.label_item.Size = new System.Drawing.Size(64, 18);
            this.label_item.TabIndex = 36;
            this.label_item.Text = "Nombre";
            // 
            // combo_item
            // 
            this.combo_item.Font = new System.Drawing.Font("Arial", 12F);
            this.combo_item.FormattingEnabled = true;
            this.combo_item.Location = new System.Drawing.Point(40, 94);
            this.combo_item.Name = "combo_item";
            this.combo_item.Size = new System.Drawing.Size(208, 26);
            this.combo_item.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(37, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 18);
            this.label3.TabIndex = 34;
            this.label3.Text = "Tipo";
            // 
            // combo_type
            // 
            this.combo_type.Font = new System.Drawing.Font("Arial", 12F);
            this.combo_type.FormattingEnabled = true;
            this.combo_type.Location = new System.Drawing.Point(40, 44);
            this.combo_type.Name = "combo_type";
            this.combo_type.Size = new System.Drawing.Size(208, 26);
            this.combo_type.TabIndex = 33;
            this.combo_type.SelectedValueChanged += new System.EventHandler(this.combo_type_SelectedValueChanged);
            // 
            // BrokenItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label_item);
            this.Controls.Add(this.combo_item);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_type);
            this.Name = "BrokenItems";
            this.Text = "Items Rotos";
            this.Load += new System.EventHandler(this.BrokenItems_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label_item;
        private System.Windows.Forms.ComboBox combo_item;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_type;
    }
}