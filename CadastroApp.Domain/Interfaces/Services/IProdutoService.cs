using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroApp.Domain.Models.Dtos;

namespace CadastroApp.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<ProdutoReadDto> CreateAsync(ProdutoCreateDto produtoDto);
        Task<ProdutoReadDto> UpdateAsync(int id, ProdutoUpdateDto produtoDto);
        Task<bool> DeleteAsync(int id);
        Task<ProdutoReadDto> GetByIdAsync(int id);
        Task<IEnumerable<ProdutoReadDto>> GetAllAsync();
    }
}
