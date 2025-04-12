using Microsoft.AspNetCore.Mvc;
using FlixList.Models;

namespace FlixList.Controllers
{
    [Route("Movies")]
    public class MoviesController : Controller
    {
        private static List<Movie> movies = new List<Movie>();

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new Movie());
        }

        [HttpPost("Create")]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movies.Add(movie);
                return RedirectToAction("Index", "Home");
            }
            return View(movie); 
        }

        [HttpGet("Read")]
        public IActionResult Read()
        {
            return View(movies);
        }
    }
}