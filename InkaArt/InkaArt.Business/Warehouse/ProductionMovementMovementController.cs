using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Warehouse;
using System.Data;
using NpgsqlTypes;
using Npgsql;
using InkaArt.Classes;

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


        public void insertPurchaseRmMovement(string idFactura, string idWh, int idItem,int cant)
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
                "INSERT INTO \"inkaart\".\"Movement\"(\"idBill\", \"idMovementType\", \"idWarehouse\", \"idMovementReason\", \"status\", \"idDocumentType\", \"idItem\", \"itemType\", \"quantity\" ) VALUES({0},  {1}, {2}, {3}, {4}, {5}, {6}, 0, {7});", idFactura, 2, idWh, 1, 1, 7, idItem,cant));
        }

        public void insertBrokenFindMovement(int idMovementType, string idWh, int idMovementReason,string dateIn,string idItem, int idItemType,int quantity)
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
                "INSERT INTO \"inkaart\".\"Movement\"(\"idMovementType\", \"idWarehouse\", \"idMovementReason\", \"dateIn\", \"status\", \"idItem\", \"itemType\", \"quantity\" ) VALUES({0},  {1}, {2}, to_date('{3}', 'DD/MM/YYYY'), {4}, {5}, {6}, {7});",idMovementType,idWh,idMovementReason,dateIn,1,idItem,idItemType,quantity));

        }


        public void insertMovement(int idLote,int movement_type,int idWare,int id_reason,string document_type)
        {
            
            string query="";

            query = "insert into inkaart.\"Movement\" (\"idBill\",\"idMovementType\",\"idWarehouse\",\"idMovementReason\",\"document_type\",\"dateIn\") values (" + idLote + "," + movement_type + "," + idWare + "," + id_reason + ",'" + document_type + "',current_date);";

            productionMovementMovementData.executeQuery(query);

        }

        public void insertMovDev(int idDoc, int movement_type, int idWare, int id_reason, int idDocType,string idItem,int idItemType,int quantity )
        {
            productionMovementMovementData.execute(string.Format(
                "INSERT INTO \"inkaart\".\"Movement\"(\"idBill\", \"idMovementType\", \"idWarehouse\", \"idMovementReason\", \"status\", \"idDocumentType\", \"idItem\", \"itemType\", \"quantity\" ) VALUES({0}, {1}, {2}, {3}, {4}, '{5}', '{6}', {7}, {8});", idDoc, movement_type, idWare, id_reason, 1,idDocType, idItem, idItemType, quantity));
        }
    }
}
