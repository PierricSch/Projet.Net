using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASP.Server.Model
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        // Mettez ici les propriété de votre livre: Nom, Autheur, Prix, Contenu et Genres associés
        // N'oublier pas qu'un livre peut avoir plusieur genres
        public string Title { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public string Content { get; set; }

        public List<Genre> Genre { get; set; }

        public Book(int id, string title, string author, float price, string content, List<Genre> genre)
        {
            Id = id;
            Title = title;
            Author = author;
            Price = price;
            Content = content;
            Genre = genre;
        }
        public Book(string title, string author, float price, string content, List<Genre> genre)
        {
            Title = title;
            Author = author;
            Price = price;
            Content = content;
            Genre = genre;

        }

        public Book()
        {
        }

    }
}
