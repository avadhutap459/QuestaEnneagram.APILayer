using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestaEnneagram.DbLayer.Migrations
{
    public partial class Initialsetupforproduction : Migration
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstAge", x => x.AgeId);
                });

            migrationBuilder.CreateTable(
                name: "mstAssessmentModule",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PartialModuleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstAssessmentModule", x => x.ModuleId);
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
                name: "MstConfig",
                columns: table => new
                {
                    ConfigId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfigName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstConfig", x => x.ConfigId);
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
                name: "mstMailTemplate",
                columns: table => new
                {
                    MailTemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMTP_SenderNAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SMTP_USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMTP_PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONFIGSET = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FromMailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BCCMailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCMailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HOST = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PORT = table.Column<int>(type: "int", nullable: false),
                    BODY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstMailTemplate", x => x.MailTemplateId);
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
                name: "mstQuestionReponseType",
                columns: table => new
                {
                    ResponseTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstQuestionReponseType", x => x.ResponseTypeId);
                });

            migrationBuilder.CreateTable(
                name: "mstQuestionSubType",
                columns: table => new
                {
                    SubTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstQuestionSubType", x => x.SubTypeId);
                });

            migrationBuilder.CreateTable(
                name: "mstQuestionType",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstQuestionType", x => x.TypeId);
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
                    CMapHId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_txnCandidate", x => x.CandidateId);
                });

            migrationBuilder.CreateTable(
                name: "TxnAttachSetToModule",
                columns: table => new
                {
                    SetToModuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ModuleOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TxnAttachSetToModule", x => x.SetToModuleId);
                    table.ForeignKey(
                        name: "FK_TxnAttachSetToModule_mstAssessmentModule_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "mstAssessmentModule",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TxnAttachSetToModule_mstAssessmentSet_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "mstAssessmentSet",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "mstQuestion",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    ResponseTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstQuestion", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_mstQuestion_mstAssessmentModule_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "mstAssessmentModule",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mstQuestion_mstQuestionReponseType_ResponseTypeId",
                        column: x => x.ResponseTypeId,
                        principalTable: "mstQuestionReponseType",
                        principalColumn: "ResponseTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mstQuestion_mstQuestionType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "mstQuestionType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "txnCandidateTestDetails",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10000, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_txnCandidateTestDetails", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_txnCandidateTestDetails_txnCandidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "txnCandidate",
                        principalColumn: "CandidateId",
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

            migrationBuilder.CreateTable(
                name: "TxnHrMapToCompany",
                columns: table => new
                {
                    CMapHId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    HrId = table.Column<int>(type: "int", nullable: false),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    InitialMailId = table.Column<int>(type: "int", nullable: true),
                    FinalMailId = table.Column<int>(type: "int", nullable: true),
                    IsReportSentToCandidate = table.Column<bool>(type: "bit", nullable: false),
                    IsReportSentToHr = table.Column<bool>(type: "bit", nullable: false),
                    IsBulkLinkGenerationReq = table.Column<bool>(type: "bit", nullable: false),
                    CountOfLink = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_TxnHrMapToCompany_mstAssessmentSet_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "mstAssessmentSet",
                        principalColumn: "AssessmentId");
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
                name: "mstQuestionResponse",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ResponseNumber = table.Column<int>(type: "int", nullable: false),
                    ResponseText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weight = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstQuestionResponse", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_mstQuestionResponse_mstQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "mstQuestion",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mstQuestionResponse_mstQuestionSubType_SubTypeId",
                        column: x => x.SubTypeId,
                        principalTable: "mstQuestionSubType",
                        principalColumn: "SubTypeId");
                });

            migrationBuilder.CreateTable(
                name: "txnModuleWiseStatus",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_txnModuleWiseStatus", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_txnModuleWiseStatus_mstAssessmentModule_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "mstAssessmentModule",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_txnModuleWiseStatus_txnCandidateTestDetails_TestId",
                        column: x => x.TestId,
                        principalTable: "txnCandidateTestDetails",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "txnQuestion",
                columns: table => new
                {
                    TxnQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ImpactScore = table.Column<int>(type: "int", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    IsAnswer = table.Column<bool>(type: "bit", nullable: true),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    ResponseAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponseBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_txnQuestion", x => x.TxnQuestionId);
                    table.ForeignKey(
                        name: "FK_txnQuestion_mstAssessmentModule_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "mstAssessmentModule",
                        principalColumn: "ModuleId");
                    table.ForeignKey(
                        name: "FK_txnQuestion_mstQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "mstQuestion",
                        principalColumn: "QuestionId");
                    table.ForeignKey(
                        name: "FK_txnQuestion_txnCandidateTestDetails_TestId",
                        column: x => x.TestId,
                        principalTable: "txnCandidateTestDetails",
                        principalColumn: "TestId");
                });

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

            migrationBuilder.CreateTable(
                name: "txnQuestionResponse",
                columns: table => new
                {
                    TestQuestionResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ResponseId = table.Column<int>(type: "int", nullable: false),
                    TxnQuestionId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    DbAssessmentModuleModelModuleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_txnQuestionResponse", x => x.TestQuestionResponseId);
                    table.ForeignKey(
                        name: "FK_txnQuestionResponse_mstAssessmentModule_DbAssessmentModuleModelModuleId",
                        column: x => x.DbAssessmentModuleModelModuleId,
                        principalTable: "mstAssessmentModule",
                        principalColumn: "ModuleId");
                    table.ForeignKey(
                        name: "FK_txnQuestionResponse_mstQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "mstQuestion",
                        principalColumn: "QuestionId");
                    table.ForeignKey(
                        name: "FK_txnQuestionResponse_mstQuestionResponse_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "mstQuestionResponse",
                        principalColumn: "ResponseId");
                    table.ForeignKey(
                        name: "FK_txnQuestionResponse_txnCandidateTestDetails_TestId",
                        column: x => x.TestId,
                        principalTable: "txnCandidateTestDetails",
                        principalColumn: "TestId");
                    table.ForeignKey(
                        name: "FK_txnQuestionResponse_txnQuestion_TxnQuestionId",
                        column: x => x.TxnQuestionId,
                        principalTable: "txnQuestion",
                        principalColumn: "TxnQuestionId");
                });

            migrationBuilder.InsertData(
                table: "mstAge",
                columns: new[] { "AgeId", "AgeName" },
                values: new object[,]
                {
                    { 1, "18-21" },
                    { 2, "22-24" },
                    { 3, "25-34" },
                    { 4, "35-44" },
                    { 5, "45-54" },
                    { 6, "55-64" },
                    { 7, "65-74" },
                    { 8, "75 and above" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_mstHumanResource_CompanyId",
                table: "mstHumanResource",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_mstQuestion_ModuleId",
                table: "mstQuestion",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_mstQuestion_ResponseTypeId",
                table: "mstQuestion",
                column: "ResponseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_mstQuestion_TypeId",
                table: "mstQuestion",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_mstQuestionResponse_QuestionId",
                table: "mstQuestionResponse",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_mstQuestionResponse_SubTypeId",
                table: "mstQuestionResponse",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_mstState_CountryId",
                table: "mstState",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TxnAttachSetToModule_AssessmentId",
                table: "TxnAttachSetToModule",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TxnAttachSetToModule_ModuleId",
                table: "TxnAttachSetToModule",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_txnCandidateTestDetails_CandidateId",
                table: "txnCandidateTestDetails",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_TxnHrMapToCompany_AssessmentId",
                table: "TxnHrMapToCompany",
                column: "AssessmentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_txnModuleWiseStatus_ModuleId",
                table: "txnModuleWiseStatus",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_txnModuleWiseStatus_TestId",
                table: "txnModuleWiseStatus",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_txnQuestion_ModuleId",
                table: "txnQuestion",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_txnQuestion_QuestionId",
                table: "txnQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_txnQuestion_TestId",
                table: "txnQuestion",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_txnQuestionResponse_DbAssessmentModuleModelModuleId",
                table: "txnQuestionResponse",
                column: "DbAssessmentModuleModelModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_txnQuestionResponse_QuestionId",
                table: "txnQuestionResponse",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_txnQuestionResponse_ResponseId",
                table: "txnQuestionResponse",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_txnQuestionResponse_TestId",
                table: "txnQuestionResponse",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_txnQuestionResponse_TxnQuestionId",
                table: "txnQuestionResponse",
                column: "TxnQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TxnRefreshToken_TestId",
                table: "TxnRefreshToken",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mstAge");

            migrationBuilder.DropTable(
                name: "MstConfig");

            migrationBuilder.DropTable(
                name: "mstEmployeeStatus");

            migrationBuilder.DropTable(
                name: "mstExperence");

            migrationBuilder.DropTable(
                name: "mstGender");

            migrationBuilder.DropTable(
                name: "mstMailTemplate");

            migrationBuilder.DropTable(
                name: "mstMaritalStatus");

            migrationBuilder.DropTable(
                name: "mstProfessional");

            migrationBuilder.DropTable(
                name: "mstQualification");

            migrationBuilder.DropTable(
                name: "mstState");

            migrationBuilder.DropTable(
                name: "TxnAttachSetToModule");

            migrationBuilder.DropTable(
                name: "TxnHrMapToCompany");

            migrationBuilder.DropTable(
                name: "txnIndustry");

            migrationBuilder.DropTable(
                name: "txnModuleWiseStatus");

            migrationBuilder.DropTable(
                name: "txnQuestionResponse");

            migrationBuilder.DropTable(
                name: "TxnRefreshToken");

            migrationBuilder.DropTable(
                name: "mstCountry");

            migrationBuilder.DropTable(
                name: "mstAssessmentSet");

            migrationBuilder.DropTable(
                name: "mstHumanResource");

            migrationBuilder.DropTable(
                name: "mstIndustry");

            migrationBuilder.DropTable(
                name: "mstQuestionResponse");

            migrationBuilder.DropTable(
                name: "txnQuestion");

            migrationBuilder.DropTable(
                name: "mstCompany");

            migrationBuilder.DropTable(
                name: "mstQuestionSubType");

            migrationBuilder.DropTable(
                name: "mstQuestion");

            migrationBuilder.DropTable(
                name: "txnCandidateTestDetails");

            migrationBuilder.DropTable(
                name: "mstAssessmentModule");

            migrationBuilder.DropTable(
                name: "mstQuestionReponseType");

            migrationBuilder.DropTable(
                name: "mstQuestionType");

            migrationBuilder.DropTable(
                name: "txnCandidate");
        }
    }
}
