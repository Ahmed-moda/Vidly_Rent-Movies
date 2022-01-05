using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_2.Models;
using Vidly_2.Viewmodel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext db;
       
        public MoviesController()
        {
            db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        public ActionResult Index()
        {
            if (User.IsInRole("canmanagemovies"))
                return View("Index");
            else
                return View("ReadOnly");

        }
        [Authorize (Roles ="canmanagemovies")]
        public ActionResult Edit(int id)
        {
            var movies = db.movies.Single(m => m.id==id);

            if (movies == null)
                return HttpNotFound();
            var mogn = new moviegenre
            {
                movie = movies,
                genre = db.Genre.ToList()
            };
            return View("mov_form", mogn);
        }
        [Authorize(Roles = "canmanagemovies")]
        public ActionResult Save(moviegenre mov)

        {
            if (!ModelState.IsValid)
            {
                var move = new moviegenre
                {
                    movie = mov.movie,
                    genre = db.Genre.ToList()
                    };

                    return View("mov_form",move);
            }

            var movie = mov.movie;
            if (mov.movie.id == 0)
            {
                movie.timeadd = DateTime.Now;
                movie.navailable = movie.nstok;

                db.movies.Add(movie);   
            }
            db.SaveChanges();

            return RedirectToAction("Index","Movies");
        }
        [Authorize(Roles = "canmanagemovies")]
        public ActionResult mov_form()
        {
            var movgen = new moviegenre
            {
                movie = new Movie(),
     
                genre = db.Genre.ToList()
            };
            movgen.movie.nstok = 0;

            return View(movgen);
        }
        public ActionResult Randome()
        {
            var movie = new Movie() { Name = "Moda !" };
            var customers = new List<Customer> {
               new Customer {Name="customer 1" },
            new Customer { Name = "customer 2" }
            };

            var viewmodel = new RandomeMovie_customer
            {
                movie = movie,
                customers = customers
            };
            return View(viewmodel);
        }

        
        public ActionResult Details(int id)
        {

            var mov = db.movies.SingleOrDefault(m=>m.id==id);
            return View(mov);

        }


    }
}