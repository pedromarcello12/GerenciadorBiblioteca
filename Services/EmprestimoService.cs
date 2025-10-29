using GerenciadorBiblioteca.Models;
using GerenciadorBiblioteca.Repository;

namespace GerenciadorBiblioteca.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        public EmprestimoService(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }
        public async Task<EmprestimoModel> BuscarPorId(int id)
        {
            return await _emprestimoRepository.BuscarPorId(id);
        }

        public async Task<List<EmprestimoModel>> BuscarTodos()
        {
            return await _emprestimoRepository.BuscarTodos();
        }

        public async Task<EmprestimoModel> Criar(EmprestimoModel emprestimo)
        {
            if(emprestimo.DataDevolucao < emprestimo.DataEmprestimo)
            {
                throw new Exception("Data de devolução não pode ser anterior à data de empréstimo.");
            }
            if(emprestimo.UsuarioId == 0)
            {
                 throw new Exception("Usuário inválido.");
            }
            if(emprestimo.LivroId == 0)
            {
                 throw new Exception("Livro inválido.");
            }
            await _emprestimoRepository.Criar(emprestimo);
            return emprestimo;

        }

        public async Task Deletar(int id)
        {
            await _emprestimoRepository.Deletar(id);
        }

        public async Task<EmprestimoModel> Editar(EmprestimoModel emprestimo)
        {
            if (emprestimo.DataDevolucao < emprestimo.DataEmprestimo)
            {
                throw new Exception("Data de devolução não pode ser anterior à data de empréstimo.");
            }
            if (emprestimo.UsuarioId == 0)
            {
                throw new Exception("Usuário inválido.");
            }
            if (emprestimo.LivroId == 0)
            {
                throw new Exception("Livro inválido.");
            }
            return await _emprestimoRepository.Editar(emprestimo);
        }
    }
}
