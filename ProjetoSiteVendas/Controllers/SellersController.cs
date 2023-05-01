using Microsoft.AspNetCore.Mvc;

namespace ProjetoSiteVendas.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
