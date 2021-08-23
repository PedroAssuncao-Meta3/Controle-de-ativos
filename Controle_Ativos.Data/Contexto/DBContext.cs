using Controle_Ativos.BLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Controle_Ativos.Data.Contexto
{
    public class DBContexto : DbContext
    {
        public DBContexto(DbContextOptions<DBContexto> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Colaborador> Colaboradores { get; set; }

        public DbSet<Patrimonio> Patrimonios { get; set; }

        public DbSet<MovimentacaoPatrimonio> MovimentacoesPatrimonios { get; set; }

        public DbSet<TipoMovimentacao> TiposMovimento { get; set; }
        
        public DbSet<TipoPatrimonio> TiposPatrimonio { get; set; }

        public DbSet<Atributo> Atributos { get; set; }
        
        public DbSet<AtributoXPatrimonio> AtributosXPatrimonios { get; set; }

        public DbSet<AtributoXTipoPatrimonio> AtributosXTiposPatrimonio { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Força o tamanho especifico para colunas mão mapeadas
            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(e => e.GetProperties()
            //        .Where(p => p.ClrType == typeof(string))))
            //    property.Relational().ColumnType = "varchar(100)";
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContexto).Assembly);

            //Desabilita todos os cascades das tabelas
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
