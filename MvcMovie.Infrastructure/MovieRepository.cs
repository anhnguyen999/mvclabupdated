using MvcMovie.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MvcMovie.Infrastructure
{
    public class MovieRepository : IMovieRepository
    {
        private MovieDBContext db = new MovieDBContext();
        public bool Add(Movie movie)
        {
            var binderCount = (from r in db.Binders where r.BinderNumber == movie.BinderId select r).Count();
            if (binderCount < 5)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Delete(Movie movie)
        {
            db.Movies.Remove(movie);
            db.SaveChanges();
        }

        public bool Edit(Movie movie)
        {
            var binderCount = (from r in db.Binders where r.BinderNumber == movie.BinderId select r).Count();
            if (binderCount < 5)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Movie FindById(int? Id)
        {
            var movie = (from m in db.Movies
                         where m.ID == Id
                         select m).FirstOrDefault();
            return movie;
        }

        public IQueryable<Movie> GetAll()
        {
            var movies = from m in db.Movies
                         select m;
            return movies;
        }

        public List<int> GetBinderList()
        {
            var GenreQry = from d in db.Binders
                           orderby d.ID
                           select d.ID;

            return GenreQry.ToList();
        }

        public List<string> GetGenereList()
        {
            var GenreLst = new List<string>();
            var GenreQry = from d in db.Movies
                           orderby d.Genre
                           select d.Genre;
            GenreLst.AddRange(GenreQry.Distinct());
            return GenreLst;
        }

        public IQueryable<Movie> GetMoviesByBinder(int binderId)
        {
            var movies = from m in db.Movies
                         where m.BinderId == binderId
                         select m;
            return movies;
        }

        public IQueryable<Movie> GetMoviesByGenre(string movieGenre)
        {
            var movies = from m in db.Movies
                         where m.Genre == movieGenre
                         select m;
            return movies;

        }

        public IQueryable<Movie> GetMoviesBySearchString(string searchString)
        {
            var movies = from m in db.Movies
                         where m.Title.Contains(searchString)
                         select m;
            return movies;
        }

        public Movie ReturnDefaultMovie()
        {
            return new Movie
            {
                Genre = "Comedy",
                Price = 3.99M,
                ReleaseDate = DateTime.Now,
                Rating = "G",
                Title = "Ghotst Busters III"
            };
        }
    }
}
