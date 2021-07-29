using Microsoft.EntityFrameworkCore.Migrations;

namespace Controle_Ativos.Migrations
{
    public partial class versao03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Colaboradores",
                type: "varchar(14)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Colaboradores");
        }
    }
}
