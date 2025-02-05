using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IznajmljivanjeAutomobila.Migrations
{
    /// <inheritdoc />
    public partial class username : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Upiti",
                newName: "Username");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$v3xuZidJdQH5gNgiOpWPFuVbXZui0Qw0UU5zhVNDFY2Dxg0ZD4hvq");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Upiti",
                newName: "Email");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$5QmHA4tQQcWhLzjlyrPGdejkY0SvPzf6ZNp7QYmMYrlOeTAMmjGh2");
        }
    }
}
