using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly_2.Models
{
    public class Genre
    {
        public int id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}