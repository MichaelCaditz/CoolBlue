CREATE TABLE [dbo].[title] (
    [ID]           INT            IDENTITY (1000, 1) NOT NULL,
    [nImportID]    INT            NULL,
    [cName]        NVARCHAR (255) NULL,
    [cImportDB]    NVARCHAR (50)  NULL,
    [dtCreateDate] DATETIME2 (7)  DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_titles] PRIMARY KEY CLUSTERED ([ID] ASC)
);

