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
            this.button_generate.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_generate.ForeColor = System.Drawing.Color.White;
            this.button_generate.Location = new System.Drawing.Point(51, 269);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(138, 51);
            this.button_generate.TabIndex = 20;
            this.button_generate.Text = "Generar";
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
            this.groupBox1.Location = new System.Drawing.Point(27, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1334, 369);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros para el reporte";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox_allW);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.list_warehouses);
            this.groupBox4.Location = new System.Drawing.Point(1019, 50);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(277, 291);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Almacenes a considerar";
            // 
            // checkBox_allW
            // 
            this.checkBox_allW.AutoSize = true;
            this.checkBox_allW.Checked = true;
            this.checkBox_allW.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_allW.Location = new System.Drawing.Point(15, 243);
            this.checkBox_allW.Name = "checkBox_allW";
            this.checkBox_allW.Size = new System.Drawing.Size(85, 27);
            this.checkBox_allW.TabIndex = 51;
            this.checkBox_allW.Text = "Todos";
            this.checkBox_allW.UseVisualStyleBackColor = true;
            this.checkBox_allW.CheckedChanged += new System.EventHandler(this.checkBox_allW_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkedListBox2);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(312, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(316, 383);
            this.groupBox5.TabIndex = 47;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Materias primas a considerar";
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.CheckOnClick = true;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(15, 31);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(241, 329);
            this.checkedListBox2.TabIndex = 45;
            // 
            // list_warehouses
            // 
            this.list_warehouses.CheckOnClick = true;
            this.list_warehouses.Enabled = false;
            this.list_warehouses.FormattingEnabled = true;
            this.list_warehouses.Location = new System.Drawing.Point(15, 31);
            this.list_warehouses.Name = "list_warehouses";
            this.list_warehouses.Size = new System.Drawing.Size(241, 204);
            this.list_warehouses.TabIndex = 45;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_allRM);
            this.groupBox2.Controls.Add(this.list_rawMaterials);
            this.groupBox2.Location = new System.Drawing.Point(621, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 291);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Materias primas a considerar";
            // 
            // checkBox_allRM
            // 
            this.checkBox_allRM.AutoSize = true;
            this.checkBox_allRM.Checked = true;
            this.checkBox_allRM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_allRM.Location = new System.Drawing.Point(18, 243);
            this.checkBox_allRM.Name = "checkBox_allRM";
            this.checkBox_allRM.Size = new System.Drawing.Size(85, 27);
            this.checkBox_allRM.TabIndex = 50;
            this.checkBox_allRM.Text = "Todos";
            this.checkBox_allRM.UseVisualStyleBackColor = true;
            this.checkBox_allRM.CheckedChanged += new System.EventHandler(this.checkBox_allRM_CheckedChanged);
            // 
            // list_rawMaterials
            // 
            this.list_rawMaterials.CheckOnClick = true;
            this.list_rawMaterials.Enabled = false;
            this.list_rawMaterials.FormattingEnabled = true;
            this.list_rawMaterials.Location = new System.Drawing.Point(18, 31);
            this.list_rawMaterials.Name = "list_rawMaterials";
            this.list_rawMaterials.Size = new System.Drawing.Size(258, 204);
            this.list_rawMaterials.TabIndex = 45;
            // 
            // groupbox_workers
            // 
            this.groupbox_workers.Controls.Add(this.checkBox_allProd);
            this.groupbox_workers.Controls.Add(this.list_products);
            this.groupbox_workers.Location = new System.Drawing.Point(273, 50);
            this.groupbox_workers.Name = "groupbox_workers";
            this.groupbox_workers.Size = new System.Drawing.Size(306, 291);
            this.groupbox_workers.TabIndex = 33;
            this.groupbox_workers.TabStop = false;
            this.groupbox_workers.Text = "Productos a considerar";
            // 
            // checkBox_allProd
            // 
            this.checkBox_allProd.AutoSize = true;
            this.checkBox_allProd.Checked = true;
            this.checkBox_allProd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_allProd.Location = new System.Drawing.Point(15, 243);
            this.checkBox_allProd.Name = "checkBox_allProd";
            this.checkBox_allProd.Size = new System.Drawing.Size(85, 27);
            this.checkBox_allProd.TabIndex = 49;
            this.checkBox_allProd.Text = "Todos";
            this.checkBox_allProd.UseVisualStyleBackColor = true;
            this.checkBox_allProd.CheckedChanged += new System.EventHandler(this.checkBox_allProd_CheckedChanged);
            // 
            // list_products
            // 
            this.list_products.CheckOnClick = true;
            this.list_products.Enabled = false;
            this.list_products.FormattingEnabled = true;
            this.list_products.Location = new System.Drawing.Point(15, 29);
            this.list_products.Name = "list_products";
            this.list_products.Size = new System.Drawing.Size(241, 204);
            this.list_products.TabIndex = 45;
            //             
            // dateTimePicker_fechaIni
            // 
            this.dateTimePicker_fechaIni.CustomFormat = "";
            this.dateTimePicker_fechaIni.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_fechaIni.Location = new System.Drawing.Point(21, 81);
            this.dateTimePicker_fechaIni.Name = "dateTimePicker_fechaIni";
            this.dateTimePicker_fechaIni.Size = new System.Drawing.Size(211, 28);
            this.dateTimePicker_fechaIni.TabIndex = 31;
            // 
            // dateTimePicker_fechaFin
            // 
            this.dateTimePicker_fechaFin.CalendarFont = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaFin.CustomFormat = "";
            this.dateTimePicker_fechaFin.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_fechaFin.Location = new System.Drawing.Point(21, 180);
            this.dateTimePicker_fechaFin.Name = "dateTimePicker_fechaFin";
            this.dateTimePicker_fechaFin.Size = new System.Drawing.Size(211, 28);
            this.dateTimePicker_fechaFin.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 152);
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
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(27, 23);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1334, 81);
            this.textBox1.TabIndex = 38;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GenerateKardexReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1392, 527);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenerateKardexReport";
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