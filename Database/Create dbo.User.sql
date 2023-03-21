USE [WindowsAuth.Database]
GO

/****** Object: Table [dbo].[User] Script Date: 21/03/2023 11:15:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User] (
    [UserId]         INT           IDENTITY (1, 1) NOT NULL,
    [sAMAccountName] VARCHAR (55)  NOT NULL,
    [Name]           VARCHAR (155) NOT NULL,
    [DateOfBirth]    DATETIME      NOT NULL
);


