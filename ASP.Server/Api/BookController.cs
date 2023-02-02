using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Server.Database;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ASP.Server.Api
{

    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        // Methode a ajouter : 
        // - GetBooks
        //   - Entrée: Optionel -> Liste d'Id de genre, limit -> defaut à 10, offset -> défaut à 0
        //     Le but de limit et offset est dé créer un pagination pour ne pas retourner la BDD en entier a chaque appel
        //   - Sortie: Liste d'object contenant uniquement: Auteur, Genres, Titre, Id, Prix
        //     la liste restourner doit être compsé des élément entre <offset> et <offset + limit>-
        //     Dans [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20] si offset=8 et limit=5, les élément retourner seront : 8, 9, 10, 11, 12

        public ActionResult<List<Book>> GetBooks([Optional] List<int> GenreId,int limit = 10, int offset = 0)
        {
            if(GenreId.Count < 0)
            {
                return libraryDbContext.Books.Include(x => x.Genre).Where(x => x.Genre.Where(y => GenreId.Contains(y.Id)).Intersect(x.Genre).Any()).Skip(offset).Take(limit).ToList();

            }
            else
            {
                return libraryDbContext.Books.Include(x => x.Genre).Skip(offset).Take(limit).ToList();
            }            
        }

        // - GetBook
        //   - Entrée: Id du livre
        //   - Sortie: Object livre entier

        public ActionResult<Book> GetBook(int id)
        {
            try
            {
                return libraryDbContext.Books.Include(x => x.Genre).Where(x => x.Id == id).First();
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("L'id ne pas etre a 0",e);
            }
        }

        // - GetGenres
        //   - Entrée: Rien
        //   - Sortie: Liste des genres

        public ActionResult<List<Genre>> GetGenres()
        {
            return libraryDbContext.Genre.ToList();
        }

        public ActionResult<List<Book>> Delete_Book(int id)
        {
            Book book = GetBook(id).Value;
            libraryDbContext.Remove(book);
            libraryDbContext.SaveChanges();

            return libraryDbContext.Books.ToList();
        }

        // Aide:
        // Pour récupéré un objet d'une table :
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.First()
        // Pour récupéré des objets d'une table :
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.ToList()
        // Pour faire une requète avec filtre:
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Skip().<Selecteurs>
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Take().<Selecteurs>
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Where(x => x == y).<Selecteurs>
        // Pour récupérer une 2nd table depuis la base:
        //   - .Include(x => x.yyyyy)
        //     ou yyyyy est la propriété liant a une autre table a récupéré
        //
        // Exemple:
        //   - Ex: libraryDbContext.MyObjectCollection.Include(x => x.yyyyy).Where(x => x.yyyyyy.Contains(z)).Skip(i).Take(j).ToList()


        // Je vous montre comment faire la 1er, a vous de la compléter et de faire les autres !
        //public ActionResult<List<Book>> GetBooks()
        //{
        //    throw new NotImplementedException("You have to do it your self");
        //}

    }
}

