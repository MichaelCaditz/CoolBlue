CREATE TABLE [dbo].[vendorMaster] (
    [ID]                    INT            IDENTITY (1000, 1) NOT NULL,
    [cNotes]                NVARCHAR (MAX) NULL,
    [dtCreateDate]          DATETIME       CONSTRAINT [DF_vendorsMaster_dtCreateDate] DEFAULT (getdate()) NULL,
    [dtModifyDate]          DATETIME       NULL,
    [cName]                 NVARCHAR (255) NULL,
    [cDescription]          NVARCHAR (255) NULL,
    [nGalProID]             INT            NULL,
    [cGalProRecordDocument] NVARCHAR (50)  NULL,
    [cSalesRep]             NVARCHAR (255) NULL,
    CONSTRAINT [PK_vendorsMaster] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (FILLFACTOR = 90)
);

