using Microsoft.EntityFrameworkCore.Migrations;

namespace Cadastro.Migrations
{
    public partial class People : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Pessoa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Pessoa");
        }
    }
}
