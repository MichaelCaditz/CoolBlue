CREATE TABLE [dbo].[budget] (
    [ID]            INT            IDENTITY (1000, 1) NOT NULL,
    [cName]         NVARCHAR (50)  NULL,
    [cDesc]         NVARCHAR (MAX) NULL,
    [cNote]         NVARCHAR (50)  NULL,
    [bDeleted]      BIT            NULL,
    [dtDateDeleted] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_budget] PRIMARY KEY CLUSTERED ([ID] ASC)
);

