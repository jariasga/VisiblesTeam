namespace InkaArt.Interface.Production
{
    partial class GeneratePerformanceReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratePerformanceReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_generate = new System.Windows.Forms.Button();
            this.groupbox_workers = new System.Windows.Forms.GroupBox();
            this.checkBox_allWorkers = new System.Windows.Forms.CheckBox();
            this.list_workers = new System.Windows.Forms.CheckedListBox();
            this.dateTimePicker_fin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_ini = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupbox_workers.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_generate);
            this.groupBox1.Controls.Add(this.groupbox_workers);
            this.groupBox1.Controls.Add(this.dateTimePicker_fin);
            this.groupBox1.Controls.Add(this.dateTimePicker_ini);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(50, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 375);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros para el reporte";
            // 
            // button_generate
            // 
            this.button_generate.BackColor = System.Drawing.Color.SteelBlue;
            this.button_generate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_generate.ForeColor = System.Drawing.Color.White;
            this.button_generate.Location = new System.Drawing.Point(44, 260);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(138, 51);
            this.button_generate.TabIndex = 24;
            this.button_generate.Text = "Generar";
            this.button_generate.UseVisualStyleBackColor = false;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // groupbox_workers
            // 
            this.groupbox_workers.Controls.Add(this.checkBox_allWorkers);
            this.groupbox_workers.Controls.Add(this.list_workers);
            this.groupbox_workers.Location = new System.Drawing.Point(238, 62);
            this.groupbox_workers.Name = "groupbox_workers";
            this.groupbox_workers.Size = new System.Drawing.Size(398, 291);
            this.groupbox_workers.TabIndex = 34;
            this.groupbox_workers.TabStop = false;
            this.groupbox_workers.Text = "Trabajadores a considerar";
            // 
            // checkBox_allWorkers
            // 
            this.checkBox_allWorkers.AutoSize = true;
            this.checkBox_allWorkers.Checked = true;
            this.checkBox_allWorkers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_allWorkers.Location = new System.Drawing.Point(15, 243);
            this.checkBox_allWorkers.Name = "checkBox_allWorkers";
            this.checkBox_allWorkers.Size = new System.Drawing.Size(85, 27);
            this.checkBox_allWorkers.TabIndex = 49;
            this.checkBox_allWorkers.Text = "Todos";
            this.checkBox_allWorkers.UseVisualStyleBackColor = true;
            this.checkBox_allWorkers.CheckedChanged += new System.EventHandler(this.checkBox_allWorkers_CheckedChanged);
            // 
            // list_workers
            // 
            this.list_workers.CheckOnClick = true;
            this.list_workers.Enabled = false;
            this.list_workers.FormattingEnabled = true;
            this.list_workers.Location = new System.Drawing.Point(15, 29);
            this.list_workers.Name = "list_workers";
            this.list_workers.Size = new System.Drawing.Size(349, 204);
            this.list_workers.TabIndex = 45;
            // 
            // dateTimePicker_fin
            // 
            this.dateTimePicker_fin.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_fin.Location = new System.Drawing.Point(36, 183);
            this.dateTimePicker_fin.Name = "dateTimePicker_fin";
            this.dateTimePicker_fin.Size = new System.Drawing.Size(158, 28);
            this.dateTimePicker_fin.TabIndex = 4;
            // 
            // dateTimePicker_ini
            // 
            this.dateTimePicker_ini.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_ini.Location = new System.Drawing.Point(36, 87);
            this.dateTimePicker_ini.Name = "dateTimePicker_ini";
            this.dateTimePicker_ini.Size = new System.Drawing.Size(158, 28);
            this.dateTimePicker_ini.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha inicial";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(50, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(658, 92);
            this.textBox1.TabIndex = 36;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GeneratePerformanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(771, 573);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "GeneratePerformanceReport";
            this.Text = "Generar Reporte de Rendimiento de Trabajadores";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupbox_workers.ResumeLayout(false);
            this.groupbox_workers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ini;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.GroupBox groupbox_workers;
        private System.Windows.Forms.CheckBox checkBox_allWorkers;
        private System.Windows.Forms.CheckedListBox list_workers;
        private System.Windows.Forms.TextBox textBox1;
    }
}