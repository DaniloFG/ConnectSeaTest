using ConnectSeaRepository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectSeaRepository.Mappings
{
    public class ManifestoEscalaMap : IEntityTypeConfiguration<ManifestoEscala>
    {
        public void Configure(EntityTypeBuilder<ManifestoEscala> builder)
        {
            builder.ToTable("Manifesto");
            builder.HasKey(t => t.ManifestoId);
            builder.HasKey(t => t.EscalaId);
            builder.Property(t => t.DataVinculacao).HasColumnName("DataVinculacao");
        }
    }
}