-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getSplit]
	
	--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)
	@accountID int,
	@accountingPeriod int

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.ID,a.dtCreateDate,b.nAccountID,b.dtTransDate,a.cMemo,a.nSubCatID,a.nAmount,a.nClassID,a.nOriginalAmount,
	 a.nCurrencyID,a.nTagID,a.nVendorsID,a.nLineID ,a.bXfer,a.nXferAccountID,a.nAccountID_C,a.nAccountID_D,a.nAmount_C,a.nAmount_D


	 FROM split a  WITH (NOLOCK)
	 
	 right join dbo.line b on a.nLineID = b.ID
	 
	

	 where (a.nAccountID_C = @accountID or a.nAccountID_D = @accountID) and b.nAccountingPeriodID=@accountingPeriod
	 
	 --b.nAccountID = @accountID 
	 
	 and ((a.bDeleted is null or a.bDeleted=0) and (b.bDeleted is null or b.bDeleted=0))
		
	order by b.dtTransDate

	
	
		
                   				 
end



