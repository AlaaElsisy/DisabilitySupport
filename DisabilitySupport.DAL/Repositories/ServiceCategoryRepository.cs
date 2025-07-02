using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DisabilitySupport.DAL.Repositories
{
    public class ServiceCategoryRepository : IServiceCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceCategory>> GetAllAsync()
        {
            return await _context.ServiceCategories.ToListAsync();
        }
    }
}
