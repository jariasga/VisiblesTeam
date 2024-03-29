﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using InkaArt.Business.Production;
using InkaArt.Business.Purchases;
namespace InkaArt.Interface.Production
{
    public partial class Recipe : Form
    {
        private string globalIdRecipe;
        private int maxRow=0;

        public Recipe()
        {
            InitializeComponent();
            globalIdRecipe = "";
        }

        public Recipe(string id, string name)
        {
            InitializeComponent();
            textBox_id.Text = id;
            textBox_product.Text = name;

            RecipeController control = new RecipeController();
            control.updateRecipeStatus();
            DataTable recipeList = control.getData();
            

            //agregar datos a combobox version
            for(int i =0; i<recipeList.Rows.Count;i++)
            {
                if (String.Compare(recipeList.Rows[i]["idProduct"].ToString(), id) == 0)
                {
                    comboBox_version.Items.Add(recipeList.Rows[i]["version"].ToString());
                }
            }
            //llenar datagrid de materias prima dependiendo de la seleccion del comboBox version
            //llanar comboBox materia prima
            RawMaterialController controlRawM = new RawMaterialController();
            DataTable rawMList = controlRawM.getData();
            //agregar datos al combobox rawmaterial
            for (int i = 0; i < rawMList.Rows.Count; i++)
                if(rawMList.Rows[i]["status"].ToString()=="Activo")
                    comboBox_rawMaterial.Items.Add(rawMList.Rows[i]["name"].ToString());
            comboBox_rawMaterial.SelectedIndex = -1;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Recipe_Load(object sender, EventArgs e)
        {

        }


        private void fillGrid()
        {
            //llenar el datagrid
            //necesito la version y el id
            string id = textBox_id.Text;
            string idRecipe = "";
            string version = comboBox_version.SelectedItem.ToString();

            RecipeController controlRecipe = new RecipeController();
            DataTable recipeList = controlRecipe.getData();

            if (comboBox_version.SelectedItem != null)
            {
                dataGridView_rawMaterial.Rows.Clear();
                //busco en cada receta la que tenga el id y version seleccionada
                //primero el id
                for (int i = 0; i < recipeList.Rows.Count; i++)
                {
                    //Debug.WriteLine(recipeList.Rows[i]["idProduct"].ToString());
                    //Debug.WriteLine(id);
                    //Debug.WriteLine("");
                    if (String.Compare(recipeList.Rows[i]["idProduct"].ToString(), id) == 0)
                    {
                        //este es el producto, ahora falta hallar la receta adecuada
                        if (String.Compare(recipeList.Rows[i]["version"].ToString(), version) == 0)
                        {
                            //version buscada
                            idRecipe = recipeList.Rows[i]["idRecipe"].ToString();
                            globalIdRecipe = recipeList.Rows[i]["idRecipe"].ToString();
                            if (int.Parse(recipeList.Rows[i]["status"].ToString()) == 1)
                                textBox_state.Text = "Activo";
                            else
                                textBox_state.Text = "Inactivo";
                            break;
                        }
                    }
                }

                //buscar toda la materia prima y llenar los datos del grid
                RecipeRawMaterialController controlRecipeRaw = new RecipeRawMaterialController();
                DataTable recipeRawList = controlRecipeRaw.getData();
                RawMaterialController controlRawM = new RawMaterialController();
                DataTable rawMList = controlRawM.getData();
                UnitController controlUnit = new UnitController();
                DataTable unitList = controlUnit.getData();

                string idRaw, nameRaw, countRaw, idUnit, nameUnit;
                string status = "Activo";
                idRaw = nameRaw = countRaw = idUnit = nameUnit = "1";

                for (int i = 0; i < recipeRawList.Rows.Count; i++)
                {
                    if (String.Compare(recipeRawList.Rows[i]["idRecipe"].ToString(), idRecipe) == 0 && 
                        string.Compare(recipeRawList.Rows[i]["status"].ToString(),"1")==0)
                    {
                        idRaw = recipeRawList.Rows[i]["idRawMaterial"].ToString();
                        countRaw = recipeRawList.Rows[i]["materialCount"].ToString();
                        //buscar nombre de la materia prima
                        for (int j = 0; j < rawMList.Rows.Count; j++)
                            if (String.Compare(rawMList.Rows[j]["id_raw_material"].ToString(), idRaw) == 0)
                            {
                                nameRaw = rawMList.Rows[j]["name"].ToString();
                                idUnit = rawMList.Rows[j]["unit"].ToString();
                                status = rawMList.Rows[j]["status"].ToString();
                                break;
                            }

                        for (int j = 0; j < unitList.Rows.Count; j++)
                            if (String.Compare(unitList.Rows[j]["id_unit"].ToString(), idUnit) == 0)
                            {
                                nameUnit = unitList.Rows[j]["name"].ToString();
                                break;
                            }
                        //estado de la materia prima
                        dataGridView_rawMaterial.Rows.Add(idRaw, nameRaw, countRaw, nameUnit,status);
                    }
                }
                maxRow = dataGridView_rawMaterial.Rows.Count;
            }
            dataGridView_rawMaterial.Refresh();
        }

        private void comboBox_version_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            bool s = checkBox_newVer.Checked;

            if (s == true)
            {
                //insert en recipe

                RecipeController control = new RecipeController();
                string desc, ver, stat, idProduct;

                desc = ver = stat = idProduct = "";
                desc = textBox_product.Text;
                ver = textbox_newVer.Text;
                stat = "1";
                idProduct = textBox_id.Text;
                try
                {
                    control.insertData(desc, ver, stat, idProduct);
                }
                catch(Exception p)
                {
                    Console.WriteLine("{0} error", p);
                }

                //refresh comboBox_version
                DataTable recipeList = control.getData();
                comboBox_version.Items.Clear();
                //agregar datos a combobox version
                for (int i = 0; i < recipeList.Rows.Count; i++)
                {
                    if (String.Compare(recipeList.Rows[i]["idProduct"].ToString(), textBox_id.Text) == 0)
                    {
                        comboBox_version.Items.Add(recipeList.Rows[i]["version"].ToString());
                    }
                }
                MessageBox.Show("Nueva versión creada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            RawMaterialController controlRaw = new RawMaterialController();
            RecipeRawMaterialController controlRecipeRaw = new RecipeRawMaterialController();
            DataTable rawList = controlRaw.getData();
            DataTable recipeRawList = controlRecipeRaw.getData();

            string idRaw = "";
            string count = numericUpDown_count.Value.ToString();

            if (comboBox_version.SelectedItem != null && string.Equals(textBox_state.Text, "Activo"))
            {
                if (numericUpDown_count.Value > 0)
                {
                    for (int i = 0; i < rawList.Rows.Count; i++)
                    {
                        if (String.Compare(rawList.Rows[i]["name"].ToString(), comboBox_rawMaterial.SelectedItem.ToString()) == 0)
                        {
                            idRaw = rawList.Rows[i]["id_raw_material"].ToString();
                            break;
                        }
                    }
                    DataTable table = controlRecipeRaw.getData();
                    try
                    {
                        controlRecipeRaw.insertDataNoAdapter(globalIdRecipe, idRaw, count);
                    }
                    catch(Exception m)
                    {
                        Console.Write("{0} error", m);
                    }
                    fillGrid();
                }
                else
                    MessageBox.Show("La cantidad de materia prima debe ser mayor a cero, por favor verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
                MessageBox.Show("Versión no válida, por favor seleccione una versión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string id = "";
            string quantity = "";
            foreach(DataGridViewRow row in dataGridView_rawMaterial.Rows)
            {
                //fill valores limites
                int number;
                
                if(row.Index>=0 && row.Index < dataGridView_rawMaterial.Rows.Count && Convert.ToBoolean(row.Cells[5].Value))
                {
                    if (int.TryParse(row.Cells[0].Value.ToString(),out number)){
                        id = row.Cells[0].Value.ToString();
                        quantity = row.Cells[2].Value.ToString();
                        RecipeRawMaterialController control = new RecipeRawMaterialController();
                        try
                        {
                            control.updateDataNoAdapter(globalIdRecipe, id, quantity);
                        }
                        catch (Exception m)
                        {
                            Console.Write("{0} error", m);
                        }
                        fillGrid();
                        break;
                    }
                }
                   
            }
        }

        private void comboBox_rawMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void massive_recipe_Click(object sender, EventArgs e)
        {
            RecipeController control = new RecipeController();
            DataTable recipeList = control.getData();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Suppliers File";
            dialog.Filter = "CSV files|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (control.massiveUpload(dialog.FileName)==0)
                {
                    recipeList = control.getData();
                    comboBox_version.Items.Clear();
                    //agregar datos a combobox version
                    for (int i = 0; i < recipeList.Rows.Count; i++)
                    {
                        if (String.Compare(recipeList.Rows[i]["idProduct"].ToString(), textBox_id.Text) == 0)
                        {
                            comboBox_version.Items.Add(recipeList.Rows[i]["version"].ToString());
                        }
                    }
                    MessageBox.Show("Recetas cargadas de manera exitosa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("No se pudo cargar el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void massive_details_Click(object sender, EventArgs e)
        {
            RecipeRawMaterialController control = new RecipeRawMaterialController();
            DataTable recipeList = control.getData();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Suppliers File";
            dialog.Filter = "CSV files|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (control.massiveUpload(dialog.FileName) == 0)
                    MessageBox.Show("Detalle de recetas cargadas de manera exitosa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se pudo cargar el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
