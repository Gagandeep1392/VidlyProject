using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyNew.DTO;
using VidlyNew.Models;

namespace VidlyNew.Controllers.Api
{
    public class RentalController : ApiController
    {
        ApplicationDbContext m_dbContext;

        public RentalController()
        {
            m_dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (rentalDto.MovieIds.Count == 0)
                return BadRequest("There is no movies");

            var customer = m_dbContext.Customer.SingleOrDefault(c => c.Id == rentalDto.CustomerId);
            if (customer == null)
                return BadRequest("Customer is not valid");

            foreach (int movieId in rentalDto.MovieIds)
            {
                var movie = m_dbContext.Movies.SingleOrDefault(m => m.Id == movieId);
                if (movie != null)
                {
                    if(movie.NumberAvailable == 0)
                        return BadRequest("Movie is not available");

                    movie.NumberAvailable--;

                    Rental objRental = new Rental()
                    {
                        CustomerId = customer.Id,
                        MovieId = movie.Id,
                        DateRented = DateTime.Now
                        
                    };

                    rentalDto.Id = objRental.Id;
                    m_dbContext.Rental.Add(objRental);
                    m_dbContext.SaveChanges();
                }
            }

            return Ok(); //Created(new Uri(Request.RequestUri + "/" + objRental.Id), rentalDto);
        }



    }
}
