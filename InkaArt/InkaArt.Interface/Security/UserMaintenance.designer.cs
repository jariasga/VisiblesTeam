namespace InkaArt.Interface.Security
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserMaintenance)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUserMaintenance
            // 
            this.dataGridViewUserMaintenance.AllowUserToAddRows = false;
            this.dataGridViewUserMaintenance.AllowUserToDeleteRows = false;
            this.dataGridViewUserMaintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserMaintenance.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewUserMaintenance.MultiSelect = false;
            this.dataGridViewUserMaintenance.Name = "dataGridViewUserMaintenance";
            this.dataGridViewUserMaintenance.ReadOnly = true;
            this.dataGridViewUserMaintenance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserMaintenance.Size = new System.Drawing.Size(811, 232);
            this.dataGridViewUserMaintenance.TabIndex = 0;
            // 
            // buttonNew
            // 
            this.buttonNew.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonNew.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNew.ForeColor = System.Drawing.Color.White;
            this.buttonNew.Location = new System.Drawing.Point(155, 265);
            this.buttonNew.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(105, 39);
            this.buttonNew.TabIndex = 4;
            this.buttonNew.Text = "＋ Crear";
            this.buttonNew.UseVisualStyleBackColor = false;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonModify
            // 
            this.buttonModify.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonModify.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModify.ForeColor = System.Drawing.Color.White;
            this.buttonModify.Location = new System.Drawing.Point(264, 265);
            this.buttonModify.Margin = new System.Windows.Forms.Padding(2);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(105, 39);
            this.buttonModify.TabIndex = 5;
            this.buttonModify.Text = "🖉 Editar";
            this.buttonModify.UseVisualStyleBackColor = false;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // buttonMassiveUpload
            // 
            this.buttonMassiveUpload.BackColor = System.Drawing.Color.Gray;
            this.buttonMassiveUpload.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMassiveUpload.ForeColor = System.Drawing.Color.White;
            this.buttonMassiveUpload.Location = new System.Drawing.Point(480, 265);
            this.buttonMassiveUpload.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMassiveUpload.Name = "buttonMassiveUpload";
            this.buttonMassiveUpload.Size = new System.Drawing.Size(199, 39);
            this.buttonMassiveUpload.TabIndex = 15;
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
            this.buttonCancel.Location = new System.Drawing.Point(373, 265);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 39);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // UserMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(835, 329);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonMassiveUpload);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.dataGridViewUserMaintenance);
            this.Name = "UserMaintenance";
            this.Text = "Mantenimiento de Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserMaintenance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonMassiveUpload;
        protected System.Windows.Forms.DataGridView dataGridViewUserMaintenance;
        private System.Windows.Forms.Button buttonCancel;
    }
}