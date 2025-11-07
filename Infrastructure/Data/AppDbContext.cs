using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<GrupoVeiculos> GruposVeiculos { get; set; }
        public DbSet<EmpresaAssistencia> EmpresasAssistencia { get; set; }
        public DbSet<PlanoAssistencia> PlanosAssistencia { get; set; }
        public DbSet<VeiculoAssistencia> VeiculosAssistencia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }
           private string GetStringConectionConfig()
            {
                //string strCon = "Data Source=MURILO;Initial Catalog=DDD_ECOMMERCE;Integrated Security=True;TrustServerCertificate=True;";
                string strCon = "Data Source=MURILO;Initial Catalog=SistemaAlocacao;Integrated Security=True;TrustServerCertificate=True;";
                return strCon;
            }
    }
}
