-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getAllAccountsForSplit]
	
	--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)
	--@accountID int

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.ID,a.dtCreateDate,a.nAccountTypeID,a.cName as cShortName,a.cNote,a.cDesc,a.nCurrencyID,a.nCatID,b.cName as currencyName,
	  isnull(c.cName+': ','')+ a.cName as cName


	 FROM dbo.account a WITH (NOLOCK)
	 left join dbo.currency b on a.nCurrencyID = b.ID
	  left join dbo.cat c on a.nCatID = c.ID

	 where (a.bDeleted is null or a.bDeleted=0)
		
	--order by a.nAccountTypeID

	order by c.cName+': '+ a.cName

	
	
		
                   				 
end



