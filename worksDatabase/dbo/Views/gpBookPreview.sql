
CREATE VIEW [dbo].[gpBookPreview]
AS
SELECT        a.clients_id, a.fname, a.initial, a.lname, a.areaCode, a.phone, a.address1, a.address2, a.city, a.state, a.state_other, a.zip, a.postal_code, a.country, a.bday, a.photo, 
                         a.email, a.email2, a.bus_phone, a.bus_areacode, a.bus_ext, a.res_phone, a.res_areacode, a.fax_areacode, a.fax_phone, a.pager_areacode, a.pager_phone, 
                         a.cell_areacode, a.cell_phone, a.company_name, a.company_type, a.company_title, a.notes, a.bSendEmail, a.bSendPaperMail, a.bWorkoutWorks, 
                         a.bWWCancellationAgree, a.imgWWCancellationAgreeSig, a.customCk1, a.customCk2, a.customCk3, a.bWWWaiverAgree, a.cBillAddress1, a.cBillAddress2, 
                         a.cBillCity, a.cBillState, a.cBillZip, a.cBillStateOther, a.cBillPostalCode, a.cBillCountry, a.nImportID, a.cImportDB, a.cTitle, a.cWebsite, a.cDescription, a.cPhoneOther,
                          a.cSalesRep2, a.cAssistant, a.cAssistantPhone, a.dtOriginalCreateDate, a.nClientMasterID, a.bNTTC, a.cEmailAssistant, a.bPrivate, a.bWebsite, a.cDates, 
                         a.cNationality, a.nArtistCategoryID, a.bDeceased, a.bRepresented, a.bPrimary, a.cSpouseName, a.bRecordChecked, c.cName AS 'Contact  Group'
FROM            dbo.clients AS a INNER JOIN
                         dbo.clientsContactGroup AS b ON a.clients_id = b.nClientsID INNER JOIN
                         dbo.contactGroup AS c ON c.ID = b.nContactGroupID
WHERE        (b.nContactGroupID IN (1013)) AND (b.nContactGroupID NOT IN (1017, 1033, 1050, 1051, 1120, 1147))
and isnull(a.nMergedToID,0) = 0



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
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 283
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 321
               Bottom = 135
               Right = 503
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 541
               Bottom = 135
               Right = 711
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'gpBookPreview';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'gpBookPreview';

