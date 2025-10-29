using GerenciadorBiblioteca.Models;

namespace GerenciadorBiblioteca.Services
{
    public interface IEmprestimoService
    {
        Task<EmprestimoModel> Criar(EmprestimoModel emprestimo);
        Task<List<EmprestimoModel>> BuscarTodos();
        Task<EmprestimoModel> BuscarPorId(int id);
        Task<EmprestimoModel> Editar(EmprestimoModel emprestimo);
        Task Deletar(int id);

    }
}
