using Controle_Ativos.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Controle_Ativos.Data.Mappings
{
    public class PatrimonioMapping : IEntityTypeConfiguration<Patrimonio>
    {
        public void Configure(EntityTypeBuilder<Patrimonio> builder)
        {
            builder.HasKey(tab => tab.Id);

            builder.Property(tab => tab.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");            

            builder.Property(tab => tab.NumeroPatrimonio)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasMany(pai => pai.MovimentacaoPatrimonios)
                .WithOne(filho => filho.Patrimonio)
                .HasForeignKey(filho => filho.PatrimonioId);

            builder.HasMany(pai => pai.AtributoXPatrimonio)
                .WithOne(filho => filho.Patrimonio)
                .HasForeignKey(filho => filho.PatrimonioId);

            builder.ToTable("Patrimonio");
        }
    }
}
