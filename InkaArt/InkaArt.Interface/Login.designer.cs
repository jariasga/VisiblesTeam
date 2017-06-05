﻿namespace InkaArt.Interface
{
    partial class Login
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
            this.label_title = new System.Windows.Forms.Label();
            this.label_user = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.textbox_user = new System.Windows.Forms.TextBox();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.label_forgot = new System.Windows.Forms.Label();
            this.button_Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.Location = new System.Drawing.Point(64, 54);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(293, 35);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "Bienvenido a Inka Art";
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_user.Location = new System.Drawing.Point(67, 148);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(82, 23);
            this.label_user.TabIndex = 1;
            this.label_user.Text = "Usuario:";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_password.Location = new System.Drawing.Point(67, 208);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(118, 23);
            this.label_password.TabIndex = 2;
            this.label_password.Text = "Contraseña:";
            // 
            // textbox_user
            // 
            this.textbox_user.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_user.Location = new System.Drawing.Point(196, 144);
            this.textbox_user.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_user.Name = "textbox_user";
            this.textbox_user.Size = new System.Drawing.Size(161, 30);
            this.textbox_user.TabIndex = 3;
            this.textbox_user.Text = "MCastañeda";
            // 
            // textbox_password
            // 
            this.textbox_password.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_password.Location = new System.Drawing.Point(196, 204);
            this.textbox_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(161, 30);
            this.textbox_password.TabIndex = 4;
            this.textbox_password.Text = "MCastañeda";
            // 
            // label_forgot
            // 
            this.label_forgot.AutoSize = true;
            this.label_forgot.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_forgot.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label_forgot.Location = new System.Drawing.Point(67, 258);
            this.label_forgot.Name = "label_forgot";
            this.label_forgot.Size = new System.Drawing.Size(179, 17);
            this.label_forgot.TabIndex = 5;
            this.label_forgot.Text = "¿Olvidaste tu contraseña?";
            // 
            // button_Login
            // 
            this.button_Login.BackColor = System.Drawing.Color.SteelBlue;
            this.button_Login.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Login.ForeColor = System.Drawing.Color.White;
            this.button_Login.Location = new System.Drawing.Point(156, 298);
            this.button_Login.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(123, 48);
            this.button_Login.TabIndex = 45;
            this.button_Login.Text = "Ingresar";
            this.button_Login.UseVisualStyleBackColor = false;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.button_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(433, 385);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.label_forgot);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_user);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.label_title);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inka Art";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textbox_user;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Label label_forgot;
        private System.Windows.Forms.Button button_Login;
    }
}