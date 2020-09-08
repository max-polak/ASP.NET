using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie(){ Name= "Shrek" };

            var customers = new List<Customer>
            {
                new Customer{ Name = "Customer 1"},
                new Customer{ Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel); // zwraca nowy film

            //return Content("Hello World!"); // Zwraca ciąg znaków
            //return HttpNotFound(); // zwraca 404 Not Found
            //return new EmptyResult(); // zwraca nic
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" }); // przekierowuje na inną strone z parametrami URL
        }

        // GET: Movies/Edit/id
        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        // GET: Movies/
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrEmpty(sortBy))
                sortBy = "name";

            return Content(String.Format("pageIndex={0}, sortBy={1}", pageIndex, sortBy));
        }

        //[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}:range(1,12))}")]
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}