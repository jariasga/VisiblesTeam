using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Warehouse;
using System.Data;
using NpgsqlTypes;
using Npgsql;


namespace InkaArt.Business.Warehouse
{
    public class ProductionMovementMovementController
    {
        private ProductionMovementMovementData productionMovementMovementData;
        public ProductionMovementMovementController()
        {
            productionMovementMovementData = new ProductionMovementMovementData();

        }

        public DataTable GetProductionMovementMovementList()
        {
            return productionMovementMovementData.GetData();
        }


        public void insertPurchaseRmMovement(string idFactura, string idWh, string fecha)
        {
            NpgsqlDataAdapter adapt;
            DataSet data;
            data = new DataSet();
            DataTable table;

            adapt = productionMovementMovementData.ProductionMovementMovementDataAdapter();
            data.Clear();
            data = productionMovementMovementData.getData(adapt, "Movement");

            table = data.Tables["Movement"];
            productionMovementMovementData.execute(string.Format(
                "INSERT INTO \"inkaart\".\"Movement\"(\"idBill\", \"idMovementType\", \"idWarehouse\", \"idMovementReason\", \"status\", \"idDocumentType\") VALUES({0},  {1}, {2}, {3}, {4}, {5});", idFactura, 2, idWh, 1, 1, 1));
        }

        
        public void insertMovement(int idLote,int movement_type,int idWare,int id_reason,string document_type)
        {
            
            string query="";

            query = "insert into inkaart.\"Movement\" (\"idBill\",\"idMovementType\",\"idWarehouse\",\"idMovementReason\",\"document_type\",\"dateIn\") values (" + idLote + "," + movement_type + "," + idWare + "," + id_reason + ",'" + document_type + "',current_date);";

            productionMovementMovementData.executeQuery(query);

        }
    }
}
