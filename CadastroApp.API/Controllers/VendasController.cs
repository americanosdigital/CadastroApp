using CadastroApp.API.Services;
using CadastroApp.Domain.Interfaces.Services;
using CadastroApp.Domain.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendasController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaReadDto>>> GetAll()
        {
            try
            {
                var vendas = await _vendaService.GetAllAsync();
                return Ok(vendas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendaReadDto>> GetById(int id)
        {
            try
            {
                var venda = await _vendaService.GetByIdAsync(id);
                return Ok(venda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<VendaReadDto>> Create(VendaCreateDto vendaCreateDto)
        {
            try
            {
                var venda = await _vendaService.CreateAsync(vendaCreateDto);
                return CreatedAtAction(nameof(GetById), new { id = venda.Id }, venda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _vendaService.DeleteAsync(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, VendaUpdateDto vendaUpdateDto)
        // {
        //     await _vendaService.UpdateAsync(id, vendaUpdateDto);
        //     return NoContent();
        // }
    }
}
