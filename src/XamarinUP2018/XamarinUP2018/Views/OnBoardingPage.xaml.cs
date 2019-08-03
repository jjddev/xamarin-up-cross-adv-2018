using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinUP2018.Services;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinUP2018.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnBoardingPage : ContentPage
    {
        public OnBoardingPage()
        {
            InitializeComponent();
            var movieService = new MovieService();
            var response = movieService.GetMoviesAsync();

            int teste = 10;
            
        }
    }
}