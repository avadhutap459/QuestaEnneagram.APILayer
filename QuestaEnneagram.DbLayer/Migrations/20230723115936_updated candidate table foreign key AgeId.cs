using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestaEnneagram.DbLayer.Migrations
{
    public partial class updatedcandidatetableforeignkeyAgeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_txnCandidate_mstAge_AgeId",
                table: "txnCandidate");

            migrationBuilder.AddForeignKey(
                name: "FK_txnCandidate_mstAge_AgeId",
                table: "txnCandidate",
                column: "AgeId",
                principalTable: "mstAge",
                principalColumn: "AgeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_txnCandidate_mstAge_AgeId",
                table: "txnCandidate");

            migrationBuilder.AddForeignKey(
                name: "FK_txnCandidate_mstAge_AgeId",
                table: "txnCandidate",
                column: "AgeId",
                principalTable: "mstAge",
                principalColumn: "AgeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
