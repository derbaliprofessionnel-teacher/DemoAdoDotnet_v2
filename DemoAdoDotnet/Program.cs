
using DemoAdoDotnet.Data;
using DemoAdoDotnet.Models;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");

IConfiguration configuration =  new ConfigurationBuilder()
                                        .SetBasePath(AppContext.BaseDirectory)
                                        .AddJsonFile("appsettings.json", optional: true)
                                        .AddUserSecrets<Program>()
                                        .Build();


//tester le Dao développé
CategorieDaoImpl categorieDaoImpl = new CategorieDaoImpl(configuration);

//console.writeline("lecture des categories en cours");
//list<categorie> categories = categoriedaoimpl.getallcategories();

//console.writeline($"il y a {categories.count} catégories trouvés");

//foreach (var item in categories)
//{
//    console.writeline($"{item.id} - {item.nom}");
//}

//Console.WriteLine("AJOUT D'UNE NOUVELLE CATEGORIE");
//categorieDaoImpl.AddCategorie("");

//Console.WriteLine("LECTURE DES CATEGORIES EN COURS");
//categories = categorieDaoImpl.GetAllCategories();

//Console.WriteLine($"Il y a {categories.Count} catégories trouvés");

//foreach (var item in categories)
//{
//    Console.WriteLine($"{item.Id} - {item.Nom}");
//}

//Console.WriteLine("RECHERCHE UNE CATEGORIE");
//var categorie = categorieDaoImpl.GetCategorieById(2);
//if(categorie != null) 
//    Console.WriteLine($"{categorie.Id} - {categorie.Nom}");
//else
//    Console.WriteLine("Catégorie introuvable");

//Console.WriteLine("METTRE À JOUR UNE CATEGORIE");
//categorieDaoImpl.UpdateCategorie(7, "Music");

Console.WriteLine("DELETE UNE CATEGORIE");
categorieDaoImpl.DeleteCategorie(6);