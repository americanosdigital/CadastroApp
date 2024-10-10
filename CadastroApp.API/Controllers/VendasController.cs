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
            var vendas = await _vendaService.GetAllAsync();
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendaReadDto>> GetById(int id)
        {
            var venda = await _vendaService.GetByIdAsync(id);
            return Ok(venda);
        }

        [HttpPost]
        public async Task<ActionResult<VendaReadDto>> Create(VendaCreateDto vendaCreateDto)
        {
            var venda = await _vendaService.CreateAsync(vendaCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = venda.Id }, venda);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _vendaService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, VendaUpdateDto vendaUpdateDto)
        // {
        //     await _vendaService.UpdateAsync(id, vendaUpdateDto);
        //     return NoContent();
        // }
    }
}
