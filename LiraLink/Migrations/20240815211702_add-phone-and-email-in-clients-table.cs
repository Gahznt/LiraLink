using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiraLink.Migrations
{
    /// <inheritdoc />
    public partial class addphoneandemailinclientstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "telefone",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "telefone",
                table: "Cliente");
        }
    }
}
