using MonAPIAlphorm.DTOs;
using MonAPIAlphorm.Entities;

namespace MonAPIAlphorm.Utils
{
    public static class ProspectUtils
    {
        public static ProspectDTO ToDTO(this ProspectEntity entity)
        {
            return new ProspectDTO
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Phone = entity.Phone,
                CompanyCity = entity.Company?.City,
                CompanyName = entity.Company?.Name,
                CompanyId = entity.CompanyId
            };
        }

        public static ProspectEntity ToEntity(this ProspectDTO dto)
        {
            return new ProspectEntity
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone
            };
        }

        public static ProspectEntity ToEntity(this CreateProspectDTO dto)
        {
            return new ProspectEntity
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Address = dto.Address,
                Phone   = dto.Phone,
            };
        }

        public static ProspectEntity ToEntity(this EditProspectDTO dto)
        {
            return new ProspectEntity
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Address = dto.Address,
                Phone = dto.Phone,
            };
        }
    }
}
