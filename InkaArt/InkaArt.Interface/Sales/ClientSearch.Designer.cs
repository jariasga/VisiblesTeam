namespace InkaArt.Interface.Sales
{
    partial class ClientSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid_clients = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_select = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_clients)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_clients
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid_clients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_clients.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.grid_clients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_clients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grid_clients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_clients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Cantidad,
            this.cost,
            this.delete,
            this.Column1});
            this.grid_clients.Location = new System.Drawing.Point(36, 71);
            this.grid_clients.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.grid_clients.Name = "grid_clients";
            this.grid_clients.Size = new System.Drawing.Size(889, 463);
            this.grid_clients.TabIndex = 28;
            this.grid_clients.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_clients_CellContentDoubleClick);
            this.grid_clients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_clients_CellDoubleClick);
            // 
            // Producto
            // 
            this.Producto.HeaderText = "ID";
            this.Producto.Name = "Producto";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Documento";
            this.Cantidad.Name = "Cantidad";
            // 
            // cost
            // 
            this.cost.HeaderText = "Nombre";
            this.cost.Name = "cost";
            // 
            // delete
            // 
            this.delete.HeaderText = "Estado";
            this.delete.Name = "delete";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Prioridad";
            this.Column1.Name = "Column1";
            // 
            // button_select
            // 
            this.button_select.BackColor = System.Drawing.Color.SteelBlue;
            this.button_select.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_select.ForeColor = System.Drawing.Color.White;
            this.button_select.Location = new System.Drawing.Point(264, 549);
            this.button_select.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(200, 48);
            this.button_select.TabIndex = 29;
            this.button_select.Text = "＋ Seleccionar";
            this.button_select.UseVisualStyleBackColor = false;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.Gray;
            this.button_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.ForeColor = System.Drawing.Color.White;
            this.button_cancel.Location = new System.Drawing.Point(485, 549);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(200, 48);
            this.button_cancel.TabIndex = 30;
            this.button_cancel.Text = "＋ Cancelar";
            this.button_cancel.UseVisualStyleBackColor = false;
            // 
            // ClientSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 608);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.grid_clients);
            this.Name = "ClientSearch";
            this.Text = "Buscar Cliente";
            this.Load += new System.EventHandler(this.ClientSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_clients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_clients;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Button button_cancel;
    }
}