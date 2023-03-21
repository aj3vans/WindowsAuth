USE [WindowsAuth.Database]
GO

/****** Object: SqlProcedure [dbo].[User-GetBysAMAccountName] Script Date: 21/03/2023 11:18:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User-GetBysAMAccountName]
@sAMAccountName VARCHAR(55) 
AS
	SELECT *
	FROM [dbo].[User]
	WHERE sAMAccountName = @sAMAccountName
RETURN 0
