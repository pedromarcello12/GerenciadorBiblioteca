using GerenciadorBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorBiblioteca.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {   
        private readonly AppDbContext _context;
        public EmprestimoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<EmprestimoModel> BuscarPorId(int id)
        {
            try
            {
                var emprestimo =  await _context.Emprestimo.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
                if(emprestimo == null)
                {
                    throw new Exception("Empréstimo não encontrado");
                }
                return emprestimo;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EmprestimoModel>> BuscarTodos()
        {
            return await _context.Emprestimo.ToListAsync();
        }

        public async Task<EmprestimoModel> Criar(EmprestimoModel emprestimo)
        {
            var emprestimoDb = await _context.Emprestimo.AddAsync(emprestimo);
            await _context.SaveChangesAsync();
            return emprestimoDb.Entity;
        }

        public async Task Deletar(int id)
        {
            await  _context.Emprestimo.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<EmprestimoModel> Editar(EmprestimoModel emprestimo)
        {
            await _context.Emprestimo.Where(x => x.Id == emprestimo.Id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(p => p.LivroId, emprestimo.LivroId)
                    .SetProperty(p => p.UsuarioId, emprestimo.UsuarioId)
                    .SetProperty(p => p.DataEmprestimo, emprestimo.DataEmprestimo)
                    .SetProperty(p => p.DataDevolucao, emprestimo.DataDevolucao)
                );
            return emprestimo;
        }
    }
}
