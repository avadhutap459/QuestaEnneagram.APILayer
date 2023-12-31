USE [QuestaEnneagram]
GO

/****** Object:  UserDefinedTableType [dbo].[CandidateBMTbl]    Script Date: 24-07-2023 10:10:26 ******/
DROP TYPE [dbo].[CandidateBMTbl]
GO

/****** Object:  UserDefinedTableType [dbo].[CandidateBMTbl]    Script Date: 24-07-2023 10:10:26 ******/
CREATE TYPE [dbo].[CandidateBMTbl] AS TABLE(
	[CandidateId] [int] NULL,
	[TestId] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Email] [nvarchar](300) NULL,
	[PhoneNumber] [nvarchar](100) NULL,
	[DateOfBirth] [datetime] NULL,
	[GenderId] [int] NULL,
	[GenderTxt] [varchar](100) NULL,
	[AgeId] [int] NULL,
	[StateId] [int] NULL,
	[CountryId] [int] NULL,
	[QualificationId] [int] NULL,
	[QualificationTxt] [varchar](100) NULL,
	[ProfessionalId] [int] NULL,
	[MaritalStatusId] [int] NULL,
	[EmployeeStatusId] [int] NULL,
	[ExperienceId] [int] NULL,
	[IsConnectedViaMobile] [bit] NULL,
	[IsConnectedViaDesktop] [bit] NULL,
	[IsConnectedViaTab] [bit] NULL,
	[BrowserName] [nvarchar](100) NULL,
	[IsOTPRequire] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsLogin] [bit] NULL,
	[MainType] [int] NULL,
	[AssessmentId] [int] NULL,
	[CMapHId] [int] NULL,
	[Industry] [nvarchar](max) NULL
)
GO


