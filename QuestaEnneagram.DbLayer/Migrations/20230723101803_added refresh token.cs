using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestaEnneagram.DbLayer.Migrations
{
    public partial class addedrefreshtoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TxnRefreshToken",
                columns: table => new
                {
                    RefreshTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TxnRefreshToken", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_TxnRefreshToken_txnCandidateTestDetails_TestId",
                        column: x => x.TestId,
                        principalTable: "txnCandidateTestDetails",
                        principalColumn: "TestId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TxnRefreshToken_TestId",
                table: "TxnRefreshToken",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TxnRefreshToken");
        }
    }
}
