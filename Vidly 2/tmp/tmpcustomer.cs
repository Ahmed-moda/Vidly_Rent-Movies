using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly_2.Models;

namespace Vidly_2.tmp
{
    public class tmpcustomer
    {

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool issubs { get; set; }
        public int Membershipid { get; set; }

        public tmpmembership Membership { get; set; }
       // [age18]
        public DateTime BirthDate { get; set; }

    }
}