using MonAPIAlphorm.Entities;

namespace MonAPIAlphorm.Services.Prospect
{
    public interface IProspectService
    {
        Task<List<ProspectEntity>> GetProspects(int page, int pageSize);
        Task<List<ProspectEntity>> SearchProspects(string q);
        Task<ProspectEntity> GetProspect(int id);
        Task<bool> CreateProspect(ProspectEntity prospect);
        Task<bool> DeleteProspect(int id);
        Task<bool> EditProspect(ProspectEntity prospect);
    }
}   
