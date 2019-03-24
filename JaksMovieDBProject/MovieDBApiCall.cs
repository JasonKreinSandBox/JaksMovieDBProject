using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace JaksMovieDBProject
{
    public class MovieDBApiCall
    {
        private string _uri;
        public MovieDBApiCall()
        {

        }
        public async Task<MovieDetailsDTO> CallMovieDBApi(string uri)
        {
            _uri = uri;
            var movieData = new MovieDetailsDTO();
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(_uri);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var jsonData = JsonConvert.DeserializeObject(responseBody);
                    var jsonMovieDetails = JsonConvert.DeserializeObject<MovieDetailsDTO>(responseBody);
                    return movieData;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Caught Exception: {e}");
                }
            }
            return movieData;
        }
    }
}