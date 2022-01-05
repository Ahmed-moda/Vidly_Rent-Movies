using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Vidly_2.Models
{
    public class Movie
    {

        public int id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime timeadd { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        public int Genreid { get; set; }
        [Display(Name = "Release Date")]
        public DateTime releasedate { get; set; }
        [Display(Name="Number in Stock")]
        [Range(1,20)]
        public int nstok { get; set; }

        public int navailable { get; set; }

    }
}