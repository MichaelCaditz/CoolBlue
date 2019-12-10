CREATE TABLE [dbo].[contactGroup] (
    [ID]           INT            IDENTITY (1000, 1) NOT NULL,
    [cName]        NVARCHAR (255) NULL,
    [nImportID]    INT            NULL,
    [cNote]        NVARCHAR (MAX) NULL,
    [dtCreateDate] DATETIME2 (7)  DEFAULT (getdate()) NULL,
    [cImportDB]    NVARCHAR (50)  NULL,
    [bIsStaff]     BIT            NULL,
    CONSTRAINT [PK_contactGroup] PRIMARY KEY CLUSTERED ([ID] ASC)
);

