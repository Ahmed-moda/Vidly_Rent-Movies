using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly_2.Models
{
    public class Membership
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int signfree { get; set; }
        public int discounterate { get; set; }
        public int durationmon { get; set; }
        [Required]
        public string Name { get; set; }

    }
}