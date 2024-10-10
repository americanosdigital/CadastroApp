using System;
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

namespace CadastroApp.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteReadDto> CreateAsync(ClienteCreateDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            var createdCliente = await _clienteRepository.CreateAsync(cliente);
            return _mapper.Map<ClienteReadDto>(createdCliente);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _clienteRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ClienteReadDto>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClienteReadDto>>(clientes);
        }

        public async Task<ClienteReadDto> GetByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                throw new NotFoundException($"Cliente com Id {id} não encontrado.");                

            return _mapper.Map<ClienteReadDto>(cliente);
        }

        public async Task<ClienteReadDto> UpdateAsync(int id, ClienteUpdateDto clienteDto)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                throw new Exception($"Cliente com Id {id} não encontrado.");

            _mapper.Map(clienteDto, cliente);
            var updatedCliente = await _clienteRepository.UpdateAsync(cliente);
            return _mapper.Map<ClienteReadDto>(updatedCliente);
        }
    }
}