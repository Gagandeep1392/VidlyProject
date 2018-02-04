using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using VidlyNew.ViewModels;
using System.Data.Entity;

namespace VidlyNew.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext m_dbContext;

        public MoviesController()
        {
            m_dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            // var objMovies = m_dbContext.Movies.Include(c => c.GenreType).ToList();

            if (User.IsInRole(RoleNames.CanManageMovies))
                return View("Index");

            return View("ReadOnlyView");
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Details(int id)
        {
            var objMovies = m_dbContext.Movies.Include(c => c.GenreType).ToList();
            var objMovie = objMovies.SingleOrDefault(item => item.Id == id);
            return View(objMovie);
        }

        [Authorize(Roles =RoleNames.CanManageMovies)]
        public ActionResult Add()
        {
            Movie objNewMovie = new Movie();

            MovieFormViewModel objView = new MovieFormViewModel()
            {
                GenreType = m_dbContext.GenreType.ToList(),
                Movie = objNewMovie
            };

            return View("MovieForm",objView);
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Update(int Id)
        {
            var objMovieInDb = m_dbContext.Movies.Single(m => m.Id == Id);

            if (objMovieInDb == null)
                return Content("There is no entry in database for this movie.");

            var newMovieFormViewModel = new MovieFormViewModel
            {
                Movie = objMovieInDb,
                GenreType = m_dbContext.GenreType.ToList()
            };

            m_dbContext.SaveChanges();
            return View("MovieForm", newMovieFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var MoviwView = new MovieFormViewModel()
                {
                    Movie = movie,
                    GenreType = m_dbContext.GenreType.ToList()
                };

                return View("MovieForm", MoviwView);
            }

            if (movie.Id == 0)
                m_dbContext.Movies.Add(movie);
            else
            {
                var objMovieInDb = m_dbContext.Movies.Single(m => m.Id == movie.Id);
                if(objMovieInDb == null)
                    return Content("There is no entry in database for this movie.");
                else
                {
                    objMovieInDb.Id = movie.Id;
                    objMovieInDb.Name = movie.Name;
                    objMovieInDb.ReleaseDate = movie.ReleaseDate;
                    objMovieInDb.NumberInStock = movie.NumberInStock;
                    objMovieInDb.GenreTypeId = movie.GenreTypeId;
                }
            }
            m_dbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        private object GetMovies()
        {
            return new List<Movie>
            {
                new Movie{Id = 100,Name = "Lord of the Ring" },
                new Movie{Id = 200,Name = "Shrek" }
            };
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movies = new Movie() { Name = "Shrek" };

            Customer obj1 = new Customer() { Name = "Customer1" };
            Customer obj2 = new Customer() { Name = "Customer2" };

            List<Customer> lstCust = new List<Customer>();
            lstCust.Add(obj1);
            lstCust.Add(obj2);

            RandomMovieViewModel objRandomMovieViewModel = new RandomMovieViewModel();
            {
                objRandomMovieViewModel.Movie = movies;
                objRandomMovieViewModel.Customers = lstCust;
            }

            return View(objRandomMovieViewModel);
        }

        public ActionResult Edit(int iMovieId)
        {
            return Content("id =" + iMovieId);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" + month);
        }
    }
}