using ApiProva.Domain.Entities;
using ApiProva.Service.DTO;
using ApiProva.Service.ViewModel;
using AutoMapper;

namespace ApiProva.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
            CreateMap<ContatoDTO, ContatoViewModel>().ReverseMap();
        }
    }
    
}
