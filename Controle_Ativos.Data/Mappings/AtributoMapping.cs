using Controle_Ativos.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Controle_Ativos.Data.Mappings
{
    public class AtributoMapping : IEntityTypeConfiguration<Atributo>
    {
        public void Configure(EntityTypeBuilder<Atributo> builder)
        {
            builder.HasKey(tab => tab.Id);

            builder.Property(tab => tab.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            
            builder.HasMany(pai => pai.AtributoXPatrimonios)
                .WithOne(filho => filho.Atributo)
                .HasForeignKey(filho => filho.AtributoId);
            
            builder.HasMany(pai => pai.AtributoXTipoPatrimonios)
                .WithOne(filho => filho.Atributo)
                .HasForeignKey(filho => filho.AtributoId);



            builder.ToTable("Atributo");
        }
    }
}
