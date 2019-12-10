CREATE TABLE [dbo].[savedSearchList] (
    [ID]             INT            IDENTITY (1000, 1) NOT NULL,
    [cUserName]      NVARCHAR (50)  NULL,
    [cFormName]      NVARCHAR (50)  NULL,
    [cListName]      NVARCHAR (50)  NULL,
    [cSearchName]    NVARCHAR (50)  NULL,
    [cFilter]        NVARCHAR (50)  NULL,
    [cValue]         NVARCHAR (MAX) NULL,
    [bCaseSensitive] BIT            NULL,
    [bBeginsWith]    BIT            NULL,
    [dtCreateDate]   DATETIME2 (7)  NULL
);

