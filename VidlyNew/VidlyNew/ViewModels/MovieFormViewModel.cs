﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyNew.Models;

namespace VidlyNew.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreType> GenreType { get; set; }
        public Movie Movie { get; set; }
        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}