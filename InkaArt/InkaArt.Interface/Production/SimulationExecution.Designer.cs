namespace InkaArt.Interface.Production
{
    partial class SimulationExecution
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
            this.components = new System.ComponentModel.Container();
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label_state = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label_time = new System.Windows.Forms.Label();
            this.background_simulation = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progress_bar
            // 
            this.progress_bar.Location = new System.Drawing.Point(13, 46);
            this.progress_bar.Margin = new System.Windows.Forms.Padding(4);
            this.progress_bar.Maximum = 1000;
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(756, 37);
            this.progress_bar.Step = 1;
            this.progress_bar.TabIndex = 0;
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.Firebrick;
            this.button_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.ForeColor = System.Drawing.Color.White;
            this.button_cancel.Location = new System.Drawing.Point(280, 90);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(192, 44);
            this.button_cancel.TabIndex = 40;
            this.button_cancel.Text = "Cancelar simulación";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(12, 15);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(223, 23);
            this.label_state.TabIndex = 41;
            this.label_state.Text = "Estado de la simulación:";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(632, 15);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(174, 23);
            this.label_time.TabIndex = 42;
            this.label_time.Text = "Tiempo: 00 m 00 s";
            this.label_time.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // background_simulation
            // 
            this.background_simulation.WorkerReportsProgress = true;
            this.background_simulation.WorkerSupportsCancellation = true;
            this.background_simulation.DoWork += new System.ComponentModel.DoWorkEventHandler(this.background_simulation_DoWork);
            this.background_simulation.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.background_simulation_ProgressChanged);
            this.background_simulation.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.background_simulation_RunWorkerCompleted);
            // 
            // SimulationExecution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 139);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label_state);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.progress_bar);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimulationExecution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ejecutando simulación...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimulationLoadingScreen_FormClosing);
            this.Load += new System.EventHandler(this.NewSimulation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Timer timer;
        private System.ComponentModel.BackgroundWorker background_simulation;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.ProgressBar progress_bar;
    }
}