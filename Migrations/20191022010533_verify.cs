using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilizaRH.Migrations
{
    public partial class verify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GruposColaboradores_Permissoes_PermissoesId",
                table: "GruposColaboradores");

            migrationBuilder.DropIndex(
                name: "IX_GruposColaboradores_PermissoesId",
                table: "GruposColaboradores");

            migrationBuilder.DropColumn(
                name: "PermissoesId",
                table: "GruposColaboradores");

            migrationBuilder.AddColumn<bool>(
                name: "Logado",
                table: "Usuarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "PermissaoId",
                table: "GruposColaboradores",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_GruposColaboradores_PermissaoId",
                table: "GruposColaboradores",
                column: "PermissaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_GruposColaboradores_Permissoes_PermissaoId",
                table: "GruposColaboradores",
                column: "PermissaoId",
                principalTable: "Permissoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GruposColaboradores_Permissoes_PermissaoId",
                table: "GruposColaboradores");

            migrationBuilder.DropIndex(
                name: "IX_GruposColaboradores_PermissaoId",
                table: "GruposColaboradores");

            migrationBuilder.DropColumn(
                name: "Logado",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "PermissaoId",
                table: "GruposColaboradores",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PermissoesId",
                table: "GruposColaboradores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GruposColaboradores_PermissoesId",
                table: "GruposColaboradores",
                column: "PermissoesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GruposColaboradores_Permissoes_PermissoesId",
                table: "GruposColaboradores",
                column: "PermissoesId",
                principalTable: "Permissoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
