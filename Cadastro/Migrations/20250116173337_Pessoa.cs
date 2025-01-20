using Microsoft.EntityFrameworkCore.Migrations;

namespace Cadastro.Migrations
{
    public partial class Pessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nascimento = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<bool>(type: "bit", nullable: false),
                    Nacionalidade = table.Column<int>(type: "int", nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passaporte = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
