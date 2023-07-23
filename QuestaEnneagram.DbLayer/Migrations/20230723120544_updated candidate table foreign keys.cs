using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestaEnneagram.DbLayer.Migrations
{
    public partial class updatedcandidatetableforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_txnCandidate_mstAge_AgeId",
                table: "txnCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_txnCandidate_mstAssessmentSet_AssessmentId",
                table: "txnCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_txnCandidate_mstCountry_CountryId",
                table: "txnCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_txnCandidate_mstEmployeeStatus_EmployeeStatusId",
                table: "txnCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_txnCandidate_mstExperence_ExperienceId",
                table: "txnCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_txnCandidate_mstGender_GenderId",
                table: "txnCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_txnCandidate_mstMaritalStatus_MaritalStatusId",
                table: "txnCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_txnCandidate_mstProfessional_ProfessionalId",
                table: "txnCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_txnCandidate_mstQualification_QualificationId",
                table: "txnCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_txnCandidate_mstState_StateId",
                table: "txnCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_txnCandidate_TxnHrMapToCompany_HrMapToCompaniesCMapHId",
                table: "txnCandidate");

            migrationBuilder.DropIndex(
                name: "IX_txnCandidate_AgeId",
                table: "txnCandidate");

            migrationBuilder.DropIndex(
                name: "IX_txnCandidate_AssessmentId",
                table: "txnCandidate");

            migrationBuilder.DropIndex(
                name: "IX_txnCandidate_CountryId",
                table: "txnCandidate");

            migrationBuilder.DropIndex(
                name: "IX_txnCandidate_EmployeeStatusId",
                table: "txnCandidate");

            migrationBuilder.DropIndex(
                name: "IX_txnCandidate_ExperienceId",
                table: "txnCandidate");

            migrationBuilder.DropIndex(
                name: "IX_txnCandidate_GenderId",
                table: "txnCandidate");

            migrationBuilder.DropIndex(
                name: "IX_txnCandidate_HrMapToCompaniesCMapHId",
                table: "txnCandidate");

            migrationBuilder.DropIndex(
                name: "IX_txnCandidate_MaritalStatusId",
                table: "txnCandidate");

            migrationBuilder.DropIndex(
                name: "IX_txnCandidate_ProfessionalId",
                table: "txnCandidate");

            migrationBuilder.DropIndex(
                name: "IX_txnCandidate_QualificationId",
                table: "txnCandidate");

            migrationBuilder.DropIndex(
                name: "IX_txnCandidate_StateId",
                table: "txnCandidate");

            migrationBuilder.DropColumn(
                name: "HrMapToCompaniesCMapHId",
                table: "txnCandidate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HrMapToCompaniesCMapHId",
                table: "txnCandidate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_txnCandidate_AgeId",
                table: "txnCandidate",
                column: "AgeId");

            migrationBuilder.CreateIndex(
                name: "IX_txnCandidate_AssessmentId",
                table: "txnCandidate",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_txnCandidate_CountryId",
                table: "txnCandidate",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_txnCandidate_EmployeeStatusId",
                table: "txnCandidate",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_txnCandidate_ExperienceId",
                table: "txnCandidate",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_txnCandidate_GenderId",
                table: "txnCandidate",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_txnCandidate_HrMapToCompaniesCMapHId",
                table: "txnCandidate",
                column: "HrMapToCompaniesCMapHId");

            migrationBuilder.CreateIndex(
                name: "IX_txnCandidate_MaritalStatusId",
                table: "txnCandidate",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_txnCandidate_ProfessionalId",
                table: "txnCandidate",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_txnCandidate_QualificationId",
                table: "txnCandidate",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_txnCandidate_StateId",
                table: "txnCandidate",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_txnCandidate_mstAge_AgeId",
                table: "txnCandidate",
                column: "AgeId",
                principalTable: "mstAge",
                principalColumn: "AgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_txnCandidate_mstAssessmentSet_AssessmentId",
                table: "txnCandidate",
                column: "AssessmentId",
                principalTable: "mstAssessmentSet",
                principalColumn: "AssessmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_txnCandidate_mstCountry_CountryId",
                table: "txnCandidate",
                column: "CountryId",
                principalTable: "mstCountry",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_txnCandidate_mstEmployeeStatus_EmployeeStatusId",
                table: "txnCandidate",
                column: "EmployeeStatusId",
                principalTable: "mstEmployeeStatus",
                principalColumn: "EmploymentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_txnCandidate_mstExperence_ExperienceId",
                table: "txnCandidate",
                column: "ExperienceId",
                principalTable: "mstExperence",
                principalColumn: "ExperienceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_txnCandidate_mstGender_GenderId",
                table: "txnCandidate",
                column: "GenderId",
                principalTable: "mstGender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_txnCandidate_mstMaritalStatus_MaritalStatusId",
                table: "txnCandidate",
                column: "MaritalStatusId",
                principalTable: "mstMaritalStatus",
                principalColumn: "MaritalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_txnCandidate_mstProfessional_ProfessionalId",
                table: "txnCandidate",
                column: "ProfessionalId",
                principalTable: "mstProfessional",
                principalColumn: "ProfessionalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_txnCandidate_mstQualification_QualificationId",
                table: "txnCandidate",
                column: "QualificationId",
                principalTable: "mstQualification",
                principalColumn: "QualificationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_txnCandidate_mstState_StateId",
                table: "txnCandidate",
                column: "StateId",
                principalTable: "mstState",
                principalColumn: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_txnCandidate_TxnHrMapToCompany_HrMapToCompaniesCMapHId",
                table: "txnCandidate",
                column: "HrMapToCompaniesCMapHId",
                principalTable: "TxnHrMapToCompany",
                principalColumn: "CMapHId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
