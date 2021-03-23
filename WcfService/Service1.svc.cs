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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static List<JObject> _movies;
        static List<JObject> _actors;
        static List<JObject> _genre;



        public Service1()
        {
            //Connects to the API and converts the collected data from json to XElements.
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
            //skap nytt xelement med nu rot nod t.ex movies
            //för varje movie i _movies skapa nytt exeleemt(//jobject in vår lista skapa nytt movi som läggs till under rotnooden )
            //movie onject 
            //add() nytt  utanför loopen
            foreach (var item in _movies)   //item = en jobject, en film i _movies
            {
                XElement Movie = new XElement("Movies",
                    new XElement("Title", item["Title"])); 
                    //new XElement("OriginalTitle", item.OriginalTitle),
                    //new XElement("ReleaseYear", item.ReleaseYear),
                    //new XElement("Rating", item.Rating),
                    //new XElement("Synopsis", item.Synopsis)

                    //new XElement("Genre", item.Genre),
                    //new XElement("Actors", item.Actors),
            }

           throw new NotImplementedException();
        }

        public XElement GetTopTenMovies()
        {
            throw new NotImplementedException();
        }
        // för varje t.ex movie i listan jobject
        //public XElement(Movie movie)
        //{

        //}
    }
}
