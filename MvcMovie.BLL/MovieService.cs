using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcMovie.DAL;
using System.Data.Entity;


namespace MvcMovie.BLL
{
    public class MovieService
    {

        private MovieDBContext db = new MovieDBContext();
        

        public List<string> GetGenereList()
        {

              var GenreLst = new List<string>();
              var GenreQry = from d in db.Movies
                               orderby d.Genre
                               select d.Genre;
               GenreLst.AddRange(GenreQry.Distinct());
               return GenreLst;
            
        }

        public List<int> GetBinderList()
        {

           // var GenreLst = new List<int>();
            var GenreQry = from d in db.Binders
                           orderby d.ID
                           select d.ID;

            return GenreQry.ToList();

        }

        public IQueryable<Movie> GetAllMovies()
        {

            var movies = from m in db.Movies
                         select m;
            return movies; 

        }

        public IQueryable<Movie> GetMoviesBySearchString(string searchString)
        {
            var movies = from m in db.Movies where m.Title.Contains(searchString)
                         select m;
            return movies;

        }

        public IQueryable<Movie> GetMoviesByGenere(string movieGenre)
        {
            var movies = from m in db.Movies
                         where m.Genre== movieGenre
                         select m;
            return movies;

        }

        public IQueryable<Movie> GetMoviesByBinder(int  binderId)
        {
            var movies = from m in db.Movies
                         where m.BinderId == binderId
                         select m;
            return movies;

        }


        public Movie FindMovieById(int? Id)
        {
            var movie = (from m in db.Movies
                         where m.ID == Id
                         select m).FirstOrDefault();
            return movie;

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

        public void AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();

        }

        public void EditMovie(Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteMovie(Movie movie)
        {
            db.Movies.Remove(movie);
            db.SaveChanges();
        }

     
        }
    }

