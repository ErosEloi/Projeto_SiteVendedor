﻿using ProjetoSiteVendas.Data;
using ProjetoSiteVendas.Interface;
using ProjetoSiteVendas.Models;
using ProjetoSiteVendas.Models.Enums;

namespace ProjetoSiteVendas.Services
{
    public class SellerService : ISellerService
    {

        private readonly ProjetoSiteVendasContext _context;
        //ISellerService service;

        public SellerService(ProjetoSiteVendasContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            
            return _context.Seller.ToList();
        }

       


    }
}
