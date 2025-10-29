using GerenciadorBiblioteca.Models;
using GerenciadorBiblioteca.Repository;

namespace GerenciadorBiblioteca.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            try
            {
                return await _usuarioRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UsuarioModel>> BuscarTodos()
        {
            try
            {
                return await _usuarioRepository.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioModel> Criar(UsuarioModel usuario)
        {
            try
            {
                return await _usuarioRepository.Criar(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Deletar(int id)
        {
            try
            {
                await _usuarioRepository.Deletar(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioModel> Editar(UsuarioModel usuario)
        {
            try
            {
                return await _usuarioRepository.Editar(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
