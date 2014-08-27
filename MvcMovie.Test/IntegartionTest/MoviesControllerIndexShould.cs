using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Linq;
using MvcMovie.Controllers;
using MvcMovie.DAL;
using System.Web.Http;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
 
namespace MvcMovie.Tests.IntegrationTest
{
    [TestClass]
    public class MoviesControllerIndexShould
    {
        #region Readonly Global Variables 
        private readonly int MOVIECOUNT = 4;
        private readonly string SELECTEDMOVIENAME = "Rio Bravo";
        private readonly string SEARCHMOVIESTRING = "Rio";
        private readonly string SEARCHMOVIETITLE = "Rio Bravo";
        private MoviesController _moviesController;
        private readonly int MOVIEID = 1;
        private readonly string MOVIEGENERE = "COMEDY";
        private readonly int MOVIECOUNTFORAGENERE = 2; 
        private readonly  Movie expectedMovie = new Movie
        {
            Rating = "PG",
            ID = 1,
            Title = "When Harry Met Sally",
            Price = 7.99M,
            Genre = "Romantic Comedy",
            ReleaseDate = Convert.ToDateTime("1/11/1989 12:00:00 AM")


        };


        #endregion 

        [TestInitialize]
        public void TestSetup()
        {
            //Arrange
            _moviesController = new MoviesController();

        }

        #region Unit Tests for Index Action 
        [TestMethod]
        public void ReturnAllMoviesGivenEmptyStringParameters()
        {
            //Actual 
            var result = _moviesController.Index(String.Empty, String.Empty) as ViewResult;
            var movies = result.Model as IQueryable<Movie>;
             
         
           //Assert 
            Assert.AreEqual(MOVIECOUNT, movies.ToList().Count);
        }

        [TestMethod]
        public void ReturnExpectedMoviesGivenSearchString()
        {
            //Actual 
            var result = _moviesController.Index(String.Empty, SEARCHMOVIESTRING) as ViewResult;
            var movies = result.Model as IQueryable<Movie> ;
            var selectedmovie = (from r in movies where r.Title.Contains(SEARCHMOVIESTRING) select r).FirstOrDefault().Title;

            //Assert
            Assert.AreEqual(SELECTEDMOVIENAME, selectedmovie);

        }

        [TestMethod]
        public void ReturnExpetedMoviesGivenMovieGenere()
        {
            //Actual 
            var result = _moviesController.Index(MOVIEGENERE, String.Empty) as ViewResult;
            var movies = result.Model as IQueryable<Movie>;
           

            //Assert
            Assert.AreEqual(MOVIECOUNTFORAGENERE, movies.ToList().Count);

        }

        [TestMethod]
        public void ReturnExpectedMoviesGivenMoiveGenereAndTitle()
        {
            //Actual 
            var result = _moviesController.Index(MOVIEGENERE, SEARCHMOVIETITLE) as ViewResult;
            var movies = result.Model as IQueryable<Movie>;


            //Assert
            Assert.AreEqual(1, movies.ToList().Count);
        }

        #endregion 

        #region Unit Test for Details Action
        [TestMethod]
        public void ReturnBadRequestForDetailsWhenIdisNull()
        {
            //Actual 
            var result = _moviesController.Details(null);
            //Assert
            Assert.IsInstanceOfType(result,typeof(HttpStatusCodeResult));
            var httpResult = result as HttpStatusCodeResult;
            Assert.AreEqual(400, httpResult.StatusCode);
            
             
           
        }

        [TestMethod]
        public void ReturnHttpNotFoundForDetailsWhenIdisnotfound()
        {
            //Actual 
            var result = _moviesController.Details(78987);
            //Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
            var httpResult = result as HttpStatusCodeResult;
            Assert.AreEqual(404, httpResult.StatusCode);
        }

        [TestMethod]
        public void ReturnMovieForDetailsWhenIdisMatched()
        {
            var result = _moviesController.Details(1) as ViewResult;
            var movie = result.Model as Movie;

           

            //Assert
            //Assert.AreEqual(expectedMovie.ID, movie.ID);
            Assert.AreEqual(expectedMovie.Price, movie.Price);
            Assert.AreEqual(expectedMovie.Rating, movie.Rating);
            Assert.AreEqual(expectedMovie.Title, movie.Title);
            Assert.AreEqual(expectedMovie.Genre, movie.Genre);
            Assert.AreEqual(expectedMovie.ReleaseDate, movie.ReleaseDate);

        }

       #endregion 


        #region Unit Test for Create Action 


        // Not able to test valid ModelState : Need help 
        //[TestMethod]
        //public void AddMovieWhenModelStateisValidAndRedirect()
        //{


        //    var expectedViewName = "Index";
        //    var badMovie = new MvcMovie.Models.Movie () 
        //       {
                   
        //           Title = "DJ", 
        //           Genre = "Comedy",
        //           Price = 3.99M,
        //           Rating = "G", 
        //           ReleaseDate = Convert.ToDateTime("08/25/2014")
        //       };

        //    // Act

        //    // mimic the behaviour of the model binder which is responsible for Validating the Model
        //    var validationContext = new ValidationContext(badMovie, null, null);
        //    var validationResults = new List<ValidationResult>();
        //    TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(MvcMovie.Models.Movie), typeof(MvcMovie.Models.Movie)), typeof(MvcMovie.Models.Movie));
        //    var modelState =  Validator.TryValidateObject(badMovie, validationContext, validationResults, true);
           
        //    //foreach (var validationResult in validationResults)
        //    //{
        //    //    _moviesController.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
        //    //}
            
        //    var result = _moviesController.Create(badMovie) as ViewResult;        
            
        //    // Assert
        //    Assert.IsNotNull(result);
           
        //    Assert.AreEqual(expectedViewName, result.ViewName );
        //}

        #endregion 


        #region Unit Test for Edit Action 

        [TestMethod]
        public void ReturnsBadRequestForEditWhenIdisNull()
        {
            var result = _moviesController.Edit((int?)null);
            //Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
            var httpResult = result as HttpStatusCodeResult;
            Assert.AreEqual(400, httpResult.StatusCode);
        }


        [TestMethod]
        public void ReturnsHttpNotFoundForEditWhenIdisNotFound()
        {
            var result = _moviesController.Details(123456);
            //Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
            var httpResult = result as HttpStatusCodeResult;
            Assert.AreEqual(404, httpResult.StatusCode);
        }

        [TestMethod]
        public void UpdatesandRedirectsForEditWhenModelStateisValid()
        {
            //Implementation goes here 

            
        }

        [TestMethod]
        public void ReloadsViewForEditWhenModelStateisInValid()
        {
            //Implementation goes here


        }


        #endregion 

        #region Unit Test for Delete Action 

        [TestMethod]
        public void ReturnsBadRequestForDeleteWhenIdisNull()
        {
            var result = _moviesController.Delete(MOVIEID);
            //Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
            var httpResult = result as HttpStatusCodeResult;
            Assert.AreEqual(404, httpResult.StatusCode);
        }


        [TestMethod]
        public void ReturnsHttpNotFoundForDeleteWhenIdisNotFound()
        {
            var result = _moviesController.Delete(MOVIEID);
            //Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
            var httpResult = result as HttpStatusCodeResult;
            Assert.AreEqual(400, httpResult.StatusCode);
        }



        #endregion 

    }
}
