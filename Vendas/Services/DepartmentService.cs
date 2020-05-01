using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Models;
using Microsoft.EntityFrameworkCore;

namespace Vendas.Services
{
    public class DepartmentService
    {
        private readonly VendasContext _context;

        public DepartmentService(VendasContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            //SERVIÇO PARA RETORNAR OS DEPARTAMENTOS ORDENADOS
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
