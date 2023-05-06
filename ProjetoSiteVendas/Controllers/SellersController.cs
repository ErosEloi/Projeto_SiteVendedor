﻿using Microsoft.AspNetCore.Mvc;
using ProjetoSiteVendas.Interface;
using ProjetoSiteVendas.Models;
using ProjetoSiteVendas.Models.ViewModels;
using ProjetoSiteVendas.Services;

namespace ProjetoSiteVendas.Controllers
{
    public class SellersController : Controller
    {

        private readonly ISellerService _sellerService;
        private readonly IDepartmentService _departmentService;
        public SellersController(ISellerService sellerService, IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel {Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
