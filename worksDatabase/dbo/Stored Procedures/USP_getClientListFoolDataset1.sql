-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_getClientListFoolDataset1]
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




	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 --SELECT distinct a.clients_id, a.fname, a.lname,
	 -- a.address1,a.address2,a.city,a.[state],
	 --a.zip,a.country,a.res_phone,a.bus_phone,a.cell_phone,a.nClientMasterID,
	 --a.cTitle,a.fax_phone,a.phone,a.cPhoneOther,a.company_name,a.cDescription,
	 --a.cmpDisplay,a.cmpDisplayWithCity,a.notes,a.cmpDisplayWithAddress,a.cWebsite,
	 --a.email
	 
	 
	
		
		
	 SELECT distinct a.clients_id, a.fname, a.lname,
	  a.address1,a.address2,a.city,a.[state],
	 a.zip,a.country,a.res_phone,a.bus_phone,a.cell_phone,a.nClientMasterID,
	 a.cTitle,a.fax_phone,a.phone,a.cPhoneOther,a.company_name,a.cDescription,
	 a.cmpDisplay,a.cmpDisplayWithCity,a.notes,a.cmpDisplayWithAddress,a.cWebsite,
	 a.email,a.bNTTC
	 FROM clients a WITH (NOLOCK) 

	
		
                   				 
END



