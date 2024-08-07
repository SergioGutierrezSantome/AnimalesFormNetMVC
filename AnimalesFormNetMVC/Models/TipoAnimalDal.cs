using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnimalesFormNetMVC.Models
{
    public class TipoAnimalDal
    {
        private readonly ConnexionDb connexionDb;
        public TipoAnimalDal()
        {
            connexionDb = new ConnexionDb();
        }
        public string GetTypeAnimal(int id)
        {
            var tipoAnimal = new List<TipoAnimal>();
            string nombre="";
            string query = "SELECT A.NombreAnimal, A.Raza, TA.TipoDescripcion, A.FechaNacimiento " +
                  "FROM Animal A " +
                  "INNER JOIN TipoAnimal TA ON A.RIdTipoAnimal = TA.IdTipoAnimal " +
                  "WHERE TA.IdTipoAnimal = "+ id;

            
            using (var conn = connexionDb.GetConnection())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nombre = reader.GetString(1);
                        }
                    }
                }
            }
            return nombre;
        }

        public List<TipoAnimal> SelectTipoAnimalDal()
        {
            var tipoAnimal = new List<TipoAnimal>();
            using (var conn = connexionDb.GetConnection())
            {
                using (var cmd = new SqlCommand("SELECT * FROM TipoAnimal"
                    , conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tipoAnimal.Add(new TipoAnimal
                            {
                                IdTipoAnimal = reader.GetInt32(0),
                                TipoDescripcion = reader.GetString(1),
                            
                            });
                        }
                    }
                }
            }
            return tipoAnimal;
        }
    }
}