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
        private string  url = "https://api.themoviedb.org/3/movie/popular?api_key=18ab244d5cf2606de9fffc396332e450";

        public async Task<MovieRespose> GetMoviesAsync()
        {
            var httpClient = new HttpClient();
            var response = await  httpClient.GetStringAsync(url);
            var movieReponse = MovieRespose.FromJson(response);
            return movieReponse;
        }

    }
}
