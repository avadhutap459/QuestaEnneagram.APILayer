using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestaEnneagram.DbLayer.Migrations
{
    public partial class AddedcolumnandforeignkeyinHrMapToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssessmentId",
                table: "TxnHrMapToCompany",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountOfLink",
                table: "TxnHrMapToCompany",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBulkLinkGenerationReq",
                table: "TxnHrMapToCompany",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_TxnHrMapToCompany_AssessmentId",
                table: "TxnHrMapToCompany",
                column: "AssessmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TxnHrMapToCompany_mstAssessmentSet_AssessmentId",
                table: "TxnHrMapToCompany",
                column: "AssessmentId",
                principalTable: "mstAssessmentSet",
                principalColumn: "AssessmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TxnHrMapToCompany_mstAssessmentSet_AssessmentId",
                table: "TxnHrMapToCompany");

            migrationBuilder.DropIndex(
                name: "IX_TxnHrMapToCompany_AssessmentId",
                table: "TxnHrMapToCompany");

            migrationBuilder.DropColumn(
                name: "AssessmentId",
                table: "TxnHrMapToCompany");

            migrationBuilder.DropColumn(
                name: "CountOfLink",
                table: "TxnHrMapToCompany");

            migrationBuilder.DropColumn(
                name: "IsBulkLinkGenerationReq",
                table: "TxnHrMapToCompany");
        }
    }
}
