using cv_melon1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace cv_melon1.Controllers
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

        //public async Task<IActionResult> Index(CV input)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    Enumerable
        //        .Range(65, 26)
        //        .Select(e => ((char)e).ToString())
        //        .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
        //        .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
        //        .OrderBy(e => Guid.NewGuid())
        //        .Take(11)
        //        .ToList().ForEach(e => builder.Append(e));
        //    string id = builder.ToString(); //creating a unique id, it creates random id of 11 characters, 0.001% duplicates in 100 million

        //    using (var fileStream = new FileStream(@"C:\cv_uploads\"+id+ ".pdf", FileMode.Create))
        //    {
        //        await input.InputFile.CopyToAsync(fileStream);
        //    }


        //    return View();
        //}

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
