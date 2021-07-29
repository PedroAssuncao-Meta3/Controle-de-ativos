using Controle_Ativos.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Controle_Ativos.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(tab => tab.Id);

            builder.Property(tab => tab.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : N => Cliente : Colaborador
            builder.HasMany(pai => pai.Colaboradores)
                .WithOne(filho => filho.Cliente)
                .HasForeignKey(filho => filho.ClienteId);

            builder.ToTable("Clientes");
        }
    }
}
