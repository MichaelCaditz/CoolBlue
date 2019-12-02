CREATE TABLE [dbo].[tag] (
    [ID]            INT            IDENTITY (1000, 1) NOT NULL,
    [dtCreateDate]  DATETIME2 (7)  CONSTRAINT [DF_tag_dtCreateDate] DEFAULT (getdate()) NULL,
    [cName]         NVARCHAR (50)  NULL,
    [cDesc]         NVARCHAR (MAX) NULL,
    [bDeleted]      BIT            NULL,
    [dtDateDeleted] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_tag] PRIMARY KEY CLUSTERED ([ID] ASC)
);

