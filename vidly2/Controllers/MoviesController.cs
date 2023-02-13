using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly2.Models;
using vidly2.ViewModels;

namespace vidly2.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context { get; set; }
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            //this method is to dispose dbcontext
        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieGenreViewModel(movie)
            {
                Genres =_context.Genres.ToList()
            };
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieGenreViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id==0)
                _context.Movies.Add(movie);
             else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");

        }
       
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieGenreViewModel
            {
               
                Genres = genres
            };
            return View("MovieForm",viewModel); 
        }

        public ActionResult Index()
        {
            // var movies = GetMovies();
            var movies = _context.Movies.Include(m=>m.Genre).ToList();
           
            return View(movies);

        }

        public ActionResult Details(int id)
        {

            var movieTotalRow = _context.Movies.Include(mbox=>mbox.Genre).SingleOrDefault(m => m.Id == id);


            if (movieTotalRow == null)
                return HttpNotFound();

            // return Content(String.Format("{0}{1}{2}{3}{4}", movieTotalRow.Name, movieTotalRow.Genre.Name, movieTotalRow.ReleaseDate, movieTotalRow.DateAdded, movieTotalRow.NumberInStock));
            // <a href=/Movies/Details/@movie.Id>@movie.Name</a>
            // @Html.ActionLink(movie.Name,"Details","Movies",new { id = movie.Id },null)
            return View(movieTotalRow);
        }

        public ActionResult Random()
        {
            Movie movie = new Movie { Name = "Shrek!" };
            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
               new Movie { Id=1,Name="Shrek"},
               new Movie {Id=2,Name="Wall-e" }
            };
        }
    }
}
 