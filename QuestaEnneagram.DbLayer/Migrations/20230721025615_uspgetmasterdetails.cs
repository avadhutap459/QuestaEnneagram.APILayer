using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestaEnneagram.DbLayer.Migrations
{
    public partial class uspgetmasterdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[UspGetMasterDetails]
						AS
						BEGIN
						-- SET NOCOUNT ON added to prevent extra result sets from
						-- interfering with SELECT statements.
						SET NOCOUNT ON;
								BEGIN TRY

             	
											SELECT CountryId As Id,CountryName As Name,IsActive As IsActive FROM [dbo].[mstCountry] where IsActive = 1 ;
											SELECT QualificationId As Id,QualificationName As Name,IsActive  As IsActive FROM [dbo].[mstQualification] where IsActive = 1 ;
											SELECT ProfessionalId As Id,ProfessionalName As Name,IsActive As IsActive  FROM [dbo].[mstProfessional] where IsActive = 1 ;
											SELECT AgeId,AgeName,IsActive FROM [dbo].[mstAge] where IsActive = 1 ;
											SELECT GenderId As Id,GenderName As Name,IsActive As IsActive FROM [dbo].[mstGender] where IsActive = 1 ;
											SELECT MaritalId As Id,MaritalName As Name,IsActive As IsActive FROM [dbo].[mstMaritalStatus] where IsActive = 1 ;
											SELECT EmploymentId As Id,EmploymentName As Name,IsActive As IsActive FROM [dbo].[mstEmployeeStatus] where IsActive = 1 ;
											SELECT IndustryId As Id,IndustryName As Name,IsActive As IsActive FROM [dbo].[mstIndustry] where IsActive = 1 ;
											SELECT ExperienceId As Id,ExperenceName As Name,IsActive As IsActive FROM [dbo].[mstExperence] where IsActive = 1 ;

								   END TRY
								   BEGIN CATCH
										  SELECT
												  ERROR_NUMBER() As ErrorNumber,
												  ERROR_STATE() As ErrorState,
												  ERROR_SEVERITY() As ErrorSeverity,
												  ERROR_PROCEDURE() As ErrorProcedure,
												  ERROR_LINE() As ErrorLine,
												  ERROR_MESSAGE() ErrorMessage;

								   END CATCH
	

						END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

		}
    }
}
