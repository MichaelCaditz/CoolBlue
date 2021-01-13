-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getOneAccount]
	@AccountID int
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
	
	 SELECT a.ID,a.dtCreateDate,a.cName,a.cNote,a.nAccountTypeID,a.cDesc,a.cComment,a.nCurrencyID,a.nCatID,

	 cInstitutionNum,cTransitNum,cSwiftCode,nCreditLimit,cContactName,cURL,cContactEmail,cContactPhone,

	 a.nBillDate, a.nForeignConversionFee,a.nRoutingNumber,a.cAccountHolderName1,a.cAccountHolderName2,

	



	CONVERT(nvarchar(50),  
    DecryptByKey(a.pin_Encrypted, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary(256), a.ID))))  
    AS 'cDecryptedPIN' ,

	CONVERT(nvarchar(50),  
    DecryptByKey(a.CV_Encrypted, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary(256), a.ID))))  
    AS 'cDecryptedCV' ,

	CONVERT(nvarchar(50),  
    DecryptByKey(a.expiry_Encrypted, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary(256), a.ID))))  
    AS 'cDecryptedExpiry' ,

	CONVERT(nvarchar(50),  
    DecryptByKey(a.acctNum_Encrypted, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary(256), a.ID))))  
    AS 'cDecryptedAcctNum' ,

	CONVERT(nvarchar(50),  
    DecryptByKey(a.cardNum_Encrypted, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary(256), a.ID))))  
    AS 'cDecryptedCardNum' ,

	CONVERT(nvarchar(50),  
    DecryptByKey(a.username_Encrypted, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary(256), a.ID))))  
    AS 'cDecryptedUsername' ,

	CONVERT(nvarchar(50),  
    DecryptByKey(a.password_Encrypted, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary(256), a.ID))))  
    AS 'cDecryptedPassword' ,

	CONVERT(nvarchar(50),  
    DecryptByKey(a.CV_Encrypted2, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary(256), a.ID))))  
    AS 'cDecryptedCV2' ,

	CONVERT(nvarchar(50),  
    DecryptByKey(a.pin_Encrypted2, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary(256), a.ID))))  
    AS 'cDecryptedPIN2' ,

	CONVERT(nvarchar(50),  
    DecryptByKey(a.expiry_Encrypted2, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary(256), a.ID))))  
    AS 'cDecryptedExpiry2' ,

	CONVERT(nvarchar(50),  
    DecryptByKey(a.cardNum_Encrypted2, 1 ,   
    HashBytes('SHA1', CONVERT(varbinary(256), a.ID))))  
    AS 'cDecryptedCardNum2' 


	 FROM dbo.account a  WITH (NOLOCK)

	 
	 
	 --left join dbo.line b on a.nLineID = b.ID
	 
	

	 where a.ID = @AccountID
	 
	 --and (a.bDeleted is null or a.bDeleted=0) 
		
	

	
	
		
                   				 
end
