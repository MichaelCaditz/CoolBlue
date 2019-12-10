-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_getClientsArtists]
	
	@clientsID int
	--@Title nVarchar(255)

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 SELECT a.ID,a.nClientsID,a.nArtistID


	 FROM clientsArtists a 

	-- inner join contactGroup b on b.ID = a. nContactGroupID

	 where a.nClientsID=@clientsID
		
	--order by b.cName

	
	
		
                   				 
end


