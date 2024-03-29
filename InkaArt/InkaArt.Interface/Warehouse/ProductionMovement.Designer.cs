﻿namespace InkaArt.Interface.Warehouse
{
    partial class ProductionMovement
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.text_id_warehouse = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.text_name_warehouse = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.text_lote = new System.Windows.Forms.TextBox();
            this.grid_lote = new System.Windows.Forms.DataGridView();
            this.nroLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_lote)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.text_id_warehouse);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.text_name_warehouse);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(21, 25);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(1187, 128);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Almacén";
            // 
            // text_id_warehouse
            // 
            this.text_id_warehouse.BackColor = System.Drawing.Color.White;
            this.text_id_warehouse.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_id_warehouse.Location = new System.Drawing.Point(31, 66);
            this.text_id_warehouse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.text_id_warehouse.Name = "text_id_warehouse";
            this.text_id_warehouse.ReadOnly = true;
            this.text_id_warehouse.Size = new System.Drawing.Size(231, 29);
            this.text_id_warehouse.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 23);
            this.label5.TabIndex = 32;
            this.label5.Text = "ID";
            // 
            // text_name_warehouse
            // 
            this.text_name_warehouse.BackColor = System.Drawing.Color.White;
            this.text_name_warehouse.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_name_warehouse.Location = new System.Drawing.Point(305, 66);
            this.text_name_warehouse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.text_name_warehouse.Name = "text_name_warehouse";
            this.text_name_warehouse.ReadOnly = true;
            this.text_name_warehouse.Size = new System.Drawing.Size(849, 29);
            this.text_name_warehouse.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(300, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 23);
            this.label9.TabIndex = 28;
            this.label9.Text = "Nombre";
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.SteelBlue;
            this.button_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(524, 527);
            this.button_save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(184, 48);
            this.button_save.TabIndex = 55;
            this.button_save.Text = "🖫 Guardar";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.buttonSaveClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.text_lote);
            this.groupBox2.Controls.Add(this.grid_lote);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(21, 171);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1187, 350);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lote de Producción";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1096, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 38);
            this.button1.TabIndex = 57;
            this.button1.Text = "🔎 Buscar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonSearchClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(733, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 23);
            this.label3.TabIndex = 34;
            this.label3.Text = "Número de lote";
            // 
            // text_lote
            // 
            this.text_lote.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_lote.Location = new System.Drawing.Point(900, 33);
            this.text_lote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.text_lote.Name = "text_lote";
            this.text_lote.Size = new System.Drawing.Size(188, 29);
            this.text_lote.TabIndex = 34;
            this.text_lote.TextChanged += new System.EventHandler(this.textLoteTextChanged);
            // 
            // grid_lote
            // 
            this.grid_lote.AllowUserToAddRows = false;
            this.grid_lote.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grid_lote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_lote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_lote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nroLote,
            this.idProduct,
            this.ProductName,
            this.Cant,
            this.stockWarehouse,
            this.CurrentCant,
            this.MovCant,
            this.Modificar});
            this.grid_lote.Location = new System.Drawing.Point(31, 84);
            this.grid_lote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid_lote.Name = "grid_lote";
            this.grid_lote.Size = new System.Drawing.Size(1125, 230);
            this.grid_lote.TabIndex = 57;
            this.grid_lote.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLoteCellValueChanged);
            // 
            // nroLote
            // 
            this.nroLote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nroLote.DataPropertyName = "id_lote";
            this.nroLote.FillWeight = 70F;
            this.nroLote.HeaderText = "Lote";
            this.nroLote.Name = "nroLote";
            this.nroLote.ReadOnly = true;
            // 
            // idProduct
            // 
            this.idProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idProduct.DataPropertyName = "id_product";
            this.idProduct.FillWeight = 80F;
            this.idProduct.HeaderText = "ID";
            this.idProduct.Name = "idProduct";
            this.idProduct.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.DataPropertyName = "name";
            this.ProductName.FillWeight = 120F;
            this.ProductName.HeaderText = "Producto";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Cant
            // 
            this.Cant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cant.DataPropertyName = "produced";
            this.Cant.FillWeight = 90F;
            this.Cant.HeaderText = "Cantidad Total";
            this.Cant.Name = "Cant";
            this.Cant.ReadOnly = true;
            // 
            // stockWarehouse
            // 
            this.stockWarehouse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stockWarehouse.DataPropertyName = "currentStock";
            this.stockWarehouse.FillWeight = 90F;
            this.stockWarehouse.HeaderText = "Stock en almacén";
            this.stockWarehouse.Name = "stockWarehouse";
            this.stockWarehouse.ReadOnly = true;
            // 
            // CurrentCant
            // 
            this.CurrentCant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CurrentCant.DataPropertyName = "product_stock";
            this.CurrentCant.FillWeight = 105F;
            this.CurrentCant.HeaderText = "Cantidad por mover";
            this.CurrentCant.Name = "CurrentCant";
            this.CurrentCant.ReadOnly = true;
            // 
            // MovCant
            // 
            this.MovCant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MovCant.HeaderText = "Cantidad a mover";
            this.MovCant.Name = "MovCant";
            // 
            // Modificar
            // 
            this.Modificar.FillWeight = 90F;
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            this.Modificar.Width = 90;
            // 
            // ProductionMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1227, 590);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProductionMovement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimiento de producción";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_lote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox text_id_warehouse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_name_warehouse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_lote;
        private System.Windows.Forms.DataGridView grid_lote;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cant;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentCant;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovCant;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Modificar;
    }
}