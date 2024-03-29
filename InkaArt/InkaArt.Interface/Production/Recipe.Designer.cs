﻿namespace InkaArt.Interface.Production
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_state = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_version = new System.Windows.Forms.ComboBox();
            this.textBox_product = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.textbox_newVer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_newVer = new System.Windows.Forms.CheckBox();
            this.dataGridView_rawMaterial = new System.Windows.Forms.DataGridView();
            this.button_add = new System.Windows.Forms.Button();
            this.comboBox_rawMaterial = new System.Windows.Forms.ComboBox();
            this.numericUpDown_count = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.Nuevo = new System.Windows.Forms.GroupBox();
            this.massive_recipe = new System.Windows.Forms.Button();
            this.massive_details = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Borrar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rawMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_count)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.Nuevo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_state);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox_version);
            this.groupBox1.Controls.Add(this.textBox_product);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_id);
            this.groupBox1.Location = new System.Drawing.Point(21, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(227, 275);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Basicos";
            // 
            // textBox_state
            // 
            this.textBox_state.BackColor = System.Drawing.Color.White;
            this.textBox_state.Enabled = false;
            this.textBox_state.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_state.Location = new System.Drawing.Point(21, 167);
            this.textBox_state.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_state.Name = "textBox_state";
            this.textBox_state.ReadOnly = true;
            this.textBox_state.Size = new System.Drawing.Size(182, 24);
            this.textBox_state.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 18);
            this.label7.TabIndex = 26;
            this.label7.Text = "Estado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 208);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "Versión";
            // 
            // comboBox_version
            // 
            this.comboBox_version.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_version.FormattingEnabled = true;
            this.comboBox_version.Location = new System.Drawing.Point(22, 229);
            this.comboBox_version.Name = "comboBox_version";
            this.comboBox_version.Size = new System.Drawing.Size(181, 25);
            this.comboBox_version.TabIndex = 24;
            this.comboBox_version.SelectedIndexChanged += new System.EventHandler(this.comboBox_version_SelectedIndexChanged);
            // 
            // textBox_product
            // 
            this.textBox_product.BackColor = System.Drawing.Color.White;
            this.textBox_product.Enabled = false;
            this.textBox_product.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_product.Location = new System.Drawing.Point(21, 110);
            this.textBox_product.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_product.Name = "textBox_product";
            this.textBox_product.ReadOnly = true;
            this.textBox_product.Size = new System.Drawing.Size(182, 24);
            this.textBox_product.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 88);
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
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "ID";
            // 
            // textBox_id
            // 
            this.textBox_id.BackColor = System.Drawing.Color.White;
            this.textBox_id.Enabled = false;
            this.textBox_id.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_id.Location = new System.Drawing.Point(21, 49);
            this.textBox_id.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(182, 24);
            this.textBox_id.TabIndex = 14;
            // 
            // textbox_newVer
            // 
            this.textbox_newVer.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_newVer.Location = new System.Drawing.Point(22, 86);
            this.textbox_newVer.Name = "textbox_newVer";
            this.textbox_newVer.Size = new System.Drawing.Size(181, 24);
            this.textbox_newVer.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 62);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 18);
            this.label6.TabIndex = 27;
            this.label6.Text = "Nombre de la versión";
            // 
            // checkBox_newVer
            // 
            this.checkBox_newVer.AutoSize = true;
            this.checkBox_newVer.Location = new System.Drawing.Point(20, 30);
            this.checkBox_newVer.Name = "checkBox_newVer";
            this.checkBox_newVer.Size = new System.Drawing.Size(128, 22);
            this.checkBox_newVer.TabIndex = 26;
            this.checkBox_newVer.Text = "Nueva Version";
            this.checkBox_newVer.UseVisualStyleBackColor = true;
            // 
            // dataGridView_rawMaterial
            // 
            this.dataGridView_rawMaterial.AllowUserToAddRows = false;
            this.dataGridView_rawMaterial.AllowUserToDeleteRows = false;
            this.dataGridView_rawMaterial.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_rawMaterial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_rawMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_rawMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Nombre,
            this.Cantidad,
            this.Unidad,
            this.Estado,
            this.Borrar});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_rawMaterial.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_rawMaterial.Location = new System.Drawing.Point(19, 84);
            this.dataGridView_rawMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_rawMaterial.Name = "dataGridView_rawMaterial";
            this.dataGridView_rawMaterial.Size = new System.Drawing.Size(615, 286);
            this.dataGridView_rawMaterial.TabIndex = 17;
            this.dataGridView_rawMaterial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.SteelBlue;
            this.button_add.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.ForeColor = System.Drawing.Color.White;
            this.button_add.Location = new System.Drawing.Point(402, 30);
            this.button_add.Margin = new System.Windows.Forms.Padding(2);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(114, 39);
            this.button_add.TabIndex = 26;
            this.button_add.Text = "+ Agregar";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // comboBox_rawMaterial
            // 
            this.comboBox_rawMaterial.BackColor = System.Drawing.Color.White;
            this.comboBox_rawMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_rawMaterial.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_rawMaterial.FormattingEnabled = true;
            this.comboBox_rawMaterial.Location = new System.Drawing.Point(19, 45);
            this.comboBox_rawMaterial.Name = "comboBox_rawMaterial";
            this.comboBox_rawMaterial.Size = new System.Drawing.Size(214, 25);
            this.comboBox_rawMaterial.TabIndex = 22;
            this.comboBox_rawMaterial.SelectedIndexChanged += new System.EventHandler(this.comboBox_rawMaterial_SelectedIndexChanged);
            // 
            // numericUpDown_count
            // 
            this.numericUpDown_count.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_count.Location = new System.Drawing.Point(248, 46);
            this.numericUpDown_count.Name = "numericUpDown_count";
            this.numericUpDown_count.Size = new System.Drawing.Size(114, 24);
            this.numericUpDown_count.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 24);
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
            this.button_save.Location = new System.Drawing.Point(53, 118);
            this.button_save.Margin = new System.Windows.Forms.Padding(2);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(119, 39);
            this.button_save.TabIndex = 27;
            this.button_save.Text = "＋ Crear";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(256, 24);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(652, 392);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Receta";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.Firebrick;
            this.button_delete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.ForeColor = System.Drawing.Color.White;
            this.button_delete.Location = new System.Drawing.Point(521, 30);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(113, 39);
            this.button_delete.TabIndex = 50;
            this.button_delete.Text = "🗑 Borrar";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // Nuevo
            // 
            this.Nuevo.Controls.Add(this.label6);
            this.Nuevo.Controls.Add(this.textbox_newVer);
            this.Nuevo.Controls.Add(this.checkBox_newVer);
            this.Nuevo.Controls.Add(this.button_save);
            this.Nuevo.Location = new System.Drawing.Point(21, 306);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(227, 168);
            this.Nuevo.TabIndex = 29;
            this.Nuevo.TabStop = false;
            this.Nuevo.Text = "Nuevo";
            // 
            // massive_recipe
            // 
            this.massive_recipe.BackColor = System.Drawing.Color.SteelBlue;
            this.massive_recipe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.massive_recipe.ForeColor = System.Drawing.Color.White;
            this.massive_recipe.Location = new System.Drawing.Point(613, 424);
            this.massive_recipe.Margin = new System.Windows.Forms.Padding(2);
            this.massive_recipe.Name = "massive_recipe";
            this.massive_recipe.Size = new System.Drawing.Size(146, 39);
            this.massive_recipe.TabIndex = 29;
            this.massive_recipe.Text = "⬆ Cargar Recetas";
            this.massive_recipe.UseVisualStyleBackColor = false;
            this.massive_recipe.Click += new System.EventHandler(this.massive_recipe_Click);
            // 
            // massive_details
            // 
            this.massive_details.BackColor = System.Drawing.Color.SteelBlue;
            this.massive_details.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.massive_details.ForeColor = System.Drawing.Color.White;
            this.massive_details.Location = new System.Drawing.Point(763, 424);
            this.massive_details.Margin = new System.Windows.Forms.Padding(2);
            this.massive_details.Name = "massive_details";
            this.massive_details.Size = new System.Drawing.Size(145, 39);
            this.massive_details.TabIndex = 30;
            this.massive_details.Text = "⬆ Cargar Detalles";
            this.massive_details.UseVisualStyleBackColor = false;
            this.massive_details.Click += new System.EventHandler(this.massive_details_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(485, 434);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 18);
            this.label8.TabIndex = 31;
            this.label8.Text = "Cargas Masivas";
            // 
            // Producto
            // 
            this.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Producto.FillWeight = 80F;
            this.Producto.HeaderText = "ID";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cantidad.FillWeight = 90F;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Unidad
            // 
            this.Unidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Borrar
            // 
            this.Borrar.FillWeight = 70F;
            this.Borrar.HeaderText = "Borrar";
            this.Borrar.Name = "Borrar";
            this.Borrar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Borrar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Borrar.Width = 70;
            // 
            // Recipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(921, 485);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.massive_details);
            this.Controls.Add(this.massive_recipe);
            this.Controls.Add(this.Nuevo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Recipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
            this.PerformLayout();

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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_newVer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textbox_newVer;
        private System.Windows.Forms.GroupBox Nuevo;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button massive_recipe;
        private System.Windows.Forms.Button massive_details;
        private System.Windows.Forms.TextBox textBox_state;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Borrar;
    }
}