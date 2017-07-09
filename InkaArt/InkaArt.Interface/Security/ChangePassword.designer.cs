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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelNumberChar = new System.Windows.Forms.Label();
            this.labelLowerChar = new System.Windows.Forms.Label();
            this.labelUpperChar = new System.Windows.Forms.Label();
            this.label8Char = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
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
            this.textbox_password_old.BackColor = System.Drawing.Color.White;
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
            this.textbox_password_new_1.BackColor = System.Drawing.Color.White;
            this.textbox_password_new_1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_password_new_1.Location = new System.Drawing.Point(328, 75);
            this.textbox_password_new_1.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_password_new_1.Name = "textbox_password_new_1";
            this.textbox_password_new_1.PasswordChar = '*';
            this.textbox_password_new_1.Size = new System.Drawing.Size(165, 26);
            this.textbox_password_new_1.TabIndex = 6;
            this.textbox_password_new_1.TextChanged += new System.EventHandler(this.textbox_password_new_1_TextChanged);
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
            this.textbox_password_new_2.BackColor = System.Drawing.Color.White;
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
            this.button_change.Location = new System.Drawing.Point(328, 193);
            this.button_change.Margin = new System.Windows.Forms.Padding(2);
            this.button_change.Name = "button_change";
            this.button_change.Size = new System.Drawing.Size(165, 39);
            this.button_change.TabIndex = 9;
            this.button_change.Text = "Cambiar contraseña";
            this.button_change.UseVisualStyleBackColor = false;
            this.button_change.Click += new System.EventHandler(this.button_change_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelNumberChar);
            this.groupBox1.Controls.Add(this.labelLowerChar);
            this.groupBox1.Controls.Add(this.labelUpperChar);
            this.groupBox1.Controls.Add(this.label8Char);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(39, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 109);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Requisitos";
            // 
            // labelNumberChar
            // 
            this.labelNumberChar.AutoSize = true;
            this.labelNumberChar.Font = new System.Drawing.Font("Arial", 11F);
            this.labelNumberChar.Location = new System.Drawing.Point(6, 82);
            this.labelNumberChar.Name = "labelNumberChar";
            this.labelNumberChar.Size = new System.Drawing.Size(151, 17);
            this.labelNumberChar.TabIndex = 3;
            this.labelNumberChar.Text = "- Al menos un número";
            // 
            // labelLowerChar
            // 
            this.labelLowerChar.AutoSize = true;
            this.labelLowerChar.Font = new System.Drawing.Font("Arial", 11F);
            this.labelLowerChar.Location = new System.Drawing.Point(6, 62);
            this.labelLowerChar.Name = "labelLowerChar";
            this.labelLowerChar.Size = new System.Drawing.Size(176, 17);
            this.labelLowerChar.TabIndex = 2;
            this.labelLowerChar.Text = "- Al menos una minúscula";
            // 
            // labelUpperChar
            // 
            this.labelUpperChar.AutoSize = true;
            this.labelUpperChar.Font = new System.Drawing.Font("Arial", 11F);
            this.labelUpperChar.Location = new System.Drawing.Point(6, 42);
            this.labelUpperChar.Name = "labelUpperChar";
            this.labelUpperChar.Size = new System.Drawing.Size(180, 17);
            this.labelUpperChar.TabIndex = 1;
            this.labelUpperChar.Text = "- Al menos una mayúscula";
            // 
            // label8Char
            // 
            this.label8Char.AutoSize = true;
            this.label8Char.Font = new System.Drawing.Font("Arial", 11F);
            this.label8Char.Location = new System.Drawing.Point(6, 22);
            this.label8Char.Name = "label8Char";
            this.label8Char.Size = new System.Drawing.Size(163, 17);
            this.label8Char.TabIndex = 0;
            this.label8Char.Text = "- Al menos 8 caracteres";
            // 
            // ChangePassword
            // 
            this.AcceptButton = this.button_change;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(535, 297);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_change);
            this.Controls.Add(this.textbox_password_new_2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textbox_password_new_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox_password_old);
            this.Controls.Add(this.label_password);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar contraseña";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelLowerChar;
        private System.Windows.Forms.Label labelUpperChar;
        private System.Windows.Forms.Label label8Char;
        private System.Windows.Forms.Label labelNumberChar;
    }
}