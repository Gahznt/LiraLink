using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiraLink.Migrations
{
    /// <inheritdoc />
    public partial class addprofileinusertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "perfil",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "perfil",
                table: "Usuarios");
        }
    }
}
