﻿namespace InkaArt.Interface.Warehouse
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.list_products = new System.Windows.Forms.CheckedListBox();
            this.groupbox_workers = new System.Windows.Forms.GroupBox();
            this.list_rawMaterials = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.list_warehouses = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupbox_workers.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_generate
            // 
            this.button_generate.BackColor = System.Drawing.Color.SteelBlue;
            this.button_generate.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_generate.ForeColor = System.Drawing.Color.White;
            this.button_generate.Location = new System.Drawing.Point(110, 315);
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
            this.groupBox1.Controls.Add(this.dateTimePicker_fechaFin);
            this.groupBox1.Controls.Add(this.button_generate);
            this.groupBox1.Controls.Add(this.dateTimePicker_fechaIni);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1433, 453);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros para el reporte";
            // 
            // dateTimePicker_fechaFin
            // 
            this.dateTimePicker_fechaFin.CalendarFont = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaFin.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_fechaFin.Location = new System.Drawing.Point(21, 195);
            this.dateTimePicker_fechaFin.Name = "dateTimePicker_fechaFin";
            this.dateTimePicker_fechaFin.Size = new System.Drawing.Size(334, 28);
            this.dateTimePicker_fechaFin.TabIndex = 32;
            // 
            // dateTimePicker_fechaIni
            // 
            this.dateTimePicker_fechaIni.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_fechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_fechaIni.Location = new System.Drawing.Point(21, 78);
            this.dateTimePicker_fechaIni.Name = "dateTimePicker_fechaIni";
            this.dateTimePicker_fechaIni.Size = new System.Drawing.Size(334, 28);
            this.dateTimePicker_fechaIni.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 167);
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
            // list_products
            // 
            this.list_products.CheckOnClick = true;
            this.list_products.FormattingEnabled = true;
            this.list_products.Location = new System.Drawing.Point(15, 31);
            this.list_products.Name = "list_products";
            this.list_products.Size = new System.Drawing.Size(241, 329);
            this.list_products.TabIndex = 45;
            // 
            // groupbox_workers
            // 
            this.groupbox_workers.Controls.Add(this.list_products);
            this.groupbox_workers.Location = new System.Drawing.Point(403, 50);
            this.groupbox_workers.Name = "groupbox_workers";
            this.groupbox_workers.Size = new System.Drawing.Size(316, 383);
            this.groupbox_workers.TabIndex = 33;
            this.groupbox_workers.TabStop = false;
            this.groupbox_workers.Text = "Productos a considerar";
            // 
            // list_rawMaterials
            // 
            this.list_rawMaterials.CheckOnClick = true;
            this.list_rawMaterials.FormattingEnabled = true;
            this.list_rawMaterials.Location = new System.Drawing.Point(15, 31);
            this.list_rawMaterials.Name = "list_rawMaterials";
            this.list_rawMaterials.Size = new System.Drawing.Size(241, 329);
            this.list_rawMaterials.TabIndex = 45;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.list_rawMaterials);
            this.groupBox2.Location = new System.Drawing.Point(756, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 383);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Materias primas a considerar";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(15, 31);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(241, 329);
            this.checkedListBox1.TabIndex = 45;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkedListBox1);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(312, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 383);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Materias primas a considerar";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.list_warehouses);
            this.groupBox4.Location = new System.Drawing.Point(1099, 50);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(316, 383);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Almacenes a considerar";
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
            this.list_warehouses.FormattingEnabled = true;
            this.list_warehouses.Location = new System.Drawing.Point(15, 31);
            this.list_warehouses.Name = "list_warehouses";
            this.list_warehouses.Size = new System.Drawing.Size(241, 329);
            this.list_warehouses.TabIndex = 45;
            // 
            // GenerateKardexReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1485, 502);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenerateKardexReport";
            this.Text = "Generar Reporte Kardex";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupbox_workers.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}