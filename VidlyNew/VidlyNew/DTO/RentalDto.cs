using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyNew.DTO
{
    public class RentalDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public List<int> MovieIds { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime DateReturn { get; set; }
    }
}