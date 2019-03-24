using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaksMovieDBProject
{
    public class MovieDetailsDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string TagLine { get; set; }
        public int ReleaseDate { get; set; }
        public string Status { get; set; }
        public string OverView { get; set; }
        public int RunTime { get; set; }
        public int IMDBId { get; set; }
    }
}