CREATE TABLE [dbo].[line] (
    [ID]            INT           IDENTITY (1000, 1) NOT NULL,
    [dtCreateDate]  DATETIME2 (7) CONSTRAINT [DF_line_dtCreateDate] DEFAULT (getdate()) NULL,
    [cNote]         NVARCHAR (50) NULL,
    [nAccountID]    INT           NULL,
    [dtTransDate]   DATETIME2 (7) NULL,
    [bDeleted]      BIT           NULL,
    [dtDateDeleted] DATETIME2 (7) NULL,
    CONSTRAINT [PK_line] PRIMARY KEY CLUSTERED ([ID] ASC)
);

