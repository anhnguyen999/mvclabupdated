using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;
using MvcMovie.BLL;
using MvcMovie.DAL;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private MovieService db = new MovieService();

        // GET: /Movies/
        public ActionResult Index(string movieGenre, string searchString, string BinderList)
        {

            ViewBag.movieGenre = new SelectList(db.GetGenereList());
            ViewBag.BinderList = new SelectList(db.GetBinderList());

            var movies = db.GetAllMovies();

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = db.GetMoviesBySearchString(searchString);
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = db.GetMoviesByGenere(movieGenre);
            }

            if (!string.IsNullOrEmpty(BinderList))
            {
                movies = db.GetMoviesByBinder(Convert.ToInt32(BinderList));
            }
            return View(movies);
        }

        // GET: /Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = db.FindMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: /Movies/Create
        public ActionResult Create()
        {
            return View(db.ReturnDefaultMovie());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price,Rating,BinderId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (db.AddMovie(movie))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(movie);
        }

        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.FindMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: /Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price,Rating,BinderId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (db.EditMovie(movie))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(movie);
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.FindMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.FindMovieById(id);
            db.DeleteMovie(movie);
            return RedirectToAction("Index");
        }


    }
}
