namespace InkaArt.Interface.Security
{
    partial class ChangePassword
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
            this.label_password = new System.Windows.Forms.Label();
            this.textbox_password_old = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_password_new_1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_password_new_2 = new System.Windows.Forms.TextBox();
            this.button_change = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_password.Location = new System.Drawing.Point(36, 32);
            this.label_password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(209, 18);
            this.label_password.TabIndex = 2;
            this.label_password.Text = "Ingrese su contraseña actual:";
            // 
            // textbox_password_old
            // 
            this.textbox_password_old.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_password_old.Location = new System.Drawing.Point(328, 29);
            this.textbox_password_old.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_password_old.Name = "textbox_password_old";
            this.textbox_password_old.PasswordChar = '*';
            this.textbox_password_old.Size = new System.Drawing.Size(165, 26);
            this.textbox_password_old.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ingrese la nueva contraseña:";
            // 
            // textbox_password_new_1
            // 
            this.textbox_password_new_1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_password_new_1.Location = new System.Drawing.Point(328, 75);
            this.textbox_password_new_1.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_password_new_1.Name = "textbox_password_new_1";
            this.textbox_password_new_1.PasswordChar = '*';
            this.textbox_password_new_1.Size = new System.Drawing.Size(165, 26);
            this.textbox_password_new_1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Vuelva a ingresar la nueva contraseña:";
            // 
            // textbox_password_new_2
            // 
            this.textbox_password_new_2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_password_new_2.Location = new System.Drawing.Point(328, 123);
            this.textbox_password_new_2.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_password_new_2.Name = "textbox_password_new_2";
            this.textbox_password_new_2.PasswordChar = '*';
            this.textbox_password_new_2.Size = new System.Drawing.Size(165, 26);
            this.textbox_password_new_2.TabIndex = 8;
            // 
            // button_change
            // 
            this.button_change.BackColor = System.Drawing.Color.SteelBlue;
            this.button_change.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_change.ForeColor = System.Drawing.Color.White;
            this.button_change.Location = new System.Drawing.Point(166, 170);
            this.button_change.Margin = new System.Windows.Forms.Padding(2);
            this.button_change.Name = "button_change";
            this.button_change.Size = new System.Drawing.Size(178, 39);
            this.button_change.TabIndex = 9;
            this.button_change.Text = "Cambiar contraseña";
            this.button_change.UseVisualStyleBackColor = false;
            this.button_change.Click += new System.EventHandler(this.button_change_Click);
            // 
            // ChangePassword
            // 
            this.AcceptButton = this.button_change;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(535, 236);
            this.Controls.Add(this.button_change);
            this.Controls.Add(this.textbox_password_new_2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textbox_password_new_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox_password_old);
            this.Controls.Add(this.label_password);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ChangePassword";
            this.Text = "Cambiar contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textbox_password_old;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_password_new_1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_password_new_2;
        private System.Windows.Forms.Button button_change;
    }
}