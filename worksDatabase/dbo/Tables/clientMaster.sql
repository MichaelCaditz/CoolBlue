CREATE TABLE [dbo].[clientMaster] (
    [ID]             INT            IDENTITY (1000, 1) NOT NULL,
    [cNotes]         NVARCHAR (MAX) NULL,
    [dtCreateDate]   DATETIME       CONSTRAINT [DF_clientMaster_dtCreateDate] DEFAULT (getdate()) NULL,
    [dtModifyDate]   DATETIME       NULL,
    [cName]          NVARCHAR (255) NULL,
    [cDescription]   NVARCHAR (255) NULL,
    [nImportID]      INT            NULL,
    [nContactTypeID] INT            NULL,
    [nSalesRepID]    INT            NULL,
    [cImportDB]      NVARCHAR (50)  NULL,
    CONSTRAINT [PK_clientMaster] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (FILLFACTOR = 90)
);

