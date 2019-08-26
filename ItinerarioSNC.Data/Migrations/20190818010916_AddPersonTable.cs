using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItinerarioSNC.Infra.Data.Migrations
{
    public partial class AddPersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "usuario");

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                schema: "usuario",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<int>(nullable: false),
                    SocialName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Department = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaFisica",
                schema: "usuario");
        }
    }
}
