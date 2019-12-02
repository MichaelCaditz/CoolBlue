CREATE TABLE [dbo].[currency] (
    [ID]            INT            IDENTITY (1000, 1) NOT NULL,
    [cName]         NVARCHAR (50)  NULL,
    [bDeleted]      BIT            NULL,
    [dtCreateDate]  DATETIME2 (7)  CONSTRAINT [DF_currency_dtCreateDate] DEFAULT (getdate()) NULL,
    [cNote]         NVARCHAR (MAX) NULL,
    [dtDateDeleted] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_currency] PRIMARY KEY CLUSTERED ([ID] ASC)
);

