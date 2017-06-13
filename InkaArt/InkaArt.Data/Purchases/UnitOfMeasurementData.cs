using Npgsql;
using InkaArt.Classes;

namespace InkaArt.Data.Purchases
{
    public class UnitOfMeasurementData : BD_Connector
    {
       public NpgsqlDataAdapter unitOfMeasurementAdapter()
        {
            NpgsqlDataAdapter unitOfMeasurementAdapter = new NpgsqlDataAdapter();
            unitOfMeasurementAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"UnitOfMeasurement\";", Connection);
            
            return unitOfMeasurementAdapter;
        }
    }
}
