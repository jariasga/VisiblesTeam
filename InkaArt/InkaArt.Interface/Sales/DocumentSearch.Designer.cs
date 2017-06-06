﻿namespace InkaArt.Interface.Sales
{
    partial class DocumentSearch
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
            this.grid_documents = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_select = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_documents)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_documents
            // 
            this.grid_documents.AllowUserToAddRows = false;
            this.grid_documents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_documents.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.grid_documents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_documents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.grid_documents.Location = new System.Drawing.Point(41, 56);
            this.grid_documents.Name = "grid_documents";
            this.grid_documents.RowTemplate.Height = 24;
            this.grid_documents.Size = new System.Drawing.Size(881, 472);
            this.grid_documents.TabIndex = 0;
            this.grid_documents.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_documents_CellContentDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tipo";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Monto";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "IGV";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Total";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ID Pedido";
            this.Column6.Name = "Column6";
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.Gray;
            this.button_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.ForeColor = System.Drawing.Color.White;
            this.button_cancel.Location = new System.Drawing.Point(488, 549);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(200, 48);
            this.button_cancel.TabIndex = 32;
            this.button_cancel.Text = "＋ Cancelar";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_select
            // 
            this.button_select.BackColor = System.Drawing.Color.SteelBlue;
            this.button_select.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_select.ForeColor = System.Drawing.Color.White;
            this.button_select.Location = new System.Drawing.Point(267, 549);
            this.button_select.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(200, 48);
            this.button_select.TabIndex = 31;
            this.button_select.Text = "＋ Seleccionar";
            this.button_select.UseVisualStyleBackColor = false;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // DocumentSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 608);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.grid_documents);
            this.Name = "DocumentSearch";
            this.Text = "DocumentSearch";
            this.Load += new System.EventHandler(this.DocumentSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_documents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_documents;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_select;
    }
}