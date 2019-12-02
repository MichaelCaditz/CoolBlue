-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
creATE PROCEDURE [dbo].[USP_getAllCurrency]
	--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)
	--@accountID int

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.ID, a.cName,a.cNote,a.dtCreateDate


	 FROM dbo.currency a  WITH (NOLOCK)
	 
	 --left join dbo.line b on a.nLineID = b.ID
	 
	 where  a.bDeleted is null or a.bDeleted=0

	 --where b.nAccountID = @accountID and (a.bDeleted is null or a.bDeleted=0) and (b.bDeleted is null or b.bDeleted=0)
		
	order by a.cName

	
	
		
                   				 
end
