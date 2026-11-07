using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAdoDotnet.Models
{
    internal class DbContext
    {
        public string? ConnectionString { get; } //get pour une propriété

        //injection de dépendances
        private readonly IConfiguration configuration; //readonly pour un champ

        public DbContext(IConfiguration configuration)
        {
            this.configuration = configuration;

            //le but d'utiliser IConfiguration est de récupérer la chaine de connexion dans appsettings.json
            //et de l'assigner à la variable C# ConnectionString
            ConnectionString = this.configuration.GetConnectionString("AlwaysDataConnection");
        }
    }
}
