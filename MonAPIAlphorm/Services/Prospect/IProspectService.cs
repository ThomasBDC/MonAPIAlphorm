using MonAPIAlphorm.Entities;

namespace MonAPIAlphorm.Services.Prospect
{
    public interface IProspectService
    {
        Task<List<ProspectEntity>> GetProspects();
        Task<ProspectEntity> GetProspect(int id);
        Task<bool> CreateProspect(ProspectEntity prospect);
        Task<bool> DeleteProspect(int id);
    }
}   
