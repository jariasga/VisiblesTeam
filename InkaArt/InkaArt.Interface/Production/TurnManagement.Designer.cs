namespace InkaArt.Interface.Production
{
    partial class TurnManagement
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
            this.textBox_horaIni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_horaFin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_guardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_turn = new System.Windows.Forms.ComboBox();
            this.textBox_desc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_nuevoTurno = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_horaIni
            // 
            this.textBox_horaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_horaIni.Location = new System.Drawing.Point(50, 66);
            this.textBox_horaIni.Name = "textBox_horaIni";
            this.textBox_horaIni.Size = new System.Drawing.Size(205, 28);
            this.textBox_horaIni.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 23);
            this.label1.TabIndex = 23;
            this.label1.Text = "Hora Inicio";
            // 
            // textBox_horaFin
            // 
            this.textBox_horaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_horaFin.Location = new System.Drawing.Point(50, 137);
            this.textBox_horaFin.Name = "textBox_horaFin";
            this.textBox_horaFin.Size = new System.Drawing.Size(205, 28);
            this.textBox_horaFin.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "Hora Fin";
            // 
            // button_guardar
            // 
            this.button_guardar.BackColor = System.Drawing.Color.SteelBlue;
            this.button_guardar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_guardar.ForeColor = System.Drawing.Color.White;
            this.button_guardar.Location = new System.Drawing.Point(76, 259);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(135, 42);
            this.button_guardar.TabIndex = 27;
            this.button_guardar.Text = "🖫 Guardar";
            this.button_guardar.UseVisualStyleBackColor = false;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 23);
            this.label3.TabIndex = 28;
            this.label3.Text = "Turno";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // comboBox_turn
            // 
            this.comboBox_turn.FormattingEnabled = true;
            this.comboBox_turn.Location = new System.Drawing.Point(9, 80);
            this.comboBox_turn.Name = "comboBox_turn";
            this.comboBox_turn.Size = new System.Drawing.Size(205, 31);
            this.comboBox_turn.TabIndex = 29;
            this.comboBox_turn.SelectedIndexChanged += new System.EventHandler(this.comboBox_turn_SelectedIndexChanged);
            // 
            // textBox_desc
            // 
            this.textBox_desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_desc.Location = new System.Drawing.Point(50, 206);
            this.textBox_desc.Name = "textBox_desc";
            this.textBox_desc.Size = new System.Drawing.Size(205, 28);
            this.textBox_desc.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 23);
            this.label4.TabIndex = 30;
            this.label4.Text = "Descripcion";
            // 
            // checkBox_nuevoTurno
            // 
            this.checkBox_nuevoTurno.AutoSize = true;
            this.checkBox_nuevoTurno.Location = new System.Drawing.Point(9, 142);
            this.checkBox_nuevoTurno.Name = "checkBox_nuevoTurno";
            this.checkBox_nuevoTurno.Size = new System.Drawing.Size(141, 27);
            this.checkBox_nuevoTurno.TabIndex = 32;
            this.checkBox_nuevoTurno.Text = "Nuevo Turno";
            this.checkBox_nuevoTurno.UseVisualStyleBackColor = true;
            this.checkBox_nuevoTurno.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_nuevoTurno);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_turn);
            this.groupBox1.Location = new System.Drawing.Point(642, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 244);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Turno";
            this.groupBox1.Visible = false;
            // 
            // TurnManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(308, 344);
            this.Controls.Add(this.textBox_desc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.textBox_horaFin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_horaIni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TurnManagement";
            this.Text = "Mantenimiento de Turnos";
            this.Load += new System.EventHandler(this.TurnManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_horaIni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_horaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_turn;
        private System.Windows.Forms.TextBox textBox_desc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_nuevoTurno;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}