-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_KEEP_getClientList1]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	@lname nVarchar(255),
	@fname nVarchar(255),
	@email nVarchar(255),
	@bus_phone nVarchar(255),
	@res_phone nVarchar(255),
	@cell_phone nVarchar(255)
	
AS
BEGIN


IF OBJECT_ID ('dbo.table1', 'U') IS NOT NULL
DROP TABLE dbo.table1;

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 --SELECT distinct a.clients_id, a.fname, a.lname,
	 -- a.address1,a.address2,a.city,a.[state],
	 --a.zip,a.country,a.res_phone,a.bus_phone,a.cell_phone,a.nClientMasterID,
	 --a.cTitle,a.fax_phone,a.phone,a.cPhoneOther,a.company_name,a.cDescription,
	 --a.cmpDisplay,a.cmpDisplayWithCity,a.notes,a.cmpDisplayWithAddress,a.cWebsite,
	 --a.email
	 select a.nClientMasterID
	 into table1
	 
	 FROM clients a WITH (NOLOCK)
						 where
						 
		(a.lname like @lname or a.lname is null  )
		and (a.fname like @fname or a.fname is null )
		and (a.email like @email or a.email is null  )
		and (a.bus_phone like @bus_phone or a.bus_phone is null  )
		and (a.res_phone like @res_phone  or a.res_phone is null )
		and (a.cell_phone like @cell_phone  or a.cell_phone is null )
		
		
		
	 SELECT distinct a.clients_id, a.fname, a.lname,
	  a.address1,a.address2,a.city,a.[state],
	 a.zip,a.country,a.res_phone,a.bus_phone,a.cell_phone,a.nClientMasterID,
	 a.cTitle,a.fax_phone,a.phone,a.cPhoneOther,a.company_name,a.cDescription,
	 a.cmpDisplay,a.cmpDisplayWithCity,a.notes,a.cmpDisplayWithAddress,a.cWebsite,
	 a.email,a.bNTTC
	 FROM clients a WITH (NOLOCK) inner join table1 b on a.nClientMasterID = b.nClientMasterID

	IF OBJECT_ID ('dbo.table1', 'U') IS NOT NULL
	DROP TABLE dbo.table1;
		
                   				 
END



