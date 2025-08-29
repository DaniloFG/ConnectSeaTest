using ConnectSeaRepository.Entities;
using ConnectSeaRepository.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ConnectSeaRepository.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Escala> Escalas { get; set; }
        public DbSet<Manifesto> Manifestos { get; set; }
        public DbSet<ManifestoEscala> ManifestoEscalas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ManifestoMap());
            modelBuilder.ApplyConfiguration(new EscalaMap());
            modelBuilder.ApplyConfiguration(new ManifestoEscalaMap());

            modelBuilder.Entity<Manifesto>().HasData(
                new Manifesto { Id = 1, Numero = "IMP-2025-0001", Tipo = "IMPORTACAO", Navio = "MV Atlas", Porto_origem = "CN SHANGHAI", Porto_destino = "BR SANTOS" },
                new Manifesto { Id = 2, Numero = "EXP-2025-0042", Tipo = "EXPORTACAO", Navio = "MV Poseidon", Porto_origem = "BR RIO GRANDE", Porto_destino = "NL ROTTERDAM" }
            );

            modelBuilder.Entity<Escala>().HasData(
                new Escala { Id = 201, Navio = "MV Atlas", Porto = "BRRGD - RIO GRANDE", Status = "PREVISTA", Eta = "2025-08-27T05 = 00 = 00-03 = 00" },
                new Escala { Id = 202, Navio = "MV Atlas", Porto = "BRITJ - ITAJAI", Status = "CANCELADA", Eta = "2025-08-28T10 = 00 = 00-03 = 00" },
                new Escala { Id = 203, Navio = "MV Atlas", Porto = "BRPNG - PARANAGUA", Status = "PREVISTA", Eta = "2025-08-29T21 = 00 = 00-03 = 00" },
                new Escala { Id = 204, Navio = "MV Atlas", Porto = "BRSSZ - SANTOS", Status = "PREVISTA", Eta = "2025-08-31T08 = 00 = 00-03 = 00" },
                new Escala { Id = 301, Navio = "MV Poseidon", Porto = "BRRGD - RIO GRANDE", Status = "SAIU", Eta = "2025-08-22T03 = 00 = 00-03 = 00", Etb = "2025-08-22T06 = 00 = 00-03 = 00", Etd = "2025-08-22T18 = 00 = 00-03 = 00" },
                new Escala { Id = 302, Navio = "MV Poseidon", Porto = "BRITJ - ITAJAI", Status = "ATRACADA", Eta = "2025-08-24T06 = 00 = 00-03 = 00", Etb = "2025-08-24T07 = 30 = 00-03 = 00" },
                new Escala { Id = 303, Navio = "MV Poseidon", Porto = "BRSSZ - SANTOS", Status = "PREVISTA", Eta = "2025-08-26T09 = 00:00-03:00" }
            );

            modelBuilder.Entity<ManifestoEscala>().HasData(
                new ManifestoEscala { ManifestoId = 2, EscalaId = 301, DataVinculacao = Convert.ToDateTime("2025-08-22T10:00:00-03:00") }
            );
        }
    }
}