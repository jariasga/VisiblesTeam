using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Production;
using NpgsqlTypes;
using Npgsql;

namespace InkaArt.Business.Production
{
    public class RawMaterialController_old
    {
        private RawMaterialData rawMaterial;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable rawMaterialList;

        public RawMaterialController_old()
        {
            rawMaterial = new RawMaterialData();
            data = new DataSet();
        }
        public DataTable getData()
        {
            adapt = rawMaterial.rawMaterialAdapter();

            data.Clear();
            data = rawMaterial.getData(adapt, "RawMaterial");
            
            rawMaterialList = data.Tables["RawMaterial"];

            return rawMaterialList;
        }
    }
}
