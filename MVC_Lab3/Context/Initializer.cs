using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Xml.Linq;
using MVC_Lab3.Models;
using MVC_Lab3.ServiceReference1;


namespace MVC_Lab3.Context
{
    public class Initializer : DropCreateDatabaseAlways<MovieContext>
    {
        Service1Client cliobj = new Service1Client();
        protected override void Seed(MovieContext context)
        {
            var seededMovies = new List<Movie>();
            XElement movies = cliobj.GetAllMovies();
            Movie mov = new Movie();

            //for each movie in the xml file "movies"
            //convert to an object of type "Movie" and add to seededMovies.
            foreach (var movie in movies.Elements("Movie"))
            {
                seededMovies.Add(mov.XMLtoMovieObj(movie));            
            }
            
            seededMovies.ForEach(m => context.Movies.Add(m));

            context.SaveChanges();
        }
    }
}