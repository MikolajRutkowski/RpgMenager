using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgMenager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class makelist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Character_CharacterId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Character_CharacterId",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "NameOfTheList",
                table: "Statistics");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Statistics",
                newName: "ListId");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_CharacterId",
                table: "Statistics",
                newName: "IX_Statistics_ListId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Items",
                newName: "ListOfItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CharacterId",
                table: "Items",
                newName: "IX_Items_ListOfItemId");

            migrationBuilder.AddColumn<int>(
                name: "ListId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IndexOfItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathToImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listOfItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_listOfItems_Character_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndexOfStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathToImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfStatistics_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListOfStatistics_Items_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_listOfItems_OwnerId",
                table: "IndexOfItems",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfStatistics_CharacterId",
                table: "IndexOfStatistics",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfStatistics_OwnerId",
                table: "IndexOfStatistics",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_listOfItems_ListOfItemId",
                table: "Items",
                column: "ListOfItemId",
                principalTable: "IndexOfItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_ListOfStatistics_ListId",
                table: "Statistics",
                column: "ListId",
                principalTable: "IndexOfStatistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_listOfItems_ListOfItemId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_ListOfStatistics_ListId",
                table: "Statistics");

            migrationBuilder.DropTable(
                name: "IndexOfItems");

            migrationBuilder.DropTable(
                name: "IndexOfStatistics");

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ListId",
                table: "Statistics",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_ListId",
                table: "Statistics",
                newName: "IX_Statistics_CharacterId");

            migrationBuilder.RenameColumn(
                name: "ListOfItemId",
                table: "Items",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ListOfItemId",
                table: "Items",
                newName: "IX_Items_CharacterId");

            migrationBuilder.AddColumn<string>(
                name: "NameOfTheList",
                table: "Statistics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Character_CharacterId",
                table: "Items",
                column: "OwnerId",
                principalTable: "Character",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Character_CharacterId",
                table: "Statistics",
                column: "OwnerId",
                principalTable: "Character",
                principalColumn: "Id");
        }
    }
}
