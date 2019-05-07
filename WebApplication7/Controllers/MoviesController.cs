using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;
using System.Data.Entity;
using WebApplication7.ViewModel;

namespace WebApplication7.Controllers
{
    [RequireHttps]
    
    public class MoviesController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movie = dbContext.Movies.Include(c=>c.Genre).ToList();
            return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movie = dbContext.Movies.Include(c => c.Genre).SingleOrDefault(x => x.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie{ID=1,Name="Kalank", DateAdded=DateTime.Now, DateReleased=Convert.ToDateTime("03-03-2001")},
                new Movie{ID=2, Name="Captain Marvel",DateAdded=DateTime.Now, DateReleased=Convert.ToDateTime("04-03-2001")}
            };
            return movies;
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create()
        {
            MoviesGenreViewModel viewModel = new MoviesGenreViewModel();
            Movie movie = new Movie();
            var Genres = dbContext.Genres.ToList();
            viewModel.Movie = movie;
            viewModel.Genres = Genres;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                dbContext.Movies.Add(movie);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            MoviesGenreViewModel viewModel = new MoviesGenreViewModel();
            Movie Movie = new Movie();
            var Genres = dbContext.Genres.ToList();
            viewModel.Movie = Movie;
            viewModel.Genres = Genres;
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var movie = dbContext.Movies.SingleOrDefault(c => c.ID == Id);
            var genType = dbContext.Genres.ToList();
            MoviesGenreViewModel viewModel = new MoviesGenreViewModel()
            {
                Movie = movie,
                Genres = genType
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            var movietbl = dbContext.Movies.SingleOrDefault(c => c.ID == movie.ID);
            if (movietbl == null)
            {
                return HttpNotFound();
            }
            else
            {
                movietbl.Name = movie.Name;
                movietbl.DateAdded = movie.DateAdded;
                movietbl.DateReleased = movie.DateReleased;
                movietbl.GenreID = movie.GenreID;
                movietbl.Stock = movie.Stock;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Movies");
        }
    }
}