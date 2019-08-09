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
    public sealed class DetailViewModel : ViewModelBase
    {
        private readonly MovieService movieService;
        public ICommand GoDetail { get; }



        public DetailViewModel(INavigationService navigationService, MovieService movieService) : base(navigationService)
        {
            GoDetail = new DelegateCommand<Result>(async (movie) => await ExecuteGoDetail(movie));

            this.movieService = movieService;
        }

        private Task ExecuteGoDetail(Result movie)
        {
            var param = new NavigationParameters();
            
            param.Add("movie", movie);
            return NavigationService.NavigateAsync($"{nameof(Detail)}", param);
        }
       

        Result _movie;
        public Result movie
        {
            get { return _movie; }
            set { SetProperty(ref _movie, value); }
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            movie = (Result)parameters["movie"];
            //movie.PosterPath = "https://image.tmdb.org/t/p/w154" + movie.PosterPath;
           // await LoadIsFavorited();
        }

    }
}
