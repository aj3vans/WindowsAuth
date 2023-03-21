USE [WindowsAuth.Database]
GO

/****** Object: SqlProcedure [dbo].[User-GetAll] Script Date: 21/03/2023 11:18:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User-GetAll]
AS
	SELECT * 
	FROM [dbo].[User]
RETURN 0
