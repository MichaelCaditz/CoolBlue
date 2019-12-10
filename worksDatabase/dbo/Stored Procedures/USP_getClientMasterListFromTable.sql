-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_getClientMasterListFromTable]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	
	@nPageNumber int = 0,
	@nPageSize int = 500,
	@ClientListSaved  ClientSavedList  READONLY

	
AS
BEGIN

--declare @maxCount as int = 10


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 SELECT  distinct  a.ID,a.cName,a.nSalesRepID,
	 contactType.cName as contactType,a.cNotes,
	 a.nContactTypeID,a.nImportID as nImportIDMaster ,a.cImportDB as cImportDBMaster,
	 a.cDescription
	 
	 FROM clientMaster a WITH (NOLOCK)
	 left join contactType WITH (NOLOCK) on a.nContactTypeID = contactType.ID
	 inner join clients a1 WITH (NOLOCK) on a.ID = a1.nClientMasterID 
	 inner join @ClientListSaved z on z.nClientsID = a1.clients_id
						 
		
		order by a.ID OFFSET @nPageNumber * @nPageSize ROWS FETCH NEXT @nPageSize ROWS ONLY
                   				 
END
