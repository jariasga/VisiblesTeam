using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Common;
using InkaArt.Data.Algorithm;

namespace InkaArt.Business.Algorithm
{
    class RatioController
    {
        List<Ratio> ratios;
        IndexController indexes;

        public RatioController()
        {
            ratios = new List<Ratio>();
            indexes = new IndexController();
        }

        public void Load(DateTime date)
        {
            ratios.Clear();

            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Ratio\" WHERE date = :date AND "
                + "status = :status ORDER BY id_report ASC", connection);

            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, date);
            command.Parameters.AddWithValue("status", NpgsqlDbType.Boolean, true);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_report = reader.GetInt32(0);
                int id_worker = reader.GetInt32(2);
                int id_job = reader.GetInt32(3);
                int id_recipe = reader.GetInt32(4);
                TimeSpan start = reader.GetTimeSpan(5);
                TimeSpan end = reader.GetTimeSpan(6);
                int broken = reader.GetInt32(7);
                int produced = reader.GetInt32(8);
                double breakage = reader.GetDouble(9);
                double time = reader.GetDouble(10);

                ratios.Add(new Ratio(id_report, date, id_worker, id_job, id_recipe, start, end, broken,
                    produced, breakage, time));
            }

            connection.Close();
        }

        public Ratio Verify(int id_report, DateTime date, string worker_text, string job_text, string recipe_text,
            string start_text, string end_text, string broken_text, string produced_text, WorkerController workers,
            JobController jobs, RecipeController recipes, ref string message)
        {
            if (id_report < 0)
            {
                message = "El ID del informe de turno no es válido.";
                return null;
            }

            Worker worker = workers.GetByFullName(worker_text);
            if (worker == null)
            {
                message = "El trabajador seleccionado no es válido.";
                return null;
            }

            Job job = jobs.GetByName(job_text);
            if (job == null)
            {
                message = "El puesto de trabajo seleccionado no es válido.";
                return null;
            }

            Recipe recipe = recipes.GetByDescription(recipe_text);
            if (recipe == null)
            {
                message = "La receta seleccionada no es válida.";
                return null;
            }
            if (recipe.Product != job.Product)
            {
                message = "Los productos asocidados al puesto de trabajo y a la receta no coinciden.";
                return null;
            }

            TimeSpan start, end;
            if (!TimeSpan.TryParse(start_text, out start) || start.TotalMinutes <= 0 || start.TotalMinutes >= 24 * 60)
            {
                message = "La hora inicial ingresada no es válida.";
                return null;
            }
            if (!TimeSpan.TryParse(end_text, out end) || end.TotalMinutes <= 0 || end.TotalMinutes >= 24 * 60)
            {
                message = "La hora final ingresada no es válida.";
                return null;
            }
            if (start.TotalMinutes >= end.TotalMinutes)
            {
                message = "La hora inicial ingresada debe ser menor a la hora final ingresada.";
                return null;
            }

            int broken, produced;
            if (!int.TryParse(broken_text, out broken) || broken <= 0)
            {
                message = "El número de productos rotos no es válido.";
                return null;
            }
            if (!int.TryParse(produced_text, out produced) || produced <= 0)
            {
                message = "El número de productos elaborados no es válido.";
                return null;
            }
            if (broken > produced)
            {
                message = "El número de productos rotos no puede ser mayor al número de productos elaborados.";
                return null;
            }
            
            Ratio ratio = new Ratio(id_report, date, worker.ID, job.ID, recipe.ID, start, end, broken, produced,
                (double)broken / produced, (end - start).TotalMinutes / produced);
            return ratio;
        }

        public int VerifyAndSave(int id_report, DateTime date, string worker, string job, string recipe,
            string start, string end, string broken, string produced, WorkerController workers,
            JobController jobs, RecipeController recipes, ref string message)
        {
            Ratio ratio = Verify(id_report, date, worker, job, recipe, start, end, broken, produced,
                workers, jobs, recipes, ref message);
            if (ratio == null) return 0;

            if (id_report == 0) return Insert(ratio, ref message);
            else return Update(ratio, ref message);
        }

        public int Insert(Ratio ratio, ref string message)
        {
            try
            {
                ratio.Insert();
                ratios.Add(ratio);

                //Actualizar resumen de reportes
                /*int count = ratio.Count();
                if (count <= 0) indexes.Insert(ratio);
                else
                {
                    double average_breakage, average_time;
                    ratio.AverageValues(out average_breakage, out average_time);
                    indexes.Update(ratio, average_breakage, average_time);
                }*/
                    
                
                return ratio.ID;
            }
            catch (Exception e)
            {
                message = "Ocurrió un problema con la base de datos al intentar insertar un ratio: " + e.Message;
                LogHandler.WriteLine("Excepción al intentar insertar un ratio: " + e.ToString());
                return 0;
            }
        }

        public int Update(Ratio ratio, ref string message)
        {
            try
            {
                int index = GetIndex(ratio.ID);
                if (index < 0)
                {
                    message = "No se pudo encontrar el ID del informe de turno al intentar actualizarlo.";
                    return 0;
                }
                Ratio old_ratio = ratios[index];
                ratios[index] = ratio;
                ratios[index].Update();

                //Actualizar resumen de reportes
                if (old_ratio.Worker == ratio.Worker && old_ratio.Job == ratio.Job && old_ratio.Recipe == ratio.Recipe)
                {

                }
                else
                {

                }
                //indexes.Save(old_ratio, ref message);
                //indexes.Save(ratio, ref message);

                return ratio.ID;
            }
            catch (Exception e)
            {
                message = "Ocurrió un problema con la base de datos al intentar actualizar un ratio: " + e.Message;
                LogHandler.WriteLine("Excepción al intentar actualizar un ratio: " + e.ToString());
                return 0;
            }
        }

        public bool Delete(int id_report, ref string message)
        {
            try
            {
                int index = GetIndex(id_report);
                if (index < 0)
                {
                    message = "No se pudo encontrar el ID del informe de turno al intentar eliminarlo.";
                    return false;
                }
                ratios[index].Delete();
                ratios.RemoveAt(index);

                //Actualizar resumen de reportes

                return true;
            }
            catch (Exception e)
            {
                message = "Ocurrió un problema con la base de datos al intentar eliminar un ratio: " + e.Message;
                LogHandler.WriteLine("Excepción al intentar eliminar un ratio: " + e.ToString());
                return false;
            }
        }

        public Ratio GetById(int id)
        {
            for (int i = 0; i < ratios.Count; i++)
                if (ratios[i].ID == id) return ratios[i];
            return null;
        }

        public int GetIndex(int id)
        {
            for (int i = 0; i < ratios.Count; i++)
                if (ratios[i].ID == id) return i;
            return -1;
        }

        public Ratio this[int index]
        {
            get { return ratios[index]; }
            //set { ratios[index] = value; }
        }

        public int Count()
        {
            return ratios.Count();
        }
    }
}
