-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_getContactType]
	
	--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 SELECT contactType.cName,contactType.ID


	 FROM contactType 
		
	order by contactType.cName

	
	
		
                   				 
end


