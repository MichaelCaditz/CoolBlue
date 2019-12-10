-- =============================================
-- Author:		David Caditz
-- Create date: 6/18/2012
-- Description:	Merges records for two clients
-- =============================================
CREATE PROCEDURE [dbo].[USP_clientMerge]
	-- Add the parameters for the stored procedure here
	@mergeToClientsID int = 0,
	@mergeFromClientsID int = 0
AS
BEGIN

	SET NOCOUNT ON;

	-- merge records here:

	UPDATE [Works].[dbo].[clientsArtists] SET nClientsID = @mergeToClientsID WHERE nClientsID = @mergeFromClientsID 

	UPDATE [Works].[dbo].[clientsContactGroup] SET nClientsID = @mergeToClientsID WHERE nClientsID = @mergeFromClientsID 

	UPDATE [Works].[dbo].[clientMasterMailGroup] SET nClientMasterID = @mergeToClientsID WHERE nClientMasterID = @mergeFromClientsID -- actually uses clients_id in nClientMaster field
   
	UPDATE [Works].[dbo].[associateContact] SET primaryContactID = @mergeToClientsID WHERE primaryContactID = @mergeFromClientsID 

	UPDATE [Works].[dbo].[associateContact] SET associateContactID = @mergeToClientsID WHERE associateContactID = @mergeFromClientsID



	UPDATE [GalleryWorks].[dbo].[artwork] SET nLocationID = @mergeToClientsID WHERE nLocationID = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[bin] SET nContactID  = @mergeToClientsID WHERE nContactID  = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[entityArtwork] SET nSoldToClientsID = @mergeToClientsID WHERE nSoldToClientsID = @mergeFromClientsID 

	UPDATE [GalleryWorks].[dbo].[entityArtwork] SET nConsignedSourceContactID = @mergeToClientsID WHERE nConsignedSourceContactID = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[entityArtwork] SET nReceiveByStaffID  = @mergeToClientsID WHERE nReceiveByStaffID  = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[exhibition] SET nStaffID = @mergeToClientsID WHERE nStaffID = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[expenseDetail] SET nContactID = @mergeToClientsID WHERE nContactID = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[JVPartner] SET nClients_id = @mergeToClientsID WHERE nClients_id = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[RTC] SET nShipToContactID = @mergeToClientsID WHERE nShipToContactID = @mergeFromClientsID



	--transactions:
	UPDATE [GalleryWorks].[dbo].[transact] SET nContactFromID = @mergeToClientsID WHERE nContactFromID = @mergeFromClientsID 

	UPDATE [GalleryWorks].[dbo].[transact] SET nContactToID = @mergeToClientsID WHERE nContactToID = @mergeFromClientsID 

	UPDATE [GalleryWorks].[dbo].[transact] SET nContact0ID = @mergeToClientsID WHERE nContact0ID = @mergeFromClientsID 

	UPDATE [GalleryWorks].[dbo].[transact] SET nContact1ID = @mergeToClientsID WHERE nContact1ID = @mergeFromClientsID 

	UPDATE [GalleryWorks].[dbo].[transact] SET nPreparedByID = @mergeToClientsID WHERE  nPreparedByID = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[invoice] SET nShipToContactID  = @mergeToClientsID WHERE  nShipToContactID  = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[invoice] SET nLocationID   = @mergeToClientsID WHERE  nLocationID   = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[offer] SET nShipToContactID  = @mergeToClientsID WHERE  nShipToContactID  = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[offer] SET nLocationID   = @mergeToClientsID WHERE  nLocationID   = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[consignment] SET nShipToContactID  = @mergeToClientsID WHERE  nShipToContactID  = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[consignment] SET nLocationID   = @mergeToClientsID WHERE  nLocationID   = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[loan] SET nShipToContactID  = @mergeToClientsID WHERE  nShipToContactID  = @mergeFromClientsID

	UPDATE [GalleryWorks].[dbo].[loan] SET nLocationID   = @mergeToClientsID WHERE  nLocationID   = @mergeFromClientsID




	UPDATE [Works].[dbo].[clients] SET nMergedToID = @mergeToClientsID WHERE clients_id = @mergeFromClientsID
















END

