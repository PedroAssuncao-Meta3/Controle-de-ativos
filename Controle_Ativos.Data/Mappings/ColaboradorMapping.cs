using Controle_Ativos.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Controle_Ativos.Data.Mappings
{
    public class ColaboradorMapping : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.HasKey(tab => tab.Id);

            builder.Property(tab => tab.Nome)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(tab => tab.CPF)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.ToTable("Colaboradores");
        }
    }
}
