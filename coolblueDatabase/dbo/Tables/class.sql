CREATE TABLE [dbo].[class] (
    [ID]            INT            IDENTITY (1000, 1) NOT NULL,
    [cName]         NVARCHAR (50)  NULL,
    [cDesc]         NVARCHAR (MAX) NULL,
    [dtCreateDate]  DATETIME2 (7)  CONSTRAINT [DF_class_dtCreateDate] DEFAULT (getdate()) NULL,
    [bDeleted]      BIT            NULL,
    [dtDateDeleted] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_class] PRIMARY KEY CLUSTERED ([ID] ASC)
);

