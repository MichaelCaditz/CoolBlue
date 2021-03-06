﻿CREATE TABLE [dbo].[clients] (
    [clients_id]                INT              IDENTITY (1000, 1) NOT NULL,
    [members_id]                INT              NULL,
    [customer_categories_id]    INT              NULL,
    [create_date]               DATETIME         CONSTRAINT [DF_clients_create_date] DEFAULT (getdate()) NULL,
    [modify_date]               DATETIME         NULL,
    [created_by]                CHAR (10)        NULL,
    [username]                  CHAR (20)        NULL,
    [password]                  CHAR (20)        NULL,
    [fname]                     NVARCHAR (255)   NULL,
    [initial]                   CHAR (20)        NULL,
    [lname]                     NVARCHAR (255)   NULL,
    [gender]                    INT              NULL,
    [areaCode]                  CHAR (5)         NULL,
    [phone]                     NVARCHAR (255)   NULL,
    [address1]                  NVARCHAR (255)   NULL,
    [address2]                  NVARCHAR (255)   NULL,
    [city]                      NVARCHAR (255)   NULL,
    [state]                     NVARCHAR (255)   NULL,
    [state_other]               CHAR (15)        NULL,
    [zip]                       NVARCHAR (255)   NULL,
    [postal_code]               CHAR (10)        NULL,
    [country]                   NVARCHAR (255)   NULL,
    [bday]                      DATETIME         NULL,
    [photo]                     IMAGE            NULL,
    [email]                     NVARCHAR (255)   NULL,
    [email2]                    VARCHAR (50)     NULL,
    [bus_phone]                 NVARCHAR (255)   NULL,
    [bus_areacode]              CHAR (5)         NULL,
    [bus_ext]                   CHAR (5)         NULL,
    [res_phone]                 NVARCHAR (255)   NULL,
    [res_areacode]              CHAR (5)         NULL,
    [fax_areacode]              CHAR (5)         NULL,
    [fax_phone]                 NVARCHAR (255)   NULL,
    [pager_areacode]            CHAR (5)         NULL,
    [pager_phone]               CHAR (10)        NULL,
    [cell_areacode]             CHAR (5)         NULL,
    [cell_phone]                NVARCHAR (255)   NULL,
    [cc_no]                     CHAR (20)        NULL,
    [cc_exp]                    CHAR (8)         NULL,
    [cc_type]                   CHAR (10)        NULL,
    [ccMonth]                   TINYINT          NULL,
    [ccYear]                    SMALLINT         NULL,
    [company_name]              NVARCHAR (255)   NULL,
    [company_type]              CHAR (20)        NULL,
    [company_title]             NVARCHAR (255)   NULL,
    [referred_by]               CHAR (30)        NULL,
    [sandal_size]               CHAR (10)        NULL,
    [dosha_v]                   CHAR (2)         NULL,
    [dosha_p]                   CHAR (2)         NULL,
    [dosha_k]                   CHAR (2)         NULL,
    [dosha_dt]                  CHAR (15)        NULL,
    [notes]                     NVARCHAR (MAX)   NULL,
    [providerNotes]             VARCHAR (500)    NULL,
    [managerNotes]              VARCHAR (500)    NULL,
    [techNotes]                 VARCHAR (500)    NULL,
    [height]                    CHAR (10)        NULL,
    [weight]                    CHAR (10)        NULL,
    [hair_color]                CHAR (10)        NULL,
    [eyes]                      CHAR (10)        NULL,
    [ss_no]                     CHAR (11)        NULL,
    [web]                       BIT              NULL,
    [problem_flag]              BIT              NULL,
    [sw2001_id]                 INT              NULL,
    [clubworks_clientStatusID]  INT              NULL,
    [clubworks_accountTypesID]  INT              NULL,
    [csi_xref_id]               INT              NULL,
    [scancode]                  VARCHAR (16)     NULL,
    [assignedId]                CHAR (20)        NULL,
    [autoLicense]               VARCHAR (20)     NULL,
    [autoState]                 VARCHAR (20)     NULL,
    [autoMake]                  VARCHAR (20)     NULL,
    [autoModel]                 VARCHAR (20)     NULL,
    [autoColor]                 VARCHAR (20)     NULL,
    [dlNo]                      VARCHAR (20)     NULL,
    [dlState]                   VARCHAR (20)     NULL,
    [isChild]                   BIT              NULL,
    [isMember]                  BIT              NULL,
    [membershipExpires]         DATETIME         NULL,
    [bSendEmail]                BIT              NULL,
    [bSendPaperMail]            BIT              NULL,
    [bWorkoutWorks]             BIT              NULL,
    [bWWCancellationAgree]      BIT              NULL,
    [imgWWCancellationAgreeSig] IMAGE            NULL,
    [customCk1]                 BIT              NULL,
    [customCk2]                 BIT              NULL,
    [customCk3]                 BIT              NULL,
    [bWWWaiverAgree]            BIT              NULL,
    [imgWWWaiverAgreeSig]       IMAGE            NULL,
    [cWWCancellationPolicy]     VARCHAR (MAX)    NULL,
    [cWWWaiver]                 VARCHAR (MAX)    NULL,
    [cWWMyWorkoutsUserId]       VARCHAR (50)     NULL,
    [cWWTrainerProvidedPword]   UNIQUEIDENTIFIER NULL,
    [cBillAddress1]             VARCHAR (50)     NULL,
    [cBillAddress2]             VARCHAR (50)     NULL,
    [cBillCity]                 VARCHAR (50)     NULL,
    [cBillState]                CHAR (2)         NULL,
    [cBillZip]                  CHAR (10)        NULL,
    [cBillStateOther]           VARCHAR (50)     NULL,
    [cBillPostalCode]           VARCHAR (20)     NULL,
    [cBillCountry]              VARCHAR (30)     NULL,
    [cAspnet_UserId]            VARCHAR (50)     NULL,
    [nImportID]                 INT              NULL,
    [cImportDB]                 VARCHAR (50)     NULL,
    [cTitle]                    NVARCHAR (255)   NULL,
    [cWebsite]                  NVARCHAR (255)   NULL,
    [cDescription]              NVARCHAR (MAX)   NULL,
    [cPhoneOther]               NVARCHAR (MAX)   NULL,
    [cSalesRep2]                NVARCHAR (MAX)   NULL,
    [cAssistant]                NVARCHAR (MAX)   NULL,
    [cAssistantPhone]           NVARCHAR (MAX)   NULL,
    [dtOriginalCreateDate]      DATETIME         NULL,
    [nClientMasterID]           INT              NULL,
    [cmpDisplay]                AS               (ltrim((((isnull([fname],'')+' ')+isnull([lname],''))+case when [lname] IS NOT NULL AND [lname]<>'' AND [company_name] IS NOT NULL AND [company_name]<>'' then ', ' else '' end)+isnull([company_name],''))) PERSISTED,
    [cmpDisplayWithCity]        AS               ((((ltrim((((isnull([fname],'')+' ')+isnull([lname],''))+case when [lname] IS NOT NULL AND [lname]<>'' AND [company_name] IS NOT NULL AND [company_name]<>'' then ', ' else '' end)+isnull([company_name],''))+': ')+isnull([city],''))+', ')+isnull([state],'')) PERSISTED,
    [bNTTC]                     BIT              NULL,
    [cEmailAssistant]           NVARCHAR (100)   NULL,
    [bPrivate]                  BIT              NULL,
    [bWebsite]                  BIT              NULL,
    [cDates]                    NVARCHAR (100)   NULL,
    [cNationality]              NVARCHAR (100)   NULL,
    [nArtistCategoryID]         INT              NULL,
    [bDeceased]                 BIT              NULL,
    [bRepresented]              BIT              CONSTRAINT [DF_clients_bRepresented] DEFAULT ((0)) NULL,
    [bPrimary]                  BIT              NULL,
    [cmpDisplayWithAddress]     AS               (((((((((((ltrim((((isnull([fname],'')+' ')+isnull([lname],''))+case when [lname] IS NOT NULL AND [lname]<>'' AND [company_name] IS NOT NULL AND [company_name]<>'' then char((13))+char((10)) else '' end)+isnull([company_name],''))+char((13)))+char((10)))+isnull([address1],''))+isnull((char((13))+char((10)))+nullif([address2],''),''))+char((13)))+char((10)))+isnull([city]+', ',''))+isnull([state],''))+' ')+isnull([zip],''))+isnull((char((13))+char((10)))+[country],'')),
    [cSpouseName]               NVARCHAR (255)   NULL,
    [bRecordChecked]            BIT              NULL,
    [bArchived]                 BIT              NULL,
    [cmpDisplayLastFirst]       AS               (ltrim((((isnull([lname],'')+case when [lname] IS NOT NULL AND [lname]<>'' AND [fname] IS NOT NULL AND [fname]<>'' then ', ' else '' end)+isnull([fname],''))+case when [lname] IS NOT NULL AND [lname]<>'' AND [company_name] IS NOT NULL AND [company_name]<>'' then ', ' else '' end)+isnull([company_name],''))),
    [nMergedToID]               INT              NULL,
    [dtMergedDate]              DATETIME2 (7)    NULL,
    [cMergedBy]                 NVARCHAR (255)   NULL,
    [cHours]                    NVARCHAR (255)   NULL,
    [cMapURL]                   NVARCHAR (1000)  NULL,
    [bWebsiteGallery]           BIT              NULL,
    [cNTTCNum]                  VARCHAR (50)     NULL,
    [bDeleted]                  BIT              NULL,
    [dtDateDeleted]             DATETIME2 (7)    NULL,
    CONSTRAINT [PK_clients] PRIMARY KEY CLUSTERED ([clients_id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_nClientMasterID]
    ON [dbo].[clients]([state] ASC, [nClientMasterID] ASC)
    INCLUDE([clients_id], [fname], [lname], [phone], [address1], [address2], [city], [zip], [country], [email], [email2], [bus_phone], [res_phone], [fax_phone], [cell_phone], [company_name], [company_title], [notes], [bSendEmail], [bSendPaperMail], [nImportID], [cImportDB], [cTitle], [cWebsite], [cDescription], [cPhoneOther], [cSalesRep2], [cmpDisplay], [cmpDisplayWithCity], [bNTTC], [bPrivate], [bDeceased], [bPrimary], [cmpDisplayWithAddress], [bRecordChecked], [bArchived], [nMergedToID]);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1 = artist is represented', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'clients', @level2type = N'COLUMN', @level2name = N'bRepresented';


GO
EXECUTE sp_addextendedproperty @name = N'Description', @value = N'clients_id that this record was merged to', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'clients', @level2type = N'COLUMN', @level2name = N'nMergedToID';

