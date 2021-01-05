CREATE TABLE [dbo].[account] (
    [ID]                 INT             IDENTITY (1000, 1) NOT NULL,
    [dtCreateDate]       DATETIME2 (7)   CONSTRAINT [DF_account_dtCreateDate] DEFAULT (getdate()) NULL,
    [cName]              NVARCHAR (50)   NULL,
    [nAccountTypeID]     INT             NULL,
    [cDesc]              NVARCHAR (50)   NULL,
    [cComment]           NVARCHAR (MAX)  NULL,
    [nCurrencyID]        INT             NULL,
    [cNote]              NVARCHAR (MAX)  NULL,
    [bDeleted]           BIT             NULL,
    [dtDateDeleted]      DATETIME2 (7)   NULL,
    [nCatID]             INT             NULL,
    [pin_Encrypted]      VARBINARY (128) NULL,
    [expiry_Encrypted]   VARBINARY (128) NULL,
    [CV_Encrypted]       VARBINARY (128) NULL,
    [acctNum_Encrypted]  VARBINARY (128) NULL,
    [cardNum_Encrypted]  VARBINARY (128) NULL,
    [cInstitutionNum]    NVARCHAR (50)   NULL,
    [cTransitNum]        NVARCHAR (50)   NULL,
    [cSwiftCode]         NVARCHAR (50)   NULL,
    [nCreditLimit]       DECIMAL (14, 2) NULL,
    [cContactName]       NVARCHAR (50)   NULL,
    [cURL]               NVARCHAR (MAX)  NULL,
    [username_Encrypted] VARBINARY (128) NULL,
    [password_Encrypted] VARBINARY (128) NULL,
    [cContactEmail]      NVARCHAR (MAX)  NULL,
    [cContactPhone]      NVARCHAR (50)   NULL,
    CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_account_accountType] FOREIGN KEY ([nAccountTypeID]) REFERENCES [dbo].[accountType] ([ID])
);




GO
CREATE NONCLUSTERED INDEX [IX_account]
    ON [dbo].[account]([ID] ASC);

