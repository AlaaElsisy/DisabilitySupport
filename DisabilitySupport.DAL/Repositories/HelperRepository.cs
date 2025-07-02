using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Repositories
{
    public class HelperRepository : IHelperRepository
    {
        private readonly ApplicationDbContext _context;

        public HelperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Helper?> GetByUserIdAsync(string userId)
        {
            return await _context.Helpers!
                .Include(h => h.User)
                .FirstOrDefaultAsync(h => h.UserId == userId);
        }

        public async Task<Helper> GetByIdAsync(int id)
        {
            return await _context.Helpers
                 .Include(d => d.User)
                 .FirstOrDefaultAsync(d => d.Id == id);
        }
    }

}
