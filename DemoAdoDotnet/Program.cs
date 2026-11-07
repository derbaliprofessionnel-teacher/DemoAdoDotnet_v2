
using DemoAdoDotnet.Data;
using DemoAdoDotnet.Models;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

IConfiguration configuration =  new ConfigurationBuilder()
                                        .SetBasePath(AppContext.BaseDirectory)
                                        .AddJsonFile("appsettings.json", optional: true)
                                        .AddUserSecrets<Program>()
                                        .Build();


//tester le Dao développé
CategorieDaoImpl categorieDaoImpl = new CategorieDaoImpl(configuration);

List<Categorie> categories = categorieDaoImpl.GetAllCategories();

Console.WriteLine($"Il y a {categories.Count} catégories trouvés");

foreach (var item in categories)
{
    Console.WriteLine($"{item.Id} - {item.Nom}");
}
