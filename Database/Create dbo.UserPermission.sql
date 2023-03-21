USE [WindowsAuth.Database]
GO

/****** Object: Table [dbo].[UserPermission] Script Date: 21/03/2023 11:10:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserPermission] (
    [PermissionId] INT           IDENTITY (1, 1) NOT NULL,
    [UserId]       INT           NOT NULL,
    [Type]         VARCHAR (10)  NOT NULL,
    [Name]         VARCHAR (195) NOT NULL
);


