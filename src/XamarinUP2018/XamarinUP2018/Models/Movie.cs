using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinUP2018.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview  { get; set; }
        public string Release_date { get; set; }
        public string Vote_average { get; set; }
        public string Poster_path { get; set; }
    }
}
