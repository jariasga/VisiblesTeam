namespace InkaArt.Interface.Sales
{
    partial class ClientCreate
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radio_natural = new System.Windows.Forms.RadioButton();
            this.radio_juridic = new System.Windows.Forms.RadioButton();
            this.inter_radio = new System.Windows.Forms.RadioButton();
            this.radio_national = new System.Windows.Forms.RadioButton();
            this.radio_inactive = new System.Windows.Forms.RadioButton();
            this.radio_active = new System.Windows.Forms.RadioButton();
            this.textbox_priority = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trackbar_priority = new System.Windows.Forms.TrackBar();
            this.textbox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_ruc = new System.Windows.Forms.TextBox();
            this.documentLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textbox_email = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textbox_contact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textbox_phone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textbox_address = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_priority)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.textbox_priority);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.trackbar_priority);
            this.groupBox2.Controls.Add(this.textbox_name);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textbox_ruc);
            this.groupBox2.Controls.Add(this.documentLabel);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox2.Location = new System.Drawing.Point(25, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 405);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // radio_natural
            // 
            this.radio_natural.AutoSize = true;
            this.radio_natural.Location = new System.Drawing.Point(139, 24);
            this.radio_natural.Name = "radio_natural";
            this.radio_natural.Size = new System.Drawing.Size(93, 27);
            this.radio_natural.TabIndex = 38;
            this.radio_natural.Text = "Natural";
            this.radio_natural.UseVisualStyleBackColor = true;
            this.radio_natural.CheckedChanged += new System.EventHandler(this.personRadio_CheckedChanged);
            // 
            // radio_juridic
            // 
            this.radio_juridic.AutoSize = true;
            this.radio_juridic.Checked = true;
            this.radio_juridic.Location = new System.Drawing.Point(6, 24);
            this.radio_juridic.Name = "radio_juridic";
            this.radio_juridic.Size = new System.Drawing.Size(100, 27);
            this.radio_juridic.TabIndex = 37;
            this.radio_juridic.TabStop = true;
            this.radio_juridic.Text = "Jurídica";
            this.radio_juridic.UseVisualStyleBackColor = true;
            this.radio_juridic.CheckedChanged += new System.EventHandler(this.juridicRadio_CheckedChanged);
            // 
            // inter_radio
            // 
            this.inter_radio.AutoSize = true;
            this.inter_radio.Location = new System.Drawing.Point(137, 25);
            this.inter_radio.Name = "inter_radio";
            this.inter_radio.Size = new System.Drawing.Size(142, 27);
            this.inter_radio.TabIndex = 35;
            this.inter_radio.Text = "Internacional";
            this.inter_radio.UseVisualStyleBackColor = true;
            // 
            // radio_national
            // 
            this.radio_national.AutoSize = true;
            this.radio_national.Checked = true;
            this.radio_national.Location = new System.Drawing.Point(7, 25);
            this.radio_national.Name = "radio_national";
            this.radio_national.Size = new System.Drawing.Size(105, 27);
            this.radio_national.TabIndex = 34;
            this.radio_national.TabStop = true;
            this.radio_national.Text = "Nacional";
            this.radio_national.UseVisualStyleBackColor = true;
            // 
            // radio_inactive
            // 
            this.radio_inactive.AutoSize = true;
            this.radio_inactive.Location = new System.Drawing.Point(140, 22);
            this.radio_inactive.Name = "radio_inactive";
            this.radio_inactive.Size = new System.Drawing.Size(98, 27);
            this.radio_inactive.TabIndex = 32;
            this.radio_inactive.Text = "Inactivo";
            this.radio_inactive.UseVisualStyleBackColor = true;
            // 
            // radio_active
            // 
            this.radio_active.AutoSize = true;
            this.radio_active.Checked = true;
            this.radio_active.Location = new System.Drawing.Point(11, 22);
            this.radio_active.Name = "radio_active";
            this.radio_active.Size = new System.Drawing.Size(84, 27);
            this.radio_active.TabIndex = 31;
            this.radio_active.TabStop = true;
            this.radio_active.Text = "Activo";
            this.radio_active.UseVisualStyleBackColor = true;
            // 
            // textbox_priority
            // 
            this.textbox_priority.BackColor = System.Drawing.Color.White;
            this.textbox_priority.Location = new System.Drawing.Point(197, 292);
            this.textbox_priority.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_priority.Name = "textbox_priority";
            this.textbox_priority.Size = new System.Drawing.Size(92, 30);
            this.textbox_priority.TabIndex = 29;
            this.textbox_priority.Text = "Nivel 5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 266);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 23);
            this.label4.TabIndex = 28;
            this.label4.Text = "Prioridad";
            // 
            // trackbar_priority
            // 
            this.trackbar_priority.Location = new System.Drawing.Point(31, 292);
            this.trackbar_priority.Name = "trackbar_priority";
            this.trackbar_priority.Size = new System.Drawing.Size(159, 56);
            this.trackbar_priority.TabIndex = 27;
            this.trackbar_priority.Scroll += new System.EventHandler(this.trackbar_priority_Scroll);
            this.trackbar_priority.ValueChanged += new System.EventHandler(this.trackbar_priority_ValueChanged);
            // 
            // textbox_name
            // 
            this.textbox_name.BackColor = System.Drawing.Color.White;
            this.textbox_name.Location = new System.Drawing.Point(31, 174);
            this.textbox_name.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_name.Name = "textbox_name";
            this.textbox_name.Size = new System.Drawing.Size(258, 30);
            this.textbox_name.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 152);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "Nombre";
            // 
            // textbox_ruc
            // 
            this.textbox_ruc.BackColor = System.Drawing.Color.White;
            this.textbox_ruc.Location = new System.Drawing.Point(31, 111);
            this.textbox_ruc.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_ruc.Name = "textbox_ruc";
            this.textbox_ruc.Size = new System.Drawing.Size(258, 30);
            this.textbox_ruc.TabIndex = 24;
            // 
            // documentLabel
            // 
            this.documentLabel.AutoSize = true;
            this.documentLabel.Location = new System.Drawing.Point(28, 89);
            this.documentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.documentLabel.Name = "documentLabel";
            this.documentLabel.Size = new System.Drawing.Size(51, 23);
            this.documentLabel.TabIndex = 23;
            this.documentLabel.Text = "RUC";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textbox_email);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textbox_contact);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textbox_phone);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textbox_address);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox1.Location = new System.Drawing.Point(369, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 308);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contacto";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textbox_email
            // 
            this.textbox_email.BackColor = System.Drawing.Color.White;
            this.textbox_email.Location = new System.Drawing.Point(23, 244);
            this.textbox_email.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_email.Name = "textbox_email";
            this.textbox_email.Size = new System.Drawing.Size(281, 30);
            this.textbox_email.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 222);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 23);
            this.label9.TabIndex = 32;
            this.label9.Text = "Correo";
            // 
            // textbox_contact
            // 
            this.textbox_contact.BackColor = System.Drawing.Color.White;
            this.textbox_contact.Location = new System.Drawing.Point(23, 182);
            this.textbox_contact.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_contact.Name = "textbox_contact";
            this.textbox_contact.Size = new System.Drawing.Size(281, 30);
            this.textbox_contact.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 23);
            this.label3.TabIndex = 30;
            this.label3.Text = "Contacto";
            // 
            // textbox_phone
            // 
            this.textbox_phone.BackColor = System.Drawing.Color.White;
            this.textbox_phone.Location = new System.Drawing.Point(23, 119);
            this.textbox_phone.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_phone.Name = "textbox_phone";
            this.textbox_phone.Size = new System.Drawing.Size(281, 30);
            this.textbox_phone.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 97);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 23);
            this.label7.TabIndex = 28;
            this.label7.Text = "Teléfono";
            // 
            // textbox_address
            // 
            this.textbox_address.BackColor = System.Drawing.Color.White;
            this.textbox_address.Location = new System.Drawing.Point(23, 56);
            this.textbox_address.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_address.Name = "textbox_address";
            this.textbox_address.Size = new System.Drawing.Size(281, 30);
            this.textbox_address.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 34);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 23);
            this.label6.TabIndex = 26;
            this.label6.Text = "Dirección";
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.SteelBlue;
            this.button_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(475, 370);
            this.button_save.Margin = new System.Windows.Forms.Padding(2);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(121, 39);
            this.button_save.TabIndex = 38;
            this.button_save.Text = "🖫 Guardar";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radio_juridic);
            this.groupBox3.Controls.Add(this.radio_natural);
            this.groupBox3.Location = new System.Drawing.Point(31, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 57);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo de Persona";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radio_national);
            this.groupBox4.Controls.Add(this.inter_radio);
            this.groupBox4.Location = new System.Drawing.Point(30, 205);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(285, 58);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tipo de Cliente";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radio_active);
            this.groupBox6.Controls.Add(this.radio_inactive);
            this.groupBox6.Location = new System.Drawing.Point(30, 329);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(285, 56);
            this.groupBox6.TabIndex = 40;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Estado";
            // 
            // ClientCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(733, 452);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientCreate";
            this.Text = "Crear Cliente";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_priority)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radio_inactive;
        private System.Windows.Forms.RadioButton radio_active;
        private System.Windows.Forms.TextBox textbox_priority;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackbar_priority;
        private System.Windows.Forms.TextBox textbox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_ruc;
        private System.Windows.Forms.Label documentLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textbox_email;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textbox_contact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textbox_phone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textbox_address;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.RadioButton radio_natural;
        private System.Windows.Forms.RadioButton radio_juridic;
        private System.Windows.Forms.RadioButton inter_radio;
        private System.Windows.Forms.RadioButton radio_national;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}