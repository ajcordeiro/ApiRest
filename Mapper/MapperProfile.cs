using AutoMapper;
using WebTest.Entities;
using WebTest.Models;

namespace WebTest.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Client, ClientViewModel>();

            CreateMap<ClientInputModel, Client>();

            CreateMap<Client, ClientInputModel>();
        }
    }
}
