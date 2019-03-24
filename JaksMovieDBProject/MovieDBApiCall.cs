using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace JaksMovieDBProject
{
    public class MovieDBApiCall
    {
        private string _uri;
        public MovieDBApiCall()
        {

        }
        public async Task CallMovieDBApi(string uri)
        {
            _uri = uri;
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
    }
}