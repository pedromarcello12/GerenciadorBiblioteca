using GerenciadorBiblioteca.Models;

namespace GerenciadorBiblioteca.Repository
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> Criar(UsuarioModel usuario);
        Task<List<UsuarioModel>> BuscarTodos();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Editar(UsuarioModel usuario);
        Task Deletar(int id);
    }
}
