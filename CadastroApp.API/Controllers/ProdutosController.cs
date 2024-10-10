using CadastroApp.Domain.Interfaces.Services;
using CadastroApp.Domain.Models.Dtos;
using CadastroApp.Domain.Models.Entities;
using CadastroApp.Domain.Services;
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
            try
            {
                var produtos = await _produtoService.GetAllAsync();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoReadDto>> GetById(int id)
        {
            try
            {
                var produto = await _produtoService.GetByIdAsync(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoReadDto>> Create(ProdutoCreateDto produtoCreateDto)
        {
            try
            {
                var produto = await _produtoService.CreateAsync(produtoCreateDto);
                return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProdutoUpdateDto produtoUpdateDto)
        {
            try
            {
                await _produtoService.UpdateAsync(id, produtoUpdateDto);
                return Ok(produtoUpdateDto);
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
                var result = await _produtoService.DeleteAsync(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}