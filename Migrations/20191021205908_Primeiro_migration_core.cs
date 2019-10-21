using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilizaRH.Migrations
{
    public partial class Primeiro_migration_core : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 255, nullable: true),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gratificacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(maxLength: 255, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Porcentagem = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gratificacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tela = table.Column<string>(maxLength: 50, nullable: true),
                    Caminho = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(maxLength: 20, nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CargoGratificacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoId = table.Column<int>(nullable: false),
                    GratificacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoGratificacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoGratificacoes_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CargoGratificacoes_Gratificacoes_GratificacaoId",
                        column: x => x.GratificacaoId,
                        principalTable: "Gratificacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visualizar = table.Column<bool>(nullable: false),
                    Adicionar = table.Column<bool>(nullable: false),
                    Editar = table.Column<bool>(nullable: false),
                    Excluir = table.Column<bool>(nullable: false),
                    TelaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissoes_Telas_TelaId",
                        column: x => x.TelaId,
                        principalTable: "Telas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GruposColaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grupo = table.Column<string>(maxLength: 255, nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    PermissaoId = table.Column<int>(nullable: false),
                    PermissoesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposColaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GruposColaboradores_Permissoes_PermissoesId",
                        column: x => x.PermissoesId,
                        principalTable: "Permissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Senha = table.Column<string>(maxLength: 50, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataSaida = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    GrupoId = table.Column<int>(nullable: false),
                    CargoIdNovo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cargos_CargoIdNovo",
                        column: x => x.CargoIdNovo,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_GruposColaboradores_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "GruposColaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoFerias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataFerias = table.Column<DateTime>(nullable: false),
                    PrevisaoFerias = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoFerias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoFerias_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoPromocoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoIdAnterior = table.Column<int>(nullable: true),
                    CargoIdNovo = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoPromocoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoPromocoes_Cargos_CargoIdAnterior",
                        column: x => x.CargoIdAnterior,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoPromocoes_Cargos_CargoIdNovo",
                        column: x => x.CargoIdNovo,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoPromocoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acao = table.Column<string>(maxLength: 255, nullable: true),
                    Descricao = table.Column<string>(maxLength: 2000, nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    TelaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_Telas_TelaId",
                        column: x => x.TelaId,
                        principalTable: "Telas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Log_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioTelefones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    TelefoneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTelefones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioTelefones_Telefones_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "Telefones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioTelefones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoGratificacoes_CargoId",
                table: "CargoGratificacoes",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoGratificacoes_GratificacaoId",
                table: "CargoGratificacoes",
                column: "GratificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_GruposColaboradores_PermissoesId",
                table: "GruposColaboradores",
                column: "PermissoesId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoFerias_UsuarioId",
                table: "HistoricoFerias",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoPromocoes_CargoIdAnterior",
                table: "HistoricoPromocoes",
                column: "CargoIdAnterior");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoPromocoes_CargoIdNovo",
                table: "HistoricoPromocoes",
                column: "CargoIdNovo");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoPromocoes_UsuarioId",
                table: "HistoricoPromocoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_TelaId",
                table: "Log",
                column: "TelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_UsuarioId",
                table: "Log",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissoes_TelaId",
                table: "Permissoes",
                column: "TelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CargoIdNovo",
                table: "Usuarios",
                column: "CargoIdNovo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_GrupoId",
                table: "Usuarios",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTelefones_TelefoneId",
                table: "UsuarioTelefones",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTelefones_UsuarioId",
                table: "UsuarioTelefones",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoGratificacoes");

            migrationBuilder.DropTable(
                name: "HistoricoFerias");

            migrationBuilder.DropTable(
                name: "HistoricoPromocoes");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "UsuarioTelefones");

            migrationBuilder.DropTable(
                name: "Gratificacoes");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "GruposColaboradores");

            migrationBuilder.DropTable(
                name: "Permissoes");

            migrationBuilder.DropTable(
                name: "Telas");
        }
    }
}
