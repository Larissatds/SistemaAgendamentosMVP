using AgendaSalaoMVP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaSalaoMVP.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {       
        }

        public DbSet<Agendamento> Agendamentos { get; set;}
        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<Servico> Servicos { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Cliente)
                .WithMany()
                .HasForeignKey(a => a.IdCliente);

            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Servico)
                .WithMany()
                .HasForeignKey(a => a.IdServico);
        }
    }
}
