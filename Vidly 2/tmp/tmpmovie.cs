using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly_2.tmp
{
    public class tmpmovie
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime timeadd { get; set; }
        
        public int Genreid { get; set; }
        public tmpgenre Genre { get; set; }

        public DateTime releasedate { get; set; }
        
        [Range(1, 20)]
        public int nstok { get; set; }

    }
}