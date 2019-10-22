using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilizaRH.Migrations
{
    public partial class verificandoalteracoesnobanco : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
