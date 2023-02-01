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
using WPF.Reader.Pages;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    class ListGenre
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }

        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!
        public ObservableCollection<Genre> Genres => Ioc.Default.GetRequiredService<LibraryService>().Genres;

        public ListGenre()
        {
            ItemSelectedCommand = new RelayCommand(genre => {
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsGenre>(genre);
            });
        }
    }
}
