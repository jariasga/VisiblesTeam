﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Classes;

namespace InkaArt.Data.Algorithm
{
    //ESTA CLASE SE USA SOLO PARA LA ASIGNACIÓN DE TRABAJADORES Y PARA EL REGISTRO DE INFORMES DE TURNO
    //- Anthony
    public class Recipe
    {
        private int id_recipe;
        private int id_product;
        private string description;
        private string version;

        public int ID
        {
            get { return id_recipe; }
        }
        public int Product
        {
            get { return id_product; }
        }
        public string Description
        {
            get { return description; }
        }
        public string Version
        {
            get { return version; }
        }

        public Recipe(int id_recipe, int id_product, string description, string version)
        {
            this.id_recipe = id_recipe;
            this.id_product = id_product;
            this.description = description;
            this.version = version;
        }
    }
}
