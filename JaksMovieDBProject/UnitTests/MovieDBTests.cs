using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JaksMovieDBProject.Controllers;

namespace JaksMovieDBProject.UnitTests
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
        public void MakeAPICallToMovieDB()
        {

            var didThisWork = _movieDBController.GetLatestMovies();
            Assert.AreEqual("", didThisWork);
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
        public void GetLatestTitles()
        {

        }

        [TestMethod]
        public void GetNowPlaying()
        {
            MovieDBController _movieDBController = new MovieDBController("");
            var moviesPlayingNow = _movieDBController.GetNowPlaying();

        }
    }
}