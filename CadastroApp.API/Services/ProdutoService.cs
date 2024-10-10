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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<ProdutoReadDto> CreateAsync(ProdutoCreateDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            var createdProduto = await _produtoRepository.CreateAsync(produto);
            return _mapper.Map<ProdutoReadDto>(createdProduto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _produtoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProdutoReadDto>> GetAllAsync()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutoReadDto>>(produtos);
        }

        public async Task<ProdutoReadDto> GetByIdAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
                throw new NotFoundException($"Produto com Id {id} não encontrado.");
                
            return _mapper.Map<ProdutoReadDto>(produto);
        }

        public async Task<ProdutoReadDto> UpdateAsync(int id, ProdutoUpdateDto produtoDto)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
                throw new Exception($"Produto com Id {id} não encontrado.");

            _mapper.Map(produtoDto, produto);
            var updatedProduto = await _produtoRepository.UpdateAsync(produto);
            return _mapper.Map<ProdutoReadDto>(updatedProduto);
        }
    }
}
