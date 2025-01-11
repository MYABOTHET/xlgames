using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace XlgamesBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddGameServers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameServerItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LinkName = table.Column<string>(type: "text", nullable: false),
                    Src = table.Column<string>(type: "text", nullable: false),
                    isPopular = table.Column<bool>(type: "boolean", nullable: false),
                    CPU = table.Column<string>(type: "text", nullable: false),
                    RAM = table.Column<string>(type: "text", nullable: false),
                    Disk = table.Column<string>(type: "text", nullable: false),
                    Slots = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameServerItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameServerDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Head = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    GameServerDataPoints = table.Column<string[]>(type: "text[]", nullable: false),
                    GameServerItemId = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameServerDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameServerDatas_GameServerItems_GameServerItemId",
                        column: x => x.GameServerItemId,
                        principalTable: "GameServerItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameServerDatas_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$FCEADmvy10lxEE0tmIDWU.E6AF1mr/Q6QdQGWQf1f2AyBVeZUWqF2");

            migrationBuilder.CreateIndex(
                name: "IX_GameServerDatas_GameServerItemId",
                table: "GameServerDatas",
                column: "GameServerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_GameServerDatas_LanguageId",
                table: "GameServerDatas",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_GameServerItems_Name",
                table: "GameServerItems",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameServerDatas");

            migrationBuilder.DropTable(
                name: "GameServerItems");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$6fP/SEuGhmjX4I46IEGbru7oJT3BXSQ4urEFCKDX14f9JwvIgM6pi");
        }
    }
}
