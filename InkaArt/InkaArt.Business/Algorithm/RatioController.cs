﻿using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using InkaArt.Business.Production;
using System.Data;
using System.Globalization;

namespace InkaArt.Business.Algorithm
{
    public class RatioController
    {
        private List<Ratio> ratios;

        private WorkerController workers;
        private JobController jobs;
        private RecipeController recipes;

        private IndexController indexes;
        private RatioPerDayController ratios_per_day;

        public RatioController(WorkerController workers, JobController jobs, RecipeController recipes)
        {
            this.ratios = new List<Ratio>();

            this.workers = workers;
            this.jobs = jobs;
            this.recipes = recipes;

            this.indexes = new IndexController(workers, jobs, recipes);
            this.ratios_per_day = new RatioPerDayController(jobs);
        }

        public void Load(DateTime date)
        {
            this.ratios.Clear();

            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = BD_Connector.ConnectionString.ConnectionString;
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Ratio\" WHERE date = :date AND status = :status "
                + "ORDER BY id_ratio ASC", connection);

            command.Parameters.AddWithValue("date", NpgsqlDbType.Date, date);
            command.Parameters.AddWithValue("status", NpgsqlDbType.Boolean, true);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_ratio = Convert.ToInt32(reader["id_ratio"]);
                Worker worker = workers.GetByID(Convert.ToInt32(reader["id_worker"]));
                Job job = jobs.GetByID(Convert.ToInt32(reader["id_job"]));
                Recipe recipe = recipes.GetByID(Convert.ToInt32(reader["id_recipe"]));
                TimeSpan start = reader.GetTimeSpan(5);
                TimeSpan end = reader.GetTimeSpan(6);
                int broken = reader.GetInt32(7);
                int produced = reader.GetInt32(8);
                double breakage = reader.GetDouble(9);
                double time = reader.GetDouble(10);

                ratios.Add(new Ratio(id_ratio, date, worker, job, recipe, start, end, broken, produced, breakage, time));
            }

            connection.Close();
        }

        /// <summary>
        /// Obtiene un <see cref="DataTable"/> con los ratios filtrados por un intervalo de fechas inicial y final.
        /// </summary>
        public DataTable GetDataTable(DateTime start_date, DateTime end_date)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Ratio\" WHERE status = TRUE ORDER BY id_ratio ASC", connection);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            DataSet data_set = new DataSet();
            adapter.Fill(data_set);

            connection.Close();

            DataTable data_table = data_set.Tables[0];
            for (int i = data_table.Rows.Count - 1; i >= 0; i--)
            {
                DateTime date;
                //Asegurar de que la fecha se haya leído correctamente
                bool can_stay = DateTime.TryParse(data_table.Rows[i]["date"].ToString(), out date);
                //Asegurar de que la fecha del ratio leído está entre las fechas indicadas
                if (can_stay) can_stay &= (date.Date >= start_date.Date && date.Date <= end_date.Date);
                //En caso no se hayan cumplido con los requerimientos necesarios, eliminar el DataRow
                if (!can_stay) data_table.Rows.RemoveAt(i);
            }

            return data_table;
        }

        public Ratio Verify(int id_ratio, DateTime date, string worker_text, string job_text, string recipe_text,
            string start_text, string end_text, string broken_text, string produced_text, ref string message)
        {
            if (id_ratio < 0)
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

            Recipe recipe = recipes.GetByVersion(recipe_text);
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
            if (!int.TryParse(broken_text, out broken) || broken < 0)
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
            
            Ratio ratio = new Ratio(id_ratio, date, worker, job, recipe, start, end, broken, produced,
                (double)broken / produced, (end - start).TotalMinutes / produced);
            return ratio;
        }

        public int VerifyAndSave(int id_ratio, DateTime date, string worker, string job, string recipe,
            string start, string end, string broken, string produced, ref string message)
        {
            Ratio ratio = Verify(id_ratio, date, worker, job, recipe, start, end, broken, produced, ref message);
            if (ratio == null) return 0;

            if (id_ratio == 0) return Insert(ratio, ref message);
            else return Update(ratio, ref message);
        }

        public int Insert(Ratio ratio, ref string message)
        {
            try
            {
                //Para actualizar el resumen de reportes, se necesita conocer la cantidad de ratios actuales.
                int initial_count_ratios = ratio.CountByWorkerJobAndRecipe();

                //Realizar la operación INSERT en la base de datos
                message += ratio.Insert();
                //Con el ID generado, añadir el nuevo ratio en la lista en memoria
                ratios.Add(ratio);

                //Actualizar tablas de índices y ratios por día
                message += indexes.InsertOrUpdate(ratio, initial_count_ratios);

                if (ratio.Job.ID == 3 || ratio.Job.ID == 4 || ratio.Job.ID == 6)
                    message += ratios_per_day.InsertOrUpdate(ratio);
                
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
                if (index < 0 || index >= ratios.Count)
                {
                    message = "No se pudo encontrar el antiguo ratio a la hora de actualizarlo.";
                    return 0;
                }

                //Guardamos el ratio anterior en una variable temporal
                Ratio old_ratio = new Ratio(ratios[index]);
                //Para actualizar el resumen de reportes, se necesita conocer la cantidad de ratios actuales que cumplen
                //con los parámetros del nuevo ratio.
                int initial_count_ratios = ratio.CountByWorkerJobAndRecipe();

                //Se actualiza en base de datos el ratio
                message += ratio.Update();
                //Se reemplaza el antiguo ratio por el nuevo en la lista de ratios
                ratios[index] = ratio;

                //Actualizar resumen de reportes
                message += indexes.UpdateOrDelete(old_ratio);
                if (old_ratio.Job.ID == 3 || old_ratio.Job.ID == 4 || old_ratio.Job.ID == 6)
                    message += ratios_per_day.UpdateOrDelete(old_ratio);
                 
                message += indexes.InsertOrUpdate(ratio, initial_count_ratios);
                if (ratio.Job.ID == 3 || ratio.Job.ID == 4 || ratio.Job.ID == 6)
                    message += ratios_per_day.InsertOrUpdate(ratio);

                return ratio.ID;
            }
            catch (Exception e)
            {
                message = "Ocurrió un problema al intentar actualizar un ratio: " + e.Message;
                LogHandler.WriteLine("Excepción al intentar actualizar un ratio: " + e.ToString());
                return 0;
            }
        }

        public bool Delete(int id_ratio, ref string message)
        {
            try
            {
                Ratio ratio = GetById(id_ratio);
                if (ratio == null)
                {
                    message = "No se pudo encontrar el ID del informe de turno al intentar eliminarlo.";
                    return false;
                }
                //Se realiza el soft deletion en la base de datos
                message += ratio.Delete();
                //Se retira el ratio de la lista de ratios en memoria
                ratios.Remove(ratio);

                //Actualizar resumen de reportes
                message += indexes.UpdateOrDelete(ratio);
                if (ratio.Job.ID == 3 || ratio.Job.ID == 4 || ratio.Job.ID == 6)
                    message += ratios_per_day.UpdateOrDelete(ratio);

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
