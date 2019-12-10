CREATE TABLE [dbo].[clientMasterMailGroup] (
    [ID]              INT           IDENTITY (1000, 1) NOT NULL,
    [nClientMasterID] INT           NULL,
    [nMailGroupID]    INT           NULL,
    [dtCreateDate]    DATETIME2 (7) CONSTRAINT [DF_clientMasterMailGroup_dtCreateDate] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_clientMasterMailGroup] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_nClientMasterID]
    ON [dbo].[clientMasterMailGroup]([nClientMasterID] ASC)
    INCLUDE([nMailGroupID]);


GO
CREATE NONCLUSTERED INDEX [IX_nMailGroupID]
    ON [dbo].[clientMasterMailGroup]([nMailGroupID] ASC)
    INCLUDE([nClientMasterID]);

