using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IznajmljivanjeAutomobila.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEmailToUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$.ElNxZiX7ZWRq9fAZNlAO.LI8IAgGeyc15Jq5XH/59KOmWKCQq1Ey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$v3xuZidJdQH5gNgiOpWPFuVbXZui0Qw0UU5zhVNDFY2Dxg0ZD4hvq");
        }
    }
}
