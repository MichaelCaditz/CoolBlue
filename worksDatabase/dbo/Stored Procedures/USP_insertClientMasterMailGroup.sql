-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_insertClientMasterMailGroup]
	
	@nClientMasterID int,
	@nMailGroupID int
	--@Title nVarchar(255)

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 insert into  clientMasterMailGroup 
	 (nClientMasterID ,
	nMailGroupID)

	values
	(@nClientMasterID ,
	@nMailGroupID)


	

	

	
	
		
                   				 
end


