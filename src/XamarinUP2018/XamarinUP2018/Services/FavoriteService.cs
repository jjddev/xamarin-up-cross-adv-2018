using System;
using System.Threading.Tasks;
using XamarinUP2018.Services;
using XamarinUP2018.Repositories;
using System.Collections.Generic;

namespace XamarinUP2018.Services
{
    public interface IFavoriteService
    {
        Task Add(Result movie);
        Task Edit(Result movie);
        Task Delete(Result movie);

        Task<List<Result>> GetAll();
        Task<Result> GetById(long id);
        Task<bool> Exists(Result movie);
    }

    public sealed class FavoriteService : IFavoriteService
    {
        private readonly ILocalDataBaseRepository localDataBaseRepository;

        public FavoriteService(ILocalDataBaseRepository localDataBaseRepository)
        {
            this.localDataBaseRepository = localDataBaseRepository;
        }

        public Task Add(Result movie) => Task.Run(() => localDataBaseRepository.Add(movie));

        public Task Edit(Result movie) => Task.Run(() => localDataBaseRepository.Edit(movie));

        public Task Delete(Result movie) => Task.Run(() => localDataBaseRepository.Delete(movie));

        public Task<List<Result>> GetAll() => Task.Run(() => localDataBaseRepository.GetAll());

        public Task<Result> GetById(long id) => Task.Run(() => localDataBaseRepository.GetById(id));

        public Task<bool> Exists(Result movie) => Task.Run(() => localDataBaseRepository.Exists(movie));
    }
}