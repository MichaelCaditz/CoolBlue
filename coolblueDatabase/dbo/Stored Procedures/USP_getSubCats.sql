-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getSubCats]
	--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)
	--@accountID int

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT b.cName+': '+ a.cName,a.ID


	 FROM subCat a  WITH (NOLOCK)
	 
	 left join dbo.cat b on a.nCatID = b.ID
	 
	

	 where  (a.bDeleted is null or a.bDeleted=0) and (b.bDeleted is null or b.bDeleted=0)


	 

		
	order by b.cName+': '+ a.cName

	
	
		
                   				 
end
