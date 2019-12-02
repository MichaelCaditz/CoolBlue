-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getAllSubCats]
	--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)
	--@accountID int

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.cName,a.ID,a.nCatID,a.cNotes


	 FROM dbo.subCat a  WITH (NOLOCK)
	 
	-- left join dbo.cat b on a.nCatID = b.ID
	 
	

	 where  (a.bDeleted is null or a.bDeleted=0) 
	 --and (b.bDeleted is null or b.bDeleted=0)


	-- UNION ALL

	--  SELECT '['+ a.cName+']',a.ID,0,a.cNote


	-- FROM dbo.account a  WITH (NOLOCK)
	 
	---- left join dbo.cat b on a.nCatID = b.ID
	 
	

	-- where  (a.bDeleted is null or a.bDeleted=0) 
	-- --and (b.bDeleted is null or b.bDeleted=0)


		
	order by a.cName


	


	
	
		
                   				 
end
