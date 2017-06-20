namespace InkaArt.Interface.Purchases
{
    partial class RawMaterials
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
            this.dataGridView_rawMaterialsList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCargaMasiva = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_raw_material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.average_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rawMaterialsList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_rawMaterialsList
            // 
            this.dataGridView_rawMaterialsList.AllowUserToAddRows = false;
            this.dataGridView_rawMaterialsList.AllowUserToDeleteRows = false;
            this.dataGridView_rawMaterialsList.AllowUserToResizeRows = false;
            this.dataGridView_rawMaterialsList.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataGridView_rawMaterialsList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_rawMaterialsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_rawMaterialsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar,
            this.id_raw_material,
            this.name,
            this.description,
            this.unitName,
            this.status,
            this.average_price,
            this.unit});
            this.dataGridView_rawMaterialsList.Location = new System.Drawing.Point(15, 185);
            this.dataGridView_rawMaterialsList.MultiSelect = false;
            this.dataGridView_rawMaterialsList.Name = "dataGridView_rawMaterialsList";
            this.dataGridView_rawMaterialsList.Size = new System.Drawing.Size(663, 208);
            this.dataGridView_rawMaterialsList.TabIndex = 3;
            this.dataGridView_rawMaterialsList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.editRawMaterialDetail);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.comboBox_status);
            this.groupBox1.Controls.Add(this.textBox_id);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 158);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Gray;
            this.buttonSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Location = new System.Drawing.Point(556, 97);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(88, 39);
            this.buttonSearch.TabIndex = 28;
            this.buttonSearch.Text = "🔎 Buscar";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.button_search);
            // 
            // comboBox_status
            // 
            this.comboBox_status.AllowDrop = true;
            this.comboBox_status.BackColor = System.Drawing.Color.White;
            this.comboBox_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_status.Font = new System.Drawing.Font("Arial", 11F);
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Items.AddRange(new object[] {
            "",
            "Activo",
            "Inactivo"});
            this.comboBox_status.Location = new System.Drawing.Point(25, 110);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(192, 25);
            this.comboBox_status.TabIndex = 27;
            // 
            // textBox_id
            // 
            this.textBox_id.BackColor = System.Drawing.Color.White;
            this.textBox_id.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_id.Location = new System.Drawing.Point(25, 50);
            this.textBox_id.MaxLength = 9;
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(192, 24);
            this.textBox_id.TabIndex = 26;
            this.textBox_id.TextChanged += new System.EventHandler(this.validating_id);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "ID Materia prima";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "Estado";
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.Color.White;
            this.textBox_name.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox_name.Location = new System.Drawing.Point(240, 50);
            this.textBox_name.MaxLength = 280;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(404, 24);
            this.textBox_name.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre de la materia prima";
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(277, 414);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(133, 39);
            this.buttonDelete.TabIndex = 44;
            this.buttonDelete.Text = "🗑 Eliminar";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.button_delete);
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonCreate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.ForeColor = System.Drawing.Color.White;
            this.buttonCreate.Location = new System.Drawing.Point(148, 414);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(124, 39);
            this.buttonCreate.TabIndex = 45;
            this.buttonCreate.Text = "＋ Crear";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.button_create);
            // 
            // buttonCargaMasiva
            // 
            this.buttonCargaMasiva.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonCargaMasiva.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCargaMasiva.ForeColor = System.Drawing.Color.White;
            this.buttonCargaMasiva.Location = new System.Drawing.Point(415, 414);
            this.buttonCargaMasiva.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCargaMasiva.Name = "buttonCargaMasiva";
            this.buttonCargaMasiva.Size = new System.Drawing.Size(124, 39);
            this.buttonCargaMasiva.TabIndex = 46;
            this.buttonCargaMasiva.Text = "Carga masiva";
            this.buttonCargaMasiva.UseVisualStyleBackColor = false;
            this.buttonCargaMasiva.Click += new System.EventHandler(this.button_cargamasivaclic);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Width = 50;
            // 
            // id_raw_material
            // 
            this.id_raw_material.HeaderText = "ID";
            this.id_raw_material.Name = "id_raw_material";
            // 
            // name
            // 
            this.name.HeaderText = "Nombre";
            this.name.Name = "name";
            // 
            // description
            // 
            this.description.HeaderText = "Descripción";
            this.description.Name = "description";
            // 
            // unitName
            // 
            this.unitName.HeaderText = "Unidad";
            this.unitName.Name = "unitName";
            // 
            // status
            // 
            this.status.HeaderText = "Estado";
            this.status.Name = "status";
            // 
            // average_price
            // 
            this.average_price.HeaderText = "Precio promedio";
            this.average_price.Name = "average_price";
            this.average_price.Visible = false;
            // 
            // unit
            // 
            this.unit.HeaderText = "Id unit";
            this.unit.Name = "unit";
            this.unit.Visible = false;
            // 
            // RawMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 465);
            this.Controls.Add(this.buttonCargaMasiva);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView_rawMaterialsList);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RawMaterials";
            this.Text = "Mantenimiento de materia prima";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rawMaterialsList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_rawMaterialsList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCargaMasiva;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_raw_material;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn average_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
    }
}