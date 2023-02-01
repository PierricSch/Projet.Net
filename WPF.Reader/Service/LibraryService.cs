using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPF.Reader.Model;
using WPF.Reader.Pages;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouter et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>() {
            new Book(1, "Book1","author1",10.0F,"aefronjegbjvbeint",new List<Genre>{}),
            new Book(2, "Book2","author2",10.0F,"gznjrkbgvklebemjtbnejblnietbntemilntehib",new List<Genre>{}),
            new Book()
        };

        public ObservableCollection<Genre> Genres { get; set; } = new ObservableCollection<Genre>()
        {
            new Genre(1,"SF", new List<Book> { new Book(1, "Book1","author1",10.0F,"aefronjegbjvbeint",new List<Genre>{}) }),
            new Genre(2, "Classic", new List<Book> { }),
            new Genre(3, "Romance", new List<Book> { })
        };

        // C'est aussi ici que vous ajouterez les requête réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
        // Faite bien attention a ce que votre requête réseau ne bloque pas l'interface 
    }
}
