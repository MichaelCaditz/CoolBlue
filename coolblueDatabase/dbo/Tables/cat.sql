CREATE TABLE [dbo].[cat] (
    [ID]            INT            IDENTITY (1000, 1) NOT NULL,
    [dtCreateDate]  DATETIME2 (7)  CONSTRAINT [DF_cat_dtCreateDate] DEFAULT (getdate()) NULL,
    [cName]         NVARCHAR (50)  NULL,
    [bDeleted]      BIT            NULL,
    [dtDateDeleted] DATETIME2 (7)  NULL,
    [cNote]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_cat] PRIMARY KEY CLUSTERED ([ID] ASC)
);

