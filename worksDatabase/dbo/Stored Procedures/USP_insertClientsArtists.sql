-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_insertClientsArtists]
	
	@nContactID int,
	@nArtistID int
	--@Title nVarchar(255)

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 insert into  clientsArtists 
	 (nClientsID ,
	nArtistID)

	values
	(@nContactID ,
	@nArtistID)


	

	

	
	
		
                   				 
end


