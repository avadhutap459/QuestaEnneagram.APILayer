USE [QuestaEnneagram]
GO

/****** Object:  StoredProcedure [dbo].[UspGenerateAssessment]    Script Date: 24-07-2023 10:09:27 ******/
DROP PROCEDURE [dbo].[UspGenerateAssessment]
GO

/****** Object:  StoredProcedure [dbo].[UspGenerateAssessment]    Script Date: 24-07-2023 10:09:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UspGenerateAssessment] 
	@CandidateId INT,
	@TestId INT = NULL,
	@ModuleId INT = NULL,
	@AssessmentId INT = NULL,
	@OUTTestId INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @InModuleId INT
	BEGIN TRANSACTION;
	BEGIN TRY
		IF(@TestId IS NULL OR @TestId = 0)
		BEGIN

			INSERT INTO [dbo].[txnCandidateTestDetails](CandidateId,status,CreatedAt,LastModifiedAt)
			values(@CandidateId,'P',SWITCHOFFSET(SYSDATETIMEOFFSET(),'+05:30'),SWITCHOFFSET(SYSDATETIMEOFFSET(),'+05:30'))

			SET @TestId = SCOPE_IDENTITY();

			select TOP 1 @ModuleId = ModuleId from [dbo].[TxnAttachSetToModule] I WHERE I.AssessmentId = @AssessmentId and IsActive = 1 
			ORDER BY ModuleOrderId ASC

			DECLARE CurGetModuleIdByAssessmentId CURSOR FOR
			select ModuleId from [dbo].[TxnAttachSetToModule] I WHERE I.AssessmentId = @AssessmentId and IsActive = 1 
			ORDER BY ModuleOrderId ASC

			OPEN CurGetModuleIdByAssessmentId

			FETCH NEXT FROM CurGetModuleIdByAssessmentId     
			INTO @InModuleId
			WHILE @@FETCH_STATUS = 0
			BEGIN 

					INSERT INTO [dbo].[txnModuleWiseStatus](TestId,ModuleId,Status,CreatedAt,LastModifiedAt)
					VALUES(@TestId,@InModuleId,'NS',SWITCHOFFSET(SYSDATETIMEOFFSET(),'+05:30') ,SWITCHOFFSET(SYSDATETIMEOFFSET(),'+05:30'))

					FETCH NEXT FROM CurGetModuleIdByAssessmentId     
				INTO @InModuleId    
			END     
			CLOSE CurGetModuleIdByAssessmentId;    
			DEALLOCATE CurGetModuleIdByAssessmentId; 

			UPDATE [dbo].[txnModuleWiseStatus] Set Status = 'P' Where TestId = @TestId And ModuleId = @ModuleId

		END
		IF(@ModuleId = 1)
		BEGIN
			INSERT INTO [dbo].[txnQuestion](QuestionId,TestId,ModuleId)
			SELECT  i.QuestionId,@TestId,@ModuleId FROM mstQuestion i WITH(NOLOCK)
			where i.ModuleId = @ModuleId and i.IsActive = 1
			ORDER BY NEWID()
		END


		SELECT @OUTTestId = @TestId
		SELECT @OUTTestId

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


