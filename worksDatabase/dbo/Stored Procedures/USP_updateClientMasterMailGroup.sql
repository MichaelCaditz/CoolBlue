-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_updateClientMasterMailGroup]
	@ID int,
	@nClientMasterID int,
	@nMailGroupID int
	--@Title nVarchar(255)

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 update  a 


	 set a.nClientMasterID = @nClientMasterID,
	a.nMailGroupID= @nMailGroupID

	 from clientMasterMailGroup a

	where a.ID = @ID
	
		
                   				 
end


