using kuranmealuygulaması.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System.Globalization;
using static kuranmealuygulaması.Controllers.KelimeDuzenleme;
namespace kuranmealuygulaması.Controllers
{
    public class Ayetler : Controller
    {
        private readonly KuranContext _context;
        
        public Ayetler(KuranContext context)
        {
            _context = context;
        }
       
       
        public async Task<IActionResult> Ayetler_(int sureNumarasi = 1, int ayetNumarasi = 1)
        {
            var sure = await _context.SureTables.FirstOrDefaultAsync(s => s.SureId == sureNumarasi);
            if (sure == null)
            {
                return NotFound();
            }

            var ayet = await _context.Arapcas.FirstOrDefaultAsync(a => a.SureId == sure.SureId && a.AyetId == ayetNumarasi);
            if (ayet == null)
            {
                return NotFound();
            }

            var model = new AyetModel
            {
                SureId = sureNumarasi,
                AyetId = ayetNumarasi,
                Ayet = ayet.Ayet
            };

            return View(model);
        }
        

        [HttpPost]
        public async Task<IActionResult> NextAyet(AyetModel model)
        {
            var sure = await _context.SureTables.FirstOrDefaultAsync(s => s.SureId == model.SureId);
            if (sure == null)
            {
                return NotFound();
            }

            model.AyetId++;
            if (model.AyetId > sure.AyetSayisi)
            {
                model.AyetId = 1; 
                model.SureId++; 
            }

            var nextSure = await _context.SureTables.FirstOrDefaultAsync(s => s.SureId == model.SureId);
            if (nextSure == null)
            {
                model.SureId = 1; 
            }

            return RedirectToAction("Ayetler_", new { sureNumarasi = model.SureId, ayetNumarasi = model.AyetId });
        }

        [HttpPost]
        public async Task<IActionResult> PreviousAyet(AyetModel model)
        {
            var sure = await _context.SureTables.FirstOrDefaultAsync(s => s.SureId == model.SureId);
            if (sure == null)
            {
                return NotFound();
            }

            model.AyetId--;
            if (model.AyetId == 0)
            {
                sure = await _context.SureTables.FirstOrDefaultAsync(s => s.SureId == model.SureId-1);
                if (sure == null)
                {
                    model.SureId = 1;
                    model.AyetId = 1;
                }
                else{
                    model.AyetId = sure.AyetSayisi;
                    model.SureId = sure.SureId;
                }
               
            }
            

            var nextSure = await _context.SureTables.FirstOrDefaultAsync(s => s.SureId == model.SureId);
            if (nextSure == null)
            {
                model.SureId = 1;
            }

            return RedirectToAction("Ayetler_", new { sureNumarasi = model.SureId, ayetNumarasi = model.AyetId });
        }

        [HttpPost]
        public async Task<IActionResult> SureGit(int sure)
        {
            var sureNumarasi = sure + 1;
            return RedirectToAction("Ayetler_", new { sureNumarasi = sureNumarasi, ayetNumarasi = 1 });
        }
        [HttpPost]
        public async Task<IActionResult> AyetGit(int sure,int ayet)
        {
            
            return RedirectToAction("Ayetler_", new { sureNumarasi = sure, ayetNumarasi = ayet});
        }

        
        public async Task<IActionResult> Ara(string ara)
        {
             if (!string.IsNullOrEmpty(ara))
        {
                ara = ara.ToLower();
                List<AyetModel> result = null;

            
                  try
                {
                                    var sureler = await _context.SureTables
                    .Select(s => new { s.SureId, s.Sureler })
                    .ToListAsync();

                    var normalizedAra = ara.NormalizeText().ToLower();

                     result = sureler
                        .Where(s => s.Sureler.ToLower().NormalizeText().Contains(normalizedAra))
                        .Select(s => new AyetModel { SureId = s.SureId })
                        .ToList();
                    //Düzeltmeden arama yapmak için
                    //result = await _context.SureTables
                    //    .Where(s => EF.Functions.Like(s.Sureler.ToLower().Substring(-6), $"%{ara}%"))
                    //    .Select(s => new AyetModel { SureId = s.SureId })
                    //    .ToListAsync();
                }
                catch (InvalidOperationException ex)
                {
                    // Hata mesajını ViewData'ya ekleyin
                    ViewData["ErrorMessage"] = "Arama işlemi sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
                    // Hata detaylarını loglayın veya gerekirse hata sayfasına yönlendirin
                    // Loglama için: Console.WriteLine(ex.Message);
                    return View();
                }
                catch (Exception ex)
                {
                    // Hata mesajını ViewData'ya ekleyin
                    ViewData["ErrorMessage"] = "Beklenmedik bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
                    // Hata detaylarını loglayın veya gerekirse hata sayfasına yönlendirin
                    // Loglama için: Console.WriteLine(ex.Message);
                    return View();
                }

                var model = result?.FirstOrDefault();

                if (model == null)
                {
                    // Hata mesajını ViewData'ya ekleyin
                    ViewData["ErrorMessage"] = "Aradığınız sure bulunamadı.";
                    return View(); // Boş bir model ile view döndürülür
                }

                return View(model);
        }
        else
        {
            // Ara değeri boşsa da bir hata mesajı gösterebilirsiniz
            ViewData["ErrorMessage"] = "Lütfen bir arama terimi girin.";
            return View(); // Boş bir model ile view döndürülür
        }
        }

















    }
}
