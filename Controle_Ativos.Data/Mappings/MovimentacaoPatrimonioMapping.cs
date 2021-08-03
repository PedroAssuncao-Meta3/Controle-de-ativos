using Controle_Ativos.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Controle_Ativos.Data.Mappings
{
    public class MovimentacaoPatrimonioMapping : IEntityTypeConfiguration<MovimentacaoPatrimonio>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoPatrimonio> builder)
        {
            builder.HasKey(tab => tab.Id);

            builder.Property(tab => tab.Observacao)
               .HasColumnType("varchar(1000)");
                       
            builder.ToTable("MovimentacaoPatrimonio");
        }
    }
}
