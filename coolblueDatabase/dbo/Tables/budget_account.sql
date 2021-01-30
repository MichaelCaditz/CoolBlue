CREATE TABLE [dbo].[budget_account] (
    [ID]         INT             IDENTITY (1000, 1) NOT NULL,
    [nBudgetID]  INT             NULL,
    [nAccountID] INT             NULL,
    [nAmount]    DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_budget_account] PRIMARY KEY CLUSTERED ([ID] ASC)
);

