using MvcMovie.Core;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MvcMovie.Core
{
    public interface IMovieRepository
    {
        bool AddMovie(Movie movie);
        void DeleteMovie(Movie movie);
        bool EditMovie(Movie movie);
        Movie FindMovieById(int? Id);
        IQueryable<Movie> GetAllMovies();
        List<int> GetBinderList();
        List<string> GetGenereList();
        IQueryable<Movie> GetMoviesByBinder(int binderId);
        IQueryable<Movie> GetMoviesByGenere(string movieGenre);
        IQueryable<Movie> GetMoviesBySearchString(string searchString);
        Movie ReturnDefaultMovie();
    }
}
