using AgilizaRH.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgilizaRH.Context
{
    public class AgilizaRHContext : DbContext
    {
        public AgilizaRHContext()
        {
        }

        public AgilizaRHContext(DbContextOptions<AgilizaRHContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(a => a.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<CargoGratificacoes> CargoGratificacoes { get; set; }
        public DbSet<Cargos> Cargos { get; set; }
        public DbSet<Gratificacoes> Gratificacoes { get; set; }
        public DbSet<GruposUsuarios> GruposUsuarios { get; set; }
        public DbSet<HistoricoFerias> HistoricoFerias { get; set; }
        public DbSet<HistoricoPromocoes> HistoricoPromocoes { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Permissoes> Permissoes { get; set; }
        public DbSet<Telas> Telas { get; set; }
        public DbSet<Telefones> Telefones { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuarioTelefones> UsuarioTelefones { get; set; }
    }
}
