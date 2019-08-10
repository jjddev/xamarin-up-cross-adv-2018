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
        private readonly FavoriteService favoriteService;
        public ICommand GoDetail { get; }
        public ICommand Favorited { get; }



        public DetailViewModel(INavigationService navigationService, MovieService movieService) : base(navigationService)
        {
            GoDetail = new DelegateCommand<Result>(async (movie) => await ExecuteGoDetail(movie));
            Favorited = new DelegateCommand<Result>(ExecuteFavorite);
            this.movieService = movieService;
            //this.favoriteService = fs;
            //this.favoriteService = favoriteService;
        }

        private void ExecuteFavorite(Result movie)
        {
            Console.WriteLine("favoritado");
            
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
        }

    }
}
