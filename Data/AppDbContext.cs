using Microsoft.EntityFrameworkCore;
using Ploomers_Advogados.Models;

namespace Ploomers_Advogados.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<Advogado> Advogados { get; set; }
        public DbSet<Processo> Processos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração do relacionamento um-para-muitos entre Advogado e Processo
            modelBuilder.Entity<Processo>()
                .HasOne(processo => processo.Advogado)
                .WithMany(advogado => advogado.Processos)
                .HasForeignKey(processo => processo.AdvogadoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
