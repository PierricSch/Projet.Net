using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WPF.Reader.Api;
using WPF.Reader.Client;
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
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        /*= new ObservableCollection<Book>() {

            new Book(1, "Book1","author1",10.0F,
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas nunc erat, imperdiet sit amet mollis eu, malesuada nec turpis. Sed vestibulum venenatis dolor at gravida. Vivamus vel neque dolor. Pellentesque condimentum ac mauris vel gravida. Phasellus ut nulla sit amet leo elementum mollis. Donec sit amet arcu ut justo pulvinar placerat. Morbi ullamcorper ex mauris, nec congue nisi pharetra vitae. Ut vulputate leo ac eros pellentesque ultrices. Etiam sed mauris pulvinar odio vestibulum viverra non eget dolor. Duis semper magna non hendrerit pharetra. Sed eget ornare nisl. Morbi mi lacus, cursus a blandit et, maximus et purus. Sed pharetra turpis sed mollis posuere. Donec a porta enim.\r\n\r\nSed quis ex id risus varius laoreet. Praesent non sollicitudin eros, vitae tempor augue. Cras condimentum ut nisl a viverra. Cras tellus libero, cursus ut elit eu, egestas vehicula turpis. Sed enim nibh, cursus nec lacinia nec, convallis nec nulla. Cras vitae hendrerit sapien. In nec metus et mauris molestie ultricies. Nulla facilisi. Pellentesque ac pharetra nibh. Quisque blandit nibh nisl, ultricies facilisis augue ultricies at. Cras nec ex non arcu accumsan imperdiet in et tortor.\r\n\r\nPhasellus tempor turpis nec dui tincidunt semper. Fusce lobortis lorem sem, eu vulputate arcu finibus sit amet. Curabitur dignissim elit at sapien laoreet rhoncus. Nunc tempor in lectus sit amet consectetur. Donec commodo condimentum risus ut finibus. Ut nisi magna, iaculis sit amet nulla sit amet, lobortis efficitur mi. Suspendisse bibendum diam id vulputate posuere. Nullam placerat lobortis ultricies. Donec tellus ipsum, pretium eget consectetur eget, consequat vitae justo. Praesent a facilisis ex, interdum tincidunt urna.\r\n\r\nVestibulum malesuada et lacus nec consectetur. Curabitur at porttitor nunc. Duis eu bibendum leo. Aliquam non sagittis leo, a hendrerit orci. Mauris nec justo id nisi sagittis hendrerit at ut justo. Suspendisse est justo, tempus id efficitur id, pellentesque a dolor. Praesent a dictum erat, non pulvinar magna.\r\n\r\nAenean dictum mi nibh, a fermentum nisl pulvinar quis. Vestibulum vel metus nulla. Vivamus convallis, felis placerat mollis volutpat, justo sem dictum dolor, ut iaculis nisi nisl nec felis. Aenean vel tortor hendrerit, pulvinar mauris sit amet, imperdiet ex. Etiam ut justo at ante consectetur congue. Sed orci orci, ornare sed est et, euismod porta mi. Fusce dignissim ultrices dolor eu laoreet. Duis posuere leo et lectus venenatis, vitae viverra ipsum accumsan. Fusce eget sapien porttitor tortor blandit ullamcorper. Aliquam erat volutpat. Vivamus tincidunt pulvinar turpis, ac blandit nunc. Morbi convallis gravida sapien, vel varius leo pharetra nec.\r\n\r\nDonec quis laoreet lacus. Aenean facilisis laoreet nulla, vel elementum tellus. Donec ultrices mi ullamcorper ante ultricies hendrerit. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vitae velit vitae massa pulvinar condimentum eu ut lorem. Nam dictum neque quis fringilla iaculis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Maecenas molestie in turpis in tincidunt.\r\n\r\nCras faucibus odio in est aliquam ultricies. Donec tempus metus id elit vulputate, sit amet vehicula nulla iaculis. Integer at augue ut leo lacinia lobortis. In viverra eros at accumsan varius. Quisque gravida ultricies ante in porta. Vestibulum urna mauris, sodales quis mauris et, consequat porta tortor. Sed eleifend sagittis rhoncus. Donec pharetra leo non magna ultricies, eu tristique libero finibus. Nam luctus bibendum quam quis varius. Etiam vel vehicula tellus, sed euismod lectus. Aliquam nec nisl nec tortor vehicula feugiat. Pellentesque at cursus nisl. Aliquam efficitur orci tellus, quis placerat tortor blandit non. Nam nunc dui, vulputate a justo ut, ultricies condimentum massa. Nunc vel felis eu augue malesuada vestibulum.\r\n\r\nIn tempor mattis lorem ac varius. Nam commodo venenatis felis, nec molestie ipsum iaculis vitae. In bibendum, erat finibus accumsan egestas, purus urna rhoncus mi, eu gravida ex ante eget orci. In tincidunt urna vitae erat tempor, a iaculis augue molestie. Fusce malesuada elit quis ornare congue. Integer faucibus egestas ex in ullamcorper. Phasellus eu metus et elit dignissim tincidunt.\r\n\r\nCras at pretium sem. Aliquam erat volutpat. Vivamus a maximus metus. Vivamus rutrum feugiat libero sed ultricies. Mauris fermentum massa arcu, vitae euismod massa dignissim ac. Integer aliquet nibh id neque dignissim sollicitudin. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Mauris cursus, leo vitae viverra maximus, urna lorem commodo tortor, non cursus est nibh nec urna.\r\n\r\nFusce volutpat nibh massa, in imperdiet lorem dignissim in. Phasellus aliquam, elit et ultrices convallis, orci dui tincidunt neque, non tincidunt nibh tellus ut neque. Nam congue arcu diam, in convallis lorem rhoncus vel. Nulla volutpat velit nec nunc suscipit, euismod fringilla elit maximus. Donec tristique eget felis at accumsan. Cras finibus ligula ante, ut interdum tortor interdum consectetur. Mauris molestie aliquet commodo. In commodo facilisis velit, a ornare lorem porta a. Maecenas hendrerit tellus sit amet enim feugiat fringilla. Vestibulum lobortis bibendum accumsan."
                ,(new List<Genre>{new Genre(1,"SF"), new Genre(1, "Classic") }
                )),
            new Book(2, "Book2","author2",10.0F,"g☼ƒcz50ð♀A¢znjrkbgvklebemjtbnejblnietbntemilntehib",new List<Genre>{}),
            new Book(3,"test langue","un autheur", 10.85F,"Rubin conceived the outline of Groundhog Day in the early 1990s. He wrote it as a spec script to gain meetings with producers for other work. It eventually came to the attention of Ramis, who worked with Rubin to make his idea less dark in tone and more palatable to a general audience by enhancing the comedy. After being cast, Murray clashed with Ramis over the script; Murray wanted to focus on the philosophical elements, whereas Ramis concentrated on the comic aspects. Principal photography took place from March to June 1992 almost entirely in Woodstock, Illinois. Filming was difficult, in part because of bitterly cold weather, but also because of the ongoing conflict between Ramis and Murray.\r\n\r\n", new List<Genre>{})
            
        };*/

        public ObservableCollection<Genre> Genres { get; set; } = new ObservableCollection<Genre>()
        {
            /*
            new Genre(1,"SF", new List<Book> { new Book(1, "Book1","author1",10.0F,"aefronjegbjvbeint",new List<Genre>{}) }),
            new Genre(2, "Classic", new List<Book> { }),
            new Genre(3, "Romance", new List<Book> { })
            */
        };

        public LibraryService()
        {
            BookApi bookApi = new BookApi();
            var listBook = bookApi.BookGetBooks(new List<int>());
            foreach (Book book in listBook)
            {
                Books.Add(book);
            }

            var lisGenre = bookApi.BookGetGenres();
            foreach (Genre genre in lisGenre)
            {
                Genres.Add(genre);
            }
        }
        // C'est aussi ici que vous ajouterez les requête réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
        // Faite bien attention a ce que votre requête réseau ne bloque pas l'interface 
    }
}
