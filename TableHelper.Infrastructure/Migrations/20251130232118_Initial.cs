using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableHelper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "XwnNpcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    InitialManner = table.Column<string>(type: "TEXT", nullable: false),
                    DefaultDealOutcome = table.Column<string>(type: "TEXT", nullable: true),
                    TheirMotivation = table.Column<string>(type: "TEXT", nullable: false),
                    TheirWant = table.Column<string>(type: "TEXT", nullable: false),
                    TheirPower = table.Column<string>(type: "TEXT", nullable: false),
                    TheirHook = table.Column<string>(type: "TEXT", nullable: false),
                    TheirBackground = table.Column<string>(type: "TEXT", nullable: false),
                    TheirRoleInSociety = table.Column<string>(type: "TEXT", nullable: false),
                    TheirBiggestProblem = table.Column<string>(type: "TEXT", nullable: false),
                    AgeDescription = table.Column<string>(type: "TEXT", nullable: false),
                    TheirGreatestDesire = table.Column<string>(type: "TEXT", nullable: false),
                    MostObviousCharacterTrait = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XwnNpcs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XwnNpcs");
        }
    }
}
