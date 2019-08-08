using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using XamarinUP2018.Models;
using XamarinUP2018.Services;
using System.Windows.Input;
using XamarinUP2018.Views;
using Prism.Commands;

namespace XamarinUP2018.ViewModels
{
    public sealed class MovieViewModel : ViewModelBase
    {
        private readonly MovieService movieService;
        public ICommand GoDetail { get; set; }

        

        public MovieViewModel(INavigationService navigationService, MovieService movieService): base(navigationService)
        {
            GoDetail = new DelegateCommand<Result>(async (movie) => await ExecuteGoDetail(movie));
            
            this.movieService = movieService;
        }

        private Task ExecuteGoDetail(Result movie)
        {
            var param = new NavigationParameters();
            param.Add("movie", movie);
            
            param.Add("oi", movie.Title);
            return NavigationService.NavigateAsync($"{nameof(Detail)}", param);
        }

        /*
        private Task GetExecuteGoDetail()
        {
            return NavigationService.NavigateAsync(nameof(Detail));
        }
        */

        private ObservableCollection<XamarinUP2018.Services.Result> items = new ObservableCollection<XamarinUP2018.Services.Result>();

        public ObservableCollection<XamarinUP2018.Services.Result> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            await LoadMovies();
        }

        private async Task LoadMovies()
        {
            await ExecuteBusyAction(async () => {

                var movies = await movieService.GetMoviesAsync();

                Items.Clear();
                
                foreach (var item in movies.Results)
                {
                    item.PosterPath = "https://image.tmdb.org/t/p/w154" + item.PosterPath;
                    Items.Add(item);
                }

            });
        }
    }
}
