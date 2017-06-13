namespace InkaArt
{
    partial class Start
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
            this.button_ratio = new System.Windows.Forms.Button();
            this.button_config = new System.Windows.Forms.Button();
            this.button_simulation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_ratio
            // 
            this.button_ratio.Location = new System.Drawing.Point(40, 13);
            this.button_ratio.Name = "button_ratio";
            this.button_ratio.Size = new System.Drawing.Size(236, 31);
            this.button_ratio.TabIndex = 0;
            this.button_ratio.Text = "Registro del Informe de Turnos";
            this.button_ratio.UseVisualStyleBackColor = true;
            this.button_ratio.Click += new System.EventHandler(this.button_ratio_Click);
            // 
            // button_config
            // 
            this.button_config.Location = new System.Drawing.Point(40, 60);
            this.button_config.Name = "button_config";
            this.button_config.Size = new System.Drawing.Size(236, 31);
            this.button_config.TabIndex = 1;
            this.button_config.Text = "Configuración de asignación de trabajadores";
            this.button_config.UseVisualStyleBackColor = true;
            this.button_config.Click += new System.EventHandler(this.button_config_Click);
            // 
            // button_simulation
            // 
            this.button_simulation.Location = new System.Drawing.Point(40, 109);
            this.button_simulation.Name = "button_simulation";
            this.button_simulation.Size = new System.Drawing.Size(236, 31);
            this.button_simulation.TabIndex = 2;
            this.button_simulation.Text = "Ejecución de asignación de trabajadores";
            this.button_simulation.UseVisualStyleBackColor = true;
            this.button_simulation.Click += new System.EventHandler(this.button_simulation_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 154);
            this.Controls.Add(this.button_simulation);
            this.Controls.Add(this.button_config);
            this.Controls.Add(this.button_ratio);
            this.MaximizeBox = false;
            this.Name = "Start";
            this.Text = "Start";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_ratio;
        private System.Windows.Forms.Button button_config;
        private System.Windows.Forms.Button button_simulation;
    }
}