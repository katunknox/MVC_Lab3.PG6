using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WcfService
{
    public class Service1 : IService1
    {
        static List<JObject> _movies;
        static List<JObject> _actors;
        static List<JObject> _genre;


        public Service1()
        {
            using (WebClient webClient = new WebClient())
            {
                string jsonMovieString = webClient.DownloadString(
                Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cDovL3ByaXZhdC5iYWhuaG9mLnNlL3diNzE0ODI5L2pzb24vbW92aWVzLmpzb24=")));
                _movies = JsonConvert.DeserializeObject<List<JObject>>(jsonMovieString);

                string jsonActString = webClient.DownloadString(
                Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cDovL3ByaXZhdC5iYWhuaG9mLnNlL3diNzE0ODI5L2pzb24vYWN0b3JzLmpzb24=")));
                _actors = JsonConvert.DeserializeObject<List<JObject>>(jsonActString);

                string jsonGenreString = webClient.DownloadString(
                Encoding.UTF8.GetString(Convert.FromBase64String("aHR0cDovL3ByaXZhdC5iYWhuaG9mLnNlL3diNzE0ODI5L2pzb24vZ2VucmUuanNvbg==")));
                _genre = JsonConvert.DeserializeObject<List<JObject>>(jsonGenreString);
            }
        }
        public XElement GetAllMovies()
        {

            XElement Movies = new XElement("Movies");
            foreach (var movie in _movies)   
            {
                XElement Movie = new XElement("Movie",
                    new XElement("Title", movie["Title"].ToString()),
                    new XElement("OriginalTitle", movie["OriginalTitle"].ToString()),
                    new XElement("ReleaseYear", movie["ReleaseYear"]),
                    new XElement("Rating", movie["Rating"]),
                    new XElement("Synopsis", movie["Synopsis"].ToString()));
                                                                       
                //new XElement("Genre", item.Genre),    
                //new XElement("Actors", item.Actors),
                Movies.Add(Movie);

            }
            return Movies;
        }

        public XElement GetTopTenMovies()
        {
            throw new NotImplementedException();
        }
    }
}
