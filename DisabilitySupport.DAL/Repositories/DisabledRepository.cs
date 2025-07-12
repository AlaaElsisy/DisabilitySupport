using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using Microsoft.EntityFrameworkCore;

public class DisabledRepository : IDisabledRepository
{
    private readonly ApplicationDbContext _context;

    public DisabledRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Disabled?> GetByUserIdAsync(string userId)
    {
        return await _context.DisabledPeople
            .Include(d => d.User)
            .FirstOrDefaultAsync(d => d.UserId == userId);
    }

    public async Task<Disabled> GetByIdAsync(int id)
    {
        return await _context.DisabledPeople
             .Include(d => d.User)
             .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task UpdateAsync(Disabled disabled)
    {
        _context.DisabledPeople.Update(disabled);
        await _context.SaveChangesAsync();
    }


}
