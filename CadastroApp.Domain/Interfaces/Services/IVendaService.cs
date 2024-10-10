using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroApp.Domain.Models.Dtos;

namespace CadastroApp.Domain.Interfaces.Services
{
    public interface IVendaService
    {
        Task<VendaReadDto> CreateAsync(VendaCreateDto vendaDto);
        Task<VendaReadDto> UpdateAsync(int id, VendaCreateDto vendaDto); 
        Task<bool> DeleteAsync(int id);
        Task<VendaReadDto> GetByIdAsync(int id);
        Task<IEnumerable<VendaReadDto>> GetAllAsync();
    }
}
