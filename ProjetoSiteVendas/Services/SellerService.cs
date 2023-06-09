﻿using Microsoft.EntityFrameworkCore;
using NuGet.ProjectModel;
using ProjetoSiteVendas.Data;
using ProjetoSiteVendas.Interface;
using ProjetoSiteVendas.Models;
using ProjetoSiteVendas.Models.Enums;
using ProjetoSiteVendas.Services.Exceptions;

namespace ProjetoSiteVendas.Services
{
    public class SellerService : ISellerService
    {

        private readonly ProjetoSiteVendasContext _context;
       
        public SellerService(ProjetoSiteVendasContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
       
        public Seller FindById(int id)
        {
            return   _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not Found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
      
    }
}
