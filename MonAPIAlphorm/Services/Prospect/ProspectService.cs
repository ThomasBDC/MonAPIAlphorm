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
        public async Task<List<ProspectEntity>> GetProspects(int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 10) pageSize = 10;

            var prospects = await _context.Propects
                .Skip((page - 1)* pageSize)
                .Take(pageSize)
                .ToListAsync();
            return prospects;
        }

        public async Task<List<ProspectEntity>> SearchProspects(string q)
        {
            q = q.Trim();
            var pattern = $"%{q}%";
            var request = from p in _context.Propects
                          where
                          EF.Functions.Like(p.FirstName, pattern)
                          || EF.Functions.Like(p.LastName, pattern)
                          || EF.Functions.Like(p.Phone, pattern)
                          || EF.Functions.Like(p.Address, pattern)
                          || EF.Functions.Like(p.Email, pattern)
                          select p;

            var prospects = await request.ToListAsync();
            return prospects;
        }

        public async Task<ProspectEntity> GetProspect(int id)
        {
            var prospect = await _context.Propects.Include(p => p.Company).FirstOrDefaultAsync(p => p.Id == id);
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

        public async Task<bool> EditProspect(ProspectEntity prospect)
        {
            _context.Entry(prospect).State = EntityState.Modified;

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
