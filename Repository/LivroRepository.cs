using GerenciadorBiblioteca.Context;
using GerenciadorBiblioteca.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GerenciadorBiblioteca.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;
        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LivroModel> BuscarPorId(int id)
        {
            try
            {
                var livro = await _context.Livro.FindAsync(id);
                if (livro == null)
                {
                    throw new Exception("Livro não encontrado");
                }
                return livro;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<LivroModel>> BuscarTodos()
        {
            return await _context.Livro.ToListAsync();
        }

        public async Task<LivroModel> Criar(LivroModel livro)
        {
            _context.Livro.Add(livro);
            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task Deletar(int id)
        {
            await _context.Livro.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<LivroModel> Editar(LivroModel livro)
        {
            await _context.Livro.Where(x => x.Id == livro.Id)
                  .ExecuteUpdateAsync(l => l
                      .SetProperty(p => p.Titulo, livro.Titulo)
                      .SetProperty(p => p.Autor, livro.Autor)
                      .SetProperty(p => p.ISBN, livro.ISBN)
                      .SetProperty(p => p.AnoPublicacao, livro.AnoPublicacao)
                  );
            return livro;

        }
    }
}
