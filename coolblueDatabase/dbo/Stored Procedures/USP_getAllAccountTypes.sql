-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getAllAccountTypes]
	
	--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)
	--@accountID int

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.ID,a.cName,a.cNote,a.dtCreateDate,a.nAccountingTypeID,b.cName as accountingTypeName,b.cSymbol as accountingTypeSymbol


	 FROM accountType a WITH (NOLOCK)

	 left join accountingType b on a.nAccountingTypeID = b.ID

	 where  a.bDeleted is null or a.bDeleted=0
		
	order by a.bIsAll, a.cName

	
	
		
                   				 
end



