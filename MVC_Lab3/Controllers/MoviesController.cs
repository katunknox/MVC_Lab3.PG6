using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Lab3.Context;
using MVC_Lab3.Models;
using PagedList;
//using MVC_Lab3.ServiceReference1;

namespace MVC_Lab3.Controllers
{
    public class MoviesController : Controller
    {
        private MovieContext db = new MovieContext();
        
        /// <summary>
        /// GET: Movie
        /// </summary>
        /// <param name="page">page number</param>
        /// <param name="Input">user could give search by title, genre, original title, or release year </param>
        /// <returns>ActionResult for View Index</returns>
        public ActionResult Index(int? page ,string Input)
        {
            IPagedList<Movie> pageOfMovies;
            IPagedList<Movie> pageOfFilteredMovies;
            IPagedList<Movie> pageOfFilteredbyYear;

            int pageNumber = page ?? 1;

            int num = -1;
            if(!String.IsNullOrEmpty(Input))
            {
                if (!int.TryParse(Input, out num))
                {
                    IEnumerable<Movie> filteredMovies = (db.Movies.Where(x => x.Title.Contains(Input) ||
                                                 x.OriginalTitle.Contains(Input) ||
                                                 x.Genre.Contains(Input) || Input == null).ToList());
                    
                    pageOfFilteredMovies = filteredMovies.ToPagedList(pageNumber, 10);
                    return View(pageOfFilteredMovies);
                }
                else
                {
                    int year = Convert.ToInt32(Input);
                    IEnumerable<Movie> filteredByYear= (db.Movies.Where(x => x.ReleaseYear == year || Input == null).ToList());
                    
                    pageOfFilteredbyYear = filteredByYear.ToPagedList(pageNumber, 10);
                    return View(pageOfFilteredbyYear);
                }
            }            

            IEnumerable<Movie> allMovies = db.Movies.ToList();
            pageOfMovies = allMovies.ToPagedList(pageNumber, 10);
            return View(pageOfMovies);
        }


        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)//[Bind(Include = "MovieID,Title,OriginalTitle,ReleaseYear,Rating,Synopsis,Genre,Actors")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)//[Bind(Include = "MovieID,Title,OriginalTitle,ReleaseYear,Rating,Synopsis,Genre,Actors")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
