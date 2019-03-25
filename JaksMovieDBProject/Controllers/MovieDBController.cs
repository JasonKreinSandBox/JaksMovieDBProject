using System;
using System.Threading.Tasks;
using System.Web.Http;

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
      _movieDbApiCall = new MovieDBApiCall();
    }

    public async Task<MovieDetailsDTO> GetLatestMovies()
    {
      _uri = $"movie/latest?api_key={_key}&language=en-US";
      var detailLatest = new MovieDetailsDTO();
      try
      {
        detailLatest = await _movieDbApiCall.CallMovieDBApi(_uri);
      }
      catch
      {
        Console.WriteLine("Exception trying to retrieve data");
      }
      return detailLatest;
    }

    public async Task<MovieDetailsDTO> GetMovieDetails(string movieId)
    {
      _uri = $"movie/{movieId}?api_key={_key}&language=en-US";
      var movieDetailsForId = new MovieDetailsDTO();
      try
      {
        movieDetailsForId = await _movieDbApiCall.CallMovieDBApi(_uri);
      }
      catch
      {
        Console.WriteLine("Exception trying to retrieve data");
      }
      return movieDetailsForId;
    }

    public async Task<MovieDetailsDTO> GetNowPlaying()
    {
      _uri = $"movie/now_playing?api_key={_key}&language=en-US&page=1";
      var movieDetailsNowPlaying = new MovieDetailsDTO();
      try
      {
        movieDetailsNowPlaying = await _movieDbApiCall.CallMovieDBApi(_uri);
      }
      catch
      {
        Console.WriteLine("Exception Trying to get data");
      }

      return movieDetailsNowPlaying;
    }

    public async Task<MovieDetailsDTO> GetUpcomingMovieDetail()
    {
      _uri = "upcoming?api_key={_key}&language=en-US&page=1";

      var movieDetailsUpcomingTitles = new MovieDetailsDTO();
      try
      {
        movieDetailsUpcomingTitles = await _movieDbApiCall.CallMovieDBApi(_uri);
      }
      catch
      {
        Console.WriteLine("Exception trying to get data");
      }
      return movieDetailsUpcomingTitles;
    }

  }
}