using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IznajmljivanjeAutomobila.Migrations
{
    /// <inheritdoc />
    public partial class izmjene : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Upiti_Automobili_AutomobilId",
                table: "Upiti");

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Upiti",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "AutomobilId",
                table: "Upiti",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$NOPjT0qYLxXeB4uy2ylvJOV5qPwkD8WMADXhDSFgwBy8uY5TZFNiy");

            migrationBuilder.AddForeignKey(
                name: "FK_Upiti_Automobili_AutomobilId",
                table: "Upiti",
                column: "AutomobilId",
                principalTable: "Automobili",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Upiti_Automobili_AutomobilId",
                table: "Upiti");

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Upiti",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AutomobilId",
                table: "Upiti",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$10$.ElNxZiX7ZWRq9fAZNlAO.LI8IAgGeyc15Jq5XH/59KOmWKCQq1Ey");

            migrationBuilder.AddForeignKey(
                name: "FK_Upiti_Automobili_AutomobilId",
                table: "Upiti",
                column: "AutomobilId",
                principalTable: "Automobili",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
