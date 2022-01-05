using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_2.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly_2.Models
{
    public class Rental
    {
        public int id { get; set; }
        [Required]
        public Customer customer { get; set; }
        [Required]
        public Movie movie { get; set; }
        public DateTime datatake { get; set; }
        public DateTime? datareturn { get; set; }


    }
}