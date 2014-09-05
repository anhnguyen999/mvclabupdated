using System;
using System.Web.Mvc;
using System.Linq;
using MvcMovie.Controllers;
using MvcMovie.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MvcMovie.Tests.IntegrationTest
{
    [TestClass]
    public class MoviesControllerIndexShould
    {
        private readonly int MOVIECOUNT = 4;
        private readonly string SELECTEDMOVIENAME = "Rio Bravo";
        private readonly string SEARCHMOVIESTRING = "Rio";
        private readonly string SEARCHMOVIETITLE = "Rio Bravo";
        private MoviesController _moviesController;
        private IMovieRepository _movieRepositry;
        private readonly string MOVIEGENERE = "COMEDY";
        private readonly int MOVIECOUNTFORAGENERE = 2;

        [TestInitialize]
        public void TestSetup()
        {
            //Arrange

            _moviesController = new MoviesController(_movieRepositry);

        }

        [TestMethod]
        public void ReturnAllMoviesGivenEmptyStringParameters()
        {

            //Actual
            var result = _moviesController.Index(String.Empty, String.Empty, String.Empty) as ViewResult;
            var movies = result.Model as IQueryable<Movie>;

            // Assert
            Assert.AreEqual(MOVIECOUNT, movies.Count());


        }

        //  [TestMethod]
        public void ReturnExpectedMoviesGivenSearchString()
        {
            //Actual 
            var result = _moviesController.Index(String.Empty, SEARCHMOVIESTRING, String.Empty) as ViewResult;
            var movies = result.Model as IQueryable<Movie>;
            var selectedmovie = (from r in movies where r.Title.Contains(SEARCHMOVIESTRING) select r).FirstOrDefault().Title;

            //Assert
            Assert.AreEqual(SELECTEDMOVIENAME, selectedmovie);
        }

        //  [TestMethod]
        public void ReturnExpetedMoviesGivenMovieGenere()
        {
            //Actual 
            var result = _moviesController.Index(MOVIEGENERE, String.Empty, String.Empty) as ViewResult;
            var movies = result.Model as IQueryable<Movie>;
            //Assert
            Assert.AreEqual(MOVIECOUNTFORAGENERE, movies.ToList().Count);

        }

        // [TestMethod]
        public void ReturnExpectedMoviesGivenMoiveGenereAndTitle()
        {
            //Actual 
            var result = _moviesController.Index(MOVIEGENERE, SEARCHMOVIETITLE, String.Empty) as ViewResult;
            var movies = result.Model as IQueryable<Movie>;
            //Assert
            Assert.AreEqual(1, movies.ToList().Count);
        }

    }
}
