CREATE TABLE [dbo].[associateContact] (
    [ID]                 INT            IDENTITY (1000, 1) NOT NULL,
    [dtCreateDate]       DATETIME2 (7)  CONSTRAINT [DF_associateContact_dtCreateDate] DEFAULT (getdate()) NULL,
    [primaryContactID]   INT            NULL,
    [associateContactID] INT            NULL,
    [cNote]              NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_associateContact] PRIMARY KEY CLUSTERED ([ID] ASC)
);

