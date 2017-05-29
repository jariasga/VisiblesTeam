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
    public class ProcessController
    {
        private ProcessData process;
        private NpgsqlDataAdapter adapt;
        private DataSet data;

        public DataTable getData()
        {
            process = new ProcessData();
            adapt = new NpgsqlDataAdapter();
            data = new DataSet();

            process.connect();
            adapt = process.processAdapter();

            data.Reset();
            data = process.getData(adapt, "Product");

            DataTable processList = new DataTable();
            processList = data.Tables[0];

            return processList;
        }
    }
}
