using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.Controllers
{
    public class CreateGenreModel
    {
        [Required]
        [Display(Name = "Nom")]
        public String Name { get; set; }

        public List<Book> Books { get; set; }
        public IEnumerable<Book> AllBooks { get; init; }

    }

    public class GenreController : Controller
    {

        private string Name { get; set; }

        private List<Book> BookName { get; set; }

        private readonly LibraryDbContext libraryDbContext;

        public GenreController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        // A vous de faire comme BookController.List mais pour les genres !
        public ActionResult<CreateGenreModel> Create(CreateGenreModel genre)
        {
            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                // Il faut intéroger la base pour récupérer l'ensemble des objets genre qui correspond aux id dans CreateBookModel.Genres
                List<Book> books = new List<Book>();
                foreach (Book index in genre.Books)
                {
                    books.Add(libraryDbContext.Books.Where(x => x.Id == index.Id).First());
                }

                // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi
                libraryDbContext.Add(new Genre(genre.Name, books)  { });
                libraryDbContext.SaveChanges();
            }

            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            return View(new CreateGenreModel() { AllBooks = libraryDbContext.Books.ToList() });
        }

        public ActionResult<IEnumerable<Genre>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            List<Genre> ListGenre = libraryDbContext.Genre.ToList();
            return View(ListGenre);
        }

    }
}
