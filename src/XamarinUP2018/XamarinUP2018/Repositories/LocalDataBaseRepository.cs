using LiteDB;
using System.Collections.Generic;
using System.Linq;
using XamarinUP2018.Models;
using XamarinUP2018.Services;

namespace XamarinUP2018.Repositories
{
    public sealed class LocalDataBaseRepository : ILocalDataBaseRepository
    {
        private const string COLLECTION_NAME = "movies";

        private readonly LiteCollection<Result> liteCollection;
        private readonly IDataBaseAccessService dataBaseAccessService;

        public LocalDataBaseRepository(IDataBaseAccessService dataBaseAccessService)
        {
            this.dataBaseAccessService = dataBaseAccessService;
            liteCollection = GetCollection();
        }

        public void Add(Result movie) => liteCollection.Insert(movie);

        public void Delete(Result movie) => liteCollection.Delete(movie.Id);

        public void Edit(Result movie) => liteCollection.Update(movie);

        public List<Result> GetAll() => liteCollection.FindAll().ToList();

        public Result GetById(long id) => liteCollection.FindById(id);

        public bool Exists(Result movie) => liteCollection.FindById(movie.Id) != null;

        private LiteCollection<Result> GetCollection()
        {
            var db = GetOrCreateLiteDatabase();
            return db.GetCollection<Result>(COLLECTION_NAME);
        }

        private LiteDatabase GetOrCreateLiteDatabase()
        {
            var dbPath = dataBaseAccessService.GetDataBasePath();
            return new LiteDatabase($@"{dbPath}");
        }
    }
}