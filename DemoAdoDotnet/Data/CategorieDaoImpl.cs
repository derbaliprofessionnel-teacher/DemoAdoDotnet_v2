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
            //1. initialiser une catégorie
            Categorie categorie = null;
            try
            {
                //2. initialisier une chaine de connexion
                MySqlConnection connection = new MySqlConnection(DbContext.ConnectionString);
                //3. créer une commande SQL
                const string sql = "SELECT * FROM categorie WHERE id = @id;"; // SELECT est une lecture => alors utiliser ExecuteReader()
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.Add("@id", MySqlDbType.Int16).Value = id;

                //4. ouvrir la connexion
                connection.Open();

                //5. Exécuter la commande SELECT
                MySqlDataReader reader = command.ExecuteReader(); //reader est le résultat sous forme d'un tableau

                //6. lire le résultat et stocker-le dans la liste List<Categorie>  categories
                if (reader.Read())
                {
                    categorie = new Categorie();
                    categorie.Id = reader.GetInt32(0); //0: répresente le premier champ Id de la table categorie
                    categorie.Nom = reader.GetString(1);  //1: répresente le deuxiéme champ Nom de la table categorie
                }

                //7. fermer la connexion
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return categorie;
        }

        public void AddCategorie(string nom)
        {
            if (!string.IsNullOrEmpty(nom.Trim()))
                try
                {
                    //1. initialisier une chaine de connexion
                    MySqlConnection connection = new MySqlConnection(DbContext.ConnectionString);

                    //2. créer une commande SQL sécuritaire contre les injections SQL (plus de détails plus tard):
                    const string sql = "INSERT INTO categorie (nom) VALUES (@nomCateg);"; // INSERT => écriture : utiliser ExecuteNonQuery()
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.Add("@nomCateg", MySqlDbType.VarChar, 50).Value = nom;

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

        public void UpdateCategorie(int id, string nouveauNom)
        {
            var categorie = GetCategorieById(id);
            if (categorie != null)
            {
                if (!string.IsNullOrEmpty(nouveauNom.Trim()))
                    try
                    {
                        //1. initialisier une chaine de connexion
                        MySqlConnection connection = new MySqlConnection(DbContext.ConnectionString);

                        //2. créer une commande SQL sécuritaire contre les injections SQL (plus de détails plus tard):
                        const string sql = "UPDATE categorie SET nom=@nomCateg WHERE id=@id;"; // UPDATE => écriture : utiliser ExecuteNonQuery()
                        MySqlCommand command = new MySqlCommand(sql, connection);
                        command.Parameters.Add("@nomCateg", MySqlDbType.VarChar, 50).Value = nouveauNom;
                        command.Parameters.Add("@id", MySqlDbType.Int16).Value = id;

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

        public void DeleteCategorie(int id)
        {
            var categorie = GetCategorieById(id);
            if (categorie != null)
            {
                try
                {
                    //1. initialisier une chaine de connexion
                    MySqlConnection connection = new MySqlConnection(DbContext.ConnectionString);

                    //2. créer une commande SQL sécuritaire contre les injections SQL (plus de détails plus tard):
                    const string sql = "DELETE FROM categorie WHERE id=@id;"; // DELETE => écriture : utiliser ExecuteNonQuery()
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.Add("@id", MySqlDbType.Int16).Value = id;

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
}
