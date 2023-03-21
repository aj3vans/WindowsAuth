USE [WindowsAuth.Database]
GO

/****** Object: SqlProcedure [dbo].[UserPermission-GetById] Script Date: 21/03/2023 11:19:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserPermission-GetById]
@UserId INT
AS
	SELECT *
	FROM [dbo].[UserPermission]
	WHERE UserId = @UserId
RETURN 0
