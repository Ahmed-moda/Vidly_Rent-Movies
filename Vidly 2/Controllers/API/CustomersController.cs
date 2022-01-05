using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_2.Models;
using Vidly_2.tmp;
using AutoMapper;
using System.Data.Entity;
namespace Vidly_2.Controllers.API
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext db;

        public CustomersController()
        {
            db = new ApplicationDbContext();
        }
        public IHttpActionResult GetCustomers(string query=null)
        {

            var cusqur = db.customers.Include(c => c.Membership);

            if (!string.IsNullOrWhiteSpace(query))
                cusqur = cusqur.Where(c => c.Name.Contains(query));
            var cus =cusqur
             .ToList()
             .Select(Mapper.Map<Customer, tmpcustomer>);
            return Ok(cus);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var cus = db.customers.SingleOrDefault(c => c.id == id);
            if (cus == null)
                return NotFound();
            return Ok(Mapper.Map<Customer,tmpcustomer>(cus));
        }

        [HttpPost]
        public IHttpActionResult Createcustomer(tmpcustomer cus)
        {
            if (!ModelState.IsValid)
                return NotFound();
            var tmp = Mapper.Map<tmpcustomer, Customer>(cus);
            db.customers.Add(tmp);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Updatecustomer(int id, tmpcustomer cus)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cusdb = db.customers.SingleOrDefault(c => c.id == id);
            if (cusdb == null)
                return NotFound();
            Mapper.Map<tmpcustomer, Customer>(cus,cusdb);
            db.SaveChanges();

            return Ok();

        }

        public IHttpActionResult Deletecustomer(int id)
        {
            var cusdb = db.customers.SingleOrDefault(c => c.id == id);
            if (cusdb == null)
                return NotFound();
            db.customers.Remove(cusdb);
            db.SaveChanges();

            return Ok();
        }
    }
}
