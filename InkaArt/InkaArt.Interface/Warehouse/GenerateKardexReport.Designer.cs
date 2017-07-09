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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateKardexReport));
            this.button_generate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox_allW = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.list_warehouses = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_allRM = new System.Windows.Forms.CheckBox();
            this.list_rawMaterials = new System.Windows.Forms.CheckedListBox();
            this.groupbox_workers = new System.Windows.Forms.GroupBox();
            this.checkBox_allProd = new System.Windows.Forms.CheckBox();
            this.list_products = new System.Windows.Forms.CheckedListBox();
            this.dateTimePicker_fechaIni = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_fechaFin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupbox_workers.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_generate
            // 
            this.button_generate.BackColor = System.Drawing.Color.SteelBlue;
            this.button_generate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_generate.ForeColor = System.Drawing.Color.White;
            this.button_generate.Location = new System.Drawing.Point(38, 219);
            this.button_generate.Margin = new System.Windows.Forms.Padding(2);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(104, 41);
            this.button_generate.TabIndex = 20;
            this.button_generate.Text = "🗀 Generar";
            this.button_generate.UseVisualStyleBackColor = false;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupbox_workers);
            this.groupBox1.Controls.Add(this.button_generate);
            this.groupBox1.Controls.Add(this.dateTimePicker_fechaIni);
            this.groupBox1.Controls.Add(this.dateTimePicker_fechaFin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 99);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1000, 300);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros para el reporte";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox_allW);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.list_warehouses);
            this.groupBox4.Location = new System.Drawing.Point(764, 41);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(208, 236);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Almacenes a considerar";
            // 
            // checkBox_allW
            // 
            this.checkBox_allW.AutoSize = true;
            this.checkBox_allW.Checked = true;
            this.checkBox_allW.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_allW.Location = new System.Drawing.Point(11, 197);
            this.checkBox_allW.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_allW.Name = "checkBox_allW";
            this.checkBox_allW.Size = new System.Drawing.Size(69, 22);
            this.checkBox_allW.TabIndex = 51;
            this.checkBox_allW.Text = "Todos";
            this.checkBox_allW.UseVisualStyleBackColor = true;
            this.checkBox_allW.CheckedChanged += new System.EventHandler(this.checkBox_allW_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkedListBox2);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(234, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(237, 311);
            this.groupBox5.TabIndex = 47;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Materias primas a considerar";
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.CheckOnClick = true;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(11, 25);
            this.checkedListBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(182, 256);
            this.checkedListBox2.TabIndex = 45;
            // 
            // list_warehouses
            // 
            this.list_warehouses.CheckOnClick = true;
            this.list_warehouses.Enabled = false;
            this.list_warehouses.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_warehouses.FormattingEnabled = true;
            this.list_warehouses.Location = new System.Drawing.Point(11, 25);
            this.list_warehouses.Margin = new System.Windows.Forms.Padding(2);
            this.list_warehouses.Name = "list_warehouses";
            this.list_warehouses.Size = new System.Drawing.Size(182, 151);
            this.list_warehouses.TabIndex = 45;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_allRM);
            this.groupBox2.Controls.Add(this.list_rawMaterials);
            this.groupBox2.Location = new System.Drawing.Point(466, 41);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(254, 236);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Materias primas a considerar";
            // 
            // checkBox_allRM
            // 
            this.checkBox_allRM.AutoSize = true;
            this.checkBox_allRM.Checked = true;
            this.checkBox_allRM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_allRM.Location = new System.Drawing.Point(14, 197);
            this.checkBox_allRM.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_allRM.Name = "checkBox_allRM";
            this.checkBox_allRM.Size = new System.Drawing.Size(69, 22);
            this.checkBox_allRM.TabIndex = 50;
            this.checkBox_allRM.Text = "Todos";
            this.checkBox_allRM.UseVisualStyleBackColor = true;
            this.checkBox_allRM.CheckedChanged += new System.EventHandler(this.checkBox_allRM_CheckedChanged);
            // 
            // list_rawMaterials
            // 
            this.list_rawMaterials.CheckOnClick = true;
            this.list_rawMaterials.Enabled = false;
            this.list_rawMaterials.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_rawMaterials.FormattingEnabled = true;
            this.list_rawMaterials.Location = new System.Drawing.Point(14, 25);
            this.list_rawMaterials.Margin = new System.Windows.Forms.Padding(2);
            this.list_rawMaterials.Name = "list_rawMaterials";
            this.list_rawMaterials.Size = new System.Drawing.Size(194, 151);
            this.list_rawMaterials.TabIndex = 45;
            // 
            // groupbox_workers
            // 
            this.groupbox_workers.Controls.Add(this.checkBox_allProd);
            this.groupbox_workers.Controls.Add(this.list_products);
            this.groupbox_workers.Location = new System.Drawing.Point(205, 41);
            this.groupbox_workers.Margin = new System.Windows.Forms.Padding(2);
            this.groupbox_workers.Name = "groupbox_workers";
            this.groupbox_workers.Padding = new System.Windows.Forms.Padding(2);
            this.groupbox_workers.Size = new System.Drawing.Size(230, 236);
            this.groupbox_workers.TabIndex = 33;
            this.groupbox_workers.TabStop = false;
            this.groupbox_workers.Text = "Productos a considerar";
            // 
            // checkBox_allProd
            // 
            this.checkBox_allProd.AutoSize = true;
            this.checkBox_allProd.Checked = true;
            this.checkBox_allProd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_allProd.Location = new System.Drawing.Point(11, 197);
            this.checkBox_allProd.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_allProd.Name = "checkBox_allProd";
            this.checkBox_allProd.Size = new System.Drawing.Size(69, 22);
            this.checkBox_allProd.TabIndex = 49;
            this.checkBox_allProd.Text = "Todos";
            this.checkBox_allProd.UseVisualStyleBackColor = true;
            this.checkBox_allProd.CheckedChanged += new System.EventHandler(this.checkBox_allProd_CheckedChanged);
            // 
            // list_products
            // 
            this.list_products.CheckOnClick = true;
            this.list_products.Enabled = false;
            this.list_products.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_products.FormattingEnabled = true;
            this.list_products.Location = new System.Drawing.Point(11, 24);
            this.list_products.Margin = new System.Windows.Forms.Padding(2);
            this.list_products.Name = "list_products";
            this.list_products.Size = new System.Drawing.Size(182, 151);
            this.list_products.TabIndex = 45;
            // 
            // dateTimePicker_fechaIni
            // 
            this.dateTimePicker_fechaIni.CustomFormat = "";
            this.dateTimePicker_fechaIni.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_fechaIni.Location = new System.Drawing.Point(16, 66);
            this.dateTimePicker_fechaIni.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_fechaIni.Name = "dateTimePicker_fechaIni";
            this.dateTimePicker_fechaIni.Size = new System.Drawing.Size(159, 24);
            this.dateTimePicker_fechaIni.TabIndex = 31;
            // 
            // dateTimePicker_fechaFin
            // 
            this.dateTimePicker_fechaFin.CalendarFont = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaFin.CustomFormat = "";
            this.dateTimePicker_fechaFin.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_fechaFin.Location = new System.Drawing.Point(16, 146);
            this.dateTimePicker_fechaFin.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_fechaFin.Name = "dateTimePicker_fechaFin";
            this.dateTimePicker_fechaFin.Size = new System.Drawing.Size(159, 24);
            this.dateTimePicker_fechaFin.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 124);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Fecha final del periodo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Fecha inicial del periodo";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(20, 19);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1000, 66);
            this.textBox1.TabIndex = 38;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GenerateKardexReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1044, 428);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GenerateKardexReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Reporte Kardex";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupbox_workers.ResumeLayout(false);
            this.groupbox_workers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaIni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaFin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox list_rawMaterials;
        private System.Windows.Forms.GroupBox groupbox_workers;
        private System.Windows.Forms.CheckedListBox list_products;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.CheckedListBox list_warehouses;
        private System.Windows.Forms.CheckBox checkBox_allW;
        private System.Windows.Forms.CheckBox checkBox_allRM;
        private System.Windows.Forms.CheckBox checkBox_allProd;
        private System.Windows.Forms.TextBox textBox1;
    }
}