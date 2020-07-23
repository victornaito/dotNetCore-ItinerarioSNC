using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItinerarioSNC.Infra.Data.Migrations
{
    public partial class AddColumnsAnaliseAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnaliseAgendamento",
                schema: "usuario",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(nullable: false),
                    Carro = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    NomeColaborador = table.Column<string>(nullable: false),
                    Placa = table.Column<string>(nullable: false),
                    UnidadeAlocacao = table.Column<string>(nullable: false),
                    DataCriacaoAgendamento = table.Column<DateTime>(nullable: false),
                    PessoaFisicaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaliseAgendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnaliseAgendamento_PessoaFisica_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalSchema: "usuario",
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnaliseAgendamento_PessoaFisicaId",
                schema: "usuario",
                table: "AnaliseAgendamento",
                column: "PessoaFisicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnaliseAgendamento",
                schema: "usuario");
        }
    }
}
