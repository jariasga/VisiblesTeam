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
    public class RawMaterialController
    {
        private RawMaterialData rawMaterial;
        private NpgsqlDataAdapter adapt;
        private DataSet data;

        public RawMaterialController()
        {
            rawMaterial = new RawMaterialData();
            data = new DataSet();
        }
        public DataTable getData()
        {

            rawMaterial.connect();
            adapt = rawMaterial.rawMaterialAdapter();

            data.Clear();
            data = rawMaterial.getData(adapt, "RawMaterial");

            DataTable rawMaterialList = new DataTable();
            rawMaterialList = data.Tables[0];

            return rawMaterialList;
        }
    }
}
