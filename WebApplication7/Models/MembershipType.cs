using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class MembershipType
    {
        public int ID { get; set; }
        public string MembershipTypeName { get; set; }
        public float Amount { get; set; }
        public int DurationInMonth { get; set; }
        public float Discount { get; set; }
    }
}