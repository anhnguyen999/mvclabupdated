using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.Test.IntegartionTest
{
    [TestClass]
   public class MoviesControllerDetailsShould
    {
        //#region Unit Test for Details Action
        //[TestMethod]
        //public void ReturnBadRequestForDetailsWhenIdisNull()
        //{
        //    //Actual 
        //    var result = _moviesController.Details(null);
        //    //Assert
        //    Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        //    var httpResult = result as HttpStatusCodeResult;
        //    Assert.AreEqual(400, httpResult.StatusCode);



        //}

        //[TestMethod]
        //public void ReturnHttpNotFoundForDetailsWhenIdisnotfound()
        //{
        //    //Actual 
        //    var result = _moviesController.Details(78987);
        //    //Assert
        //    Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        //    var httpResult = result as HttpStatusCodeResult;
        //    Assert.AreEqual(404, httpResult.StatusCode);
        //}

        //[TestMethod]
        //public void ReturnMovieForDetailsWhenIdisMatched()
        //{
        //    var result = _moviesController.Details(1) as ViewResult;
        //    var movie = result.Model as Movie;



        //    //Assert
        //    //Assert.AreEqual(expectedMovie.ID, movie.ID);
        //    Assert.AreEqual(expectedMovie.Price, movie.Price);
        //    Assert.AreEqual(expectedMovie.Rating, movie.Rating);
        //    Assert.AreEqual(expectedMovie.Title, movie.Title);
        //    Assert.AreEqual(expectedMovie.Genre, movie.Genre);
        //    Assert.AreEqual(expectedMovie.ReleaseDate, movie.ReleaseDate);

        //}

        //#endregion 
    }
}
