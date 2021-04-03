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
            //{
            //     new Movie
            //     {
            //                Title = "Nyckeln till Frihet",
            //                OriginalTitle = "Shawshank Redemption",
            //                ReleaseYear = 1994,
            //                Rating = 9.2,
            //                Synopsis =
            //                    "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
            //                Genre = "Crime, Drama",
            //                Actors = "Tim Robbins, Morgan Freeman, Bob Gunton"
            //            },
            //            new Movie
            //            {
            //                Title = "Gudfadern",
            //                OriginalTitle = "The Godfather",
            //                ReleaseYear = 1972,
            //                Rating = 9.2,
            //                Synopsis =
            //                    "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
            //                Genre = "Crime, Drama",
            //                Actors = "Marlon Brando, Al Pacino, James Caan"
            //            },
            //            new Movie
            //            {
            //                Title = "Gudfadern del II",
            //                OriginalTitle = "The Godfather: Part II",
            //                ReleaseYear = 1974,
            //                Rating = 9.0,
            //                Synopsis =
            //                    "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
            //                Genre = "Crime, Drama",
            //                Actors = "Al Pacino, Robert De Niro, Robert Duvall"
            //            },
            //            new Movie
            //            {
            //                Title = "The Dark Knight",
            //                OriginalTitle = "The Dark Knight",
            //                ReleaseYear = 2008,
            //                Rating = 9.0,
            //                Synopsis =
            //                    "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham, the Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
            //                Genre = "Action, Crime, Thriller",
            //                Actors = "Christian Bale, Heath Ledger, Aaron Eckhart"
            //            },
            //            new Movie
            //            {
            //                Title = "12 edsvurna män",
            //                OriginalTitle = "12 Angry Men",
            //                ReleaseYear = 1957,
            //                Rating = 8.9,
            //                Synopsis =
            //                    "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.",
            //                Genre = "Crime, Drama",
            //                Actors = "Henry Fonda, Lee J. Cobb, Martin Balsam"
            //            }
            // };
            seededMovies.ForEach(m => context.Movies.Add(m));

            context.SaveChanges();
        }
    }
}