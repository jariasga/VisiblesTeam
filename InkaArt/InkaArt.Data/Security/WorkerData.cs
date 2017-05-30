using InkaArt.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Security
{
    public class WorkerData : BD_Connector
    {        
        public NpgsqlDataAdapter workerAdapter()
        {
            NpgsqlDataAdapter workerAdapter = new NpgsqlDataAdapter();

            workerAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Worker\";", Connection);

            //  UPDATE STATEMENT - SQL QUERY FOR NPGSQL
            //  ADDED, BUILDER IS NOT WORKING
            workerAdapter.UpdateCommand = new NpgsqlCommand("UPDATE inkaart.\"Worker\" SET " +
                "\"firstName\" = @firstNameP, " +
                "\"lastName\" = @lastNameP, " +
                "\"dni\" = @dniP, " +
                "\"turn\" = @turnP, " +
                "\"user\" = @userP, " +
                "\"phone\" = @phoneP, " +
                "\"address\" = @addressP, " +
                "\"email\" = @emailP " +
                "WHERE \"idWorker\" = @idWorkerP;", Connection);

            return workerAdapter;
        }
    }
}
