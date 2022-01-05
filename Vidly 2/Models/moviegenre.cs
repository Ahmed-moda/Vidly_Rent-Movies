using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly_2.Models
{
    public class moviegenre
    {
        public List<Genre> genre { get; set; }
        public Movie movie { get; set; }
    }
}