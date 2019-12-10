-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getAssociateContact]
	
	@clientsID int
	--@Title nVarchar(255)

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 SELECT b.cmpDisplay, a.primaryContactID,a.associateContactID,  b.cmpDisplayWithAddress,a.cNote


	 FROM associateContact a 

	 inner join clients b on b.clients_id=a.associateContactID

	 where a.primaryContactID=@clientsID
		
	order by b.cmpDisplay

	
	
		
                   				 
end


