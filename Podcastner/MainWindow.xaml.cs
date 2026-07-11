using Podcastner.Models;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace Podcastner;
using System.Windows.Threading;



public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();


        List<Podcast> podcasts =
        [
            new Podcast
            {
                Title = "6 Minute English",
                Author = "BBC Learning English",
                Description = "Improve your vocabulary with short lessons.",
                AudioPath = "C:\\Users\\Cristian hiciano\\source\\repos\\Podcastner\\Podcastner\\Resources\\Audio\\You.mp3"
            },


            new Podcast
            {
                Title = "The English We Speak",
                Author = "BBC Learning English",
                Description = "Learn everyday English expressions."
            },


            new Podcast
            {
                Title = "All Ears English",
                Author = "AEE",
                Description = "English conversation practice."
            }
        ];


        PodcastList.ItemsSource = podcasts;
    }
}