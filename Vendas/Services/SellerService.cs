﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Models;
using Microsoft.EntityFrameworkCore;
using Vendas.Services.Exceptions;

namespace Vendas.Services
{
    public class SellerService
    {
        private readonly VendasContext _context;

        public SellerService(VendasContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            //acessa a fonte de dados de vendedores, e converter para uma lista
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            //EagerLoading .Include(obj => obj.Department). Para carregar o nome do departamento em detalhes
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundExcepetion("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
