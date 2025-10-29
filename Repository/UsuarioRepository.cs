using GerenciadorBiblioteca.Context;
using GerenciadorBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorBiblioteca.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            try
            {
                var usuario = await _context.Usuario.FindAsync(id);
                if (usuario == null)
                {
                    throw new Exception("Usuário não encontrado");
                }
                return usuario;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UsuarioModel>> BuscarTodos()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> Criar(UsuarioModel usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task Deletar(int id)
        {
            await _context.Usuario.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public Task<UsuarioModel> Editar(UsuarioModel usuario)
        {
           return Task.Run(async () =>
           {
               await _context.Usuario.Where(x => x.Id == usuario.Id)
                   .ExecuteUpdateAsync(u => u
                       .SetProperty(p => p.Nome, usuario.Nome)
                       .SetProperty(p => p.Email, usuario.Email)
                   );
               return usuario;
           });
        }
    }
}
