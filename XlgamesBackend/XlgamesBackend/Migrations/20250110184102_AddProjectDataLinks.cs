using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XlgamesBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectDataLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contacts",
                table: "ProjectDatas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GameHosting",
                table: "ProjectDatas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalAccount",
                table: "ProjectDatas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ProjectDatas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Contacts", "GameHosting", "PersonalAccount" },
                values: new object[] { "...", "...", "..." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$7kcwh6TIVymeKyxCW1Kgf.TeSRjAo1jVHR6vAeSCTIQlsej7phrz.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contacts",
                table: "ProjectDatas");

            migrationBuilder.DropColumn(
                name: "GameHosting",
                table: "ProjectDatas");

            migrationBuilder.DropColumn(
                name: "PersonalAccount",
                table: "ProjectDatas");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$bgHUqExdIIkcJX1t93nTzuy2lNTaTL5goIzw5DgD2m3kvcwRe0hYe");
        }
    }
}
