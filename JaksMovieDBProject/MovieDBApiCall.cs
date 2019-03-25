﻿using System;
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