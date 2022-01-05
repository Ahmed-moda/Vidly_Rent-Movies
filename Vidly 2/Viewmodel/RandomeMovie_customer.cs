using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_2.Models;

namespace Vidly_2.Viewmodel
{
    public class RandomeMovie_customer
    {
        public Movie movie { get; set; }
        public List<Movie> movies { get; set; }
        public List<Customer> customers { get; set; }
    }
}