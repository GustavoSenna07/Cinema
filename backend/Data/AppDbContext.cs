using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Filme> Filmes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>().ToTable("filmes");
            modelBuilder.Entity<Sessao>().ToTable("sessoes");
            modelBuilder.Entity<Assentos>().ToTable("assentos");
            modelBuilder.Entity<Ingressos>().ToTable("ingressos");
            modelBuilder.Entity<Salas>().ToTable("salas");
            modelBuilder.Entity<Usuarios>().ToTable("usuarios");
            modelBuilder.Entity<Pagamentos>().ToTable("pagamentos");
        }
    }
}
