﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_updateAccount]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	@ID int,
	@cNote varchar(max),
	@cName nvarchar(255),
	@nAccountTypeID int,
	@cDesc nvarchar(255),
	@cComment nvarchar(255),
	@nCatID int,
	@nCurrencyID int,
	@cDecryptedPIN nvarchar(255),
	@cDecryptedCV nvarchar(255),
	@expiry_Decrypted nvarchar(255),
	@cDecryptedAcctNum nvarchar(255),
	@cDecryptedCardNum nvarchar(255),
	@cInstitutionNum nvarchar(255),
	@cTransitNum nvarchar(255),
	@cUsername nvarchar(255),
	@cPassword nvarchar(255),
	@cSwiftCode nvarchar(255),
	@nCreditLimit decimal(14,2),
	@cContactName nvarchar(255),
	@cURL nvarchar(255),
	@cContactEmail nvarchar(255),
	@cContactPhone nvarchar(255),
	@nBillDate int,
	@nForeignConversionFee decimal(14,4),
	@nRoutingNumber nvarchar(255),
	@cDecryptedPIN2 nvarchar(255),
	@cDecryptedCV2 nvarchar(255),
	@expiry_Decrypted2 nvarchar(255),
	@cDecryptedCardNum2 nvarchar(255),
	@cAccountHolderName1 nvarchar(255),
	@cAccountHolderName2 nvarchar(255)
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	

	OPEN SYMMETRIC KEY PIN_Key11  
   DECRYPTION BY CERTIFICATE CCPINS; 
    -- Insert statements for procedure here
	

	


	update dbo.account

	set cNote = @cNote ,
	
	cName=@cName,
	nAccountTypeID=@nAccountTypeID,
	cDesc=@cDesc,
	cComment=@cComment,
	nCatID=@nCatID,
	nCurrencyID=@nCurrencyID,

	cInstitutionNum=@cInstitutionNum,
	cTransitNum=@cTransitNum,
	
	cSwiftCode=@cSwiftCode,
	nCreditLimit=@nCreditLimit,
	cContactName=@cContactName ,
	cURL=@cURL ,
	cContactEmail=@cContactEmail,
	cContactPhone=@cContactPhone ,
	nBillDate=@nBillDate ,
	nForeignConversionFee=@nForeignConversionFee ,
	nRoutingNumber=@nRoutingNumber,


	pin_Encrypted=EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary(256),@cDecryptedPIN),1, HashBytes('SHA1', CONVERT( varbinary(256)
    , @ID))) ,

	CV_Encrypted=EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary(256),@cDecryptedCV),1, HashBytes('SHA1', CONVERT( varbinary(256)
    , @ID))) ,

	expiry_Encrypted = EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary(256),@expiry_Decrypted),1, HashBytes('SHA1', CONVERT( varbinary(256) 
    , @ID))),

	acctNum_Encrypted = EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary(256),@cDecryptedAcctNum),1, HashBytes('SHA1', CONVERT( varbinary(256)
    , @ID))),

	cardNum_Encrypted = EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary(256),@cDecryptedCardNum),1, HashBytes('SHA1', CONVERT( varbinary(256)
    , @ID))),

	username_Encrypted = EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary(256),@cUsername),1, HashBytes('SHA1', CONVERT( varbinary(256)  
    , @ID))),

	password_Encrypted = EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary(256),@cPassword),1, HashBytes('SHA1', CONVERT( varbinary(256)  
    , @ID))),



	pin_Encrypted2=EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary(256),@cDecryptedPIN2),1, HashBytes('SHA1', CONVERT( varbinary(256)
    , @ID))) ,

	CV_Encrypted2=EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary(256),@cDecryptedCV2),1, HashBytes('SHA1', CONVERT( varbinary(256)
    , @ID))) ,

	expiry_Encrypted2 = EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary(256),@expiry_Decrypted2),1, HashBytes('SHA1', CONVERT( varbinary(256) 
    , @ID))),

	cardNum_Encrypted2 = EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary(256),@cDecryptedCardNum2),1, HashBytes('SHA1', CONVERT( varbinary(256)
    , @ID))),

	cAccountHolderName1=@cAccountHolderName1,

	cAccountHolderName2=@cAccountHolderName2

	

	where ID=@ID

	

end

