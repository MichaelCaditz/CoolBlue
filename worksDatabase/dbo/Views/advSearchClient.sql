CREATE VIEW [dbo].[advSearchClient]
AS
SELECT DISTINCT 
                         dbo.clients.clients_id, dbo.clients.fname, dbo.clients.lname, dbo.clients.address1, dbo.clients.address2, dbo.clients.city, dbo.clients.state, dbo.clients.zip, 
                         dbo.clients.country, dbo.clients.res_phone, dbo.clients.bus_phone, dbo.clients.cell_phone, dbo.clients.nClientMasterID, dbo.clients.cTitle, dbo.clients.fax_phone, 
                         dbo.clients.phone, dbo.clients.cPhoneOther, dbo.clients.company_name, dbo.clients.cDescription, dbo.clients.cmpDisplay, dbo.clients.cmpDisplayWithCity, 
                         dbo.clients.notes, dbo.clients.cmpDisplayWithAddress, dbo.clients.cWebsite, dbo.clients.email, dbo.clients.bNTTC, dbo.contactType.cName AS 'contactTypeName', 
                         dbo.clientMaster.cName AS 'masterClientName'
FROM            dbo.clients WITH (NOLOCK) INNER JOIN
                         dbo.clientMaster WITH (NOLOCK) ON dbo.clients.nClientMasterID = dbo.clientMaster.ID LEFT OUTER JOIN
                         dbo.contactType WITH (NOLOCK) ON dbo.clientMaster.nContactTypeID = dbo.contactType.ID LEFT OUTER JOIN
                         dbo.clientsContactGroup WITH (NOLOCK) ON dbo.clients.clients_id = dbo.clientsContactGroup.nClientsID LEFT OUTER JOIN
                         dbo.contactGroup WITH (NOLOCK) ON dbo.contactGroup.ID = dbo.clientsContactGroup.nContactGroupID




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
         Begin Table = "clientMaster"
            Begin Extent = 
               Top = 6
               Left = 321
               Bottom = 135
               Right = 544
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "contactType"
            Begin Extent = 
               Top = 6
               Left = 582
               Bottom = 118
               Right = 752
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "clientsContactGroup"
            Begin Extent = 
               Top = 6
               Left = 790
               Bottom = 118
               Right = 972
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "contactGroup"
            Begin Extent = 
               Top = 6
               Left = 1010
               Bottom = 118
               Right = 1180
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
         Or = ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'advSearchClient';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'advSearchClient';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'advSearchClient';

