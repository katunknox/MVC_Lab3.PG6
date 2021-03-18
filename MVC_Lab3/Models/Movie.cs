using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MVC_Lab3.Models
{
    public class Movie
    {
        public int MovieID { get; set; }


        string title;
        string originalTitle;
        int releaseYear;
        double rating;
        string synopsis;
        string genre;
        string actors;
        // List<string> genre;
        // List<string> actors;
        //int MovieID;

        public string Title 
        {
            get { return title; }
            set { title = value; }
        }
        public string OriginalTitle
        {
            get { return originalTitle; }
            set { originalTitle = value; }
        }
        public int ReleaseYear 
        {
            get { return releaseYear; }
            set { releaseYear = value; }
        }
        public double Rating 
        {
            get { return rating; }
            set { rating = value; }
        }
        public string Synopsis
        {
            get { return synopsis; }
            set { synopsis = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public string Actors
        {
            get { return actors; }
            set { actors = value; }
        }



    }
}