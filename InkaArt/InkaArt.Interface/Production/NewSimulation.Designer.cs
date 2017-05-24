namespace InkaArt.Interface.Production
{
    partial class NewSimulation
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
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.label_name = new System.Windows.Forms.Label();
            this.textbox_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // progress_bar
            // 
            this.progress_bar.Location = new System.Drawing.Point(15, 60);
            this.progress_bar.Margin = new System.Windows.Forms.Padding(4);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(576, 37);
            this.progress_bar.TabIndex = 0;
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.Firebrick;
            this.button_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.ForeColor = System.Drawing.Color.White;
            this.button_cancel.Location = new System.Drawing.Point(314, 114);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(192, 44);
            this.button_cancel.TabIndex = 40;
            this.button_cancel.Text = "Cancelar simulación";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.SteelBlue;
            this.button_start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.ForeColor = System.Drawing.Color.White;
            this.button_start.Location = new System.Drawing.Point(113, 115);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(164, 43);
            this.button_start.TabIndex = 41;
            this.button_start.Text = "Iniciar simulación";
            this.button_start.UseVisualStyleBackColor = false;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(12, 20);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(184, 18);
            this.label_name.TabIndex = 42;
            this.label_name.Text = "Nombre de la simulación:";
            // 
            // textbox_name
            // 
            this.textbox_name.Location = new System.Drawing.Point(202, 17);
            this.textbox_name.Name = "textbox_name";
            this.textbox_name.Size = new System.Drawing.Size(389, 26);
            this.textbox_name.TabIndex = 43;
            this.textbox_name.Text = "Simulación 1";
            // 
            // NewSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(606, 170);
            this.Controls.Add(this.textbox_name);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.progress_bar);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewSimulation";
            this.Text = "Nueva simulación de asignación de trabajadores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progress_bar;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox textbox_name;
    }
}