namespace InkaArt.Interface.Purchases
{
    partial class SupplierDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_idSupplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ruc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar_priority = new System.Windows.Forms.TrackBar();
            this.textBox_priority = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_telephone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_contactName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridView_rm_sup = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_rawMaterial = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_price = new System.Windows.Forms.TextBox();
            this.Acción = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_materiaPrima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idrmsup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_priority)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rm_sup)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id";
            // 
            // textBox_idSupplier
            // 
            this.textBox_idSupplier.BackColor = System.Drawing.Color.White;
            this.textBox_idSupplier.Enabled = false;
            this.textBox_idSupplier.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_idSupplier.Location = new System.Drawing.Point(24, 40);
            this.textBox_idSupplier.Name = "textBox_idSupplier";
            this.textBox_idSupplier.ReadOnly = true;
            this.textBox_idSupplier.Size = new System.Drawing.Size(253, 24);
            this.textBox_idSupplier.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre";
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.Color.White;
            this.textBox_name.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(24, 94);
            this.textBox_name.MaxLength = 280;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(253, 24);
            this.textBox_name.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "RUC";
            // 
            // textBox_ruc
            // 
            this.textBox_ruc.BackColor = System.Drawing.Color.White;
            this.textBox_ruc.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ruc.Location = new System.Drawing.Point(24, 148);
            this.textBox_ruc.MaxLength = 11;
            this.textBox_ruc.Name = "textBox_ruc";
            this.textBox_ruc.Size = new System.Drawing.Size(253, 24);
            this.textBox_ruc.TabIndex = 14;
            this.textBox_ruc.TextChanged += new System.EventHandler(this.verifying_number);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Dirección";
            // 
            // textBox_address
            // 
            this.textBox_address.BackColor = System.Drawing.Color.White;
            this.textBox_address.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_address.Location = new System.Drawing.Point(24, 203);
            this.textBox_address.Multiline = true;
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(252, 46);
            this.textBox_address.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Prioridad";
            // 
            // trackBar_priority
            // 
            this.trackBar_priority.LargeChange = 1;
            this.trackBar_priority.Location = new System.Drawing.Point(24, 283);
            this.trackBar_priority.Name = "trackBar_priority";
            this.trackBar_priority.Size = new System.Drawing.Size(201, 45);
            this.trackBar_priority.TabIndex = 18;
            this.trackBar_priority.Scroll += new System.EventHandler(this.trackBar_priority_Scroll);
            // 
            // textBox_priority
            // 
            this.textBox_priority.Enabled = false;
            this.textBox_priority.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_priority.Location = new System.Drawing.Point(231, 283);
            this.textBox_priority.Name = "textBox_priority";
            this.textBox_priority.ReadOnly = true;
            this.textBox_priority.Size = new System.Drawing.Size(46, 24);
            this.textBox_priority.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_telephone);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_email);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_contactName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 386);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 210);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de contacto";
            // 
            // textBox_telephone
            // 
            this.textBox_telephone.BackColor = System.Drawing.Color.White;
            this.textBox_telephone.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_telephone.Location = new System.Drawing.Point(15, 170);
            this.textBox_telephone.MaxLength = 9;
            this.textBox_telephone.Name = "textBox_telephone";
            this.textBox_telephone.Size = new System.Drawing.Size(221, 24);
            this.textBox_telephone.TabIndex = 25;
            this.textBox_telephone.TextChanged += new System.EventHandler(this.verifying_telephone);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 18);
            this.label8.TabIndex = 24;
            this.label8.Text = "Teléfono";
            // 
            // textBox_email
            // 
            this.textBox_email.BackColor = System.Drawing.Color.White;
            this.textBox_email.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_email.Location = new System.Drawing.Point(15, 111);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(221, 24);
            this.textBox_email.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 18);
            this.label7.TabIndex = 22;
            this.label7.Text = "Correo";
            // 
            // textBox_contactName
            // 
            this.textBox_contactName.BackColor = System.Drawing.Color.White;
            this.textBox_contactName.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_contactName.Location = new System.Drawing.Point(15, 53);
            this.textBox_contactName.MaxLength = 200;
            this.textBox_contactName.Name = "textBox_contactName";
            this.textBox_contactName.Size = new System.Drawing.Size(221, 24);
            this.textBox_contactName.TabIndex = 21;
            this.textBox_contactName.TextChanged += new System.EventHandler(this.verifying_contactname);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "Nombre de contacto";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_price);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.comboBox_rawMaterial);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Controls.Add(this.buttonAdd);
            this.groupBox2.Controls.Add(this.dataGridView_rm_sup);
            this.groupBox2.Location = new System.Drawing.Point(305, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 522);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de materias primas";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 18);
            this.label11.TabIndex = 44;
            this.label11.Text = "Materia prima";
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(158, 468);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(107, 41);
            this.buttonDelete.TabIndex = 43;
            this.buttonDelete.Text = "🗑 Eliminar";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.button_delete);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAdd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(305, 46);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(107, 41);
            this.buttonAdd.TabIndex = 42;
            this.buttonAdd.Text = "＋ Agregar";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.button_add);
            // 
            // dataGridView_rm_sup
            // 
            this.dataGridView_rm_sup.AllowUserToAddRows = false;
            this.dataGridView_rm_sup.AllowUserToDeleteRows = false;
            this.dataGridView_rm_sup.AllowUserToResizeColumns = false;
            this.dataGridView_rm_sup.AllowUserToResizeRows = false;
            this.dataGridView_rm_sup.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_rm_sup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_rm_sup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_rm_sup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Acción,
            this.id_materiaPrima,
            this.nombre,
            this.Precio,
            this.idrmsup});
            this.dataGridView_rm_sup.Location = new System.Drawing.Point(23, 109);
            this.dataGridView_rm_sup.Name = "dataGridView_rm_sup";
            this.dataGridView_rm_sup.Size = new System.Drawing.Size(389, 347);
            this.dataGridView_rm_sup.TabIndex = 10;
            this.dataGridView_rm_sup.DoubleClick += new System.EventHandler(this.obtain_idEdit);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(452, 554);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(144, 42);
            this.buttonSave.TabIndex = 22;
            this.buttonSave.Text = "Editar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.button_event_click);
            // 
            // comboBox_status
            // 
            this.comboBox_status.AllowDrop = true;
            this.comboBox_status.BackColor = System.Drawing.Color.White;
            this.comboBox_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.comboBox_status.Location = new System.Drawing.Point(24, 343);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(253, 26);
            this.comboBox_status.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 322);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 18);
            this.label9.TabIndex = 25;
            this.label9.Text = "Estado";
            // 
            // comboBox_rawMaterial
            // 
            this.comboBox_rawMaterial.AllowDrop = true;
            this.comboBox_rawMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_rawMaterial.FormattingEnabled = true;
            this.comboBox_rawMaterial.Location = new System.Drawing.Point(23, 54);
            this.comboBox_rawMaterial.Name = "comboBox_rawMaterial";
            this.comboBox_rawMaterial.Size = new System.Drawing.Size(128, 26);
            this.comboBox_rawMaterial.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(173, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 18);
            this.label10.TabIndex = 46;
            this.label10.Text = "Precio";
            // 
            // textBox_price
            // 
            this.textBox_price.Location = new System.Drawing.Point(176, 54);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.Size = new System.Drawing.Size(115, 26);
            this.textBox_price.TabIndex = 47;
            this.textBox_price.TextChanged += new System.EventHandler(this.verifying_price);
            // 
            // Acción
            // 
            this.Acción.HeaderText = "";
            this.Acción.Name = "Acción";
            this.Acción.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Acción.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Acción.Width = 50;
            // 
            // id_materiaPrima
            // 
            this.id_materiaPrima.HeaderText = "ID";
            this.id_materiaPrima.Name = "id_materiaPrima";
            this.id_materiaPrima.ReadOnly = true;
            this.id_materiaPrima.Width = 80;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 110;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // idrmsup
            // 
            this.idrmsup.HeaderText = "Id RM Sup";
            this.idrmsup.Name = "idrmsup";
            this.idrmsup.Visible = false;
            // 
            // SupplierDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(764, 608);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox_status);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_priority);
            this.Controls.Add(this.trackBar_priority);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_ruc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_idSupplier);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SupplierDetail";
            this.Text = "Detalle de proveedor";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_priority)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rm_sup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_idSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ruc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBar_priority;
        private System.Windows.Forms.TextBox textBox_priority;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_contactName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_telephone;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_rm_sup;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_rawMaterial;
        private System.Windows.Forms.TextBox textBox_price;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Acción;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_materiaPrima;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn idrmsup;
    }
}