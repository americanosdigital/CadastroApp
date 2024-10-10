using CadastroApp.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroApp.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task<ClienteReadDto> CreateAsync(ClienteCreateDto clienteDto);
        Task<ClienteReadDto> UpdateAsync(int id, ClienteUpdateDto clienteDto);
        Task<bool> DeleteAsync(int id);
        Task<ClienteReadDto> GetByIdAsync(int id);
        Task<IEnumerable<ClienteReadDto>> GetAllAsync();
    }
}
