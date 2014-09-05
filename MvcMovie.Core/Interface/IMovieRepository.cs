using MvcMovie.Core;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MvcMovie.Core
{
    public interface IMovieRepository
    {
        bool Add(Movie movie);
        void Delete(Movie movie);
        bool Edit(Movie movie);
        Movie FindById(int? Id);
        IQueryable<Movie> GetAll();
        List<int> GetBinderList();
        List<string> GetGenereList();
        IQueryable<Movie> GetMoviesByBinder(int binderId);
        IQueryable<Movie> GetMoviesByGenre(string movieGenre);
        IQueryable<Movie> GetMoviesBySearchString(string searchString);
        Movie ReturnDefaultMovie();
    }
}
