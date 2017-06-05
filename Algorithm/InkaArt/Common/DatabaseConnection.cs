using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Common
{
    //ESTA CLASE SE USA SOLO PARA LA ASIGNACIÓN DE TRABAJADORES Y PARA EL REGISTRO DE INFORMES DE TURNO
    //- Anthony

    public class DatabaseConnection
    {
        private static string host = "skeletpiece.homeip.net";
        private static string database = "desarrolloprogramas1";
        private static string user = "admin";
        private static string password = "fae48";

        public static string ConnectionString()
        {
            NpgsqlConnectionStringBuilder connection_string = new NpgsqlConnectionStringBuilder();
            connection_string.Host = host;
            connection_string.Database = database;
            connection_string.Username = user;
            connection_string.Password = password;
            connection_string.Pooling = true;
            connection_string.ApplicationName = Environment.UserName + "@" + Environment.UserDomainName +
                " on InkaArt Application";
            return connection_string.ConnectionString;
        }
    }
}
