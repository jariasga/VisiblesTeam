using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NpgsqlTypes;
using System.Diagnostics;
using InkaArt.Business.Production;
namespace InkaArt.Interface.Production
{
    public partial class Recipe : Form
    {

        public Recipe()
        {
            InitializeComponent();
        }

        public Recipe(string id, string name)
        {
            InitializeComponent();
            textBox_id.Text = id;
            textBox_product.Text = name;

            RecipeController control = new RecipeController();
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
                comboBox_rawMaterial.Items.Add(rawMList.Rows[i]["name"].ToString());

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

        private void comboBox_version_SelectedIndexChanged(object sender, EventArgs e)
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

                string idRaw, nameRaw, countRaw, idUnit,nameUnit;
                idRaw = nameRaw = countRaw = idUnit = nameUnit = "1";
                
                for(int i = 0; i < recipeRawList.Rows.Count; i++)
                {
                    if (String.Compare(recipeRawList.Rows[i]["idRecipe"].ToString(), idRecipe) == 0)
                    {
                        idRaw = recipeRawList.Rows[i]["idRawMaterial"].ToString();
                        countRaw = recipeRawList.Rows[i]["materialCount"].ToString();
                        //buscar nombre de la materia prima
                        for(int j=0;j<rawMList.Rows.Count;j++)
                            if (String.Compare(rawMList.Rows[j]["idRawMaterial"].ToString(), idRaw) == 0)
                            {
                                nameRaw = rawMList.Rows[j]["name"].ToString();
                                idUnit = rawMList.Rows[j]["unit"].ToString();
                                break;
                            }

                        for (int j = 0; j < unitList.Rows.Count; j++)
                            if (String.Compare(unitList.Rows[j]["idUnit"].ToString(), idUnit) == 0)
                            {
                                nameUnit = unitList.Rows[j]["name"].ToString();
                                break;
                            }
                        dataGridView_rawMaterial.Rows.Add(idRaw, nameRaw, countRaw, nameUnit);
                    }
                    
                }           
            }
            dataGridView_rawMaterial.Refresh();
        }
    }
}
