CREATE TABLE [dbo].[subCat] (
    [ID]            INT            IDENTITY (1000, 1) NOT NULL,
    [dtCreateDate]  DATETIME2 (7)  CONSTRAINT [DF_subCat_dtCreateDate] DEFAULT (getdate()) NULL,
    [nCatID]        INT            NULL,
    [cName]         NVARCHAR (50)  NULL,
    [cNotes]        NVARCHAR (MAX) NULL,
    [bDeleted]      BIT            NULL,
    [dtDateDeleted] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_subCat] PRIMARY KEY CLUSTERED ([ID] ASC)
);

