-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getDuplicateClients]
	@count int = 100,
	@bfname bit = 0,
	@blname bit = 0,
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

	DECLARE @ORDERBY nvarchar(100)
	DECLARE @QUERY nvarchar(3000)
	DECLARE @SELECT nvarchar(2000)
	DECLARE @WHERE nvarchar(1000)

	SET @SELECT =      N'SELECT TOP (' + CAST(@count as nvarchar)+ ') ' 
	+ N'C1.clients_id as ''C1_clients_id'','
	+ N'C1.fname as ''C1_fname'','
	+ N'C1.initial as ''C1_initial'','
	+ N'C1.lname as ''C1_lname'','
	+ N'C1.phone as ''C1_phone'','
	+ N'C1.address1 as ''C1_address1'','
	+ N'C1.address2 as ''C1_address2'','
	+ N'C1.city as ''C1_city'','
	+ N'C1.state as ''C1_state'','
	+ N'C1.zip as ''C1_zip'','
	+ N'C1.country as ''C1_country'','
	+ N'C1.email as ''C1_email'','
	+ N'C1.email2 as ''C1_email2'','
	+ N'C1.bus_phone as ''C1_bus_phone'','
	+ N'C1.res_phone as ''C1_res_phone'','
	+ N'C1.fax_phone as ''C1_fax_phone'','
	+ N'C1.cell_phone as ''C1_cell_phone'','
	+ N'C1.company_name as ''C1_company_name'','
	+ N'C1.company_title as ''C1_company_title'','
	+ N'C1.notes as ''C1_notes'','
	+ N'C1.cWebsite as ''C1_cWebsite'','
	+ N'C1.cDescription as ''C1_cDescription'','
	+ N'C1.cPhoneOther as ''C1_cPhoneOther'','
	+ N'C1.cSalesRep2 as ''C1_cSalesRep2'','
	+ N'C1.cAssistant as ''C1_cAssistant'','
	+ N'C1.cAssistantPhone as ''C1_cAssistantPhone'','
	+ N'C1.nClientMasterID as ''C1_nClientMasterID '' ,'
	+ N'C2.clients_id as C2_clients_id,'
	+ N'C2.fname as ''C2_fname'','
	+ N'C2.initial as ''C2_initial'','
	+ N'C2.lname as ''C2_lname'','
	+ N'C2.phone as ''C2_phone'','
	+ N'C2.address1 as ''C2_address1'','
	+ N'C2.address2 as ''C2_address2'','
	+ N'C2.city as ''C2_city'','
	+ N'C2.state as ''C2_state'','
	+ N'C2.zip as ''C2_zip'','
	+ N'C2.country as ''C2_country'','
	+ N'C2.email as ''C2_email'','
	+ N'C2.email2 as ''C2_email2'','
	+ N'C2.bus_phone as ''C2_bus_phone'','
	+ N'C2.res_phone as ''C2_res_phone'','
	+ N'C2.fax_phone as ''C2_fax_phone'','
	+ N'C2.cell_phone as ''C2_cell_phone'','
	+ N'C2.company_name as ''C2_company_name'','
	+ N'C2.company_title as ''C2_company_title'','
	+ N'C2.notes as ''C2_notes'','
	+ N'C2.cWebsite as ''C2_cWebsite'','
	+ N'C2.cDescription as ''C2_cDescription'','
	+ N'C2.cPhoneOther as ''C2_cPhoneOther'','
	+ N'C2.cSalesRep2 as ''C2_cSalesRep2'','
	+ N'C2.cAssistant as ''C2_cAssistant'','
	+ N'C2.cAssistantPhone as ''C2_cAssistantPhone'','
	+ N'C2.nClientMasterID as ''C2_nClientMasterID '' '
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

SET @QUERY = @SELECT + ' '+  @WHERE + ' ' +  @ORDERBY
 --SELECT @QUERY
EXEC sp_executesql @QUERY

END



