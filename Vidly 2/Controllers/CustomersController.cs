using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_2.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Vidly_2.Viewmodel;
using AutoMapper;
using Vidly_2.tmp;

namespace Vidly_2.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext db;
        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (User.IsInRole("canmanagemovies"))
                return View("Index");
            else
                return View("ReadOnly");
        }

        public ActionResult New()
        {

            var mem = db.member.ToList();
            var newcus = new NewCustomerMembership
            {
                customer=new tmp.tmpcustomer(),
                memberships = mem
            };
            
            return View(newcus);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewCustomerMembership ncus)
        {

            if (!ModelState.IsValid)
            {
                var cus = new NewCustomerMembership
                {
                    customer = ncus.customer,
                    memberships = db.member.ToList()
                };

                return View("New", cus);
            }
            var tmp = Mapper.Map<tmpcustomer,Customer>(ncus.customer);
            if (ncus.customer.id==0)
                db.customers.Add(tmp);
            else
            {
                var temp = db.customers.Single(c => c.id == ncus.customer.id);
                temp.Name = ncus.customer.Name;
                temp.BirthDate = ncus.customer.BirthDate;
                temp.issubs = ncus.customer.issubs;
                temp.Membershipid = ncus.customer.Membershipid;
                
            }
                db.SaveChanges();
            
            
            return RedirectToAction("Index","Customers");
        }
         
        public ActionResult Edit(int id)
        {
            var custom = db.customers.SingleOrDefault(c=>c.id==id);

            if (custom == null)
                return HttpNotFound();
            var cusvie = new NewCustomerMembership
            {
                customer = Mapper.Map<Customer,tmpcustomer>(custom),
                memberships = db.member.ToList()
            };
            return View("New", cusvie);

        }
        public ActionResult Details(int id)
        {
            var cust = db.customers.Include(c => c.Membership).SingleOrDefault(c =>c.id==id);

            if (cust == null)
                return HttpNotFound();

            return View(cust);
        }
    }
}