CREATE TABLE [dbo].[mailGroup] (
    [ID]    INT            IDENTITY (1000, 1) NOT NULL,
    [cName] NVARCHAR (100) NULL,
    [cNote] NVARCHAR (500) NULL,
    CONSTRAINT [PK_mailGroup] PRIMARY KEY CLUSTERED ([ID] ASC)
);

