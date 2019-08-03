using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinUP2018.Models;

namespace XamarinUP2018.Services
{
    public interface IMovieService
    {
        Task<MovieRespose> GetMoviesAsync();
    }

    

    public sealed class MovieService : IMovieService
    {
        public string url = "https://api.themoviedb.org/3/movie/popular?api_key=18ab244d5cf2606de9fffc396332e450";

        /*
        async Task<List<Movie>> IMovieService.GetMovies()
        {
            await Task.Delay(2000);

            return new List<Movie>
            {
                new Movie {Id = 1, Title = "Filme 1", Vote_average = "7", Overview = "Resenha 1", Release_date = "30/01/2019",
                Poster_path = "poster1"},
                new Movie {Id = 2, Title = "Filme 2", Vote_average = "9", Overview = "Resenha 2", Release_date = "10/01/2019",
                Poster_path = "poster2"},
                new Movie {Id = 3, Title = "Filme 3", Vote_average = "6", Overview = "Resenha 3", Release_date = "15/01/2019",
                Poster_path = "poster3"}
            };
        }
        */


        public async Task<MovieRespose> GetMoviesAsync()
        {
            var httpClient = new HttpClient();
            var response = await  httpClient.GetStringAsync(url);
            var movieReponse = MovieRespose.FromJson(response);
            return movieReponse;
        }

    }
}
