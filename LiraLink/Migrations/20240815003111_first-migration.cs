using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiraLink.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoIndicadores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIndicadores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoVinculo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVinculo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cargo_id = table.Column<int>(type: "int", nullable: false),
                    senha = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    perfil = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cargos_cargo_id",
                        column: x => x.cargo_id,
                        principalTable: "Cargos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    porcentagem_aplicavel_valor_remunerado = table.Column<float>(type: "real", nullable: false),
                    porcentagem_aplicavel_participacao = table.Column<float>(type: "real", nullable: false),
                    porcentagem_aplicavel_premio = table.Column<float>(type: "real", nullable: false),
                    porcentagem_desempenho_deficiente = table.Column<float>(type: "real", nullable: false),
                    porcentagem_processo_disciplinar = table.Column<float>(type: "real", nullable: false),
                    porcentagem_ficha_advertencia = table.Column<float>(type: "real", nullable: false),
                    valor_obra = table.Column<float>(type: "real", nullable: false),
                    numero_fatura = table.Column<float>(type: "real", nullable: false),
                    criado_por = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Projetos_Cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Indicadores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_indicador_id = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicadores", x => x.id);
                    table.ForeignKey(
                        name: "FK_Indicadores_TipoIndicadores_tipo_indicador_id",
                        column: x => x.tipo_indicador_id,
                        principalTable: "TipoIndicadores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departamento_id = table.Column<int>(type: "int", nullable: false),
                    data_admissao = table.Column<DateOnly>(type: "date", nullable: false),
                    tipo_vinculo_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Departamentos_departamento_id",
                        column: x => x.departamento_id,
                        principalTable: "Departamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaboradores_TipoVinculo_tipo_vinculo_id",
                        column: x => x.tipo_vinculo_id,
                        principalTable: "TipoVinculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjetoDepartamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projeto_id = table.Column<int>(type: "int", nullable: false),
                    departamento_id = table.Column<int>(type: "int", nullable: false),
                    distribuicao_valor_participacao = table.Column<float>(type: "real", nullable: false),
                    distribuicao_valor_premio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoDepartamentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProjetoDepartamentos_Departamentos_departamento_id",
                        column: x => x.departamento_id,
                        principalTable: "Departamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetoDepartamentos_Projetos_projeto_id",
                        column: x => x.projeto_id,
                        principalTable: "Projetos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjetoIndicadores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    indicador_id = table.Column<int>(type: "int", nullable: false),
                    projeto_id = table.Column<int>(type: "int", nullable: false),
                    percentual = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoIndicadores", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProjetoIndicadores_Indicadores_indicador_id",
                        column: x => x.indicador_id,
                        principalTable: "Indicadores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetoIndicadores_Projetos_projeto_id",
                        column: x => x.projeto_id,
                        principalTable: "Projetos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rateios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departamento_id = table.Column<int>(type: "int", nullable: false),
                    projeto_id = table.Column<int>(type: "int", nullable: false),
                    indicador_id = table.Column<int>(type: "int", nullable: false),
                    percentual = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rateios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rateios_Departamentos_departamento_id",
                        column: x => x.departamento_id,
                        principalTable: "Departamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rateios_Indicadores_indicador_id",
                        column: x => x.indicador_id,
                        principalTable: "Indicadores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rateios_Projetos_projeto_id",
                        column: x => x.projeto_id,
                        principalTable: "Projetos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjetoColaboradores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    colaborador_id = table.Column<int>(type: "int", nullable: false),
                    projeto_id = table.Column<int>(type: "int", nullable: false),
                    estado_participacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    performance = table.Column<int>(type: "int", nullable: false),
                    quantidade_processos_disciplinar = table.Column<int>(type: "int", nullable: false),
                    quantidade_ficha_advertencia = table.Column<int>(type: "int", nullable: false),
                    desempenho_deficiente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    processo_disciplinar = table.Column<int>(type: "int", nullable: true),
                    fichas_advertencia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoColaboradores", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProjetoColaboradores_Colaboradores_colaborador_id",
                        column: x => x.colaborador_id,
                        principalTable: "Colaboradores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetoColaboradores_Projetos_projeto_id",
                        column: x => x.projeto_id,
                        principalTable: "Projetos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_departamento_id",
                table: "Colaboradores",
                column: "departamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_tipo_vinculo_id",
                table: "Colaboradores",
                column: "tipo_vinculo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Indicadores_tipo_indicador_id",
                table: "Indicadores",
                column: "tipo_indicador_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoColaboradores_colaborador_id",
                table: "ProjetoColaboradores",
                column: "colaborador_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoColaboradores_projeto_id",
                table: "ProjetoColaboradores",
                column: "projeto_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoDepartamentos_departamento_id",
                table: "ProjetoDepartamentos",
                column: "departamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoDepartamentos_projeto_id",
                table: "ProjetoDepartamentos",
                column: "projeto_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoIndicadores_indicador_id",
                table: "ProjetoIndicadores",
                column: "indicador_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoIndicadores_projeto_id",
                table: "ProjetoIndicadores",
                column: "projeto_id");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_cliente_id",
                table: "Projetos",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rateios_departamento_id",
                table: "Rateios",
                column: "departamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rateios_indicador_id",
                table: "Rateios",
                column: "indicador_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rateios_projeto_id",
                table: "Rateios",
                column: "projeto_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_cargo_id",
                table: "Usuarios",
                column: "cargo_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjetoColaboradores");

            migrationBuilder.DropTable(
                name: "ProjetoDepartamentos");

            migrationBuilder.DropTable(
                name: "ProjetoIndicadores");

            migrationBuilder.DropTable(
                name: "Rateios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Indicadores");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "TipoVinculo");

            migrationBuilder.DropTable(
                name: "TipoIndicadores");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
