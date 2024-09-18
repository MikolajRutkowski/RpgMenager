using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgMenager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPathToImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathToImage",
                table: "Statistics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathToImage",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathToImage",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathToImage",
                table: "Character",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathToImage",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "PathToImage",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PathToImage",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PathToImage",
                table: "Character");
        }
    }
}
