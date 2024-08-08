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
                name: "BondTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BondTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Indicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndicatorTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indicators_Indicators_IndicatorTypeId",
                        column: x => x.IndicatorTypeId,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorTypesModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorTypesModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collaborators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AdmissionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BondTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collaborators_BondTypes_BondTypeId",
                        column: x => x.BondTypeId,
                        principalTable: "BondTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsModels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    WorkValue = table.Column<float>(type: "real", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsModels", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProjectsModels_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apportionments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    IndicatorId = table.Column<int>(type: "int", nullable: false),
                    Percentual = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apportionments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apportionments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apportionments_Indicators_IndicatorId",
                        column: x => x.IndicatorId,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apportionments_ProjectsModels_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectsModels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCollaborators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ParticipationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Performance = table.Column<int>(type: "int", nullable: false),
                    ProcessesDisciplinaryNumber = table.Column<int>(type: "int", nullable: false),
                    WarningSheetQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCollaborators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectCollaborators_Collaborators_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectCollaborators_ProjectsModels_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectsModels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndicatorId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Percentual = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectIndicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectIndicators_Indicators_IndicatorId",
                        column: x => x.IndicatorId,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectIndicators_ProjectsModels_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectsModels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apportionments_DepartmentId",
                table: "Apportionments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Apportionments_IndicatorId",
                table: "Apportionments",
                column: "IndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Apportionments_ProjectId",
                table: "Apportionments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborators_BondTypeId",
                table: "Collaborators",
                column: "BondTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_IndicatorTypeId",
                table: "Indicators",
                column: "IndicatorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCollaborators_CollaboratorId",
                table: "ProjectCollaborators",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCollaborators_ProjectId",
                table: "ProjectCollaborators",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectIndicators_IndicatorId",
                table: "ProjectIndicators",
                column: "IndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectIndicators_ProjectId",
                table: "ProjectIndicators",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsModels_ClientId",
                table: "ProjectsModels",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apportionments");

            migrationBuilder.DropTable(
                name: "IndicatorTypesModels");

            migrationBuilder.DropTable(
                name: "ProjectCollaborators");

            migrationBuilder.DropTable(
                name: "ProjectIndicators");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Collaborators");

            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.DropTable(
                name: "ProjectsModels");

            migrationBuilder.DropTable(
                name: "BondTypes");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
