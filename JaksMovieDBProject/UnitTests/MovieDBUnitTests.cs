using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using NUnit.Framework;
using JaksMovieDBProject.Controllers;

namespace JaksMovieDBProject.UnitTests
{
    [TestFixture]
    public class MovieDBUnitTests
    {
        [TestCase]
        public void MakeAPICallToMovieDB()
        {
            MovieDBController _movieDBController = new MovieDBController("");
            var didThisWork = _movieDBController.GetLatestMovies();
            Assert.AreEqual("", didThisWork);
        }

        [TestCase]
        public void GetMovieDetails(int movieId)
        {

        }

        [TestCase]
        public void GetReleaseDates(int movieId)
        {

        }
        [TestCase]
        public void GetLatestTitles()
        {

        }

        [TestCase]
        public void GetNowPlaying()
        {
            MovieDBController _movieDBController = new MovieDBController("");
            var moviesPlayingNow = _movieDBController.GetNowPlaying();

        }
    }
}