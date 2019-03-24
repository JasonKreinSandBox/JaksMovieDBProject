using JaksMovieDBProject.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Net.Http.Headers;

namespace JaksMovieDBProject.Controllers
{
    public class MovieDBController : ApiController
    {
        private string _key;
        private string _uri;
        MovieDBApiCall _movieDbApiCall;
        public MovieDBController(string apiKey)
        {
            _key = apiKey;
        }

        public async Task GetLatestMovies()
        {
            _uri = $"https://api.themoviedb.org/3/movie/latest?api_key={_key}&language=en-US";

            var detailLatest = await _movieDbApiCall.CallMovieDBApi(_uri);
        }

        public async Task<MovieDetailsDTO> GetMovieDetails(string movieId)
        {
            _uri = $"https://api.themoviedb.org/3/movie/{movieId}?api_key={_key}&language=en-US";
            var movieDetailsForId = new MovieDetailsDTO();
            var detail = await _movieDbApiCall.CallMovieDBApi(_uri);
            return movieDetailsForId;
        }

        public async Task<MovieDetailsDTO> GetNowPlaying()
        {
            _uri = $"https://api.themoviedb.org/3/movie/now_playing?api_key={_key}&language=en-US&page=1";
            var movieDetailsNowPlaying = new MovieDetailsDTO();
            await _movieDbApiCall.CallMovieDBApi(_uri);

            return movieDetailsNowPlaying;
        }

    }
}