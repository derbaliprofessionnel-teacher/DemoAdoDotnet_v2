using DemoAdoDotnet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAdoDotnet.Data
{
    //l'interface en OO est un contrat
    internal interface ICategorieDao
    {
        List<Categorie> GetAllCategories(); // trouve toutes les catégories de la DB
        Categorie? GetCategorieById(int id); // trouve une catégorie identifiée par son id dans DB
        void AddCategorie(Categorie categorie); // ajouter une nouvelle catégorie dans DB
        
        //on peut enrichir le Dao par d'autres méthodes


    }
}
