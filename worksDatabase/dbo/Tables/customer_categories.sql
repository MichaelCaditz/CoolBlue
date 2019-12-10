CREATE TABLE [dbo].[customer_categories] (
    [customer_categories_id] INT            IDENTITY (1000, 1) NOT NULL,
    [foxpro_id]              CHAR (50)      NULL,
    [logon_staff_id]         INT            NULL,
    [transaction_staff_id]   INT            NULL,
    [create_date]            DATETIME       CONSTRAINT [DF_customer_categories_create_date] DEFAULT (getdate()) NULL,
    [modify_date]            DATETIME       NULL,
    [category]               NVARCHAR (255) NULL,
    [descrip]                VARCHAR (MAX)  NULL,
    [abbrev]                 CHAR (5)       NULL,
    [bFlag]                  BIT            NULL,
    CONSTRAINT [PK_customer_categories] PRIMARY KEY CLUSTERED ([customer_categories_id] ASC)
);

