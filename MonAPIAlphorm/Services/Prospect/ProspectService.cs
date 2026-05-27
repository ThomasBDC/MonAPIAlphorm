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
        public List<ProspectEntity> GetProspects()
        {
            return new List<ProspectEntity>
            { 
                new ProspectEntity { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Phone = "123-456-7890", Address = "123 Main St" } 
            };
        }

        public async Task<bool> CreateProspect(ProspectEntity prospect)
        {
            _context.Add(prospect);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
