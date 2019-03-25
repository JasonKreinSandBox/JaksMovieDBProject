using JaksMovieDBProject.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JaksMovieDBProject.Tests
{
  [TestClass]
  public class MovieDBTests
  {
    MovieDBController _movieDBController;
    string movieDBApiKey = "afe1f2141267461ad56f6b6461e030ab";

    [TestInitialize]
    public void MDBInit()
    {
      _movieDBController = new MovieDBController(movieDBApiKey);
    }

    [TestMethod]
    public void GetMovieDetailsById(int id)
    {
      var details = _movieDBController.GetMovieDetails("166428");
      Assert.IsNotNull(details);
    }

    [TestMethod]
    public void GetNowPlaying()
    {
      var moviesPlayingNow = _movieDBController.GetNowPlaying();
      Assert.IsNotNull(moviesPlayingNow);
    }

    [TestMethod]
    public void MakeAPICallToMovieDB()
    {
      var upcomingTitles = _movieDBController.GetUpcomingMovieDetail();
      Assert.IsNotNull(upcomingTitles);
    }

    [TestMethod]
    public void GetMovieDetails(int movieId)
    {
      //TODO: This test would call the api and select just a single movie with the id of the movie from the site.
      //Because this test is just validating the call for a single id, if the test returns details it passes.
    }

    [TestMethod]
    public void FailToGetMovieDetailsForBadID(int movieId)
    {
      //TODO: This test would make the call with an invalid Id and ensure it fails elegantly. In this case expecting
      //an error code from the api call. Handle the code properly.
    }

    [TestMethod]
    public void GetReleaseDates(int movieId)
    {
      //TODO: Given a good ID, ensure the api call returns json data for release dates for movie, would want to ensure we
      //know the movie requested dates for so we could validate in returned correct data. Fail test for error code or exception
    }


    [TestMethod]
    public void GetReleaseDatesFail(int movieId)
    {
      //TODO: Given a bad ID, ensure the api call returns proper error code and code and exception are handled.
    }

    [TestMethod]
    public void GetLatestTitles()
    {
      //TODO: Make the API and make sure data is returned succesfully
    }

    [TestMethod]
    public void GetLatestTitlesErrorHandling()
    {
      //TODO: Make the API and make sure error code and exception handling are successfully elegant.
    }

  }
}