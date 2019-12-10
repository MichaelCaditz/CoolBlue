CREATE TABLE [dbo].[staff_categories] (
    [staff_categories_id]  INT            NOT NULL,
    [foxpro_id]            CHAR (50)      NULL,
    [logon_staff_id]       INT            NULL,
    [transaction_staff_id] INT            NULL,
    [create_date]          DATETIME       NULL,
    [modify_date]          DATETIME       NULL,
    [category]             CHAR (30)      NULL,
    [descrip]              VARCHAR (1000) NULL,
    [abbrev]               CHAR (5)       NULL,
    [notes]                VARCHAR (500)  NULL,
    [picture_cal]          CHAR (30)      NULL,
    [catcolor]             CHAR (20)      NULL,
    [show_on_cal]          BIT            NULL,
    [show_on_management]   BIT            NULL,
    [norder]               INT            NULL
);

