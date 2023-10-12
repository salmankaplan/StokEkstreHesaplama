using Microsoft.AspNetCore.Mvc;
using Stok.Ekstre.Helper;
using Stok.Ekstre.Models;
using System.Diagnostics;

namespace Stok.Ekstre.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStokService _service;

        public HomeController(ILogger<HomeController> logger, IStokService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.result = await _service.GetMalKodu(); //mal kodu parametre olarak yollanabilmesi için proje çalıştığında gelecek şekilde ayarlandı
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string kod , DateTime baslaTarih, DateTime bitTarih)
        {
            ViewBag.result = await _service.GetMalKodu(); //mal kodları tekrar gönderildi

            int baslangicTarih = Convert.ToInt32(baslaTarih.ToOADate()); //prosedür için tarih int dönüşümü yapıldı
            int bitisTarih = Convert.ToInt32(bitTarih.ToOADate()); //prosedür için tarih int dönüşümü yapıldı

            var result = await _service.GetStokRaporu(kod, baslangicTarih, bitisTarih);
            return View(result);
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