using AgilizaRH.Models;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<CargoGratificacoes> CargoGratificacoes { get; set; }
        public DbSet<Cargos> Cargos { get; set; }
        public DbSet<Gratificacoes> Gratificacoes { get; set; }
        public DbSet<GruposColaboradores> GruposColaboradores { get; set; }
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
