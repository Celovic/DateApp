using Microsoft.EntityFrameworkCore.Migrations;

namespace Tinder.Data.Migrations
{
    public partial class vlast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoveTBL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoveTBL",
                columns: table => new
                {
                    LoveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikePersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiketPersonId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoveTBL", x => x.LoveId);
                    table.ForeignKey(
                        name: "FK_LoveTBL_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoveTBL_TBLMatches_LiketPersonId",
                        column: x => x.LiketPersonId,
                        principalTable: "TBLMatches",
                        principalColumn: "MatchesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoveTBL_LiketPersonId",
                table: "LoveTBL",
                column: "LiketPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LoveTBL_PersonId",
                table: "LoveTBL",
                column: "PersonId");
        }
    }
}
