using Controle_Ativos.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Controle_Ativos.Data.Mappings
{
    public class TipoMovimentoMapping : IEntityTypeConfiguration<TipoMovimentacao>
    {
        public void Configure(EntityTypeBuilder<TipoMovimentacao> builder)
        {
            builder.HasKey(tab => tab.Id);

            builder.Property(tab => tab.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            
            builder.HasMany(pai => pai.MovimentacaoPatrimonios)
                .WithOne(filho => filho.TipoMovimento)
                .HasForeignKey(filho => filho.TipoMovimentoId);

            builder.ToTable("TipoMovimento");
        }
    }
}
