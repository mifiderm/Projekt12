using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IznajmljivanjeAutomobila.Migrations
{
    /// <inheritdoc />
    public partial class logiranje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutomobilId",
                table: "Upiti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash" },
                values: new object[] { 1, "mia.vekic82@gmail.com", "$2a$10$eo9XU0vCafDF7KdM9uYeFO89E0IJmKe6tNNTsMipv8.0IxcMmm1Vu" });

            migrationBuilder.CreateIndex(
                name: "IX_Upiti_AutomobilId",
                table: "Upiti",
                column: "AutomobilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Upiti_Automobili_AutomobilId",
                table: "Upiti",
                column: "AutomobilId",
                principalTable: "Automobili",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Upiti_Automobili_AutomobilId",
                table: "Upiti");

            migrationBuilder.DropIndex(
                name: "IX_Upiti_AutomobilId",
                table: "Upiti");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "AutomobilId",
                table: "Upiti");
        }
    }
}
