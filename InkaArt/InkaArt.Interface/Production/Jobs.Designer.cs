﻿namespace InkaArt.Interface.Production
{
    partial class Jobs
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
            this.dataGridView_process = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioExportacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Button_processDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_process)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_process
            // 
            this.dataGridView_process.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_process.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_process.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_process.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.PrecioLocal,
            this.PrecioExportacion,
            this.Seleccionar});
            this.dataGridView_process.Location = new System.Drawing.Point(23, 23);
            this.dataGridView_process.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_process.Name = "dataGridView_process";
            this.dataGridView_process.Size = new System.Drawing.Size(444, 246);
            this.dataGridView_process.TabIndex = 7;
            this.dataGridView_process.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // PrecioLocal
            // 
            this.PrecioLocal.HeaderText = "Proceso";
            this.PrecioLocal.Name = "PrecioLocal";
            // 
            // PrecioExportacion
            // 
            this.PrecioExportacion.HeaderText = "Cantidad de puestos";
            this.PrecioExportacion.Name = "PrecioExportacion";
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Seleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Button_processDetails
            // 
            this.Button_processDetails.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_processDetails.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_processDetails.ForeColor = System.Drawing.Color.White;
            this.Button_processDetails.Location = new System.Drawing.Point(178, 276);
            this.Button_processDetails.Name = "Button_processDetails";
            this.Button_processDetails.Size = new System.Drawing.Size(103, 42);
            this.Button_processDetails.TabIndex = 20;
            this.Button_processDetails.Text = "Ver Detalles";
            this.Button_processDetails.UseVisualStyleBackColor = false;
            this.Button_processDetails.Click += new System.EventHandler(this.Button_processDetails_Click);
            // 
            // Jobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 335);
            this.Controls.Add(this.Button_processDetails);
            this.Controls.Add(this.dataGridView_process);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Jobs";
            this.Text = "Procesos de Producción";
            this.Load += new System.EventHandler(this.Jobs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_process)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_process;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioExportacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.Button Button_processDetails;
    }
}