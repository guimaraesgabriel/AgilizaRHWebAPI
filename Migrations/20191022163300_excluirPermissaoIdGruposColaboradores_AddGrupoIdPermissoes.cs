using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilizaRH.Migrations
{
    public partial class excluirPermissaoIdGruposColaboradores_AddGrupoIdPermissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GruposColaboradores_Permissoes_PermissaoId",
                table: "GruposColaboradores");

            migrationBuilder.DropIndex(
                name: "IX_GruposColaboradores_PermissaoId",
                table: "GruposColaboradores");

            migrationBuilder.DropColumn(
                name: "PermissaoId",
                table: "GruposColaboradores");

            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "Permissoes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PermissoesId",
                table: "GruposColaboradores",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissoes_GrupoId",
                table: "Permissoes",
                column: "GrupoId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Permissoes_GruposColaboradores_GrupoId",
                table: "Permissoes",
                column: "GrupoId",
                principalTable: "GruposColaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GruposColaboradores_Permissoes_PermissoesId",
                table: "GruposColaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissoes_GruposColaboradores_GrupoId",
                table: "Permissoes");

            migrationBuilder.DropIndex(
                name: "IX_Permissoes_GrupoId",
                table: "Permissoes");

            migrationBuilder.DropIndex(
                name: "IX_GruposColaboradores_PermissoesId",
                table: "GruposColaboradores");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "PermissoesId",
                table: "GruposColaboradores");

            migrationBuilder.AddColumn<int>(
                name: "PermissaoId",
                table: "GruposColaboradores",
                type: "int",
                nullable: true);

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
    }
}
