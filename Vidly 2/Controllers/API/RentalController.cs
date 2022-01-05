using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_2.Models;
using Vidly_2.Viewmodel;
using AutoMapper;
using Vidly_2.tmp;

namespace Vidly_2.Controllers.API
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext db;

        public RentalController()
        {
            db = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateRental(newrental nr)
        {
            var cust = db.customers.Single(m => m.id == nr.cusid);
            var movies = db.movies.Where(m => nr.movids.Contains(m.id));
            
            foreach(var mo in movies)
            {
                mo.navailable--;
                var rental = new Rental
                {
                    movie = mo,
                    customer = cust,
                    datatake = DateTime.Now
                };
                db.rental.Add(rental);
            }

            db.SaveChanges();
            return Ok();
        }
    }
}
