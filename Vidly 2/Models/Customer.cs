using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly_2.Models
{
    public class Customer
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Membership Membership { get; set; }
        public bool issubs { get; set; }

        [Display (Name = "Membership Type")]
        public int Membershipid { get; set; }
       // [age18]
        public DateTime BirthDate { get; set; }
    }
}