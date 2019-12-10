-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_deleteClientMasterMailGroup]
	@ID int
	

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 delete  a 


	 

	 from clientMasterMailGroup a

	where a.ID = @ID
	
		
                   				 
end


