using GerenciadorBiblioteca.Models;
using GerenciadorBiblioteca.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciadorBiblioteca.Controllers
{
    [Route("api/Usuario")]

    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _userService;
        public UsuarioController(IUsuarioService userService)
        {
            _userService = userService;
        }
        // GET: UsuarioController
        [HttpGet("Index")]
        public ActionResult Index()
        {
            try
            {
                return Ok(_userService.BuscarTodos());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: UsuarioController/Details/5
        [HttpGet("Detalhes/{id}")]
        public async Task<ActionResult> Detalhes(int id)
        {
            try
            {
                return Ok(await _userService.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }


        // POST: UsuarioController/Criar
        [HttpPost("Criar")]
        public ActionResult Criar([FromBody] UsuarioModel usuario)
        {
            try
            {
                return Ok(_userService.Criar(usuario));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: UsuarioController/Editar/5
        [HttpPost("Editar")]
        public ActionResult Editar([FromBody] UsuarioModel usuario)
        {
            try
            {
               return Ok(_userService.Editar(usuario));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST: UsuarioController/Delete/5
        [HttpPost("Deletar")]
        public ActionResult Deletar(int id)
        {
            try
            {
                return Ok(_userService.Deletar(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
