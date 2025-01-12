using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Costium.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ExpenseType_UserId",
                table: "ExpenseType",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseType_Users_UserId",
                table: "ExpenseType",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseType_Users_UserId",
                table: "ExpenseType");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseType_UserId",
                table: "ExpenseType");
        }
    }
}
