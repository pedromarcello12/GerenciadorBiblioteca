using GerenciadorBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorBiblioteca.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<LivroModel> Livro { get; set; }
        public DbSet<EmprestimoModel> Emprestimo { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
