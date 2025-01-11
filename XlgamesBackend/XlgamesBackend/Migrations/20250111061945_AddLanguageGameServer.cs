using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XlgamesBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguageGameServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameServer_Name",
                table: "Languages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GameServer_Unlimited",
                table: "Languages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$6fP/SEuGhmjX4I46IEGbru7oJT3BXSQ4urEFCKDX14f9JwvIgM6pi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameServer_Name",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "GameServer_Unlimited",
                table: "Languages");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$7kcwh6TIVymeKyxCW1Kgf.TeSRjAo1jVHR6vAeSCTIQlsej7phrz.");
        }
    }
}
