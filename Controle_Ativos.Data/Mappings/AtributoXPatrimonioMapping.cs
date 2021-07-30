using Controle_Ativos.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Controle_Ativos.Data.Mappings
{
    public class AtributoxPatrimonioMapping : IEntityTypeConfiguration<AtributoXPatrimonio>
    {
        public void Configure(EntityTypeBuilder<AtributoXPatrimonio> builder)
        {
            builder.HasKey(tab => tab.Id);

            builder.Property(tab => tab.Conteudo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            
            builder.ToTable("AtributoXPatrimonio");
        }
    }
}
