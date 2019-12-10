CREATE TABLE [dbo].[memberWall] (
    [nMemberWallId] INT           IDENTITY (1000, 1) NOT NULL,
    [dCreateDate]   DATETIME      CONSTRAINT [DF_memberWall_dCreateDate] DEFAULT (getdate()) NULL,
    [dModifyDate]   DATETIME      NULL,
    [cUserId]       VARCHAR (50)  NULL,
    [cComment]      VARCHAR (MAX) NULL,
    [lDeleted]      BIT           NULL
);

