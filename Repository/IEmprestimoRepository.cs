using GerenciadorBiblioteca.Models;

namespace GerenciadorBiblioteca.Repository
{
    public interface IEmprestimoRepository
    {
        Task<EmprestimoModel> Criar(EmprestimoModel emprestimo);
        Task<List<EmprestimoModel>> BuscarTodos();
        Task<EmprestimoModel> BuscarPorId(int id);
        Task<EmprestimoModel> Editar(EmprestimoModel emprestimo);
        Task Deletar(int id);
    }
}
