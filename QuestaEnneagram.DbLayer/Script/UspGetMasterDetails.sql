USE [QuestaEnneagram]
GO

/****** Object:  StoredProcedure [dbo].[UspGetMasterDetails]    Script Date: 24-07-2023 10:09:03 ******/
DROP PROCEDURE [dbo].[UspGetMasterDetails]
GO

/****** Object:  StoredProcedure [dbo].[UspGetMasterDetails]    Script Date: 24-07-2023 10:09:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UspGetMasterDetails]
						AS
						BEGIN
						-- SET NOCOUNT ON added to prevent extra result sets from
						-- interfering with SELECT statements.
						SET NOCOUNT ON;
								BEGIN TRY

             	
											SELECT * FROM [dbo].[mstCountry] where IsActive = 1 ;
											SELECT * FROM [dbo].[mstQualification] where IsActive = 1 ;
											SELECT ProfessionalId As Id,ProfessionalName As Name,IsActive As IsActive  FROM [dbo].[mstProfessional] where IsActive = 1 ;
											SELECT AgeId As Id,AgeName As Name,IsActive As IsActive FROM [dbo].[mstAge] where IsActive = 1 ;
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
	

						END
GO


