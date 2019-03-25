using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JaksMovieDBProject
{
  public class MovieDBApiCall
  {
    private string _uri;
    HttpResponseMessage _response;
    public MovieDBApiCall()
    {
      _response = new HttpResponseMessage();
    }
    public async Task<MovieDetailsDTO> CallMovieDBApi(string uri)
    {
      _uri = uri;
      var movieData = new MovieDetailsDTO();
      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
        try
        {
          _response = await client.GetAsync(_uri);
          _response.EnsureSuccessStatusCode();
          string responseBody = await _response.Content.ReadAsStringAsync();
          movieData = JsonConvert.DeserializeObject<MovieDetailsDTO>(responseBody);
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