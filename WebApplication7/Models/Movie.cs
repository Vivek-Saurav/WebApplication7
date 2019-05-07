using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateReleased { get; set; }
        public int Stock { get; set; }

        public Genre Genre { get; set; }
        public int GenreID { get; set; }
    }
}