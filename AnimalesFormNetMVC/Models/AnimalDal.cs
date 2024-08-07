using AnimalesFormNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnimalesFormNetMVC.Controllers
{

    public class AnimalDal
    {
        private readonly ConnexionDb connexionDb;
        public AnimalDal()
        {
            connexionDb = new ConnexionDb();
        }
        public void AddAnimal(Animal animal)
        {
            using (var connection = connexionDb.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("INSERT INTO Animal (NombreAnimal, Raza, RIdTipoAnimal, FechaNacimiento) VALUES (@NombreAnimal, @Raza, @RIdTipoAnimal, @FechaNacimiento)", connection))
                {
                    command.Parameters.AddWithValue("@NombreAnimal", animal.NombreAnimal);
                    command.Parameters.AddWithValue("@Raza", (object)animal.Raza ?? DBNull.Value);
                    command.Parameters.AddWithValue("@RIdTipoAnimal", animal.RIdTipoAnimal);
                    command.Parameters.AddWithValue("@FechaNacimiento", (object)animal.FechaNacimiento ?? DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateAnimal(Animal animal)
        {
            using (var connection = connexionDb.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE Animal SET NombreAnimal = @NombreAnimal, Raza = @Raza, RIdTipoAnimal = @RIdTipoAnimal, FechaNacimiento = @FechaNacimiento WHERE IdAnimal = @IdAnimal", connection))
                {
                    command.Parameters.AddWithValue("@NombreAnimal", animal.NombreAnimal);
                    command.Parameters.AddWithValue("@Raza", (object)animal.Raza ?? DBNull.Value);
                    command.Parameters.AddWithValue("@RIdTipoAnimal", animal.RIdTipoAnimal);
                    command.Parameters.AddWithValue("@FechaNacimiento", (object)animal.FechaNacimiento ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
                    command.ExecuteNonQuery();
                }
            }
        }
        public Animal GetById(int id)
        {
            Animal animal = null;
            using (var connection = connexionDb.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Animal WHERE IdAnimal = @IdAnimal", connection))
                {
                    command.Parameters.AddWithValue("@IdAnimal", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            animal = new Animal
                            {
                                IdAnimal = (int)reader["IdAnimal"],
                                NombreAnimal = reader["NombreAnimal"].ToString(),
                                Raza = reader["Raza"]?.ToString(),
                                RIdTipoAnimal = (int)reader["RIdTipoAnimal"],
                                FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                            };
                        }
                    }
                }
            }
            return animal;
        }
        public void DeletedAnimals(int[] selectedItems)
        {
            if (selectedItems != null && selectedItems.Length > 0)
            {
                using (var conn = connexionDb.GetConnection())
                {
                    conn.Open();
                    var id = string.Join(",", selectedItems);
                    var query = $"DELETE FROM Animal WHERE IdAnimal IN ({id})";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public List<Animal> SelectAnimalDal()
        {
            var animal = new List<Animal>();
            using (var conn = connexionDb.GetConnection())
            {
                using (var cmd = new SqlCommand("SELECT * FROM Animal"
                    , conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            animal.Add(new Animal
                            {
                                IdAnimal = reader.GetInt32(0),
                                NombreAnimal = reader.GetString(1),
                                Raza = reader.GetString(2),
                                RIdTipoAnimal = reader.GetInt32(3),
                                FechaNacimiento = reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }
            return animal;
        }
    }
    }
