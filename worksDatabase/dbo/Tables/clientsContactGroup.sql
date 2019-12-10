CREATE TABLE [dbo].[clientsContactGroup] (
    [ID]              INT           IDENTITY (1000, 1) NOT NULL,
    [nClientsID]      INT           NOT NULL,
    [nContactGroupID] INT           NOT NULL,
    [dtCreateDate]    DATETIME2 (7) CONSTRAINT [DF_clientsContactGroup_dtCreateDate] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_clientsContactGroup] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_nClientsID]
    ON [dbo].[clientsContactGroup]([nClientsID] ASC)
    INCLUDE([nContactGroupID]);

