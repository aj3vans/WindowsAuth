USE [WindowsAuth.Database]
GO

/****** Object: SqlProcedure [dbo].[UserPermission-GetBysAMAccountName] Script Date: 21/03/2023 11:19:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserPermission-GetBysAMAccountName]
@sAMAccountName VARCHAR(55)
AS
	SELECT UP.*
	FROM [dbo].[UserPermission] AS UP
		INNER JOIN [dbo].[User] AS U ON UP.[UserId] = U.[UserId]
	WHERE U.[sAMAccountName] = @sAMAccountName
RETURN 0
