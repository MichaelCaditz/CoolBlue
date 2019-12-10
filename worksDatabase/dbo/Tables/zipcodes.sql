CREATE TABLE [dbo].[zipcodes] (
    [zipcodes_id] INT       NOT NULL,
    [zip]         CHAR (5)  NOT NULL,
    [state]       CHAR (2)  NOT NULL,
    [city]        CHAR (28) NOT NULL,
    [preferred]   CHAR (1)  NOT NULL
);

