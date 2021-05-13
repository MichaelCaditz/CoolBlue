CREATE TABLE [dbo].[staff_categories] (
    [ID]                INT            IDENTITY (1000, 1) NOT NULL,
    [dtCreateDate]      DATETIME2 (7)  CONSTRAINT [DF_staff_categories_dtCreateDate] DEFAULT (getdate()) NULL,
    [cName]             NVARCHAR (50)  NULL,
    [cDescrip]          NVARCHAR (MAX) NULL,
    [cAbbrev]           NVARCHAR (50)  NULL,
    [cNote]             NVARCHAR (MAX) NULL,
    [picture_cal]       NVARCHAR (50)  NULL,
    [cColour]           NVARCHAR (50)  NULL,
    [bShowOnCal]        BIT            NULL,
    [bShowOnManagement] BIT            NULL,
    [nOrder]            INT            NULL,
    [bNotActive]        BIT            NULL,
    [bDeleted]          BIT            NULL,
    [dtDateDeleted]     DATETIME2 (7)  NULL,
    CONSTRAINT [PK_staff_categories] PRIMARY KEY CLUSTERED ([ID] ASC)
);



