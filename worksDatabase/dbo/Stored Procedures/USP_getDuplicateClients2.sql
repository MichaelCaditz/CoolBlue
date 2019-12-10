
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	RETURNS 2 rows which are proposed duplicates
-- =============================================
CREATE PROCEDURE [dbo].[USP_getDuplicateClients2]

	@bfname bit = 1,
	@blname bit = 1,
	@binitial bit = 0,
	@bphone bit = 0,
	@bemail bit = 0,
	@bclientMasterID bit = 0,
	@baddress bit = 0,
	@bcity bit = 0,
	@bstate bit = 0


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	CREATE TABLE #tmpClientID 
	( 
	   COL1 INT ,
	   COL2 INT 
	) 


	DECLARE @ORDERBY nvarchar(100)
	DECLARE @SUBQUERY nvarchar(3000)
	DECLARE @SELECT nvarchar(2000)
	DECLARE @WHERE nvarchar(1000)

	--+ N'CAST(C1.clients_id as varchar) + '','' + CAST(C2.clients_id as varchar) '

	SET @SELECT =  N'SELECT TOP (1) ' 
	+ N'C1.clients_id ,C2.clients_id '
	+ N'FROM clients C1 ,clients C2   ';

SET @WHERE = N'WHERE  '
	+ N'C1.clients_id < C2.clients_id '

	if @blname = 1 SET @WHERE = @WHERE + N' AND C1.lname = C2.lname  ';
	if @bfname = 1 SET @WHERE = @WHERE + N' AND C1.fname = C2.fname  ';
	if @binitial = 1 SET @WHERE = @WHERE + N' AND C1.initial = C2.initial  ';
	if @bphone = 1 SET @WHERE = @WHERE + N' AND C1.phone = C2.phone  ';
	if @bemail = 1 SET @WHERE = @WHERE + N' AND C1.email = C2.email  ';
	if @bclientMasterID = 1 SET @WHERE = @WHERE + N' AND C1.nClientMasterID = C2.nClientMasterID ';
	if @baddress = 1 SET @WHERE = @WHERE + N' AND C1.address1 = C2.address1  ';
	if @bcity = 1 SET @WHERE = @WHERE + N' AND C1.city = C2.city  ';
	if @bstate = 1 SET @WHERE = @WHERE + N' AND C1.state = C2.state  ';
	
	if SIGN((@blname+0) + (@bfname+0) + (@binitial+0) + (@bphone+0) + (@bemail+0) + (@bclientMasterID+0) + (@baddress+0)+ (@bcity+0)+ (@bstate+0)) = 0 
			SET @WHERE = @WHERE +' AND 0=1 ' -- no results if no options set

SET @ORDERBY = ' ORDER BY C1.clients_id DESC';

SET @SUBQUERY = @SELECT + ' '+  @WHERE + ' ' +  @ORDERBY

INSERT INTO #tmpClientID EXEC sp_executesql @SUBQUERY;




SELECT 
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
	INNER JOIN #tmpClientID T
	ON (clients.clients_id = T.COL1 OR clients.clients_id = T.COL2)
	


END




