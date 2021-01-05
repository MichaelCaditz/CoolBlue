-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getAllAccounts]
	
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
	
	 SELECT a.ID,a.dtCreateDate,a.nAccountTypeID,a.cName as cShortName,a.cNote,a.cDesc,a.nCurrencyID,a.nCatID,b.cName as currencyName,b.cSymbol as currencySymbol,
	  isnull(c.cName+': ','')+ a.cName as cName,
	   
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

	 where (a.bDeleted is null or a.bDeleted=0)
		
	--order by a.nAccountTypeID

	order by c.cName+': '+ a.cName
	
		
                   				 
end



