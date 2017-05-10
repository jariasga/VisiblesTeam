namespace InkaArt.Presentation.Security
{
    partial class GeneralParameters
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabcontrol_algorithms = new System.Windows.Forms.TabControl();
            this.tab_grasp = new System.Windows.Forms.TabPage();
            this.textbox_grasp_iterations = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_grasp_alpha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tab_tabu = new System.Windows.Forms.TabPage();
            this.textbox_tabu_increment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textbox_tabu_initial = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textbox_tabu_neighbors = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textbox_tabu_time = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textbox_tabu_iterations = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textbox_tabu_alpha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabcontrol_misc = new System.Windows.Forms.TabControl();
            this.tab_financial = new System.Windows.Forms.TabPage();
            this.textbox_exchange = new System.Windows.Forms.TextBox();
            this.label_exchange = new System.Windows.Forms.Label();
            this.textbox_igv = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tab_program = new System.Windows.Forms.TabPage();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textbox_login_signout = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textbox_login_tries = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabcontrol_algorithms.SuspendLayout();
            this.tab_grasp.SuspendLayout();
            this.tab_tabu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabcontrol_misc.SuspendLayout();
            this.tab_financial.SuspendLayout();
            this.tab_program.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabcontrol_algorithms);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 218);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algoritmos";
            // 
            // tabcontrol_algorithms
            // 
            this.tabcontrol_algorithms.Controls.Add(this.tab_grasp);
            this.tabcontrol_algorithms.Controls.Add(this.tab_tabu);
            this.tabcontrol_algorithms.Location = new System.Drawing.Point(8, 23);
            this.tabcontrol_algorithms.Name = "tabcontrol_algorithms";
            this.tabcontrol_algorithms.SelectedIndex = 0;
            this.tabcontrol_algorithms.Size = new System.Drawing.Size(325, 185);
            this.tabcontrol_algorithms.TabIndex = 0;
            // 
            // tab_grasp
            // 
            this.tab_grasp.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tab_grasp.Controls.Add(this.textbox_grasp_iterations);
            this.tab_grasp.Controls.Add(this.label2);
            this.tab_grasp.Controls.Add(this.textbox_grasp_alpha);
            this.tab_grasp.Controls.Add(this.label1);
            this.tab_grasp.Location = new System.Drawing.Point(4, 27);
            this.tab_grasp.Name = "tab_grasp";
            this.tab_grasp.Padding = new System.Windows.Forms.Padding(3);
            this.tab_grasp.Size = new System.Drawing.Size(317, 154);
            this.tab_grasp.TabIndex = 0;
            this.tab_grasp.Text = "GRASP";
            // 
            // textbox_grasp_iterations
            // 
            this.textbox_grasp_iterations.Location = new System.Drawing.Point(7, 72);
            this.textbox_grasp_iterations.Name = "textbox_grasp_iterations";
            this.textbox_grasp_iterations.Size = new System.Drawing.Size(112, 26);
            this.textbox_grasp_iterations.TabIndex = 3;
            this.textbox_grasp_iterations.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Iteraciones:";
            // 
            // textbox_grasp_alpha
            // 
            this.textbox_grasp_alpha.Location = new System.Drawing.Point(7, 24);
            this.textbox_grasp_alpha.Name = "textbox_grasp_alpha";
            this.textbox_grasp_alpha.Size = new System.Drawing.Size(112, 26);
            this.textbox_grasp_alpha.TabIndex = 1;
            this.textbox_grasp_alpha.Text = "0.2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alpha:";
            // 
            // tab_tabu
            // 
            this.tab_tabu.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tab_tabu.Controls.Add(this.textbox_tabu_increment);
            this.tab_tabu.Controls.Add(this.label6);
            this.tab_tabu.Controls.Add(this.textbox_tabu_initial);
            this.tab_tabu.Controls.Add(this.label7);
            this.tab_tabu.Controls.Add(this.textbox_tabu_neighbors);
            this.tab_tabu.Controls.Add(this.label8);
            this.tab_tabu.Controls.Add(this.textbox_tabu_time);
            this.tab_tabu.Controls.Add(this.label5);
            this.tab_tabu.Controls.Add(this.textbox_tabu_iterations);
            this.tab_tabu.Controls.Add(this.label3);
            this.tab_tabu.Controls.Add(this.textbox_tabu_alpha);
            this.tab_tabu.Controls.Add(this.label4);
            this.tab_tabu.Location = new System.Drawing.Point(4, 27);
            this.tab_tabu.Name = "tab_tabu";
            this.tab_tabu.Padding = new System.Windows.Forms.Padding(3);
            this.tab_tabu.Size = new System.Drawing.Size(317, 154);
            this.tab_tabu.TabIndex = 1;
            this.tab_tabu.Text = "Tabu Search";
            // 
            // textbox_tabu_increment
            // 
            this.textbox_tabu_increment.Location = new System.Drawing.Point(153, 120);
            this.textbox_tabu_increment.Name = "textbox_tabu_increment";
            this.textbox_tabu_increment.Size = new System.Drawing.Size(112, 26);
            this.textbox_tabu_increment.TabIndex = 15;
            this.textbox_tabu_increment.Text = "3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "# Iteraciones sin Inc.:";
            // 
            // textbox_tabu_initial
            // 
            this.textbox_tabu_initial.Location = new System.Drawing.Point(153, 72);
            this.textbox_tabu_initial.Name = "textbox_tabu_initial";
            this.textbox_tabu_initial.Size = new System.Drawing.Size(112, 26);
            this.textbox_tabu_initial.TabIndex = 13;
            this.textbox_tabu_initial.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(153, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tamaño Inicial Lista:";
            // 
            // textbox_tabu_neighbors
            // 
            this.textbox_tabu_neighbors.Location = new System.Drawing.Point(153, 24);
            this.textbox_tabu_neighbors.Name = "textbox_tabu_neighbors";
            this.textbox_tabu_neighbors.Size = new System.Drawing.Size(112, 26);
            this.textbox_tabu_neighbors.TabIndex = 11;
            this.textbox_tabu_neighbors.Text = "500";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(153, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "Max Vecinos:";
            // 
            // textbox_tabu_time
            // 
            this.textbox_tabu_time.Location = new System.Drawing.Point(7, 120);
            this.textbox_tabu_time.Name = "textbox_tabu_time";
            this.textbox_tabu_time.Size = new System.Drawing.Size(112, 26);
            this.textbox_tabu_time.TabIndex = 9;
            this.textbox_tabu_time.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tiempo Límite (m):";
            // 
            // textbox_tabu_iterations
            // 
            this.textbox_tabu_iterations.Location = new System.Drawing.Point(7, 72);
            this.textbox_tabu_iterations.Name = "textbox_tabu_iterations";
            this.textbox_tabu_iterations.Size = new System.Drawing.Size(112, 26);
            this.textbox_tabu_iterations.TabIndex = 7;
            this.textbox_tabu_iterations.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "# Iteraciones:";
            // 
            // textbox_tabu_alpha
            // 
            this.textbox_tabu_alpha.Location = new System.Drawing.Point(7, 24);
            this.textbox_tabu_alpha.Name = "textbox_tabu_alpha";
            this.textbox_tabu_alpha.Size = new System.Drawing.Size(112, 26);
            this.textbox_tabu_alpha.TabIndex = 5;
            this.textbox_tabu_alpha.Text = "0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Alpha:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabcontrol_misc);
            this.groupBox2.Location = new System.Drawing.Point(363, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 218);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Miscelánea";
            // 
            // tabcontrol_misc
            // 
            this.tabcontrol_misc.Controls.Add(this.tab_financial);
            this.tabcontrol_misc.Controls.Add(this.tab_program);
            this.tabcontrol_misc.Location = new System.Drawing.Point(8, 23);
            this.tabcontrol_misc.Name = "tabcontrol_misc";
            this.tabcontrol_misc.SelectedIndex = 0;
            this.tabcontrol_misc.Size = new System.Drawing.Size(325, 185);
            this.tabcontrol_misc.TabIndex = 0;
            // 
            // tab_financial
            // 
            this.tab_financial.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tab_financial.Controls.Add(this.textbox_exchange);
            this.tab_financial.Controls.Add(this.label_exchange);
            this.tab_financial.Controls.Add(this.textbox_igv);
            this.tab_financial.Controls.Add(this.label10);
            this.tab_financial.Location = new System.Drawing.Point(4, 27);
            this.tab_financial.Name = "tab_financial";
            this.tab_financial.Padding = new System.Windows.Forms.Padding(3);
            this.tab_financial.Size = new System.Drawing.Size(317, 154);
            this.tab_financial.TabIndex = 0;
            this.tab_financial.Text = "Financiero";
            // 
            // textbox_exchange
            // 
            this.textbox_exchange.Location = new System.Drawing.Point(7, 72);
            this.textbox_exchange.Name = "textbox_exchange";
            this.textbox_exchange.Size = new System.Drawing.Size(112, 26);
            this.textbox_exchange.TabIndex = 3;
            this.textbox_exchange.Text = "3.24";
            // 
            // label_exchange
            // 
            this.label_exchange.AutoSize = true;
            this.label_exchange.Location = new System.Drawing.Point(7, 50);
            this.label_exchange.Name = "label_exchange";
            this.label_exchange.Size = new System.Drawing.Size(124, 18);
            this.label_exchange.TabIndex = 2;
            this.label_exchange.Text = "Tipo de Cambio:";
            // 
            // textbox_igv
            // 
            this.textbox_igv.Location = new System.Drawing.Point(7, 24);
            this.textbox_igv.Name = "textbox_igv";
            this.textbox_igv.Size = new System.Drawing.Size(112, 26);
            this.textbox_igv.TabIndex = 1;
            this.textbox_igv.Text = "0.18";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "IGV:";
            // 
            // tab_program
            // 
            this.tab_program.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tab_program.Controls.Add(this.textBox11);
            this.tab_program.Controls.Add(this.label11);
            this.tab_program.Controls.Add(this.textBox12);
            this.tab_program.Controls.Add(this.label12);
            this.tab_program.Controls.Add(this.textbox_login_signout);
            this.tab_program.Controls.Add(this.label13);
            this.tab_program.Controls.Add(this.textBox14);
            this.tab_program.Controls.Add(this.label14);
            this.tab_program.Controls.Add(this.textBox15);
            this.tab_program.Controls.Add(this.label15);
            this.tab_program.Controls.Add(this.textbox_login_tries);
            this.tab_program.Controls.Add(this.label16);
            this.tab_program.Location = new System.Drawing.Point(4, 27);
            this.tab_program.Name = "tab_program";
            this.tab_program.Padding = new System.Windows.Forms.Padding(3);
            this.tab_program.Size = new System.Drawing.Size(317, 154);
            this.tab_program.TabIndex = 1;
            this.tab_program.Text = "Programa";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(153, 120);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(112, 26);
            this.textBox11.TabIndex = 15;
            this.textBox11.Text = "- - -";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(153, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 18);
            this.label11.TabIndex = 14;
            this.label11.Text = "TBD:";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(153, 72);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(112, 26);
            this.textBox12.TabIndex = 13;
            this.textBox12.Text = "- - -";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(153, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 18);
            this.label12.TabIndex = 12;
            this.label12.Text = "TBD:";
            // 
            // textbox_login_signout
            // 
            this.textbox_login_signout.Location = new System.Drawing.Point(153, 24);
            this.textbox_login_signout.Name = "textbox_login_signout";
            this.textbox_login_signout.Size = new System.Drawing.Size(112, 26);
            this.textbox_login_signout.TabIndex = 11;
            this.textbox_login_signout.Text = "5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(153, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 18);
            this.label13.TabIndex = 10;
            this.label13.Text = "Cierre Sesión (m):";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(7, 120);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(112, 26);
            this.textBox14.TabIndex = 9;
            this.textBox14.Text = "- - -";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 98);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 18);
            this.label14.TabIndex = 8;
            this.label14.Text = "TBD:";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(7, 72);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(112, 26);
            this.textBox15.TabIndex = 7;
            this.textBox15.Text = "- - -";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 18);
            this.label15.TabIndex = 6;
            this.label15.Text = "TBD:";
            // 
            // textbox_login_tries
            // 
            this.textbox_login_tries.Location = new System.Drawing.Point(7, 24);
            this.textbox_login_tries.Name = "textbox_login_tries";
            this.textbox_login_tries.Size = new System.Drawing.Size(112, 26);
            this.textbox_login_tries.TabIndex = 5;
            this.textbox_login_tries.Text = "3";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(142, 18);
            this.label16.TabIndex = 4;
            this.label16.Text = "Max intentos Login:";
            // 
            // GeneralParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(716, 236);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GeneralParameters";
            this.Text = "Parámetros generales";
            this.groupBox1.ResumeLayout(false);
            this.tabcontrol_algorithms.ResumeLayout(false);
            this.tab_grasp.ResumeLayout(false);
            this.tab_grasp.PerformLayout();
            this.tab_tabu.ResumeLayout(false);
            this.tab_tabu.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabcontrol_misc.ResumeLayout(false);
            this.tab_financial.ResumeLayout(false);
            this.tab_financial.PerformLayout();
            this.tab_program.ResumeLayout(false);
            this.tab_program.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabcontrol_algorithms;
        private System.Windows.Forms.TabPage tab_grasp;
        private System.Windows.Forms.TextBox textbox_grasp_iterations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_grasp_alpha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tab_tabu;
        private System.Windows.Forms.TextBox textbox_tabu_increment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textbox_tabu_initial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textbox_tabu_neighbors;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textbox_tabu_time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textbox_tabu_iterations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textbox_tabu_alpha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabcontrol_misc;
        private System.Windows.Forms.TabPage tab_financial;
        private System.Windows.Forms.TextBox textbox_exchange;
        private System.Windows.Forms.Label label_exchange;
        private System.Windows.Forms.TextBox textbox_igv;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tab_program;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textbox_login_signout;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textbox_login_tries;
        private System.Windows.Forms.Label label16;
    }
}