using Microsoft.EntityFrameworkCore.Migrations;

namespace Thomas.Data.Migrations
{
    public partial class AtulizadoFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Fornecedores",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TipoFornecedor",
                table: "Fornecedores",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "TipoFornecedor",
                table: "Fornecedores");
        }
    }
}
