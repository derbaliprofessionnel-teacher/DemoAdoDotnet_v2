using DemoAdoDotnet.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAdoDotnet.Data
{
    internal class CategorieDaoImpl : ICategorieDao
    {
        public DbContext DbContext { get; set; }

        public CategorieDaoImpl(IConfiguration configuration)
        {
            DbContext = new DbContext(configuration);
        }

        public List<Categorie> GetAllCategories()
        {
            //1. initialiser une liste des catégories vide
            List<Categorie> categories = new List<Categorie>();
            try
            {
                //2. initialisier une chaine de connexion
                MySqlConnection connection = new MySqlConnection(DbContext.ConnectionString);
                //3. créer une commande SQL
                const string sql = "SELECT * FROM categorie;"; // SELECT est une lecture => alors utiliser ExecuteReader()

                //quand on éxécute : INSERT, UPDATE ou DELETE => écriture : utiliser ExecuteNonQuery()

                MySqlCommand command = new MySqlCommand(sql, connection);

                //4. ouvrir la connexion
                connection.Open();

                //5. Exécuter la commande SELECT
                MySqlDataReader reader = command.ExecuteReader(); //reader est le résultat sous forme d'un tableau

                //6. lire le résultat et stocker-le dans la liste List<Categorie>  categories
                while (reader.Read())
                {
                    Categorie cat = new Categorie();
                    cat.Id = reader.GetInt32(0); //0: répresente le premier champ Id de la table categorie
                    cat.Nom = reader.GetString(1);  //1: répresente le deuxiéme champ Nom de la table categorie

                    //ajouter la categorie à la liste
                    categories.Add(cat);
                }

                //7. fermer la connexion
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return categories;
        }

        public Categorie? GetCategorieById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddCategorie(string nom)
        {
            try
            {
                //1. initialisier une chaine de connexion
                MySqlConnection connection = new MySqlConnection(DbContext.ConnectionString);
                //2. créer une commande SQL
                string sql = "INSERT INTO categorie (nom) VALUES (" + nom + ");"; // INSERT => écriture : utiliser ExecuteNonQuery()

                MySqlCommand command = new MySqlCommand(sql, connection);

                //3. ouvrir la connexion
                connection.Open();

                //4. Exécuter la commande INSERT
                command.ExecuteNonQuery();

                //5. fermer la connexion
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
