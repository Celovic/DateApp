using Microsoft.EntityFrameworkCore.Migrations;

namespace Tinder.Data.Migrations
{
    public partial class loves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLMatches_AspNetUsers_UserId",
                table: "TBLMatches");

            migrationBuilder.DropIndex(
                name: "IX_TBLMatches_UserId",
                table: "TBLMatches");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TBLMatches");

            migrationBuilder.AlterColumn<string>(
                name: "PersonId",
                table: "TBLMatches",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LoveTBL",
                columns: table => new
                {
                    LoveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LiketPersonId = table.Column<int>(type: "int", nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikePersonName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "IX_TBLMatches_PersonId",
                table: "TBLMatches",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LoveTBL_LiketPersonId",
                table: "LoveTBL",
                column: "LiketPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LoveTBL_PersonId",
                table: "LoveTBL",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLMatches_AspNetUsers_PersonId",
                table: "TBLMatches",
                column: "PersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLMatches_AspNetUsers_PersonId",
                table: "TBLMatches");

            migrationBuilder.DropTable(
                name: "LoveTBL");

            migrationBuilder.DropIndex(
                name: "IX_TBLMatches_PersonId",
                table: "TBLMatches");

            migrationBuilder.AlterColumn<string>(
                name: "PersonId",
                table: "TBLMatches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TBLMatches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLMatches_UserId",
                table: "TBLMatches",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLMatches_AspNetUsers_UserId",
                table: "TBLMatches",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
