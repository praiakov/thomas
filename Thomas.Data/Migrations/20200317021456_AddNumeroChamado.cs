using Microsoft.EntityFrameworkCore.Migrations;

namespace Thomas.Data.Migrations
{
    public partial class AddNumeroChamado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroChamado",
                table: "Chamados",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroChamado",
                table: "Chamados");
        }
    }
}
