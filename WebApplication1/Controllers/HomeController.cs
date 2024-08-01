using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Ayetler()
        {
            return View();
        }
        public IActionResult Arama()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public async Task<IActionResult> Sure(int sureNumarasi , int ayetNumarasi )
        {

            var model = new AyetModel
            {
                SureId = sureNumarasi,
                AyetId = ayetNumarasi,

            };

            return View(model);


            
        }
        [HttpPost]
        public async Task<IActionResult> SonrakiSure(int sure, int ayet)
        {
            if (sure >= 114)
            {
                var sureNumarasi = sure;
                return RedirectToAction("Sure", new { sureNumarasi = sureNumarasi, ayetNumarasi = 1 });
            }
            else
            {
                var sureNumarasi = sure + 1;
                return RedirectToAction("Sure", new { sureNumarasi = sureNumarasi, ayetNumarasi = 1 });
            }
        }
            
        [HttpPost]
        public async Task<IActionResult> OncekiSure(int sure, int ayet)
        {
            if (sure == 1){
                var sureNumarasi = sure;
                return RedirectToAction("Sure", new { sureNumarasi = sureNumarasi, ayetNumarasi = 1 });
            }
            else {

                var sureNumarasi = sure - 1;
                return RedirectToAction("Sure", new { sureNumarasi = sureNumarasi, ayetNumarasi = 1 });
            }
            
        }
        
    }
}