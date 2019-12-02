-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_insertAccount]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	
	@nAccountTypeID  int = 0,
	@nCatID  int = 0,
	@nCurrencyID  int = 0,
	@cPIN nvarchar = '',
	@cCV nvarchar = '',
	@cExpiry nvarchar = '',
	@cAcctNum nvarchar = '',
	@transactIdentity int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	--CREATE SYMMETRIC KEY PIN_Key11  
 --   WITH ALGORITHM = AES_256  
 --   ENCRYPTION BY CERTIFICATE CCPINS;  

	OPEN SYMMETRIC KEY PIN_Key11  
   DECRYPTION BY CERTIFICATE CCPINS; 


	insert into dbo.account

	(
	cName,
	nAccountTypeID,
	cDesc,
	cComment,
	nCurrencyID,
	cNote,
	nCatID
	
	
	)

	values (
	'',
	@nAccountTypeID,
	'',
	'',
	@nCurrencyID,
	'',
	@nCatID
	


	)

	select @transactIdentity  = SCOPE_IDENTITY();

	UPDATE account
SET pin_Encrypted = EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary,@cPIN),1, HashBytes('SHA1', CONVERT( varbinary  
    , @transactIdentity))),

	CV_Encrypted = EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary,@cCV),1, HashBytes('SHA1', CONVERT( varbinary  
    , @transactIdentity))),

	expiry_Encrypted = EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary,@cExpiry),1, HashBytes('SHA1', CONVERT( varbinary  
    , @transactIdentity))),

	acctNum_Encrypted = EncryptByKey(Key_GUID('PIN_Key11')  
    , convert(varbinary,@cAcctNum),1, HashBytes('SHA1', CONVERT( varbinary  
    , @transactIdentity)))

	where ID = @transactIdentity

	--DROP SYMMETRIC KEY PIN_Key11  
end
