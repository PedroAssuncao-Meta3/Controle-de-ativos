using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Controle_Ativos.Migrations
{
    public partial class versao04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Colaboradores",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Colaboradores",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Colaboradores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Colaboradores",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereço",
                table: "Colaboradores",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Colaboradores",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Atributo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atributo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPatrimonio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPatrimonio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AtributoXTipoPatrimonio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AtributoId = table.Column<Guid>(nullable: false),
                    TipoPatrimonioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtributoXTipoPatrimonio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtributoXTipoPatrimonio_Atributo_AtributoId",
                        column: x => x.AtributoId,
                        principalTable: "Atributo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtributoXTipoPatrimonio_TipoPatrimonio_TipoPatrimonioId",
                        column: x => x.TipoPatrimonioId,
                        principalTable: "TipoPatrimonio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patrimonio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataAquisicao = table.Column<DateTime>(nullable: true),
                    DataSaida = table.Column<DateTime>(nullable: true),
                    NumeroPatrimonio = table.Column<string>(type: "varchar(200)", nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    TipoPatrimonioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimonio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patrimonio_TipoPatrimonio_TipoPatrimonioId",
                        column: x => x.TipoPatrimonioId,
                        principalTable: "TipoPatrimonio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtributoXPatrimonio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Conteudo = table.Column<string>(type: "varchar(200)", nullable: false),
                    AtributoId = table.Column<Guid>(nullable: false),
                    PatrimonioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtributoXPatrimonio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtributoXPatrimonio_Atributo_AtributoId",
                        column: x => x.AtributoId,
                        principalTable: "Atributo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtributoXPatrimonio_Patrimonio_PatrimonioId",
                        column: x => x.PatrimonioId,
                        principalTable: "Patrimonio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacaoPatrimonio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataIncio = table.Column<DateTime>(nullable: false),
                    DataFechamento = table.Column<DateTime>(nullable: true),
                    Observacao = table.Column<string>(type: "varchar(1000)", nullable: true),
                    ColaboradorId = table.Column<Guid>(nullable: false),
                    PatrimonioId = table.Column<Guid>(nullable: false),
                    TipoMovimentoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoPatrimonio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentacaoPatrimonio_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimentacaoPatrimonio_Patrimonio_PatrimonioId",
                        column: x => x.PatrimonioId,
                        principalTable: "Patrimonio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimentacaoPatrimonio_TipoMovimento_TipoMovimentoId",
                        column: x => x.TipoMovimentoId,
                        principalTable: "TipoMovimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtributoXPatrimonio_AtributoId",
                table: "AtributoXPatrimonio",
                column: "AtributoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtributoXPatrimonio_PatrimonioId",
                table: "AtributoXPatrimonio",
                column: "PatrimonioId");

            migrationBuilder.CreateIndex(
                name: "IX_AtributoXTipoPatrimonio_AtributoId",
                table: "AtributoXTipoPatrimonio",
                column: "AtributoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtributoXTipoPatrimonio_TipoPatrimonioId",
                table: "AtributoXTipoPatrimonio",
                column: "TipoPatrimonioId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoPatrimonio_ColaboradorId",
                table: "MovimentacaoPatrimonio",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoPatrimonio_PatrimonioId",
                table: "MovimentacaoPatrimonio",
                column: "PatrimonioId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoPatrimonio_TipoMovimentoId",
                table: "MovimentacaoPatrimonio",
                column: "TipoMovimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonio_TipoPatrimonioId",
                table: "Patrimonio",
                column: "TipoPatrimonioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtributoXPatrimonio");

            migrationBuilder.DropTable(
                name: "AtributoXTipoPatrimonio");

            migrationBuilder.DropTable(
                name: "MovimentacaoPatrimonio");

            migrationBuilder.DropTable(
                name: "Atributo");

            migrationBuilder.DropTable(
                name: "Patrimonio");

            migrationBuilder.DropTable(
                name: "TipoMovimento");

            migrationBuilder.DropTable(
                name: "TipoPatrimonio");

            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Endereço",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Colaboradores");
        }
    }
}
