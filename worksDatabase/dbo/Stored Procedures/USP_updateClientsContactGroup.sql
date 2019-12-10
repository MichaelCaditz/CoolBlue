-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_updateClientsContactGroup]
	@ID int,
	@nContactID int,
	@nContactGroupID int
	--@Title nVarchar(255)

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 update  a 


	 set a.nClientsID = @nContactID,
	a.nContactGroupID= @nContactGroupID

	 from clientsContactGroup a

	where a.ID = @ID
	
		
                   				 
end


