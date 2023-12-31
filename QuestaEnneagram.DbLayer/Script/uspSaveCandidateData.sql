USE [QuestaEnneagram]
GO

/****** Object:  StoredProcedure [dbo].[uspSaveCandidateData]    Script Date: 24-07-2023 10:10:00 ******/
DROP PROCEDURE [dbo].[uspSaveCandidateData]
GO

/****** Object:  StoredProcedure [dbo].[uspSaveCandidateData]    Script Date: 24-07-2023 10:10:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspSaveCandidateData] 
	@CandidateBMTbl  dbo.CandidateBMTbl READONLY  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @GenderId INT
	DECLARE @QualificationId INT
	DECLARE @CandidateID INT
	DECLARE @GenderTxt VARCHAR(100)
	DECLARE @QualificationTxt VARCHAR(100)
	DECLARE @IndustryTxt NVARCHAR(max)
	BEGIN TRANSACTION;
	BEGIN TRY
		
		SELECT @GenderId = GenderId,
				@CandidateID = CandidateId,
				@GenderTxt = GenderTxt,
				@QualificationId = QualificationId,
				@QualificationTxt = QualificationTxt,
				@IndustryTxt  = Industry
		FROM @CandidateBMTbl


		IF(@GenderId = 3)
		BEGIN 
			INSERT INTO mstGender(GenderName,IsActive)
			VALUES(@GenderTxt,1)
			SET @GenderId = SCOPE_IDENTITY();
		END

		IF(@QualificationId = 8)
		BEGIN
			INSERT INTO mstQualification(QualificationName,IsActive)
			VALUES(@QualificationTxt,1)
			SET @QualificationId = SCOPE_IDENTITY();
		END

		DELETE FROM txnIndustry where CandidateId = @CandidateID

		INSERT INTO txnIndustry(IndustryId,CandidateId)
		SELECT MI.IndustryId,@CandidateID FROM [dbo].[fn_split](@IndustryTxt,',') I 
				INNER JOIN mstIndustry MI on I.value = MI.IndustryName

		UPDATE TC
		SET TC.Title = TblC.Title,
		TC.FirstName = TblC.FirstName,
		TC.LastName = TblC.LastName, 
		TC.Email = TblC.Email,
		TC.PhoneNumber = TblC.PhoneNumber,
		TC.DateOfBirth = TblC.DateOfBirth,
		TC.GenderId = @GenderId,
		TC.AgeId = TblC.AgeId,
		TC.CountryId = TblC.CountryId,
		TC.StateId = TblC.StateId,
		TC.QualificationId = @QualificationId,
		TC.ProfessionalId = TblC.ProfessionalId,
		TC.MaritalStatusId = TblC.MaritalStatusId,
		TC.EmployeeStatusId = TblC.EmployeeStatusId,
		TC.ExperienceId = TblC.ExperienceId,
		TC.IsConnectedViaMobile= TblC.IsConnectedViaMobile,
		TC.IsConnectedViaDesktop = TblC.IsConnectedViaDesktop,
		TC.IsConnectedViaTab = TblC.IsConnectedViaTab,
		TC.BrowserName = TblC.BrowserName,
		TC.IsOTPRequire = 0,
		TC.IsActive = TblC.IsActive,
		TC.IsLogin = TblC.IsLogin,
		TC.MainType = TblC.MainType,
		--TC.CreatedAt = TblC.CreatedAt,
		TC.LastModified = GETDATE(),
		TC.AssessmentId = TblC.AssessmentId,
		TC.CMapHId = TblC.CMapHId
		FROM txnCandidate TC
		INNER JOIN @CandidateBMTbl TblC ON TC.CandidateId = TblC.CandidateId


		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
              SELECT
                    ERROR_NUMBER() As ErrorNumber,
                    ERROR_STATE() As ErrorState,
                    ERROR_SEVERITY() As ErrorSeverity,
                    ERROR_PROCEDURE() As ErrorProcedure,
                    ERROR_LINE() As ErrorLine,
                    ERROR_MESSAGE() ErrorMessage;

              IF @@TRANCOUNT > 0
              BEGIN
                      ROLLBACK TRANSACTION;
              END
       END CATCH
END
GO


