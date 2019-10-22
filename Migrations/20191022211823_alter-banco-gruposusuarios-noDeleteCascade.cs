using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilizaRH.Migrations
{
    public partial class alterbancogruposusuariosnoDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoGratificacoes_Cargos_CargoId",
                table: "CargoGratificacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_CargoGratificacoes_Gratificacoes_GratificacaoId",
                table: "CargoGratificacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoFerias_Usuarios_UsuarioId",
                table: "HistoricoFerias");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoPromocoes_Usuarios_UsuarioId",
                table: "HistoricoPromocoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_Telas_TelaId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_Usuarios_UsuarioId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissoes_GruposColaboradores_GrupoId",
                table: "Permissoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissoes_Telas_TelaId",
                table: "Permissoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Cargos_CargoIdNovo",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_GruposColaboradores_GrupoId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioTelefones_Telefones_TelefoneId",
                table: "UsuarioTelefones");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioTelefones_Usuarios_UsuarioId",
                table: "UsuarioTelefones");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CargoIdNovo",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GruposColaboradores",
                table: "GruposColaboradores");

            migrationBuilder.DropColumn(
                name: "CargoIdNovo",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "GruposColaboradores",
                newName: "GruposUsuarios");

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PrevisaoFerias",
                table: "HistoricoFerias",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GruposUsuarios",
                table: "GruposUsuarios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CargoId",
                table: "Usuarios",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoGratificacoes_Cargos_CargoId",
                table: "CargoGratificacoes",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CargoGratificacoes_Gratificacoes_GratificacaoId",
                table: "CargoGratificacoes",
                column: "GratificacaoId",
                principalTable: "Gratificacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoFerias_Usuarios_UsuarioId",
                table: "HistoricoFerias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoPromocoes_Usuarios_UsuarioId",
                table: "HistoricoPromocoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Telas_TelaId",
                table: "Log",
                column: "TelaId",
                principalTable: "Telas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Usuarios_UsuarioId",
                table: "Log",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissoes_GruposUsuarios_GrupoId",
                table: "Permissoes",
                column: "GrupoId",
                principalTable: "GruposUsuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissoes_Telas_TelaId",
                table: "Permissoes",
                column: "TelaId",
                principalTable: "Telas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Cargos_CargoId",
                table: "Usuarios",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_GruposUsuarios_GrupoId",
                table: "Usuarios",
                column: "GrupoId",
                principalTable: "GruposUsuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioTelefones_Telefones_TelefoneId",
                table: "UsuarioTelefones",
                column: "TelefoneId",
                principalTable: "Telefones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioTelefones_Usuarios_UsuarioId",
                table: "UsuarioTelefones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoGratificacoes_Cargos_CargoId",
                table: "CargoGratificacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_CargoGratificacoes_Gratificacoes_GratificacaoId",
                table: "CargoGratificacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoFerias_Usuarios_UsuarioId",
                table: "HistoricoFerias");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoPromocoes_Usuarios_UsuarioId",
                table: "HistoricoPromocoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_Telas_TelaId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_Usuarios_UsuarioId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissoes_GruposUsuarios_GrupoId",
                table: "Permissoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissoes_Telas_TelaId",
                table: "Permissoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Cargos_CargoId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_GruposUsuarios_GrupoId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioTelefones_Telefones_TelefoneId",
                table: "UsuarioTelefones");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioTelefones_Usuarios_UsuarioId",
                table: "UsuarioTelefones");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CargoId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GruposUsuarios",
                table: "GruposUsuarios");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "GruposUsuarios",
                newName: "GruposColaboradores");

            migrationBuilder.AddColumn<int>(
                name: "CargoIdNovo",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PrevisaoFerias",
                table: "HistoricoFerias",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GruposColaboradores",
                table: "GruposColaboradores",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CargoIdNovo",
                table: "Usuarios",
                column: "CargoIdNovo");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoGratificacoes_Cargos_CargoId",
                table: "CargoGratificacoes",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CargoGratificacoes_Gratificacoes_GratificacaoId",
                table: "CargoGratificacoes",
                column: "GratificacaoId",
                principalTable: "Gratificacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoFerias_Usuarios_UsuarioId",
                table: "HistoricoFerias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoPromocoes_Usuarios_UsuarioId",
                table: "HistoricoPromocoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Telas_TelaId",
                table: "Log",
                column: "TelaId",
                principalTable: "Telas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Usuarios_UsuarioId",
                table: "Log",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissoes_GruposColaboradores_GrupoId",
                table: "Permissoes",
                column: "GrupoId",
                principalTable: "GruposColaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissoes_Telas_TelaId",
                table: "Permissoes",
                column: "TelaId",
                principalTable: "Telas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Cargos_CargoIdNovo",
                table: "Usuarios",
                column: "CargoIdNovo",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_GruposColaboradores_GrupoId",
                table: "Usuarios",
                column: "GrupoId",
                principalTable: "GruposColaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioTelefones_Telefones_TelefoneId",
                table: "UsuarioTelefones",
                column: "TelefoneId",
                principalTable: "Telefones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioTelefones_Usuarios_UsuarioId",
                table: "UsuarioTelefones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
