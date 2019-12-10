


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	GETS potential duplicate clients given a client_id
-- =============================================
CREATE PROCEDURE [dbo].[USP_getDuplicateClientMaster]
	@clientMasterID int ,
	@bName bit = 1,
	@bDescription bit = 0,
	@bNotes bit = 0,
	@bSalesRep bit = 0,
	@bContactType bit = 0,
	@bCreateDate bit = 0,
	@bModifyDate bit = 0,
	@bChild bit = 0


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



	--CREATE TABLE #tmpClientID 
	--( 
	--   COL1 INT 
	--) 
	DECLARE @tmpClientMasterID  TABLE 
	( 
	   COL1 INT 
	) 

	DECLARE @ORDERBY nvarchar(100)
	DECLARE @SUBQUERY nvarchar(3000)
	DECLARE @SELECT nvarchar(2000)
	DECLARE @WHERE nvarchar(1000)

	--+ N'CAST(C1.clients_id as varchar) + '','' + CAST(C2.clients_id as varchar) '

	SET @SELECT =  N'SELECT  TOP(100) ' 
	+ N'C2.ID '
	+ N'FROM clientMaster C1 ,clientMaster C2    ';
	if @bChild = 1 
	SET @SELECT = @SELECT + N',clients CL1 ,clients CL2     ';


SET @WHERE = N'WHERE  '
	+ N' C1.ID = ''' + CAST(@clientMasterID as varchar) + '''' 
	+ N' AND C1.ID <> C2.ID ';

	if @bName = 1 SET @WHERE = @WHERE + N' AND UPPER(C2.cName) LIKE UPPER(STUFF(C1.cName,6,20,''%'') ) ';
	if @bDescription = 1 SET @WHERE = @WHERE + N' AND C1.cDescription = C2.cDescription  ';
	if @bNotes = 1 SET @WHERE = @WHERE + N' AND UPPER(C2.cNotes) = UPPER(C1.cNotes)  ';
	if @bSalesRep = 1 SET @WHERE = @WHERE + N' AND C1.nSalesRepID = C2.nSalesRepID  ';
	if @bCreateDate = 1 SET @WHERE = @WHERE + N' AND ABS(DATEDIFF(dd,C1.dtCreateDate, C2.dtCreateDate)) < 1  ';
	if @bModifyDate = 1 SET @WHERE = @WHERE + N' AND ABS(DATEDIFF(dd,C1.dtModifyDate, C2.dtModifyDate)) < 1  ';


	if @bChild = 1 
	BEGIN
			SET @WHERE = @WHERE + N' AND CL1.nClientMasterID =  C1.ID  '
			 + N'AND CL2.nClientMasterID =  C2.ID  '
			 + N'AND ( '
			 + N'(CL1.lname = CL2.lname) '
			 + N'OR '
			 + N'(CL1.company_name = CL2.company_name) '
			 + N'OR '
			 + N'(CL1.phone = CL2.phone) '
			 + N'OR '
			 + N'(CL1.address1 = CL2.address1)'
			 + N') ';
	END

	if SIGN((@bName+0) + (@bDescription+0) + (@bSalesRep+0) + (@bCreateDate+0) + (@bModifyDate+0) + (@bChild+0)) = 0 
			SET @WHERE = @WHERE +' AND 0=1 ' -- no results if no options set

SET @ORDERBY = ' ORDER BY C2.ID DESC';

SET @SUBQUERY = @SELECT + ' '+  @WHERE + ' ' +  @ORDERBY


--SELECT @SUBQUERY

--RETURN

INSERT INTO @tmpClientMasterID EXEC sp_executesql @SUBQUERY;
--SELECT * FROM #tmpClientID 



-- @bMerge is a fake field to trick Visual Studio into adding a boolean field on the bound grid control.
	DECLARE @bMerge as bit;
	SET @bMerge = 0;

	SELECT 
	@bMerge as 'merge',
	CM.ID ,
	CM.cNotes,
	CM.dtCreateDate,
	CM.dtModifyDate,
	CM.cName,
	CM.cDescription,
	CM.nSalesRepID,
	CM.nContactTypeID,
	CM.cImportDB,
	CT.cName as 'cContactTypeName',
	S.cmpDisplay as cSalesRepName
	FROM clientMaster CM
	LEFT JOIN contactType CT on CM.nContactTypeID = CT.ID
	LEFT JOIN clients S on S.clients_id = CM.nSalesRepID
	WHERE CM.ID IN ( SELECT * FROM @tmpClientMasterID )

END




