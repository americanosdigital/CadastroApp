using CadastroApp.Domain.Interfaces.Services;
using CadastroApp.Domain.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoReadDto>>> GetAll()
        {
            var produtos = await _produtoService.GetAllAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoReadDto>> GetById(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoReadDto>> Create(ProdutoCreateDto produtoCreateDto)
        {
            var produto = await _produtoService.CreateAsync(produtoCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProdutoUpdateDto produtoUpdateDto)
        {
            await _produtoService.UpdateAsync(id, produtoUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _produtoService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
