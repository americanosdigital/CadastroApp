using AutoMapper;
using CadastroApp.Domain.Models.Dtos;
using CadastroApp.Domain.Models.Entities;

namespace CadastroApp.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Cliente
            CreateMap<ClienteCreateDto, Cliente>();
            CreateMap<ClienteUpdateDto, Cliente>();
            CreateMap<Cliente, ClienteReadDto>();

            // Endereco
            CreateMap<EnderecoDto, Endereco>();
            CreateMap<Endereco, EnderecoDto>();

            // Contato
            CreateMap<ContatoDto, Contato>();
            CreateMap<Contato, ContatoDto>();

            // Produto
            CreateMap<ProdutoCreateDto, Produto>();
            CreateMap<ProdutoUpdateDto, Produto>();
            CreateMap<Produto, ProdutoReadDto>();

            // Venda
            CreateMap<VendaCreateDto, Venda>();
            CreateMap<Venda, VendaReadDto>();

            // VendaItem
            CreateMap<VendaItem, VendaItemReadDto>()
                .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.Quantidade * src.PrecoVenda));
        }
    }
}
