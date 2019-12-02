CREATE TABLE [dbo].[currencyConversion] (
    [ID]    INT             IDENTITY (1000, 1) NOT NULL,
    [n1000] NUMERIC (20, 4) NULL,
    [n1001] NUMERIC (20, 4) NULL,
    [nFrom] INT             NULL,
    CONSTRAINT [PK_currencyConversion] PRIMARY KEY CLUSTERED ([ID] ASC)
);

