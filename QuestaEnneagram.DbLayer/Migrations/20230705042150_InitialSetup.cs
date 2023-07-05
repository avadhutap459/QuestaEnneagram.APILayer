using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestaEnneagram.DbLayer.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mstAge",
                columns: table => new
                {
                    AgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstAge", x => x.AgeId);
                });

            migrationBuilder.CreateTable(
                name: "mstAssessmentSet",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalQuestion = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstAssessmentSet", x => x.AssessmentId);
                });

            migrationBuilder.CreateTable(
                name: "mstCompany",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstCompany", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "mstCountry",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstCountry", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "mstEmployeeStatus",
                columns: table => new
                {
                    EmploymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstEmployeeStatus", x => x.EmploymentId);
                });

            migrationBuilder.CreateTable(
                name: "mstExperence",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperenceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstExperence", x => x.ExperienceId);
                });

            migrationBuilder.CreateTable(
                name: "mstGender",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstGender", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "mstIndustry",
                columns: table => new
                {
                    IndustryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstIndustry", x => x.IndustryId);
                });

            migrationBuilder.CreateTable(
                name: "mstMaritalStatus",
                columns: table => new
                {
                    MaritalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaritalName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstMaritalStatus", x => x.MaritalId);
                });

            migrationBuilder.CreateTable(
                name: "mstProfessional",
                columns: table => new
                {
                    ProfessionalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionalName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstProfessional", x => x.ProfessionalId);
                });

            migrationBuilder.CreateTable(
                name: "mstQualification",
                columns: table => new
                {
                    QualificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualificationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstQualification", x => x.QualificationId);
                });

            migrationBuilder.CreateTable(
                name: "mstHumanResource",
                columns: table => new
                {
                    HrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HrName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HrMobileNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HrEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstHumanResource", x => x.HrId);
                    table.ForeignKey(
                        name: "FK_mstHumanResource_mstCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "mstCompany",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mstState",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstState", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_mstState_mstCountry_CountryId",
                        column: x => x.CountryId,
                        principalTable: "mstCountry",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TxnHrMapToCompany",
                columns: table => new
                {
                    CMapHId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    HrId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TxnHrMapToCompany", x => x.CMapHId);
                    table.ForeignKey(
                        name: "FK_TxnHrMapToCompany_mstCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "mstCompany",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TxnHrMapToCompany_mstHumanResource_HrId",
                        column: x => x.HrId,
                        principalTable: "mstHumanResource",
                        principalColumn: "HrId");
                });

            migrationBuilder.CreateTable(
                name: "txnCandidate",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    AgeId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    QualificationId = table.Column<int>(type: "int", nullable: false),
                    ProfessionalId = table.Column<int>(type: "int", nullable: false),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    EmployeeStatusId = table.Column<int>(type: "int", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    IsConnectedViaMobile = table.Column<bool>(type: "bit", nullable: true),
                    IsConnectedViaDesktop = table.Column<bool>(type: "bit", nullable: true),
                    IsConnectedViaTab = table.Column<bool>(type: "bit", nullable: true),
                    BrowserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsOTPRequire = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsLogin = table.Column<bool>(type: "bit", nullable: true),
                    MainType = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    CMapHId = table.Column<int>(type: "int", nullable: false),
                    HrMapToCompaniesCMapHId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_txnCandidate", x => x.CandidateId);
                    table.ForeignKey(
                        name: "FK_txnCandidate_mstAge_AgeId",
                        column: x => x.AgeId,
                        principalTable: "mstAge",
                        principalColumn: "AgeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_txnCandidate_mstAssessmentSet_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "mstAssessmentSet",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_txnCandidate_mstCountry_CountryId",
                        column: x => x.CountryId,
                        principalTable: "mstCountry",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_txnCandidate_mstEmployeeStatus_EmployeeStatusId",
                        column: x => x.EmployeeStatusId,
                        principalTable: "mstEmployeeStatus",
                        principalColumn: "EmploymentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_txnCandidate_mstExperence_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "mstExperence",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_txnCandidate_mstGender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "mstGender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_txnCandidate_mstMaritalStatus_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "mstMaritalStatus",
                        principalColumn: "MaritalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_txnCandidate_mstProfessional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "mstProfessional",
                        principalColumn: "ProfessionalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_txnCandidate_mstQualification_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "mstQualification",
                        principalColumn: "QualificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_txnCandidate_mstState_StateId",
                        column: x => x.StateId,
                        principalTable: "mstState",
                        principalColumn: "StateId");
                    table.ForeignKey(
                        name: "FK_txnCandidate_TxnHrMapToCompany_HrMapToCompaniesCMapHId",
                        column: x => x.HrMapToCompaniesCMapHId,
                        principalTable: "TxnHrMapToCompany",
                        principalColumn: "CMapHId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "txnIndustry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_txnIndustry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_txnIndustry_mstIndustry_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "mstIndustry",
                        principalColumn: "IndustryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_txnIndustry_txnCandidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "txnCandidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mstHumanResource_CompanyId",
                table: "mstHumanResource",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_mstState_CountryId",
                table: "mstState",
                column: "CountryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TxnHrMapToCompany_CompanyId",
                table: "TxnHrMapToCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TxnHrMapToCompany_HrId",
                table: "TxnHrMapToCompany",
                column: "HrId");

            migrationBuilder.CreateIndex(
                name: "IX_txnIndustry_CandidateId",
                table: "txnIndustry",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_txnIndustry_IndustryId",
                table: "txnIndustry",
                column: "IndustryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "txnIndustry");

            migrationBuilder.DropTable(
                name: "mstIndustry");

            migrationBuilder.DropTable(
                name: "txnCandidate");

            migrationBuilder.DropTable(
                name: "mstAge");

            migrationBuilder.DropTable(
                name: "mstAssessmentSet");

            migrationBuilder.DropTable(
                name: "mstEmployeeStatus");

            migrationBuilder.DropTable(
                name: "mstExperence");

            migrationBuilder.DropTable(
                name: "mstGender");

            migrationBuilder.DropTable(
                name: "mstMaritalStatus");

            migrationBuilder.DropTable(
                name: "mstProfessional");

            migrationBuilder.DropTable(
                name: "mstQualification");

            migrationBuilder.DropTable(
                name: "mstState");

            migrationBuilder.DropTable(
                name: "TxnHrMapToCompany");

            migrationBuilder.DropTable(
                name: "mstCountry");

            migrationBuilder.DropTable(
                name: "mstHumanResource");

            migrationBuilder.DropTable(
                name: "mstCompany");
        }
    }
}
