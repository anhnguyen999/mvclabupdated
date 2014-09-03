using MvcMovie.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.Test.UnitTest
{
   public class FakeMovieRepository : IMovieRepository
    {
       
            public bool WasGetAllMoviesCalled { private set; get; }
            public bool WasGetMoviesBySearchStringCalled  { get; private set; }
            
             public bool WasGetMoviesByGenereCalled { get; private set;}

          


            public IQueryable<Movie> GetAllMovies()
            {
                WasGetAllMoviesCalled = true;
                List<Movie> lstMovies = new List<Movie>
                    {
                        new Movie
                        {
                            Rating = "PG",
                            ID = 1,
                            Title = "When Harry Met Sally",
                            Price = 7.99M,
                            Genre = "Romantic Comedy",
                            ReleaseDate = Convert.ToDateTime("1/11/1989 12:00:00 AM")
                        }
                    };

                return lstMovies.AsQueryable();
            }



            public IQueryable<Movie> GetMoviesBySearchString(string searchString)
            {
                WasGetMoviesBySearchStringCalled = true;
                if (searchString.Length > 0)
                {
                    List<Movie> lstMovie = new List<Movie>()
                   {
                      new Movie
                      {  
                          BinderId=1,
                          Genre="Comedy",
                          ID=1,Price= 3.4M,
                          Rating="A",
                          ReleaseDate=Convert.ToDateTime("1/11/1989 12:00:00 AM"),
                          Title="Rio"
                      }
                   };
                    return lstMovie.AsQueryable();
                }
                else
                {
                    return null; 
                }
            }


            public IQueryable<Movie> GetMoviesByGenere(string movieGenre)
            {

                WasGetMoviesByGenereCalled = true;
                if (movieGenre == "Comedy")
                {
                    List<Movie> lstMovie = new List<Movie>()
                   {
                      new Movie
                      {  
                          BinderId=1,
                          Genre="Comedy",
                          ID=1,Price= 3.4M,
                          Rating="A",
                          ReleaseDate=Convert.ToDateTime("1/11/1989 12:00:00 AM"),
                          Title="Rio"
                      }
                   };
                    return lstMovie.AsQueryable();
                }
                else
                {
                    return null;
                }


            }


            public bool AddMovie(Movie movie)
            {
                return true;
            }

            public void DeleteMovie(Movie movie)
            {

            }

            public bool EditMovie(Movie movie)
            {
                return false;
            }

            public Movie FindMovieById(int? Id)
            {
                Movie m = new Movie { BinderId = 1, Genre = "Comedy", ID = 1, Price = 3.4M, Rating = "A", ReleaseDate = Convert.ToDateTime("1/11/1989 12:00:00 AM"), Title = "Hello" };
                return m;
            }




            public List<int> GetBinderList()
            {
                List<int> lstInt = new List<int>()
           {
               1,2,3
           };
                return lstInt;
            }

            public List<string> GetGenereList()
            {
                List<string> lstInt = new List<string>()
           {
               "a1","a2","a3"
           };
                return lstInt;
            }

            public IQueryable<Movie> GetMoviesByBinder(int binderId)
            {
                List<Movie> lstMovie = new List<Movie>()
            {
               new Movie{BinderId=1,Genre="Comedy",ID=1,Price= 3.4M,Rating="A",ReleaseDate=Convert.ToDateTime("1/11/1989 12:00:00 AM"),Title="Hello"}
            };
                return lstMovie as IQueryable<Movie>;
            }

           
       

            public Movie ReturnDefaultMovie()
            {
                Movie m = new Movie { BinderId = 1, Genre = "Comedy", ID = 1, Price = 3.4M, Rating = "A", ReleaseDate = Convert.ToDateTime("1/11/1989 12:00:00 AM"), Title = "Hello" };
                return m;
            }
        }
    }
