using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyNew.Models;

namespace VidlyNew.DTO
{
    public class MoviedDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        //[NumberofStockValidation]
        public int NumberInStock { get; set; }

        public GenreTypeDto GenreType { get; set; }

        [Required]
        public byte GenreTypeId { get; set; }

    }
}