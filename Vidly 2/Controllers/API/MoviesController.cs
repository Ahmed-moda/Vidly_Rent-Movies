using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_2.Models;
using AutoMapper;
using Vidly_2.tmp;
using System.Data.Entity;

namespace Vidly_2.Controllers.API
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext db;

        public MoviesController()
        {
            db = new ApplicationDbContext();
        }
        public IHttpActionResult GetMovies(string query=null)
        {
            var movqur = db.movies.Include(c => c.Genre).Where(m=>m.navailable>0);

            if (!string.IsNullOrWhiteSpace(query))
                movqur = movqur.Where(c => c.Name.Contains(query));
            var mov = movqur
             .ToList()
             .Select(Mapper.Map<Movie, tmpmovie>);
            return Ok(mov);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var mov = db.movies.SingleOrDefault(c => c.id == id);
            if (mov == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, tmpmovie>(mov));
        }

        public IHttpActionResult GetAllMovies()
        {
            var movqur = db.movies.Include(c => c.Genre);
            var mov = movqur
             .ToList()
             .Select(Mapper.Map<Movie, tmpmovie>);
            return Ok(mov);
        }

        public IHttpActionResult RentMovie(int id)
        {
            var mov = db.movies.SingleOrDefault(c => c.id == id);
            if (mov == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, tmpmovie>(mov));
        }

        [HttpPost]
        public IHttpActionResult Createmovie(tmpmovie mov)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var tmp = Mapper.Map<tmpmovie, Movie>(mov);
            db.movies.Add(tmp);
            db.SaveChanges();
            mov.id = tmp.id;
            return Created(new Uri(Request.RequestUri + "/" + tmp.id), mov);
        }

        public IHttpActionResult Updatecustomer(int id, tmpmovie mov)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movdb = db.movies.SingleOrDefault(c => c.id == id);
            if (movdb == null)
                return NotFound();
            Mapper.Map<tmpmovie, Movie>(mov, movdb);
            db.SaveChanges();

            return Ok();

        }

        public IHttpActionResult Deletecustomer(int id)
        {
            var movdb = db.movies.SingleOrDefault(c => c.id == id);
            if (movdb == null)
                return NotFound();
            db.movies.Remove(movdb);
            db.SaveChanges();

            return Ok();
        }
    }

}

