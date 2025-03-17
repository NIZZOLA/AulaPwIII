using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPessoas.Migrations
{
    /// <inheritdoc />
    public partial class fase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "PessoaModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "PessoaModel",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "PessoaModel",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "PessoaModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "PessoaModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PessoaModel",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "PessoaModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "PessoaModel",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "PessoaModel",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "PessoaModel",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "PessoaModel");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "PessoaModel");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "PessoaModel");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "PessoaModel");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "PessoaModel");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "PessoaModel");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "PessoaModel");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "PessoaModel");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "PessoaModel");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "PessoaModel");
        }
    }
}
