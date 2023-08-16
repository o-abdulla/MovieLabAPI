using Microsoft.AspNetCore.Mvc;
using OMDB_API_Lab.Models;
using System.Diagnostics;

namespace OMDB_API_Lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieSearchForm()
        {
            return View("MovieSearch");    //need the quotes when the method name is differenct from view or sending to a specific view
        }


        [HttpPost]
        public IActionResult MovieSearchResults(string title)
        {
            MovieModel result = MovieSearchDAL.GetMovie(title);
            return View("MovieSearch", result);    //need the quotes when the method name is differenct from view or sending to a specific view
        }


        [HttpGet]
        public IActionResult MovieNightForm()
        {
            return View("MovieNight");    //need the quotes when the method name is differenct from view or sending to a specific view
        }
      

        [HttpPost]
        public IActionResult MovieNightResults(string title1, string title2, string title3)
        {
            List<MovieModel> result = new List<MovieModel>();
            result.Add(MovieSearchDAL.GetMovie(title1));
            result.Add(MovieSearchDAL.GetMovie(title2));
            result.Add(MovieSearchDAL.GetMovie(title3));

            return View("MovieNight", result);    //need the quotes when the method name is differenct from view or sending to a specific view
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}