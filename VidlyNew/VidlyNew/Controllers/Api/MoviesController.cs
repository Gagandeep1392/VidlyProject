using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyNew.DTO;
using VidlyNew.Models;
using System.Data.Entity;

namespace VidlyNew.Controllers.Api
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext m_dbContext;

        public MoviesController()
        {
            m_dbContext = new Models.ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<MoviedDto> GetMovie(string query = null)
        {
            var objMoviesQuery = m_dbContext.Movies.Include(m => m.GenreType).Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrEmpty(query))
                objMoviesQuery = objMoviesQuery.Where(m => m.Name.Contains(query));

            return objMoviesQuery.ToList().Select(Mapper.Map<Movie, MoviedDto>);
        }


        public IHttpActionResult GetMovie(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieinDb = m_dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movieinDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MoviedDto>(movieinDb));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MoviedDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MoviedDto, Movie>(movieDto);
            m_dbContext.Movies.Add(movie);
            m_dbContext.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(Request.RequestUri +"/"+ movie.Id,movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,MoviedDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieinDb = m_dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movieinDb == null)
                return NotFound();

            var mov = Mapper.Map<MoviedDto, Movie>(movieDto, movieinDb);
            m_dbContext.SaveChanges();

            return Ok(mov);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieinDb = m_dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movieinDb == null)
                return NotFound();

            m_dbContext.Movies.Remove(movieinDb);
            m_dbContext.SaveChanges();

            return Ok(Mapper.Map<Movie, MoviedDto>(movieinDb));
        }


    }
}
