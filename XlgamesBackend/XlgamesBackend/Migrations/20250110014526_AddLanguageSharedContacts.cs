using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XlgamesBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguageSharedContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Shared_Email",
                table: "Languages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Shared_INN",
                table: "Languages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Shared_IP",
                table: "Languages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Shared_OGRNIP",
                table: "Languages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Shared_PhoneNumber",
                table: "Languages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$bgHUqExdIIkcJX1t93nTzuy2lNTaTL5goIzw5DgD2m3kvcwRe0hYe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shared_Email",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Shared_INN",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Shared_IP",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Shared_OGRNIP",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Shared_PhoneNumber",
                table: "Languages");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$EuWGvWkRsZYbmyfaP1HiWukPYs3HJ/0STq/CH/pz83./0FdXgAmA.");
        }
    }
}
