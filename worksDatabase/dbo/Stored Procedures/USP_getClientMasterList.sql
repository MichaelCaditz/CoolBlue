-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getClientMasterList]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	@lname nVarchar(255),
	@fname nVarchar(255),
	@email nVarchar(255),
	@bus_phone nVarchar(255),
	@res_phone nVarchar(255),
	@cell_phone nVarchar(255),
	@company nVarchar(255) = NULL,
	@clients_id nVarchar(255),
	@nPageNumber int = 0,
	@nPageSize int = 500

	
AS
BEGIN

--declare @maxCount as int = 10


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 SELECT  distinct clientMaster.ID,clientMaster.cName,clientMaster.nSalesRepID,
	 contactType.cName as contactType,clientMaster.cNotes,
	 clientMaster.nContactTypeID,clientMaster.nImportID as nImportIDMaster ,clientMaster.cImportDB as cImportDBMaster,
	 clientMaster.cDescription
	 
	 FROM clientMaster  WITH (NOLOCK)
	 left join contactType WITH (NOLOCK) on clientMaster.nContactTypeID = contactType.ID
	 inner join clients a1 WITH (NOLOCK) on clientMaster.ID = a1.nClientMasterID 
						 where
						 
		a1.nClientMasterID is not null and  a1.nClientMasterID >0
		 and   isnull(a1.nMergedToID,0) = 0 and              
        (upper(isnull(a1.lname,'')) like upper(@lname) )
        and (upper(isnull(a1.fname,'')) like upper(@fname) )
        and (upper(isnull(a1.email,'')) like upper(@email) )
		 and (upper(isnull(a1.company_name,'')) like upper(@company) )
        and ((upper(isnull(a1.bus_phone,'')) like upper(@bus_phone))
        or (upper(isnull(a1.res_phone,'')) like upper(@bus_phone))
        or (upper(isnull(a1.cell_phone,'')) like upper(@bus_phone)))
		and (upper(isnull(a1.clients_id,'')) like upper(@clients_id) or @clients_id = '' ) 
		
		
		
		order by clientMaster.ID OFFSET @nPageNumber * @nPageSize ROWS FETCH NEXT @nPageSize ROWS ONLY
                   				 
END
