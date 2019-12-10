CREATE TABLE [dbo].[contactType] (
    [ID]           INT            IDENTITY (1000, 1) NOT NULL,
    [nImportID]    INT            NULL,
    [cName]        NVARCHAR (255) NULL,
    [bIsStaff]     BIT            NULL,
    [cImportDB]    NVARCHAR (50)  NULL,
    [dtCreateDate] DATETIME2 (7)  DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_contactType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

