using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyNew.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name ="Movie")]
        public int MovieId { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturn { get; set; }
    }
}