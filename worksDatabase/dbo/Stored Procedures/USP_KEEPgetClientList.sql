-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_KEEPgetClientList]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	@lname nVarchar(255),
	@fname nVarchar(255),
	@email nVarchar(255),
	@bus_phone nVarchar(255),
	@res_phone nVarchar(255),
	@cell_phone nVarchar(255),
	@clients_id nVarchar(255),
	@nClientsID int
	
AS
BEGIN


SELECT distinct top 500 a.clients_id, a.fname, a.lname,
      a.address1,a.address2,a.city,a.[state],
     a.zip,a.country,a.res_phone,a.bus_phone,a.cell_phone,a.nClientMasterID,
     a.cTitle,a.fax_phone,a.phone,a.cPhoneOther,a.company_name,a.cDescription,
     a.cmpDisplay,a.cmpDisplayWithCity,a.notes,a.cmpDisplayWithAddress,a.cWebsite,
     a.email,a.bNTTC,a.bSendPaperMail,a.bSendEmail,a.initial,
	 a.cAssistant,a.cAssistantPhone, a.cEmailAssistant,a.bPrimary
     FROM clients a

WITH (NOLOCK) WHERE  a.nClientMasterID IN(


select distinct a1.nClientMasterID

FROM clients a1 
                        WITH (NOLOCK) where
                         
        (upper(a1.lname) like upper(@lname) or a1.lname is null  )
        and (upper(a1.fname) like upper(@fname) or a1.fname is null )
        and (upper(a1.email) like upper(@email) or a1.email is null  )
        and (upper(a1.bus_phone) like upper(@bus_phone) or a1.bus_phone is null  )
        and (upper(a1.res_phone) like upper(@res_phone)  or a1.res_phone is null )
        and (upper(a1.cell_phone) like upper(@cell_phone)  or a1.cell_phone is null )
		 and (upper(a1.clients_id) like upper(@clients_id)  or a1.clients_id is null )

		 
)
and a.clients_id>@nClientsID
order by bPrimary desc,a.clients_id
		
                   				 
END



