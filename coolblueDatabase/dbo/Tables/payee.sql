CREATE TABLE [dbo].[payee] (
    [ID]            INT           IDENTITY (1000, 1) NOT NULL,
    [dtCreatedate]  DATETIME2 (7) NULL,
    [cName]         NVARCHAR (50) NULL,
    [nSubCatID]     INT           NULL,
    [nTagID]        INT           NULL,
    [nClassID]      INT           NULL,
    [nAmount]       MONEY         NULL,
    [bDeleted]      BIT           NULL,
    [dtDateDeleted] DATETIME2 (7) NULL,
    CONSTRAINT [PK_payee] PRIMARY KEY CLUSTERED ([ID] ASC)
);

