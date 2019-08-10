using System.Collections.Generic;
using XamarinUP2018.Models;
using XamarinUP2018.Services;

namespace XamarinUP2018.Repositories
{
    public interface ILocalDataBaseRepository
    {
        void Add(Result movie);
        void Edit(Result movie);
        void Delete(Result movie);

        List<Result> GetAll();
        Result GetById(long id);
        bool Exists(Result movie);
    }
}