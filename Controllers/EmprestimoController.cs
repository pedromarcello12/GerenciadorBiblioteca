using GerenciadorBiblioteca.Models;
using GerenciadorBiblioteca.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorBiblioteca.Controllers
{
    [Route("api/Emprestimo")]

    public class EmprestimoController : Controller
    {

        private readonly IEmprestimoService _emprestimoService;
        public EmprestimoController(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }

        // GET: EmprestimoController
        [HttpGet("Index")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmprestimoController/Detalhes/5
        [HttpGet("Detalhes/{id}")]
        public ActionResult Detalhes(int id)
        {
            try
            {
                return Ok(_emprestimoService.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }


        // POST: EmprestimoController/Create
        [HttpPost("Criar")]
        public ActionResult Criar([FromBody] EmprestimoModel emprestimo)
        {
            try
            {
                return Ok(_emprestimoService.Criar(emprestimo));
            }
            catch(Exception ex
            )
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: EmprestimoController/Edit
        [HttpPost("Editar")]
        public ActionResult Editar([FromBody] EmprestimoModel emprestimo)
        {
            try
            {
                return Ok(_emprestimoService.Editar(emprestimo));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST: EmprestimoController/Delete/5
        [HttpPost("Deletar")]
        public ActionResult Deletar(int id)
        {
            try
            {
                return Ok(_emprestimoService.Deletar(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
