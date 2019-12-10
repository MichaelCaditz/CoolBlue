-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_getClientMasterMailGroup]
	
	@clientMasterID int
	--@Title nVarchar(255)

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 SELECT a.ID,a.nClientMasterID,a.nMailGroupID


	 FROM clientMasterMailGroup a 

	-- inner join contactGroup b on b.ID = a. nContactGroupID

	 where a.nClientMasterID=@clientMasterID
		
	--order by b.cName

	
	
		
                   				 
end


