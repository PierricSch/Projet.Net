using CommunityToolkit.Mvvm.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Pages;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }
        public ICommand DetailGenre { get; set; }


        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!
        public ObservableCollection<Book> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;
        public ObservableCollection<Genre> Genres => Ioc.Default.GetRequiredService<LibraryService>().Genres;


        public ListBook()
        {
            ItemSelectedCommand = new RelayCommand(book => {
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(book);
            });

            DetailGenre = new RelayCommand(genre => {
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsGenre>(genre);
            });


        }
    }
}
