-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KEEP_getClientList]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	@lname nVarchar(255),
	@fname nVarchar(255),
	@email nVarchar(255),
	@bus_phone nVarchar(255),
	@res_phone nVarchar(255),
	@cell_phone nVarchar(255),
	@nClientsID int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 SELECT top 50 clients.clients_id, clients.fname, clients.lname,
	  clients.address1,clients.address2,clients.city,clients.[state],
	 clients.zip,clients.country,clients.res_phone,clients.bus_phone,clients.cell_phone,clients.nClientMasterID,
	 clients.cTitle,clients.fax_phone,clients.phone,clients.cPhoneOther,clients.company_name,clients.cDescription,
	 clients.cmpDisplay,clients.cmpDisplayWithCity,clients.notes,clients.cmpDisplayWithAddress,clients.cWebsite,
	 clients.email
	 
	 FROM clients WITH (NOLOCK)  inner join clientMaster WITH (NOLOCK) on clients.nClientMasterID=clientMaster.ID 
						 where
						 
		(clients.lname like @lname or clients.lname is null  )
		and (clients.fname like @fname or clients.fname is null )
		and (clients.email like @email or clients.email is null  )
		and (clients.bus_phone like @bus_phone or clients.bus_phone is null  )
		and (clients.res_phone like @res_phone  or clients.res_phone is null )
		and (clients.cell_phone like @cell_phone  or clients.cell_phone is null )
		
		
		and clients.clients_id > @nClientsID

		order by clients.clients_id
                   				 
END



