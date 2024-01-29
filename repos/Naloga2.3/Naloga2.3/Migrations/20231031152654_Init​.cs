using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Naloga2._3.Migrations
{
    /// <inheritdoc />
    public partial class Init​ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kavarne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    naziv = table.Column<string>(type: "TEXT", nullable: false),
                    kraj = table.Column<string>(type: "TEXT", nullable: false),
                    letoUstanovitve = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kavarne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Natakari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ime = table.Column<string>(type: "TEXT", nullable: false),
                    priimek = table.Column<string>(type: "TEXT", nullable: false),
                    letoRojstva = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Natakari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NatakariKavarn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    natakarId = table.Column<int>(type: "INTEGER", nullable: false),
                    kavarnaId = table.Column<int>(type: "INTEGER", nullable: false),
                    letoOd = table.Column<int>(type: "INTEGER", nullable: false),
                    letoDo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatakariKavarn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NatakariKavarn_Kavarne_kavarnaId",
                        column: x => x.kavarnaId,
                        principalTable: "Kavarne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NatakariKavarn_Natakari_natakarId",
                        column: x => x.natakarId,
                        principalTable: "Natakari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NatakariKavarn_kavarnaId",
                table: "NatakariKavarn",
                column: "kavarnaId");

            migrationBuilder.CreateIndex(
                name: "IX_NatakariKavarn_natakarId",
                table: "NatakariKavarn",
                column: "natakarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NatakariKavarn");

            migrationBuilder.DropTable(
                name: "Kavarne");

            migrationBuilder.DropTable(
                name: "Natakari");
        }
    }
}
