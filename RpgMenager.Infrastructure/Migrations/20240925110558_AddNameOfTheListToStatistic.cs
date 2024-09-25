using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgMenager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNameOfTheListToStatistic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameOfTheList",
                table: "Statistics",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOfTheList",
                table: "Statistics");
        }
    }
}
