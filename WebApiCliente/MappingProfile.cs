using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApiCliente
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>();

            CreateMap<Account, AccountDto>();

            CreateMap<ClientForCreationDto, Client>();

            CreateMap<ClientForUpdateDto, Client>();
        }
    }
}
