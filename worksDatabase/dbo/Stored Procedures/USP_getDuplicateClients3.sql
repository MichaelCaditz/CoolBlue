

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	GETS potential duplicate clients given a client_id
-- =============================================
CREATE PROCEDURE [dbo].[USP_getDuplicateClients3]
	@clientID int ,
	@bfname bit = 1,
	@blname bit = 1,
	@binitial bit = 0,
	@bphone bit = 0,
	@bemail bit = 0,
	@bclientMasterID bit = 0,
	@baddress1 bit = 0,
	@baddress2 bit = 0,
	@bcity bit = 0,
	@bstate bit = 0,
	@bzip bit = 0,
	@bcountry bit = 0


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



	--CREATE TABLE #tmpClientID 
	--( 
	--   COL1 INT 
	--) 
	DECLARE @tmpClientID  TABLE 
	( 
	   COL1 INT 
	) 

	DECLARE @ORDERBY nvarchar(100)
	DECLARE @SUBQUERY nvarchar(3000)
	DECLARE @SELECT nvarchar(2000)
	DECLARE @WHERE nvarchar(1000)

	--+ N'CAST(C1.clients_id as varchar) + '','' + CAST(C2.clients_id as varchar) '

	SET @SELECT =  N'SELECT  ' 
	+ N'C2.clients_id '
	+ N'FROM clients C1 ,clients C2   ';

SET @WHERE = N'WHERE  '
	+ N'C1.clients_id = ''' + CAST(@clientID as varchar) + '''' 
	+ N' AND C1.clients_id <> C2.clients_id ';

	if @blname = 1 SET @WHERE = @WHERE + N' AND C1.lname = C2.lname  ';
	if @bfname = 1 SET @WHERE = @WHERE + N' AND C1.fname = C2.fname  ';
	if @binitial = 1 SET @WHERE = @WHERE + N' AND C1.initial = C2.initial  ';
	if @bphone = 1 SET @WHERE = @WHERE + N' AND C1.phone = C2.phone  ';
	if @bemail = 1 SET @WHERE = @WHERE + N' AND C1.email = C2.email  ';
	if @bclientMasterID = 1 SET @WHERE = @WHERE + N' AND C1.nClientMasterID = C2.nClientMasterID ';
	if @baddress1 = 1 SET @WHERE = @WHERE + N' AND C1.address1 = C2.address1  ';
	if @baddress2 = 1 SET @WHERE = @WHERE + N' AND C1.address2 = C2.address2  ';
	if @bcity = 1 SET @WHERE = @WHERE + N' AND C1.city = C2.city  ';
	if @bstate = 1 SET @WHERE = @WHERE + N' AND C1.state = C2.state  ';
	if @bzip = 1 SET @WHERE = @WHERE + N' AND C1.zip = C2.zip ';
	if @bcountry = 1 SET @WHERE = @WHERE + N' AND C1.country = C2.country  ';

	if SIGN((@blname+0) + (@bfname+0) + (@binitial+0) + (@bphone+0) + (@bemail+0) + (@bclientMasterID+0) + (@baddress1+0) + (@baddress2+0)+ (@bcity+0)+ (@bzip+0)+ (@bstate+0)+ (@bcountry+0)) = 0 
			SET @WHERE = @WHERE +' AND 0=1 ' -- no results if no options set

SET @ORDERBY = ' ORDER BY C1.clients_id DESC';

SET @SUBQUERY = @SELECT + ' '+  @WHERE + ' ' +  @ORDERBY

--INSERT INTO @tmpClientID VALUES ( @clientID);
INSERT INTO @tmpClientID EXEC sp_executesql @SUBQUERY;
--SELECT * FROM #tmpClientID 



-- @bMerge is a fake field to trivk Visual Studio into adding a boolean field on the bound grid control.
	DECLARE @bMerge as bit;
	SET @bMerge = 0;

	SELECT 
	@bMerge as 'merge',
	clients_id ,
	fname,
	initial,
	lname ,
	phone ,
	address1 ,
	address2 ,
	city ,
	state ,
	zip ,
	country ,
	email ,
	email2 ,
	bus_phone ,
	res_phone ,
	fax_phone ,
	cell_phone ,
	company_name ,
	company_title ,
	notes ,
	cWebsite ,
	cDescription,
	cPhoneOther ,
	cSalesRep2 ,
	cAssistant ,
	cAssistantPhone ,
	nClientMasterID 
	FROM clients
	WHERE clients_id in( SELECT * FROM @tmpClientID )

END





