using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableHelper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddXwnNpcsIndicies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_XwnNpcs_FirstName",
                table: "XwnNpcs",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_XwnNpcs_Gender",
                table: "XwnNpcs",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_XwnNpcs_Surname",
                table: "XwnNpcs",
                column: "Surname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_XwnNpcs_FirstName",
                table: "XwnNpcs");

            migrationBuilder.DropIndex(
                name: "IX_XwnNpcs_Gender",
                table: "XwnNpcs");

            migrationBuilder.DropIndex(
                name: "IX_XwnNpcs_Surname",
                table: "XwnNpcs");
        }
    }
}
