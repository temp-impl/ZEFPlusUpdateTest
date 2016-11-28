USE [master]
GO

CREATE  DATABASE [SampleDb]
GO

Use [SampleDb]

CREATE TABLE [dbo].[Book] (
    [Id] INT NOT NULL,
    [Title] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
