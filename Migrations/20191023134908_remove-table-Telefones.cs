using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilizaRH.Migrations
{
    public partial class removetableTelefones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioTelefones_Telefones_TelefoneId",
                table: "UsuarioTelefones");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioTelefones_TelefoneId",
                table: "UsuarioTelefones");

            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "UsuarioTelefones");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "UsuarioTelefones",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "UsuarioTelefones",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "UsuarioTelefones");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "UsuarioTelefones");

            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "UsuarioTelefones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTelefones_TelefoneId",
                table: "UsuarioTelefones",
                column: "TelefoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioTelefones_Telefones_TelefoneId",
                table: "UsuarioTelefones",
                column: "TelefoneId",
                principalTable: "Telefones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
