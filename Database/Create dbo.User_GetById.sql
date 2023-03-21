USE [WindowsAuth.Database]
GO

/****** Object: SqlProcedure [dbo].[User-GetById] Script Date: 21/03/2023 11:18:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[User-GetById]
@UserId INT
AS
	SELECT * 
	FROM [dbo].[User]
	WHERE UserId = @UserId
RETURN 0
