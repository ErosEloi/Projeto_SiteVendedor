using Microsoft.AspNetCore.Mvc;
using ProjetoSiteVendas.Interface;
using ProjetoSiteVendas.Services;

namespace ProjetoSiteVendas.Controllers
{
    public class SellersController : Controller
    {

        private readonly ISellerService _sellerService;

        public SellersController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
    }
}
