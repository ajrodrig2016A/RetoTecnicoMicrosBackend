using Core.RetoTecnico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RetoTecnico.Infrastructure.Context
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Personas>().UseTpcMappingStrategy();
            modelBuilder.Entity<Clientes>()
                .HasMany(a => a.Cuentas)
                .WithOne(u => u.Cliente)
                .HasForeignKey(ai => ai.ClienteId);

            modelBuilder.Entity<Cuentas>()
                .HasMany(m => m.Movimientos)
                .WithOne(a => a.Cuenta)
                .HasForeignKey(ai => ai.CuentaId);

        }
    }
}
