using WebApplication3.Models;
using System.Collections.Generic;
namespace WebApplication3.Repository
{
    public interface IMovieRepository
    {

        List<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);

    }
}
