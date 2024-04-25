using AgendaSalaoMVP.Application.DTOs;
using AgendaSalaoMVP.Domain.Entities;
using AutoMapper;

namespace AgendaSalaoMVP.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Agendamento, AgendamentoDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Servico, ServicoDTO>().ReverseMap();
        }
    }
}
