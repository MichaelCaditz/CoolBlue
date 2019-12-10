CREATE TABLE [dbo].[contactContactGroup] (
    [ID]              INT           IDENTITY (1000, 1) NOT NULL,
    [nContactID]      INT           NOT NULL,
    [nContactGroupID] INT           NOT NULL,
    [dtCreateDate]    DATETIME2 (7) CONSTRAINT [DF_contactContactGroup_dtCreateDate] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_contactContactGroup] PRIMARY KEY CLUSTERED ([ID] ASC)
);

