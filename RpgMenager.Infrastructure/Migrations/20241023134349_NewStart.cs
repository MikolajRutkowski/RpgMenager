using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgMenager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RealFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathToImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hp = table.Column<int>(type: "int", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    AttitudeToAnotherCharacter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathToImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IndexsOfItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathToImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexsOfItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndexsOfItems_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Charges = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathToImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_IndexsOfItems_ListId",
                        column: x => x.ListId,
                        principalTable: "IndexsOfItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndexsOfStatistic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathToImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexsOfStatistic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndexsOfStatistic_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndexsOfStatistic_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    statisticsEnum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathToImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistics_IndexsOfStatistic_ListId",
                        column: x => x.ListId,
                        principalTable: "IndexsOfStatistic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_PlayerId",
                table: "Character",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexsOfItems_CharacterId",
                table: "IndexsOfItems",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexsOfItems_ItemId",
                table: "IndexsOfItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexsOfStatistic_CharacterId",
                table: "IndexsOfStatistic",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexsOfStatistic_ItemId",
                table: "IndexsOfStatistic",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ListId",
                table: "Items",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_ListId",
                table: "Statistics",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndexsOfItems_Items_ItemId",
                table: "IndexsOfItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Players_PlayerId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_IndexsOfItems_Character_CharacterId",
                table: "IndexsOfItems");

            migrationBuilder.DropForeignKey(
                name: "FK_IndexsOfItems_Items_ItemId",
                table: "IndexsOfItems");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "IndexsOfStatistic");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "IndexsOfItems");
        }
    }
}
