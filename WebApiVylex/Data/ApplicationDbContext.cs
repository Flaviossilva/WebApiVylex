using Microsoft.EntityFrameworkCore;
using WebApiVylex.DTOs;
using WebApiVylex.Models;

namespace WebApiVylex.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da relação entre Product e Category
            modelBuilder.Entity<Avaliacao>()
                .HasOne(p => p.Cursos)
                .WithMany(c => Avaliacoes)
                .HasForeignKey(p => p.CursoId);
        }


        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
    }
}
