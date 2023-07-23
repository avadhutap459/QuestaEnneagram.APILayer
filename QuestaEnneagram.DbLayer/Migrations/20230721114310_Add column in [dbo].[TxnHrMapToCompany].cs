using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestaEnneagram.DbLayer.Migrations
{
    public partial class AddcolumnindboTxnHrMapToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinalMailId",
                table: "TxnHrMapToCompany",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InitialMailId",
                table: "TxnHrMapToCompany",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReportSentToCandidate",
                table: "TxnHrMapToCompany",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReportSentToHr",
                table: "TxnHrMapToCompany",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalMailId",
                table: "TxnHrMapToCompany");

            migrationBuilder.DropColumn(
                name: "InitialMailId",
                table: "TxnHrMapToCompany");

            migrationBuilder.DropColumn(
                name: "IsReportSentToCandidate",
                table: "TxnHrMapToCompany");

            migrationBuilder.DropColumn(
                name: "IsReportSentToHr",
                table: "TxnHrMapToCompany");
        }
    }
}
