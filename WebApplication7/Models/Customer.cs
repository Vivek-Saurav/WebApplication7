using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name="Customer Name")]
        public string Name { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        //Referencing The Table
        public MembershipType MembershipType { get; set; }

        //Referencing the column
        [Display(Name = "Membership Type")]
        [Required]
        public int MembershipTypeID { get; set; }
    }
}