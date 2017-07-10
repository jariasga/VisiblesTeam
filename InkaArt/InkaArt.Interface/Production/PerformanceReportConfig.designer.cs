namespace InkaArt.Interface.Production
{
    partial class PerformanceReportConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerformanceReportConfig));
            this.groupbox_parameters = new System.Windows.Forms.GroupBox();
            this.groupbox_dates = new System.Windows.Forms.GroupBox();
            this.checkbox_dates = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.date_picker_start = new System.Windows.Forms.DateTimePicker();
            this.date_picker_end = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupbox_workers = new System.Windows.Forms.GroupBox();
            this.checkbox_workers = new System.Windows.Forms.CheckBox();
            this.list_workers = new System.Windows.Forms.CheckedListBox();
            this.button_generate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupbox_parameters.SuspendLayout();
            this.groupbox_dates.SuspendLayout();
            this.groupbox_workers.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupbox_parameters
            // 
            this.groupbox_parameters.Controls.Add(this.groupbox_dates);
            this.groupbox_parameters.Controls.Add(this.groupbox_workers);
            this.groupbox_parameters.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupbox_parameters.Location = new System.Drawing.Point(11, 110);
            this.groupbox_parameters.Margin = new System.Windows.Forms.Padding(2);
            this.groupbox_parameters.Name = "groupbox_parameters";
            this.groupbox_parameters.Padding = new System.Windows.Forms.Padding(2);
            this.groupbox_parameters.Size = new System.Drawing.Size(556, 290);
            this.groupbox_parameters.TabIndex = 0;
            this.groupbox_parameters.TabStop = false;
            this.groupbox_parameters.Text = "Parámetros para el reporte";
            // 
            // groupbox_dates
            // 
            this.groupbox_dates.Controls.Add(this.checkbox_dates);
            this.groupbox_dates.Controls.Add(this.label1);
            this.groupbox_dates.Controls.Add(this.date_picker_start);
            this.groupbox_dates.Controls.Add(this.date_picker_end);
            this.groupbox_dates.Controls.Add(this.label2);
            this.groupbox_dates.Location = new System.Drawing.Point(15, 36);
            this.groupbox_dates.Name = "groupbox_dates";
            this.groupbox_dates.Size = new System.Drawing.Size(163, 231);
            this.groupbox_dates.TabIndex = 35;
            this.groupbox_dates.TabStop = false;
            this.groupbox_dates.Text = "Intervalo de fechas";
            // 
            // checkbox_dates
            // 
            this.checkbox_dates.AutoSize = true;
            this.checkbox_dates.Checked = true;
            this.checkbox_dates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_dates.Location = new System.Drawing.Point(11, 174);
            this.checkbox_dates.Margin = new System.Windows.Forms.Padding(2);
            this.checkbox_dates.Name = "checkbox_dates";
            this.checkbox_dates.Size = new System.Drawing.Size(69, 22);
            this.checkbox_dates.TabIndex = 50;
            this.checkbox_dates.Text = "Todos";
            this.checkbox_dates.UseVisualStyleBackColor = true;
            this.checkbox_dates.CheckedChanged += new System.EventHandler(this.checkbox_dates_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha inicial";
            // 
            // date_picker_start
            // 
            this.date_picker_start.Enabled = false;
            this.date_picker_start.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_picker_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_picker_start.Location = new System.Drawing.Point(11, 58);
            this.date_picker_start.Margin = new System.Windows.Forms.Padding(2);
            this.date_picker_start.Name = "date_picker_start";
            this.date_picker_start.Size = new System.Drawing.Size(120, 24);
            this.date_picker_start.TabIndex = 3;
            // 
            // date_picker_end
            // 
            this.date_picker_end.Enabled = false;
            this.date_picker_end.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_picker_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_picker_end.Location = new System.Drawing.Point(11, 126);
            this.date_picker_end.Margin = new System.Windows.Forms.Padding(2);
            this.date_picker_end.Name = "date_picker_end";
            this.date_picker_end.Size = new System.Drawing.Size(120, 24);
            this.date_picker_end.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha final";
            // 
            // groupbox_workers
            // 
            this.groupbox_workers.Controls.Add(this.checkbox_workers);
            this.groupbox_workers.Controls.Add(this.list_workers);
            this.groupbox_workers.Location = new System.Drawing.Point(196, 36);
            this.groupbox_workers.Margin = new System.Windows.Forms.Padding(2);
            this.groupbox_workers.Name = "groupbox_workers";
            this.groupbox_workers.Padding = new System.Windows.Forms.Padding(2);
            this.groupbox_workers.Size = new System.Drawing.Size(344, 231);
            this.groupbox_workers.TabIndex = 34;
            this.groupbox_workers.TabStop = false;
            this.groupbox_workers.Text = "Trabajadores a considerar";
            // 
            // checkbox_workers
            // 
            this.checkbox_workers.AutoSize = true;
            this.checkbox_workers.Checked = true;
            this.checkbox_workers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_workers.Location = new System.Drawing.Point(13, 200);
            this.checkbox_workers.Margin = new System.Windows.Forms.Padding(2);
            this.checkbox_workers.Name = "checkbox_workers";
            this.checkbox_workers.Size = new System.Drawing.Size(69, 22);
            this.checkbox_workers.TabIndex = 49;
            this.checkbox_workers.Text = "Todos";
            this.checkbox_workers.UseVisualStyleBackColor = true;
            this.checkbox_workers.CheckedChanged += new System.EventHandler(this.checkbox_workers_CheckedChanged);
            // 
            // list_workers
            // 
            this.list_workers.CheckOnClick = true;
            this.list_workers.Enabled = false;
            this.list_workers.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_workers.FormattingEnabled = true;
            this.list_workers.Location = new System.Drawing.Point(13, 24);
            this.list_workers.Margin = new System.Windows.Forms.Padding(2);
            this.list_workers.Name = "list_workers";
            this.list_workers.Size = new System.Drawing.Size(317, 172);
            this.list_workers.TabIndex = 45;
            // 
            // button_generate
            // 
            this.button_generate.BackColor = System.Drawing.Color.SteelBlue;
            this.button_generate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_generate.ForeColor = System.Drawing.Color.White;
            this.button_generate.Location = new System.Drawing.Point(207, 407);
            this.button_generate.Margin = new System.Windows.Forms.Padding(2);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(158, 41);
            this.button_generate.TabIndex = 24;
            this.button_generate.Text = "Generar reporte";
            this.button_generate.UseVisualStyleBackColor = false;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(11, 11);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(556, 84);
            this.textBox1.TabIndex = 36;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GeneratePerformanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 459);
            this.Controls.Add(this.button_generate);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupbox_parameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GeneratePerformanceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Reporte de Rendimiento de Trabajadores";
            this.groupbox_parameters.ResumeLayout(false);
            this.groupbox_dates.ResumeLayout(false);
            this.groupbox_dates.PerformLayout();
            this.groupbox_workers.ResumeLayout(false);
            this.groupbox_workers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupbox_parameters;
        private System.Windows.Forms.DateTimePicker date_picker_start;
        private System.Windows.Forms.DateTimePicker date_picker_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.GroupBox groupbox_workers;
        private System.Windows.Forms.CheckBox checkbox_workers;
        private System.Windows.Forms.CheckedListBox list_workers;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupbox_dates;
        private System.Windows.Forms.CheckBox checkbox_dates;
    }
}