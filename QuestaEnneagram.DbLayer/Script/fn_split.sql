USE [QuestaEnneagram]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_split]    Script Date: 24-07-2023 10:11:01 ******/
DROP FUNCTION [dbo].[fn_split]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_split]    Script Date: 24-07-2023 10:11:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create FUNCTION [dbo].[fn_split](  
@delimited NVARCHAR(MAX),  
@delimiter NVARCHAR(100)  
) RETURNS @table TABLE (id INT IDENTITY(1,1), [value] NVARCHAR(MAX))  
AS  
BEGIN  
DECLARE @xml XML  
SET @xml = N'<t>' + REPLACE(@delimited,@delimiter,'</t><t>') + '</t>'  
INSERT INTO @table([value])  
SELECT r.value('.','Nvarchar(MAX)') as item  
FROM @xml.nodes('/t') as records(r)  
RETURN  
END 
GO


