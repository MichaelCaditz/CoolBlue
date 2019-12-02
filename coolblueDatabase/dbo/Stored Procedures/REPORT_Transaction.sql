-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[REPORT_Transaction]
		--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)
	@accountID int,
	@startDate datetime,
	@endDate datetime
AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.ID,a.dtCreateDate,b.nAccountID,b.dtTransDate as dtLineTransdate,ISNULL(a.cMemo,'') as cSplitMemo,a.nSubCatID,a.nAmount,a.nClassID,a.nOriginalAmount,
	 a.nCurrencyID,a.nTagID,a.nVendorsID,a.nLineID,ISNULL(b.cNote,'') as cLineNote,ISNULL(c.name,'') as cVendorName,
	 ISNULL(d.cName,'') as cTagName,ISNULL(e.cName,'') as cClassName, ISNULL(g.cName+': '+ f.cName,'') as cCategory,
	 ISNULL(i.cName+': '+ h.cName,'') as cAccount,ISNULL(j.cName,'') as cCurrencyName


	 FROM split a  WITH (NOLOCK)
	 
	 left join dbo.line b on a.nLineID = b.ID
	 left join Works.dbo.vendors c on a.nVendorsID = c.vendors_id
	 left join dbo.tag d on a.nTagID = d.ID
	 left join dbo.class e on a.nClassID = e.ID
	 left join dbo.subCat f on a.nSubCatID = f.ID
	 left join dbo.cat g on f.nCatID = g.ID
	 left join dbo.account h on b.nAccountID = h.ID
	 left join dbo.accountType i on h.nAccountTypeID = i.ID
	 left join dbo.currency j on a.nCurrencyID = j.ID
	 
	

	 where
	 --b.nAccountID = @accountID and
	 (a.bDeleted is null or a.bDeleted=0) and (b.bDeleted is null or b.bDeleted=0)
	AND b.dtTransDate BETWEEN DATEADD(dd, 0, DATEDIFF(dd, 0, @startDate  )) AND DATEADD(dd,1, DATEDIFF(dd, 0, @endDate  ))
	
	order by b.dtTransDate
END
