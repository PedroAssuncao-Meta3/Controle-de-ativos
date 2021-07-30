using Controle_Ativos.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Controle_Ativos.Data.Mappings
{
    public class TipoPatrimonioMapping : IEntityTypeConfiguration<TipoPatrimonio>
    {
        public void Configure(EntityTypeBuilder<TipoPatrimonio> builder)
        {
            builder.HasKey(tab => tab.Id);

            builder.Property(tab => tab.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            
            builder.HasMany(pai => pai.AtributoXTipoPatrimonio)
                .WithOne(filho => filho.TipoPatrimonio)
                .HasForeignKey(filho => filho.TipoPatrimonioId);

            builder.HasMany(pai => pai.Patrimonio)
                .WithOne(filho => filho.TipoPatrimonio)
                .HasForeignKey(filho => filho.TipoPatrimonioId);


            builder.ToTable("TipoPatrimonio");
        }
    }
}
