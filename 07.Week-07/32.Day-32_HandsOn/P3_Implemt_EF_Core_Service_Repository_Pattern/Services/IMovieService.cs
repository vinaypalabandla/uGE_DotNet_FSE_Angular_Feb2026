using WebApplication3.Models;
namespace WebApplication3.Services
{
    //implementinterface
    public interface IMovieService
        {
        //creating methods
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
     
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}
