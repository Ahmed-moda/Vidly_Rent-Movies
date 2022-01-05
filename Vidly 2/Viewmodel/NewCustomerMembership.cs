using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_2.Models;
using Vidly_2.tmp;

namespace Vidly_2.Viewmodel
{
    public class NewCustomerMembership
    {
        public List<Membership> memberships { get; set; }
        public tmpcustomer customer { get; set; }
    }
}