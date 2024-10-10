using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CadastroApp.Domain.Models.Entities;
using CadastroApp.Domain.Interfaces.Repositories;
using CadastroApp.Domain.Interfaces.Services;
using CadastroApp.Domain.Models.Dtos;
using CadastroApp.Domain.Exceptions;

namespace CadastroApp.API.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public VendaService(
            IVendaRepository vendaRepository,
            IClienteRepository clienteRepository,
            IProdutoRepository produtoRepository,
            IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<VendaReadDto> CreateAsync(VendaCreateDto vendaDto)
        {
            var cliente = await _clienteRepository.GetByIdAsync(vendaDto.ClienteId);
            if (cliente == null)
                throw new NotFoundException($"Cliente com Id {vendaDto.ClienteId} não encontrado.");

            var venda = new Venda
            {
                DataEmissao = DateTime.UtcNow,
                Cliente = cliente,
                VendaItens = new List<VendaItem>()
            };

            foreach (var itemDto in vendaDto.Itens)
            {
                var produto = await _produtoRepository.GetByIdAsync(itemDto.ProdutoId);
                if (produto == null)
                    throw new NotFoundException($"Produto com Id {itemDto.ProdutoId} não encontrado.");                   

                venda.VendaItens.Add(new VendaItem
                {
                    Produto = produto,
                    Quantidade = itemDto.Quantidade,
                    PrecoVenda = produto.PrecoVenda
                });
            }

            var createdVenda = await _vendaRepository.CreateAsync(venda);
            return _mapper.Map<VendaReadDto>(createdVenda);
        }

        // Implementar UpdateAsync se necessário

        public async Task<bool> DeleteAsync(int id)
        {
            return await _vendaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<VendaReadDto>> GetAllAsync()
        {
            var vendas = await _vendaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<VendaReadDto>>(vendas);
        }

        public async Task<VendaReadDto> GetByIdAsync(int id)
        {
            var venda = await _vendaRepository.GetByIdAsync(id);
            if (venda == null)
                throw new NotFoundException($"Venda com Id {id} não encontrado.");

            return _mapper.Map<VendaReadDto>(venda);
        }

        public async Task<VendaReadDto> UpdateAsync(int id, VendaCreateDto vendaDto)
        {
            // Implementação semelhante ao CreateAsync, ajustando a venda existente
            throw new NotImplementedException();
        }
    }
}
