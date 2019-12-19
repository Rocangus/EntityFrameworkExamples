using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EntityFrameworkExamples.Models;
using Microsoft.Extensions.Configuration;
using EntityFrameworkExamples.Services;

namespace EntityFrameworkExamples.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISettings _settings;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ISettings settings)
        {
            _logger = logger;
            _configuration = configuration;
            _settings = settings;
        }

        public IActionResult Index()
        {
            //var capacity = _configuration.GetValue(typeof(int), "UniversitySettings:Capacity");
            return View();
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
