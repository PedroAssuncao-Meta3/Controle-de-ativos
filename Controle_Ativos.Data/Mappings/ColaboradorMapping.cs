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

            builder.Property(tab => tab.Cargo)
                .IsRequired()
                .HasColumnType("varchar(200)");
            
            builder.Property(tab => tab.Email)
                .HasColumnType("varchar(200)");

            builder.Property(tab => tab.DataNascimento)
                .HasColumnType("Date()");
            
            builder.Property(tab => tab.Telefone)
                .HasColumnType("varchar(200)");

            builder.Property(tab => tab.Endereço)
                .HasColumnType("varchar(200)");

             builder.HasMany(pai => pai.MovimentacaoPatrimonios)
                .WithOne(filho => filho.Colaborador)
                .HasForeignKey(filho => filho.ColaboradorId);



            builder.ToTable("Colaboradores");
        }
    }
}
