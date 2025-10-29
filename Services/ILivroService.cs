using GerenciadorBiblioteca.Models;

namespace GerenciadorBiblioteca.Services
{
    public interface ILivroService
    {
        Task<LivroModel> Criar(LivroModel livro);
        Task<List<LivroModel>> BuscarTodos();
        Task<LivroModel> BuscarPorId(int id);
        Task<LivroModel> Editar(LivroModel livro);
        Task Deletar(int id);
    }
}
