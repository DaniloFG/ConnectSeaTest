using ConnectSeaRepository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectSeaRepository.Mappings
{
    public class EscalaMap : IEntityTypeConfiguration<Escala>
    {
        public void Configure(EntityTypeBuilder<Escala> builder)
        {
            builder.ToTable("Manifesto");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Navio).HasColumnName("Navio");
            builder.Property(t => t.Porto).HasColumnName("Porto");
            builder.Property(t => t.Status).HasColumnName("Status");
        }
    }
}