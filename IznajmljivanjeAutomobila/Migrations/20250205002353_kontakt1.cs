using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IznajmljivanjeAutomobila.Migrations
{
    /// <inheritdoc />
    public partial class kontakt1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$gXHrXhkwRHzJfzGDlpOF6uHW5wXylgWhgubtFa8L/hamGKOn0ALr2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$rQqnMlH1Mdx8XDmxElArqOuaBEayIGk.dPJbEm0HhUOrqJbxAPSvu");
        }
    }
}
