﻿CREATE TABLE [dbo].[split] (
    [ID]               INT             IDENTITY (1000, 1) NOT NULL,
    [dtCreateDate]     DATETIME2 (7)   CONSTRAINT [DF_split_dtCreateDate] DEFAULT (getdate()) NULL,
    [nLineID]          INT             NULL,
    [nSubCatID]        INT             NULL,
    [nAmount]          NUMERIC (18, 2) NULL,
    [nVendorsID]       INT             NULL,
    [cMemo]            TEXT            NULL,
    [nTagID]           INT             NULL,
    [nClassID]         INT             NULL,
    [nAccountID]       INT             NULL,
    [nOriginalAmount]  MONEY           NULL,
    [nCurrencyID]      INT             NULL,
    [bDeleted]         BIT             NULL,
    [dtDateDeleted]    DATETIME2 (7)   NULL,
    [bXfer]            BIT             NULL,
    [nXferAccountID]   INT             NULL,
    [nAccountID_C]     INT             NULL,
    [nAccountID_D]     INT             NULL,
    [nAmount_C]        NUMERIC (18, 2) NULL,
    [nAmount_D]        NUMERIC (18, 2) NULL,
    [nEntryCurrencyID] INT             NULL,
    [nAmount_C_Native] NUMERIC (18, 2) NULL,
    [nAmount_D_Native] NUMERIC (18, 2) NULL,
    CONSTRAINT [PK_split] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_split_line] FOREIGN KEY ([nLineID]) REFERENCES [dbo].[line] ([ID])
);



