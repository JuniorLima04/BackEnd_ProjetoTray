using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoTray.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas([FromQuery] string nome, [FromQuery] string email)
        {
            var pessoas = await _pessoaService.FindPessoasAsync(nome, email);
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(string id)
        {
            var pessoa = await _pessoaService.GetPessoaByIdAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa([FromBody] Pessoa pessoa)
        {
            await _pessoaService.AddPessoaAsync(pessoa);
            return CreatedAtAction(nameof(GetPessoa), new { id = pessoa.Id }, pessoa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(string id, [FromBody] Pessoa pessoa)
        {
            await _pessoaService.UpdatePessoaAsync(id, pessoa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(string id)
        {
            try
            {
                await _pessoaService.DeletePessoaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}