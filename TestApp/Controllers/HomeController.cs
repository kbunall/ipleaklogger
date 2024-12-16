using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {



        private readonly ILogger<HomeController> _logger;
        private SqlBaglanti sqlBaglanti = new SqlBaglanti();

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult DataPost(KayitModel kayitlar)
        {
            SqlBaglanti sqlBaglanti = new SqlBaglanti();
            sqlBaglanti.KayitEkle(kayitlar.departman, kayitlar.ipadresi, kayitlar.aciklik, kayitlar.kullanici, kayitlar.aciklama);
            return Ok(new { message = "Veriler baþarýyla kaydedildi." });
        }

    
        public ActionResult Sorgula(string ipdata)
        {
            var veriler = sqlBaglanti.GetirVeriler(ipdata);
            return Json(veriler);
        }
    }

    public class KayitModel
    {
        public string departman { get; set; }
        public string ipadresi { get; set; }
        public string aciklik { get; set; }
        public string kullanici { get; set; }
        public string aciklama { get; set; }
    }
}

