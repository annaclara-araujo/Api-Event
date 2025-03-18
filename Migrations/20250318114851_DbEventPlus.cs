using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Event.Migrations
{
    /// <inheritdoc />
    public partial class DbEventPlus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    InstitucaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.InstitucaoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeEvento",
                columns: table => new
                {
                    TipoDeEventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoEvento = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeEvento", x => x.TipoDeEventoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeUsuario",
                columns: table => new
                {
                    TipoDeUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoUsuario = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeUsuario", x => x.TipoDeUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeEvento = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "DATE", nullable: false),
                    DescricaoEvento = table.Column<string>(type: "TEXT", nullable: false),
                    TipoDeEventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstituicaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_Evento_Instituicao_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicao",
                        principalColumn: "InstitucaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evento_TipoDeEvento_TipoDeEventoId",
                        column: x => x.TipoDeEventoId,
                        principalTable: "TipoDeEvento",
                        principalColumn: "TipoDeEventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeUsuario = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    EmailUsuario = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    SenhaUsuario = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    TipoDeUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoDeUsuario_TipoDeUsuarioId",
                        column: x => x.TipoDeUsuarioId,
                        principalTable: "TipoDeUsuario",
                        principalColumn: "TipoDeUsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioEvento",
                columns: table => new
                {
                    ComentarioEventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: false),
                    Exibe = table.Column<bool>(type: "BIT", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioEvento", x => x.ComentarioEventoId);
                    table.ForeignKey(
                        name: "FK_ComentarioEvento_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentarioEvento_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Presenca",
                columns: table => new
                {
                    PresencaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Situacao = table.Column<bool>(type: "BIT", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenca", x => x.PresencaId);
                    table.ForeignKey(
                        name: "FK_Presenca_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Presenca_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_EventoId",
                table: "ComentarioEvento",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_Exibe",
                table: "ComentarioEvento",
                column: "Exibe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_UsuarioId",
                table: "ComentarioEvento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_InstituicaoId",
                table: "Evento",
                column: "InstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_TipoDeEventoId",
                table: "Evento",
                column: "TipoDeEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicao_CNPJ",
                table: "Instituicao",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_EventoId",
                table: "Presenca",
                column: "EventoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_Situacao",
                table: "Presenca",
                column: "Situacao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_UsuarioId",
                table: "Presenca",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmailUsuario",
                table: "Usuario",
                column: "EmailUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoDeUsuarioId",
                table: "Usuario",
                column: "TipoDeUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioEvento");

            migrationBuilder.DropTable(
                name: "Presenca");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "TipoDeEvento");

            migrationBuilder.DropTable(
                name: "TipoDeUsuario");
        }
    }
}
