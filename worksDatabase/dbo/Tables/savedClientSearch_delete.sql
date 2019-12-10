CREATE TABLE [dbo].[savedClientSearch_delete] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [username]     NVARCHAR (50)  NULL,
    [searchName]   NVARCHAR (50)  NULL,
    [fname]        NVARCHAR (255) NULL,
    [initial]      CHAR (20)      NULL,
    [lname]        NVARCHAR (255) NULL,
    [gender]       INT            NULL,
    [address1]     NVARCHAR (255) NULL,
    [city]         NVARCHAR (255) NULL,
    [state]        NVARCHAR (255) NULL,
    [zip]          NVARCHAR (255) NULL,
    [country]      NVARCHAR (255) NULL,
    [email]        NVARCHAR (255) NULL,
    [bus_phone]    NVARCHAR (255) NULL,
    [res_phone]    NVARCHAR (255) NULL,
    [cell_phone]   NVARCHAR (255) NULL,
    [company_name] NVARCHAR (255) NULL,
    CONSTRAINT [PK_savedClientSearch] PRIMARY KEY CLUSTERED ([ID] ASC)
);

