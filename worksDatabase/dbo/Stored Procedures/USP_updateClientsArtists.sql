-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_updateClientsArtists]
	@ID int,
	@nContactID int,
	@nArtistID int
	--@Title nVarchar(255)

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 update  a 


	 set a.nClientsID = @nContactID,
	a.nArtistID= @nArtistID

	 from clientsArtists a

	where a.ID = @ID
	
		
                   				 
end


