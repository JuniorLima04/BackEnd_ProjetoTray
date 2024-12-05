using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoTray.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string produto, string preco, string cidade, string estado)
        {
            try
            {
                var comprasFiltradas = await _compraService.FindComprasAsync(produto, null);
                return Ok(comprasFiltradas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar compras: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Compra compra)
        {
            if (compra == null)
            {
                return BadRequest("Dados da compra inválidos.");
            }

            try
            {
                await _compraService.AddCompraAsync(compra);
                return CreatedAtAction(nameof(Get), new { id = compra.Id }, compra);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao cadastrar compra: {ex.Message}");
            }
        }
    }
}