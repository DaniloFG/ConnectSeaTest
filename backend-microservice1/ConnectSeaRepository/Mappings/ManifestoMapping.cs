using ConnectSeaRepository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectSeaRepository.Mappings
{
    public class ManifestoMap : IEntityTypeConfiguration<Manifesto>
    {
        public void Configure(EntityTypeBuilder<Manifesto> builder)
        {
            builder.ToTable("Manifesto");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Numero).HasColumnName("Numero");
            builder.Property(t => t.Tipo).HasColumnName("Tipo");
            builder.Property(t => t.Navio).HasColumnName("Navio");
            builder.Property(t => t.Porto_origem).HasColumnName("Porto_origem");
            builder.Property(t => t.Porto_destino).HasColumnName("Porto_destino");
        }
    }
}