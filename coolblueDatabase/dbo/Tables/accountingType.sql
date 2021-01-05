CREATE TABLE [dbo].[accountingType] (
    [ID]            INT            IDENTITY (1000, 1) NOT NULL,
    [cName]         NVARCHAR (50)  NULL,
    [cNote]         NVARCHAR (MAX) NULL,
    [bDeleted]      BIT            NULL,
    [dtDateDeleted] DATETIME2 (7)  NULL,
    [dtCreateDate]  DATETIME2 (7)  CONSTRAINT [DF_accountingType_dtCreateDate] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_accountingType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

