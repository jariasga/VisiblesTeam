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
    public class ProcessProductController
    {
        private ProcessProductData processProduct;
        private NpgsqlDataAdapter adapt;
        private DataSet data;

        public DataTable getProcessProductsData(int process)
        {
            processProduct = new ProcessProductData();
            adapt = new NpgsqlDataAdapter();
            data = new DataSet();
            
            adapt = processProduct.processProductsAdapter();
            adapt.SelectCommand.Parameters[0].NpgsqlValue = process;

            data.Reset();
            data = processProduct.getData(adapt, "Process-Product");

            int rows = data.Tables[0].Rows.Count;
            DataTable processProductsList = new DataTable();

            if (rows > 0)//para evitar una excepcion
            {
                processProductsList = data.Tables[0];
            }

            return processProductsList;
        }

        public DataTable getProductProceses(int idProduct)
        {
            processProduct = new ProcessProductData();
            adapt = new NpgsqlDataAdapter();
            data = new DataSet();
            
            adapt = processProduct.productProcesesAdapter();
            //adapt.SelectCommand.Parameters[0].NpgsqlValue = idProduct;

            data.Reset();
            data = processProduct.getData(adapt, "Process-Product");

            int rows = data.Tables[0].Rows.Count;
            DataTable productProcesesList = new DataTable();

            if (rows > 0)//para evitar una excepcion
            {
                productProcesesList = data.Tables[0];
            }

            return productProcesesList;
        }

        public DataTable getData()
        {
            processProduct = new ProcessProductData();
            adapt = new NpgsqlDataAdapter();
            data = new DataSet();
            
            adapt = processProduct.productProcessAdapter();

            data.Reset();
            data = processProduct.getData(adapt, "Process-Product");

            DataTable productProcessList = new DataTable();
            productProcessList = data.Tables[0];

            return productProcessList;
        }
    }
}
