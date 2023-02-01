using CommunityToolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    public class DetailsGenre : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ReadCommand { get; init; } = new RelayCommand(x => { /* A vous de définir la commande */ });

        // n'oublier pas faire de faire le binding dans DetailsBook.xaml !!!!
        public Genre CurrentGenre { get; init; }

        public DetailsGenre(Genre genre)
        {
            CurrentGenre = genre;
        }

        public ObservableCollection<Book> Genres => Ioc.Default.GetRequiredService<LibraryService>().Books;

    }
}
