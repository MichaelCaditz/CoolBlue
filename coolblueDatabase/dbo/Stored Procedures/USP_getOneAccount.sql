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


	 FROM dbo.account a  WITH (NOLOCK)

	 
	 
	 --left join dbo.line b on a.nLineID = b.ID
	 
	

	 where a.ID = @AccountID
	 
	 --and (a.bDeleted is null or a.bDeleted=0) 
		
	

	
	
		
                   				 
end
