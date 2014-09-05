using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcMovie.Controllers;
using MvcMovie.Core;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcMovie.Test.UnitTests
{
    [TestClass]
    public class MoviesControllerIndexShould
    {

        [TestMethod]
        public void ReturnAllMoviesGivenEmptyStringParameters()
        {

            //Arange 
            FakeMovieRepository repo = new FakeMovieRepository();
            var moviesController = new MoviesController(repo);

            //Actual
            var result = moviesController.Index(String.Empty, String.Empty, String.Empty) as ViewResult;

            var movies = result.Model as IQueryable<Movie>;

            // Assert
            Assert.AreEqual(1, movies.Count());
            Assert.AreEqual(true, repo.WasGetAllMoviesCalled);

        }

        [TestMethod]
        public void ReturnExpectedMoviesGivenSearchString()
        {
            //Arrange 

            FakeMovieRepository repo = new FakeMovieRepository();
            var moviesController = new MoviesController(repo);


            //Actual
            var result = moviesController.Index(String.Empty, "Rio", String.Empty) as ViewResult;
            var movies = result.Model as IQueryable<Movie>;
            var selectedmovie = (from r in movies where r.Title.Contains("Rio") select r).FirstOrDefault().Title;

            //Assert
            Assert.AreEqual(true, repo.WasGetAllMoviesCalled);
            Assert.AreEqual("Rio", selectedmovie);



        }


        [TestMethod]
        public void ReturnExpectedMoviesGivenGenere()
        {
            //Arrange 

            FakeMovieRepository repo = new FakeMovieRepository();
            var moviesController = new MoviesController(repo);

            //Actual
            var result = moviesController.Index("Comedy", String.Empty, String.Empty) as ViewResult;

            // returning null always :(  on debigging found that calling fake repo function but returning null !
            var movies = result.Model as IQueryable<Movie>;

            // Assert
            Assert.AreEqual(1, movies.Count());
            Assert.AreEqual(true, repo.WasGetAllMoviesCalled);

        }
    }
}
