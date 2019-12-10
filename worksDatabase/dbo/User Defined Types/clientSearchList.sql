CREATE TYPE [dbo].[clientSearchList] AS TABLE (
    [ID]         INT            NULL,
    [username]   NVARCHAR (50)  NULL,
    [searchName] NVARCHAR (50)  NULL,
    [cmpDisplay] NVARCHAR (100) NULL,
    [city]       NVARCHAR (50)  NULL,
    [state]      NVARCHAR (50)  NULL,
    [country]    NVARCHAR (50)  NULL,
    [zip]        NVARCHAR (50)  NULL,
    [group]      NVARCHAR (50)  NULL,
    [type]       NVARCHAR (50)  NULL,
    [cityIn]     NVARCHAR (255) NULL,
    [stateIn]    NVARCHAR (255) NULL,
    [countryIn]  NVARCHAR (255) NULL,
    [zipIn]      NVARCHAR (255) NULL,
    [cClientIDs] NVARCHAR (255) NULL,
    [cGroupIDs]  NVARCHAR (255) NULL,
    [cTypeIDs]   NVARCHAR (255) NULL);

