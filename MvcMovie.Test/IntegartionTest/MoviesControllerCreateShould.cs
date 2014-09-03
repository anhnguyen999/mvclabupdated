using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.Test.IntegartionTest
{
    [TestClass]
   public class MoviesControllerCreateShould
    {
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
    }
}
