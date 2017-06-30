﻿namespace InkaArt.Interface.Production
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
            this.dateTimePicker_ini = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_fin = new System.Windows.Forms.DateTimePicker();
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
            this.groupBox1.Controls.Add(this.dateTimePicker_ini);
            this.groupBox1.Controls.Add(this.dateTimePicker_fin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(38, 119);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(494, 305);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros para el reporte";
            // 
            // button_generate
            // 
            this.button_generate.BackColor = System.Drawing.Color.SteelBlue;
            this.button_generate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_generate.ForeColor = System.Drawing.Color.White;
            this.button_generate.Location = new System.Drawing.Point(33, 211);
            this.button_generate.Margin = new System.Windows.Forms.Padding(2);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(104, 41);
            this.button_generate.TabIndex = 24;
            this.button_generate.Text = "Generar";
            this.button_generate.UseVisualStyleBackColor = false;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // groupbox_workers
            // 
            this.groupbox_workers.Controls.Add(this.checkBox_allWorkers);
            this.groupbox_workers.Controls.Add(this.list_workers);
            this.groupbox_workers.Location = new System.Drawing.Point(178, 50);
            this.groupbox_workers.Margin = new System.Windows.Forms.Padding(2);
            this.groupbox_workers.Name = "groupbox_workers";
            this.groupbox_workers.Padding = new System.Windows.Forms.Padding(2);
            this.groupbox_workers.Size = new System.Drawing.Size(298, 236);
            this.groupbox_workers.TabIndex = 34;
            this.groupbox_workers.TabStop = false;
            this.groupbox_workers.Text = "Trabajadores a considerar";
            // 
            // checkBox_allWorkers
            // 
            this.checkBox_allWorkers.AutoSize = true;
            this.checkBox_allWorkers.Checked = true;
            this.checkBox_allWorkers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_allWorkers.Location = new System.Drawing.Point(11, 197);
            this.checkBox_allWorkers.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_allWorkers.Name = "checkBox_allWorkers";
            this.checkBox_allWorkers.Size = new System.Drawing.Size(69, 22);
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
            this.list_workers.Location = new System.Drawing.Point(11, 24);
            this.list_workers.Margin = new System.Windows.Forms.Padding(2);
            this.list_workers.Name = "list_workers";
            this.list_workers.Size = new System.Drawing.Size(263, 151);
            this.list_workers.TabIndex = 45;
            // 
            // dateTimePicker_ini
            // 
            this.dateTimePicker_ini.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_ini.Location = new System.Drawing.Point(27, 71);
            this.dateTimePicker_ini.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_ini.Name = "dateTimePicker_ini";
            this.dateTimePicker_ini.Size = new System.Drawing.Size(120, 24);
            this.dateTimePicker_ini.TabIndex = 3;
            // 
            // dateTimePicker_fin
            // 
            this.dateTimePicker_fin.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_fin.Location = new System.Drawing.Point(27, 149);
            this.dateTimePicker_fin.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_fin.Name = "dateTimePicker_fin";
            this.dateTimePicker_fin.Size = new System.Drawing.Size(120, 24);
            this.dateTimePicker_fin.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha inicial";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(38, 22);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(494, 75);
            this.textBox1.TabIndex = 36;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GeneratePerformanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 466);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GeneratePerformanceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.DateTimePicker dateTimePicker_ini;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.GroupBox groupbox_workers;
        private System.Windows.Forms.CheckBox checkBox_allWorkers;
        private System.Windows.Forms.CheckedListBox list_workers;
        private System.Windows.Forms.TextBox textBox1;
    }
}