using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using XamarinUP2018.Models;
using XamarinUP2018.Services;

namespace XamarinUP2018.ViewModels
{
    public sealed class MovieViewModel : ViewModelBase
    {
        private readonly MovieService movieService;

        public MovieViewModel(INavigationService navigationService
            , MovieService movieService)
            : base(navigationService)
        {
            this.movieService = movieService;
        }

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
                    
                    Items.Add(item);
                }

            });
        }
    }
}
