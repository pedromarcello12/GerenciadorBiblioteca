using GerenciadorBiblioteca.Models;
using GerenciadorBiblioteca.Repository;

namespace GerenciadorBiblioteca.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        public async Task<LivroModel> BuscarPorId(int id)
        {
            try
            {
                return await _livroRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<LivroModel>> BuscarTodos()
        {
            try
            {
                return await _livroRepository.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LivroModel> Criar(LivroModel livro)
        {
            try
            {
                return await _livroRepository.Criar(livro);
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
            await _livroRepository.Deletar(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LivroModel> Editar(LivroModel livro)
        {
            try
            {
                return await _livroRepository.Editar(livro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }
    }
}
