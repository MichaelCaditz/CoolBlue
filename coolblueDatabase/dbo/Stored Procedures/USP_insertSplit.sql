-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_insertSplit]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	
	
	@lineID int = 0,
	@subCatID int = 0,
	@xferAccountID int = 0,
	@bXfer bit = 0,
	@amount decimal (20,4)= 0,
	@vendorsID int = 0,
	@memo varchar (max) = '',
	@tagID int = 0,
	@classID int = 0,
	@accountID int = 0,
	@originalAmount decimal (20,4)= 0,
	@currencyID int = 0,
	@nAccountID_C int = 0,
	@nAccountID_D int = 0,
	@nAmount_C decimal (20,4)= 0,
	@nAmount_D decimal (20,4)= 0,
	@nEntryCurrencyID int = 0,
	@nAmount_C_Native decimal (20,4)= 0,
	@nAmount_D_Native decimal (20,4)= 0,
	

	@transactIdentity int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	

	


	insert into coolblue.dbo.split

	(
	nLineID,
	nSubCatID,
	nXferAccountID,
	bXfer,
	nAmount,
	nVendorsID,
	cMemo,
	nTagID,
	nClassID,
	nAccountID,
	nOriginalAmount,
	nCurrencyID,
	bDeleted,
	nAccountID_C,
	nAccountID_D ,
	nAmount_C ,
	nAmount_D ,
	nEntryCurrencyID,
	nAmount_C_Native,
	nAmount_D_Native 
	)
	
	
	

	values (
	@lineID,
	@subCatID,
	@xferAccountID,
	@bXfer,
	@amount,
	@vendorsID,
	@memo,
	@tagID,
	@classID,
	@accountID,
	@originalAmount,
	@currencyID,
	0,
	@nAccountID_C,
	@nAccountID_D ,
	@nAmount_C ,
	@nAmount_D ,
	@nEntryCurrencyID ,
	@nAmount_C_Native,
	@nAmount_D_Native
	

	)

	select @transactIdentity  = SCOPE_IDENTITY();

	

end
