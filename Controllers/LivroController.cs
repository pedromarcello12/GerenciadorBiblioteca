using GerenciadorBiblioteca.Models;
using GerenciadorBiblioteca.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorBiblioteca.Controllers
{
    [Route("api/Livro")]

    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;
        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }
        // GET: LivroController
        [HttpGet("Index")]
        public async Task<ActionResult> Index()
        {
            try
            {
                return Ok(await _livroService.BuscarTodos());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }   
        }

        // GET: LivroController/Detalhes/5
        [HttpGet("Detalhes/{id}")]
        public async Task<ActionResult> Detalhes(int id)
        {
            try
            {
                return Ok(await _livroService.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: LivroController/Create
        [HttpPost("Criar")]
        public async Task<ActionResult> Criar([FromBody] LivroModel livro)
        {
            try
            {
                return Ok(await _livroService.Criar(livro));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST: LivroController/Edit/5
        [HttpPost("Editar")]
        public async Task<ActionResult> Editar([FromBody] LivroModel livro)
        {
            try
            {
                return Ok( await _livroService.Editar(livro));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: LivroController/Delete/5
        [HttpPost("Deletar")]
        public async Task<ActionResult> Deletar(int id )
        {
            try
            {
                return Ok(_livroService.Deletar(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }
    }
}
