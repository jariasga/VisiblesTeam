namespace InkaArt.Interface.Production
{
    partial class Recipe
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
            this.textbox_newVer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_newVer = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_version = new System.Windows.Forms.ComboBox();
            this.textBox_product = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.dataGridView_rawMaterial = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Borrar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button_add = new System.Windows.Forms.Button();
            this.comboBox_rawMaterial = new System.Windows.Forms.ComboBox();
            this.numericUpDown_count = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Nuevo = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rawMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_count)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.Nuevo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox_version);
            this.groupBox1.Controls.Add(this.textBox_product);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_id);
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(227, 221);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Basicos";
            // 
            // textbox_newVer
            // 
            this.textbox_newVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_newVer.Location = new System.Drawing.Point(30, 88);
            this.textbox_newVer.Name = "textbox_newVer";
            this.textbox_newVer.Size = new System.Drawing.Size(172, 24);
            this.textbox_newVer.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 18);
            this.label6.TabIndex = 27;
            this.label6.Text = "Nombre Nueva Version";
            // 
            // checkBox_newVer
            // 
            this.checkBox_newVer.AutoSize = true;
            this.checkBox_newVer.Location = new System.Drawing.Point(32, 26);
            this.checkBox_newVer.Name = "checkBox_newVer";
            this.checkBox_newVer.Size = new System.Drawing.Size(128, 22);
            this.checkBox_newVer.TabIndex = 26;
            this.checkBox_newVer.Text = "Nueva Version";
            this.checkBox_newVer.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 153);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "Versión";
            // 
            // comboBox_version
            // 
            this.comboBox_version.FormattingEnabled = true;
            this.comboBox_version.Location = new System.Drawing.Point(32, 174);
            this.comboBox_version.Name = "comboBox_version";
            this.comboBox_version.Size = new System.Drawing.Size(171, 26);
            this.comboBox_version.TabIndex = 24;
            this.comboBox_version.SelectedIndexChanged += new System.EventHandler(this.comboBox_version_SelectedIndexChanged);
            // 
            // textBox_product
            // 
            this.textBox_product.Enabled = false;
            this.textBox_product.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_product.Location = new System.Drawing.Point(31, 106);
            this.textBox_product.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_product.Name = "textBox_product";
            this.textBox_product.ReadOnly = true;
            this.textBox_product.Size = new System.Drawing.Size(174, 24);
            this.textBox_product.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Producto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Id";
            // 
            // textBox_id
            // 
            this.textBox_id.Enabled = false;
            this.textBox_id.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_id.Location = new System.Drawing.Point(31, 45);
            this.textBox_id.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(172, 24);
            this.textBox_id.TabIndex = 14;
            // 
            // dataGridView_rawMaterial
            // 
            this.dataGridView_rawMaterial.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_rawMaterial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_rawMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_rawMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Nombre,
            this.Cantidad,
            this.Unidad,
            this.Borrar});
            this.dataGridView_rawMaterial.Location = new System.Drawing.Point(15, 84);
            this.dataGridView_rawMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_rawMaterial.Name = "dataGridView_rawMaterial";
            this.dataGridView_rawMaterial.Size = new System.Drawing.Size(538, 184);
            this.dataGridView_rawMaterial.TabIndex = 17;
            this.dataGridView_rawMaterial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Id";
            this.Producto.Name = "Producto";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Unidad
            // 
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            // 
            // Borrar
            // 
            this.Borrar.HeaderText = "Borrar";
            this.Borrar.Name = "Borrar";
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.Gray;
            this.button_add.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.ForeColor = System.Drawing.Color.White;
            this.button_add.Location = new System.Drawing.Point(346, 30);
            this.button_add.Margin = new System.Windows.Forms.Padding(2);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(97, 39);
            this.button_add.TabIndex = 26;
            this.button_add.Text = "＋ Agregar";
            this.button_add.UseVisualStyleBackColor = false;
            // 
            // comboBox_rawMaterial
            // 
            this.comboBox_rawMaterial.FormattingEnabled = true;
            this.comboBox_rawMaterial.Location = new System.Drawing.Point(15, 42);
            this.comboBox_rawMaterial.Name = "comboBox_rawMaterial";
            this.comboBox_rawMaterial.Size = new System.Drawing.Size(128, 26);
            this.comboBox_rawMaterial.TabIndex = 22;
            this.comboBox_rawMaterial.Text = "Piedra";
            // 
            // numericUpDown_count
            // 
            this.numericUpDown_count.Location = new System.Drawing.Point(193, 43);
            this.numericUpDown_count.Name = "numericUpDown_count";
            this.numericUpDown_count.Size = new System.Drawing.Size(68, 26);
            this.numericUpDown_count.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Materia Prima";
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.SteelBlue;
            this.button_save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(53, 126);
            this.button_save.Margin = new System.Windows.Forms.Padding(2);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(107, 39);
            this.button_save.TabIndex = 27;
            this.button_save.Text = "🖫 Guardar";
            this.button_save.UseVisualStyleBackColor = false;
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(448, 30);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(105, 39);
            this.button_delete.TabIndex = 46;
            this.button_delete.Text = "🗑 Eliminar";
            this.button_delete.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_delete);
            this.groupBox2.Controls.Add(this.dataGridView_rawMaterial);
            this.groupBox2.Controls.Add(this.button_add);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox_rawMaterial);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericUpDown_count);
            this.groupBox2.Location = new System.Drawing.Point(280, 73);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(568, 302);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Receta";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // Nuevo
            // 
            this.Nuevo.Controls.Add(this.label6);
            this.Nuevo.Controls.Add(this.textbox_newVer);
            this.Nuevo.Controls.Add(this.checkBox_newVer);
            this.Nuevo.Controls.Add(this.button_save);
            this.Nuevo.Location = new System.Drawing.Point(13, 268);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(227, 187);
            this.Nuevo.TabIndex = 29;
            this.Nuevo.TabStop = false;
            this.Nuevo.Text = "Nuevo";
            // 
            // Recipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(861, 479);
            this.Controls.Add(this.Nuevo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Recipe";
            this.Text = "Receta";
            this.Load += new System.EventHandler(this.Recipe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rawMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_count)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Nuevo.ResumeLayout(false);
            this.Nuevo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_product;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.DataGridView dataGridView_rawMaterial;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.ComboBox comboBox_rawMaterial;
        private System.Windows.Forms.NumericUpDown numericUpDown_count;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Borrar;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_newVer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textbox_newVer;
        private System.Windows.Forms.GroupBox Nuevo;
    }
}