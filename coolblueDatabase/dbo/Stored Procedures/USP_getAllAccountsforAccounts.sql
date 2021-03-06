﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getAllAccountsforAccounts]
	
	--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)
	--@accountID int

AS
BEGIN




	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;




	OPEN SYMMETRIC KEY PIN_Key11  
   DECRYPTION BY CERTIFICATE CCPINS; 


	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.ID,a.dtCreateDate,a.nAccountTypeID,a.cName as cShortName,replace(left(a.cNote,160),CHAR(13)+CHAR(10),' ') as cNote,a.cDesc,a.nCurrencyID,a.nCatID,b.cSymbol as currencyName,b.cSymbol as currencySymbol,
	  isnull(c.cName+': ','')+ a.cName as cName, a.nBillDate, a.nForeignConversionFee,
	   
	  CONVERT(nvarchar,  
    DecryptByKey(a.pin_Encrypted, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary, a.ID))))  
    AS 'cDecryptedPIN' ,

	CONVERT(nvarchar,  
    DecryptByKey(a.CV_Encrypted, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary, a.ID))))  
    AS 'cDecryptedCV' ,

	CONVERT(nvarchar,  
    DecryptByKey(a.expiry_Encrypted, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary, a.ID))))  
    AS 'cDecryptedExpiry' ,

	CONVERT(nvarchar,  
    DecryptByKey(a.acctNum_Encrypted, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary, a.ID))))  
    AS 'cDecryptedAcctNum' 

	 FROM dbo.account a WITH (NOLOCK)
	 left join dbo.currency b on a.nCurrencyID = b.ID
	  left join dbo.cat c on a.nCatID = c.ID
	  left join dbo.accountType d on a.nAccountTypeID=d.ID

	  where  (a.bDeleted is null or a.bDeleted=0) and (d.bIsAll is null or d.bIsAll=0)
		
	--order by a.nAccountTypeID

	order by c.cName+': '+ a.cName
	
		
                   				 
end