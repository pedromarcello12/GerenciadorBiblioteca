using GerenciadorBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorBiblioteca
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
        }
        public DbSet<LivroModel> Livro { get; set; }
        public DbSet<EmprestimoModel> Emprestimo { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
