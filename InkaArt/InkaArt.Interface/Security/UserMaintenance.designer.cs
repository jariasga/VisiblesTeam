﻿namespace InkaArt.Interface.Security
{
    partial class UserMaintenance
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
            this.dataGridViewUserMaintenance = new System.Windows.Forms.DataGridView();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonMassiveUpload = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxLastnameFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNameFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserMaintenance)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewUserMaintenance
            // 
            this.dataGridViewUserMaintenance.AllowUserToAddRows = false;
            this.dataGridViewUserMaintenance.AllowUserToDeleteRows = false;
            this.dataGridViewUserMaintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserMaintenance.Location = new System.Drawing.Point(12, 82);
            this.dataGridViewUserMaintenance.MultiSelect = false;
            this.dataGridViewUserMaintenance.Name = "dataGridViewUserMaintenance";
            this.dataGridViewUserMaintenance.ReadOnly = true;
            this.dataGridViewUserMaintenance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserMaintenance.Size = new System.Drawing.Size(899, 302);
            this.dataGridViewUserMaintenance.TabIndex = 0;
            this.dataGridViewUserMaintenance.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUserMaintenance_CellContentDoubleClick);
            // 
            // buttonNew
            // 
            this.buttonNew.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonNew.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNew.ForeColor = System.Drawing.Color.White;
            this.buttonNew.Location = new System.Drawing.Point(183, 411);
            this.buttonNew.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(88, 39);
            this.buttonNew.TabIndex = 4;
            this.buttonNew.Text = "Nuevo";
            this.buttonNew.UseVisualStyleBackColor = false;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonModify
            // 
            this.buttonModify.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonModify.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModify.ForeColor = System.Drawing.Color.White;
            this.buttonModify.Location = new System.Drawing.Point(292, 411);
            this.buttonModify.Margin = new System.Windows.Forms.Padding(2);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(88, 39);
            this.buttonModify.TabIndex = 5;
            this.buttonModify.Text = "Modificar";
            this.buttonModify.UseVisualStyleBackColor = false;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // buttonMassiveUpload
            // 
            this.buttonMassiveUpload.BackColor = System.Drawing.Color.Gray;
            this.buttonMassiveUpload.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMassiveUpload.ForeColor = System.Drawing.Color.White;
            this.buttonMassiveUpload.Location = new System.Drawing.Point(531, 411);
            this.buttonMassiveUpload.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMassiveUpload.Name = "buttonMassiveUpload";
            this.buttonMassiveUpload.Size = new System.Drawing.Size(199, 39);
            this.buttonMassiveUpload.TabIndex = 7;
            this.buttonMassiveUpload.Text = "Carga Masiva";
            this.buttonMassiveUpload.UseVisualStyleBackColor = false;
            this.buttonMassiveUpload.Click += new System.EventHandler(this.buttonMassiveUpload_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Gray;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(407, 411);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(86, 39);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxLastnameFilter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxNameFilter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 54);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar por:";
            // 
            // textBoxLastnameFilter
            // 
            this.textBoxLastnameFilter.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBoxLastnameFilter.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLastnameFilter.Location = new System.Drawing.Point(253, 19);
            this.textBoxLastnameFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxLastnameFilter.Name = "textBoxLastnameFilter";
            this.textBoxLastnameFilter.Size = new System.Drawing.Size(100, 26);
            this.textBoxLastnameFilter.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(184, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Apellido:";
            // 
            // textBoxNameFilter
            // 
            this.textBoxNameFilter.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBoxNameFilter.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNameFilter.Location = new System.Drawing.Point(76, 19);
            this.textBoxNameFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNameFilter.Name = "textBoxNameFilter";
            this.textBoxNameFilter.Size = new System.Drawing.Size(100, 26);
            this.textBoxNameFilter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre:";
            // 
            // buttonFilter
            // 
            this.buttonFilter.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonFilter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFilter.ForeColor = System.Drawing.Color.White;
            this.buttonFilter.Location = new System.Drawing.Point(397, 26);
            this.buttonFilter.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(88, 39);
            this.buttonFilter.TabIndex = 3;
            this.buttonFilter.Text = "Filtrar";
            this.buttonFilter.UseVisualStyleBackColor = false;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // UserMaintenance
            // 
            this.AcceptButton = this.buttonFilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(923, 470);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonMassiveUpload);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.dataGridViewUserMaintenance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserMaintenance";
            this.Text = "Mantenimiento de Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserMaintenance)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonMassiveUpload;
        protected System.Windows.Forms.DataGridView dataGridViewUserMaintenance;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxLastnameFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNameFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFilter;
    }
}