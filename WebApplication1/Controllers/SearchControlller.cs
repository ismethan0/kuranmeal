using kuranmealuygulaması.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace kuranmealuygulaması.Controllers
{
    public class SearchControlller : Controller
    {
        private readonly KuranContext _context;

        public SearchControlller(KuranContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                IQueryable query=null;
                if (model.Meal == "Diyanet(Yeni)")
                {
                    query = _context.DiyanetYenis.AsQueryable();
                }
                else if (model.Meal == "Diyanet(Eski)")
                {
                    query = _context.DiyanetEskis.AsQueryable();
                }
                else if (model.Meal == "Elmalılı Muhammed Hamdi Yazır (Yenilenmiş)")
                {
                    query = _context.ElmaliHamdis.AsQueryable();
                }
                else if (model.Meal == "Elmalılı Muhammed Hamdi Yazır (Orjinal)")
                {
                    query = _context.ElmaliHamdiOrginals.AsQueryable();
                }
                else if (model.Meal == "Yaşar Nuri Öztürk")
                {
                    query = _context.YasarNuriInısAyetlers.AsQueryable();
                }
                else if (model.Meal == "Suleymaniye Vakfı")
                {
                    query = _context.Suleymaniyes.AsQueryable();
                }
                else if (model.Meal == "Edip Yüksel")
                {
                    query = _context.Edipyuksels.AsQueryable();
                }
                else if (model.Meal == "Muhammed Esed")
                {
                    query = _context.Eseds.AsQueryable();
                }
                else if (model.Meal == "Yusuf Ali(ingilizce)")
                {
                    query = _context.Yusufalis.AsQueryable();
                }
                else if (model.Meal == "Anadolu Türkçesi")
                {
                    query = _context.AnadoluTurkcesis.AsQueryable();
                }
                else if (model.Meal == "Anonim")
                {
                    query = _context.Anonims.AsQueryable();
                }
                else if (model.Meal == "Azeri Türkçesi")
                {
                    query = _context.AzeriTurkcesis.AsQueryable();
                }
                else if (model.Meal == "Arapça Metin")
                {
                    query = _context.Arapcas.AsQueryable();
                }
                else
                {
                    query = _context.Arapcas.AsQueryable(); // Default olarak Arapça metin
                }


                // Sure filtresi
                if (!string.IsNullOrEmpty(model.Sure) && model.Sure != "Tüm Surelerde ara")
                {
                    int sureId = int.Parse(model.Sure);
                    query = query.Where("SureId == @0", sureId);
                }

                // Keyword filtresi
                if (!string.IsNullOrEmpty(model.Keyword))
                {
                    switch (model.SearchOption)
                    {
                        case "AllWords":
                            var words = model.Keyword.Split(' ');
                            foreach (var word in words)
                            {
                                query = query.Where("Ayet.Contains(@0)", word);
                            }
                            break;

                        case "AnyWord":
                            var keywords = model.Keyword.Split(' ');
                            var predicate = string.Join(" || ", keywords.Select((kw, index) => $"Ayet.Contains(@{index})"));
                            query = query.Where(predicate, keywords.Cast<object>().ToArray());
                            break;

                        case "ExactMatch":
                            query = query.Where("Ayet.Contains(@0)", model.Keyword);
                            break;
                    }
                }

                // Sıralama
                query = query.OrderBy("SureId");
                var results = await query.ToDynamicListAsync();

                return View(results); // SearchResults.cshtml
            }

            return View("Error");
        }
    }
}

