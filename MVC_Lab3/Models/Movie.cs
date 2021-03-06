using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MVC_Lab3.Models
{
    /// <summary>
    /// Model class for Movie.
    /// </summary>
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
        ///<summary>
        ///Converts given movie from XElement to Movie.
        ///</summary>
        ///<param name="movie"></param>
        ///<returns>movie object of type Movie</returns>
        public Movie XMLtoMovieObj(XElement movie)
        {
            string genres = "";
            string actors = "";

            Movie movieobj = new Movie();
            movieobj.Title = movie.Element("Title").Value;
            movieobj.OriginalTitle = movie.Element("OriginalTitle").Value;
            movieobj.ReleaseYear = Convert.ToInt32(movie.Element("ReleaseYear").Value);
            movieobj.Rating = Convert.ToDouble(movie.Element("Rating").Value);
            movieobj.Synopsis = movie.Element("Synopsis").Value;
            
            foreach (var item in movie.Elements("Genres").Elements())
            {
                genres += item.Value.ToString() + ", ";
            }
            foreach (var item in movie.Elements("Actors").Elements())
            {
                actors += item.Value.ToString() + ", ";
            }
            //To remove the last comma and space, ", " 
            genres = genres.Remove(genres.Length - 2);
            actors = actors.Remove(actors.Length - 2);

            movieobj.Genre = genres;
            movieobj.Actors = actors;

            return movieobj;
        }
    }
}