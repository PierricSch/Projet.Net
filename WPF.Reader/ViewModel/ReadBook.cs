using System;
using System.Speech.Synthesis;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.Model;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WPF.Reader.ViewModel
{
    class ReadBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // A vous de jouer maintenant
        public static String CurrentContent;
        public Book CurrentReadBook { get; init; }


        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        public string IsSpeaking
        {
            get
            {
                return speechSynthesizer.State.ToString();
            }
        }
        public ReadBook(Book book)
        {
            CurrentReadBook = book;       
            CurrentContent = book.Content;
            speechSynthesizer.StateChanged += SpeechSynthesizer_StateChanged;

             speechButton = new RelayCommand(speech => {

                 Thread thread = new Thread(() =>
                 {
                     try
                     {
                         speechSynthesizer.Speak(CurrentContent);
                     }
                     finally
                     {
                         Debug.WriteLine("Closed");
                     }
                 });

                 switch (speechSynthesizer.State.ToString())
                 {
                     case "Ready":
                         thread.Start();
                         break;
                     case "Speaking":
                         speechSynthesizer.Pause();
                         break;
                     case "Paused":
                         speechSynthesizer.Resume();
                         break;
                     default:
                         break;
                 }
             });
        }

        private void SpeechSynthesizer_StateChanged(object sender, StateChangedEventArgs e)
        {
            Debug.Write($"Event {e.State}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSpeaking)));
        }

        bool IsReading { get; set; } = false;

        public ICommand speechButton { get; set; }

    }

    /* Cette classe sert juste a afficher des donnée de test dans le designer */
    //class InDesignReadBook : ReadBook
    //{
    //    public InDesignReadBook() : base()
    //    {
    //    }
    //}
}
