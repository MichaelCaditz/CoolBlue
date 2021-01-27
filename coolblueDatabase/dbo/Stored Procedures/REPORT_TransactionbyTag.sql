-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[REPORT_TransactionbyTag]
		--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)
	@accountID int,
	@startDate datetime,
	@endDate datetime,
	@tagID int,
	@currencyID int,
	@accountingPeriod int
AS

BEGIN
--declare @cmd nvarchar(100)
--declare @fieldname varchar(100)
--set @fieldname = 'aa.['+cast(@currencyID as varchar(100))+']'

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.ID,a.dtCreateDate,b.nAccountID,b.dtTransDate as dtLineTransdate,ISNULL(a.cMemo,'') as cSplitMemo,a.nSubCatID,





	



	 case 
		 when @currencyID = h.nCurrencyID and (select w.cName from dbo.account x  inner join  dbo.accountType w on w.ID = x.nAccountTypeID where a.nAccountID_D = x.ID) not in ('Chequing')
		 then a.nAmount_C

		 when @currencyID = h.nCurrencyID and (select w.cName from dbo.account x  inner join  dbo.accountType w on w.ID = x.nAccountTypeID where a.nAccountID_D = x.ID) in ('Chequing')
		 then -a.nAmount_C
		
		 else
		 case
		 when @currencyID = 1001 and (select w.cName from dbo.account x  inner join  dbo.accountType w on w.ID = x.nAccountTypeID where a.nAccountID_D = x.ID) not in ('Chequing')
		-- (select EVAL(@fieldname) from dbo.currencyConversion aa where aa.[from] = h.nCurrencyID) * a.nAmount
		 then (select aa.n1001 from dbo.currencyConversion aa where aa.[nFrom] = h.nCurrencyID) * a.nAmount_C
		 --set @cmd = 'dhdfh'
		  -- exec('(select aa.['+Cast(@currencyID AS Varchar(10))+'] from dbo.currencyConversion aa where aa.[from] = '+Cast(h.nCurrencyID AS Varchar(10))+') * a.nAmount'
	 --(select aa.nRate from currencyConversion aa where aa.nTo = @currencyID and aa.nFrom = h.nCurrencyID)* a.nAmount
		
		
		when @currencyID = 1001 and (select w.cName from dbo.account x  inner join  dbo.accountType w on w.ID = x.nAccountTypeID where a.nAccountID_D = x.ID) in ('Chequing')
		-- (select EVAL(@fieldname) from dbo.currencyConversion aa where aa.[from] = h.nCurrencyID) * a.nAmount
		 then -(select aa.n1001 from dbo.currencyConversion aa where aa.[nFrom] = h.nCurrencyID) * a.nAmount_C
	 else
	  (select 0)
	 end
	 
	 end
	 as 'nAmount_C_adj',


	 nAmount_D as 'nAmount_D',
	  nAmount_C as 'nAmount_C',
	  nAmount_D_Native as 'nAmount_D_Native',
	  nAmount_C_Native as 'nAmount_C_native',









	






	 a.nClassID,a.nOriginalAmount,
	 a.nCurrencyID,a.nTagID,
	 a.nVendorsID,a.nLineID,
	 ISNULL(b.cNote,'') as cLineNote,
	 ISNULL(c.name,'') as cVendorName,
	 ISNULL(d.cName,'') as cTagName,
	 ISNULL(e.cName,'') as cClassName,
	 ISNULL(l.cName+': '+ k.cName,'') as cCategory,
	 ISNULL(i.cName+': '+ h.cName,'') as cAccount,
	 ISNULL(j.cName,'') as cCurrencyName,
	 h.nCurrencyID as nAccountCurrencyID,
	 isnull(l.cName + ': ','') + isnull(k.cName,'') as cAccount_D,
	 isnull(n.cName + ': ','') + isnull(m.cName,'') as cAccount_C,
	 isnull(o.cName,'') as cEntryCurrency
	 

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
	 left join dbo.account k on a.nAccountID_D = k.ID
	 left join dbo.cat l on k.nCatID = l.ID
	 left join dbo.account m on a.nAccountID_C = m.ID
	 left join dbo.cat n on m.nCatID = n.ID
	  left join dbo.currency o on a.nEntryCurrencyID = o.ID
	

	 where
	 --b.nAccountID = @accountID and
	  --a.nTagID = @tagID and
	 (a.bDeleted is null or a.bDeleted=0) and (b.bDeleted is null or b.bDeleted=0)
	AND b.dtTransDate BETWEEN DATEADD(dd, 0, DATEDIFF(dd, 0, @startDate  )) AND DATEADD(dd,1, DATEDIFF(dd, 0, @endDate  ))
	and b.nAccountingPeriodID=@accountingPeriod
	
	order by b.dtTransDate
END
