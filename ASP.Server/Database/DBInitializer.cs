using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.Server.Database
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext bookDbContext)
        {

            if (bookDbContext.Books.Any())
                return;

            Genre SF, Classic, Romance, Thriller;
            bookDbContext.Genre.AddRange(
                SF = new Genre(1,"SF", new List<Book> { }),
                Classic = new Genre(2, "Classic", new List<Book> { }),
                Romance = new Genre(3, "Romance", new List<Book> { }),
                Thriller = new Genre(4, "Thriller", new List<Book> { })
            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book("Book1", "author", 10.0F, "test", new List<Genre> { SF}), 
                new Book("Book2", "author2", 15.0F, "Test", new List<Genre> { SF }),
                new Book("Book3", "author3", 16F, "tesfgtéa", new List<Genre> { SF }),
                new Book("Book4", "author4", 18F, "aeffafafe", new List<Genre> { SF })
            );
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}