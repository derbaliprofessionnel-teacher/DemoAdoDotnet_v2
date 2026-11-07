using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAdoDotnet.Models
{
    internal class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public int Quantite { get; set; }
        public DateTime Date_ajout { get; set; }
        public int Categorie_id { get; set; }
    }
}
