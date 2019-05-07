using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.ViewModel
{
    public class CustomerMembershipViewModel
    {
        public Customer Customer { get; set; }
        public List<MembershipType> MembershipTypes { get; set; }
    }
}