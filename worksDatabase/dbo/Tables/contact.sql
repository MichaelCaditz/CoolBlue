﻿CREATE TABLE [dbo].[contact] (
    [ID]                     INT            IDENTITY (1000, 1) NOT NULL,
    [members_id]             INT            NULL,
    [logon_staff_id]         INT            NULL,
    [transaction_staff_id]   INT            NULL,
    [foxpro_id]              CHAR (50)      NULL,
    [customer_categories_id] INT            NULL,
    [dtCreateDate]           DATETIME       CONSTRAINT [DF_contacts_dtCreateDate] DEFAULT (getdate()) NULL,
    [dtModifyDate]           DATETIME       NULL,
    [created_by]             CHAR (10)      NULL,
    [cUsername]              CHAR (20)      NULL,
    [cPassword]              CHAR (20)      NULL,
    [cNameFirst]             NVARCHAR (255) NULL,
    [cInitial]               CHAR (20)      NULL,
    [cNameLast]              NVARCHAR (255) NULL,
    [iGender]                INT            NULL,
    [areaCode]               CHAR (5)       NULL,
    [cPhone]                 NVARCHAR (255) NULL,
    [cAddress1]              NVARCHAR (255) NULL,
    [cAddress2]              NVARCHAR (255) NULL,
    [cCity]                  NVARCHAR (255) NULL,
    [cState]                 NVARCHAR (255) NULL,
    [state_other]            CHAR (15)      NULL,
    [cZip]                   NVARCHAR (255) NULL,
    [postal_code]            CHAR (10)      NULL,
    [cCountry]               NVARCHAR (255) NULL,
    [bday]                   DATETIME       NULL,
    [photo]                  IMAGE          NULL,
    [cEmail]                 NVARCHAR (255) NULL,
    [email2]                 VARCHAR (50)   NULL,
    [cBusPhone]              NVARCHAR (255) NULL,
    [bus_areacode]           CHAR (5)       NULL,
    [bus_ext]                CHAR (5)       NULL,
    [cResPhone]              NVARCHAR (255) NULL,
    [res_areacode]           CHAR (5)       NULL,
    [fax_areacode]           CHAR (5)       NULL,
    [cFaxPhone]              NVARCHAR (255) NULL,
    [pager_areacode]         CHAR (5)       NULL,
    [cPagerPhone]            CHAR (10)      NULL,
    [cell_areacode]          CHAR (5)       NULL,
    [cCellPhone]             NVARCHAR (255) NULL,
    [cc_no]                  CHAR (20)      NULL,
    [cc_exp]                 CHAR (8)       NULL,
    [cc_type]                CHAR (10)      NULL,
    [ccMonth]                TINYINT        NULL,
    [ccYear]                 SMALLINT       NULL,
    [cCompanyName]           NVARCHAR (255) NULL,
    [company_type]           CHAR (20)      NULL,
    [cCompanyTitle]          NVARCHAR (255) NULL,
    [referred_by]            CHAR (30)      NULL,
    [cNotes]                 NVARCHAR (MAX) NULL,
    [cProviderNotes]         VARCHAR (500)  NULL,
    [cManagerNotes]          VARCHAR (500)  NULL,
    [cTechNotes]             VARCHAR (500)  NULL,
    [ss_no]                  CHAR (11)      NULL,
    [bWeb]                   BIT            NULL,
    [csi_xref_id]            INT            NULL,
    [scancode]               VARCHAR (16)   NULL,
    [assignedId]             CHAR (20)      NULL,
    [dlState]                VARCHAR (20)   NULL,
    [isChild]                BIT            NULL,
    [isMember]               BIT            NULL,
    [bSendEmail]             BIT            CONSTRAINT [DF_contacts_bSendEmail] DEFAULT ((1)) NULL,
    [bSendPaperMail]         BIT            NULL,
    [bWorkoutWorks]          BIT            NULL,
    [customCk1]              BIT            NULL,
    [customCk2]              BIT            NULL,
    [customCk3]              BIT            NULL,
    [cBillAddress1]          VARCHAR (50)   NULL,
    [cBillAddress2]          VARCHAR (50)   NULL,
    [cBillCity]              VARCHAR (50)   NULL,
    [cBillState]             CHAR (2)       NULL,
    [cBillZip]               CHAR (10)      NULL,
    [cBillStateOther]        VARCHAR (50)   NULL,
    [cBillPostalCode]        VARCHAR (20)   NULL,
    [cBillCountry]           VARCHAR (30)   NULL,
    [cAspnet_UserId]         VARCHAR (50)   NULL,
    [nGalProID]              INT            NULL,
    [cGalProDB]              VARCHAR (50)   NULL,
    [cTitle]                 NVARCHAR (255) NULL,
    [cWebsite]               NVARCHAR (255) NULL,
    [cDescription]           NVARCHAR (MAX) NULL,
    [cPhoneOther]            NVARCHAR (MAX) NULL,
    [cSalesRep2]             NVARCHAR (MAX) NULL,
    [cAssistant]             NVARCHAR (MAX) NULL,
    [cAssistantPhone]        NVARCHAR (MAX) NULL,
    [dtOriginalCreateDate]   DATETIME       NULL,
    [nContactMasterID]       INT            NULL,
    [cmpDisplay]             AS             (ltrim((((isnull([cNameFirst],'')+' ')+isnull([cNameLast],''))+case when [cNameLast] IS NOT NULL AND [cNameLast]<>'' AND [cCompanyName] IS NOT NULL AND [cCompanyName]<>'' then ', ' else '' end)+isnull([cCompanyName],''))),
    [cmpDisplayWithAddress]  AS             (((((((((((ltrim((((isnull([cNameFirst],'')+' ')+isnull([cNameLast],''))+case when [cNameLast] IS NOT NULL AND [cNameLast]<>'' AND [cCompanyName] IS NOT NULL AND [cCompanyName]<>'' then ', ' else '' end)+isnull([cCompanyName],''))+char((13)))+char((10)))+isnull([cAddress1],''))+isnull((char((13))+char((10)))+[cAddress2],''))+char((13)))+char((10)))+isnull([cCity]+', ',''))+isnull([cState],''))+char((13)))+char((10)))+isnull([cZip],'')) PERSISTED,
    CONSTRAINT [PK_contacts] PRIMARY KEY CLUSTERED ([ID] ASC)
);

