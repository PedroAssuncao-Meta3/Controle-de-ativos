using Controle_Ativos.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Controle_Ativos.Data.Mappings
{
    public class AtributoXTipoPatrimonioMapping : IEntityTypeConfiguration<AtributoXTipoPatrimonio>
    {
        public void Configure(EntityTypeBuilder<AtributoXTipoPatrimonio> builder)
        {
            builder.HasKey(tab => tab.Id);


          
            builder.ToTable("AtributoXTipoPatrimonio");
        }
    }
}
