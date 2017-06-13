using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Warehouse;
using System.Data;

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
        
        public void insertMovement(int idLote,int movement_type,int idWare,int id_reason,string document_type)
        {
            
            string query="";

            query = "insert into inkaart.\"Movement\" (\"idBill\",\"idMovementType\",\"idWarehouse\",\"idMovementReason\",\"document_type\",\"dateIn\") values (" + idLote + "," + movement_type + "," + idWare + "," + id_reason + ",'" + document_type + "',current_date);";

            productionMovementMovementData.executeQuery(query);
        }
    }
}
