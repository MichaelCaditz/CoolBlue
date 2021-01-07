CREATE TABLE [dbo].[accountingPeriod] (
    [ID]            INT            IDENTITY (1000, 1) NOT NULL,
    [dtCreateDate]  DATETIME2 (7)  CONSTRAINT [DF_accountingPeriod_dtCreateDate] DEFAULT (getdate()) NULL,
    [cName]         NVARCHAR (50)  NULL,
    [dtBeginDate]   DATETIME2 (7)  NULL,
    [dtEndDate]     DATETIME2 (7)  NULL,
    [cNote]         NVARCHAR (MAX) NULL,
    [bDeleted]      BIT            NULL,
    [dtDateDeleted] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_accountingPeriods] PRIMARY KEY CLUSTERED ([ID] ASC)
);

