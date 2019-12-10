CREATE TABLE [dbo].[clientsArtists] (
    [ID]           INT           IDENTITY (1000, 1) NOT NULL,
    [dtCreateDate] DATETIME2 (7) CONSTRAINT [DF_clientsArtists_dtCreateDate] DEFAULT (getdate()) NULL,
    [nClientsID]   INT           NULL,
    [nArtistID]    INT           NULL,
    CONSTRAINT [PK_clientsArtists] PRIMARY KEY CLUSTERED ([ID] ASC)
);

