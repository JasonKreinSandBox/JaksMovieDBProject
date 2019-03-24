using JaksMovieDBProject.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace JaksMovieDBProject.Controllers
{
    public class MovieDBController : ApiController
    {
        private static readonly HttpClient httpClient;
        private string _key;
        private string _uri;
        public MovieDBController(string apiKey)
        {
            _key = apiKey;
        }
        //const string movieDBKey = "afe1f2141267461ad56f6b6461e030ab";
        //private string uri = $"https://api.themoviedb.org/3/movie/latest?api_key={movieDBKey}&language=en-US";
        public async Task GetLatestMovies()
        {
            _uri = $"https://api.themoviedb.org/3/movie/latest?api_key={_key}&language=en-US";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(_uri);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Caught Exception: {e}");
                }
            }
        }

        public async Task<MovieDetailsDTO> GetMovieDetails(string movieId)
        {
            _uri = $"https://api.themoviedb.org/3/movie/{movieId}?api_key={_key}&language=en-US";
            var movieDetails = new MovieDetailsDTO();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(_uri);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Caught Exception: {e}");
                }
            }
            return movieDetails;
        }

        public async Task<MovieDetailsDTO> GetNowPlaying()
        {
            _uri = $"https://api.themoviedb.org/3/movie/now_playing?api_key={_key}&language=en-US&page=1";
            var movieDetails = new MovieDetailsDTO();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(_uri);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Caught Exception: {e}");
                }
            }

            return movieDetails;
        }
        //public List<string> GetList()
        //{
        //    using (var client = new HttpResponseMessage())
        //    {
        //        var url = new Uri("https://api.themoviedb.org/3/movie/550?api_key={_key}");

        //    }
        //        return new List<string>() { "My", "Test" };
        //}
    }
}