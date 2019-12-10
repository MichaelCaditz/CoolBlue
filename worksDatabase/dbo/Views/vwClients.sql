CREATE VIEW [dbo].[vwClients]
AS
SELECT        clients_id, members_id, logon_staff_id, transaction_staff_id, foxpro_id, customer_categories_id, create_date, modify_date, created_by, username, password, fname, 
                         initial, lname, gender, areaCode, phone, address1, address2, city, state, state_other, zip, postal_code, country, bday, photo, email, email2, bus_phone, 
                         bus_areacode, bus_ext, res_phone, res_areacode, fax_areacode, fax_phone, pager_areacode, pager_phone, cell_areacode, cell_phone, cc_no, cc_exp, cc_type, 
                         ccMonth, ccYear, company_name, company_type, company_title, referred_by, sandal_size, dosha_v, dosha_p, dosha_k, dosha_dt, notes, providerNotes, 
                         managerNotes, techNotes, height, weight, hair_color, eyes, ss_no, web, problem_flag, sw2001_id, clubworks_clientStatusID, clubworks_accountTypesID, csi_xref_id,
                          scancode, assignedId, autoLicense, autoState, autoMake, autoModel, autoColor, dlNo, dlState, isChild, isMember, membershipExpires, bSendEmail, 
                         bSendPaperMail, bWorkoutWorks, bWWCancellationAgree, imgWWCancellationAgreeSig, customCk1, customCk2, customCk3, bWWWaiverAgree, 
                         imgWWWaiverAgreeSig, cWWCancellationPolicy, cWWWaiver, cWWMyWorkoutsUserId, cWWTrainerProvidedPword, cBillAddress1, cBillAddress2, cBillCity, 
                         cBillState, cBillZip, cBillStateOther, cBillPostalCode, cBillCountry, cAspnet_UserId, nImportID, cImportDB, cTitle, cWebsite, cDescription, cPhoneOther, cSalesRep2, 
                         cAssistant, cAssistantPhone, dtOriginalCreateDate, nClientMasterID, cmpDisplay, cmpDisplayWithCity, bNTTC, cEmailAssistant, bPrivate, bWebsite, cDates, 
                         cNationality, nArtistCategoryID, bDeceased, bRepresented, bPrimary, cmpDisplayWithAddress, cSpouseName, bRecordChecked, bArchived, cmpDisplayLastFirst, 
                         nMergedToID, dtMergedDate, cMergedBy, cHours, cMapURL, bWebsiteGallery
FROM            dbo.clients
WHERE        (ISNULL(nMergedToID, 0) = 0)


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "clients"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 283
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwClients';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwClients';

