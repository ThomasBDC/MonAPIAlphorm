using Microsoft.EntityFrameworkCore;
using MonAPIAlphorm.BDD;
using MonAPIAlphorm.Entities;

namespace MonAPIAlphorm.Services.Prospect
{
    public class ProspectService : IProspectService
    {
        private readonly ApplicationDbContext _context;
        public ProspectService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProspectEntity>> GetProspects()
        {
            var prospects = await _context.Propects.ToListAsync();
            return prospects;
        }

        public async Task<ProspectEntity> GetProspect(int id)
        {
            var prospect = await _context.Propects.FindAsync(id);
            return prospect;
        }

        public async Task<bool> CreateProspect(ProspectEntity prospect)
        {
            _context.Add(prospect);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteProspect(int id)
        {
            var prospect = await GetProspect(id);
            if (prospect != null)
            {
                _context.Propects.Remove(prospect);

                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
