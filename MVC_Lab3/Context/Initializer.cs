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
            XElement top = cliobj.GetTopTenMovies();    //för att testa om den funkar. DELETE innan inlämning
            Movie mov = new Movie();

            foreach (var item in movies.Elements("Movie"))
            {
                seededMovies.Add(mov.XMLtoMovieObj(item));
            
            }
            
            seededMovies.ForEach(m => context.Movies.Add(m));

            context.SaveChanges();
        }
    }
}