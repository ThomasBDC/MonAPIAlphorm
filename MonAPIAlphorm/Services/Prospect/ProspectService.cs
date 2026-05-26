using MonAPIAlphorm.Entities;

namespace MonAPIAlphorm.Services.Prospect
{
    public class ProspectService : IProspectService
    {
        public List<ProspectEntity> GetProspects()
        {
            return new List<ProspectEntity>
            { 
                new ProspectEntity { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Phone = "123-456-7890", Address = "123 Main St" } 
            };
        }
    }
}
