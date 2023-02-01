using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Server.Model
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<Book> BookNames { get; set; }

        public Genre(int id, string name, List<Book> bookNames)
        {
            Id = id;
            Name = name;
            BookNames = bookNames;
        }

        public Genre(string name, List<Book> bookNames)
        {
            Name = name;
            BookNames = bookNames;
        }

        public Genre(string name)
        {
            Name = name;
        }

        public Genre()
        {
        }



        // Mettez ici les propriété de votre livre: Nom et Livres associés

        // N'oublier pas qu'un genre peut avoir plusieur livres

    }

}

