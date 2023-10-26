using Entities.DataTransferObjects;
using Entities.Models;

namespace MappingProfile
{
    public class MappingProfile 
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>();
        }
    }
}