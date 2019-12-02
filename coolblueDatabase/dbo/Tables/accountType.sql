CREATE TABLE [dbo].[accountType] (
    [ID]            INT            IDENTITY (1000, 1) NOT NULL,
    [dtCreateDate]  DATETIME2 (7)  CONSTRAINT [DF_accountType_dtCreateDate] DEFAULT (getdate()) NULL,
    [cName]         NVARCHAR (50)  NULL,
    [cNote]         NVARCHAR (MAX) NULL,
    [bDeleted]      BIT            NULL,
    [dtDateDeleted] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_accountType] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_accountType_accountType] FOREIGN KEY ([ID]) REFERENCES [dbo].[accountType] ([ID])
);

