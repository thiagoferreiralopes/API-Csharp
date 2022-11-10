using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiViagens.Migrations
{
    public partial class AtualizaClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "cliente");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "cliente",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cliente",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "cliente",
                newName: "email");

             migrationBuilder.RenameColumn(
                name: "Senha_Cliente",
                table: "cliente",
                newName: "Senha_Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cliente",
                table: "cliente",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_cliente",
                table: "cliente");

            migrationBuilder.RenameTable(
                name: "cliente",
                newName: "clientes");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "clientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "clientes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "data_nascimento",
                table: "clientes",
                newName: "DataNascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "Id");
        }
    }
}
