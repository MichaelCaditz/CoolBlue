-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getClientList]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	@lname nVarchar(255) = NULL,
	@fname nVarchar(255) = NULL,
	@email nVarchar(255) = NULL,
	@bus_phone nVarchar(255) = NULL,
	@res_phone nVarchar(255) = NULL,
	@cell_phone nVarchar(255) = NULL,
	@company nVarchar(255) = NULL,
	@clients_id nVarchar(255) = NULL,
	--@nClientsID int
	@nPageNumber int = 0,
	@nPageSize int = 500
	
AS
BEGIN


-- SELECT DIRECT RESULTS:
(
SELECT DISTINCT  a.clients_id, a.fname, a.lname,
     a.address1,a.address2,a.city,a.[state],a.bDeceased,
     a.zip,a.country,a.res_phone,a.bus_phone,a.cell_phone,a.nClientMasterID,
     a.cTitle,a.fax_phone,a.phone,a.cPhoneOther,a.company_name,a.cDescription,
     a.cmpDisplay,a.cmpDisplayWithCity,a.notes,a.cmpDisplayWithAddress,a.cWebsite,
     a.email,a.email2,a.bNTTC,a.bSendPaperMail,a.bSendEmail,a.initial,a.company_title,
	 a.cAssistant,a.cAssistantPhone, a.cEmailAssistant,a.bPrimary, CAST(1 as bit) AS 'bDirectSearchResult',
	 a.nImportID as nImportIDClient ,a.cImportDB as cImportDBClient ,a.bRecordChecked,a.bPrivate,a.cSalesRep2,a.bArchived,
	 a.cHours,a.cMapURL,a.bWebsiteGallery
     FROM clients a WITH (NOLOCK)

	 WHERE
        a.nClientMasterID is not null and  a.nClientMasterID >0
		 and  isnull(a.nMergedToID,0) = 0 and            
        (upper(isnull(a.lname,'')) like upper(@lname) )
        and (upper(isnull(a.fname,'')) like upper(@fname) )
        and (upper(isnull(a.email,'')) like upper(@email) )
		and (upper(isnull(a.company_name,'')) like upper(@company) )
        and ((upper(isnull(a.bus_phone,'')) like upper(@bus_phone))
        or (upper(isnull(a.res_phone,'')) like upper(@bus_phone))
        or (upper(isnull(a.cell_phone,'')) like upper(@bus_phone)))
		and (upper(isnull(a.clients_id,'')) like upper(@clients_id) or @clients_id = '') 
		
		)

UNION 

--SELECT SIBLINGS OF DIRECT RESULTS:
(
SELECT DISTINCT  a.clients_id, a.fname, a.lname,
     a.address1,a.address2,a.city,a.[state],a.bDeceased,
     a.zip,a.country,a.res_phone,a.bus_phone,a.cell_phone,a.nClientMasterID,
     a.cTitle,a.fax_phone,a.phone,a.cPhoneOther,a.company_name,a.cDescription,
     a.cmpDisplay,a.cmpDisplayWithCity,a.notes,a.cmpDisplayWithAddress,a.cWebsite,
     a.email,a.email2,a.bNTTC,a.bSendPaperMail,a.bSendEmail,a.initial,a.company_title,
	 a.cAssistant,a.cAssistantPhone, a.cEmailAssistant,a.bPrimary, CAST(0 as bit) AS 'bDirectSearchResult',
	 a.nImportID as nImportIDClient ,a.cImportDB as cImportDBClient ,a.bRecordChecked as bRecordChecked,a.bPrivate,a.cSalesRep2,a.bArchived,
	  a.cHours,a.cMapURL,a.bWebsiteGallery
     FROM clients a WITH (NOLOCK) 
	 
	 WHERE    isnull(a.nMergedToID,0) = 0 and   
		a.nClientMasterID IN (
		SELECT  DISTINCT nClientMasterID
		FROM clients WITH (NOLOCK) 		
		WHERE                         
        (
			(upper(isnull(lname,'')) like upper(@lname) )
        and (upper(isnull(fname,'')) like upper(@fname) )
        and (upper(isnull(email,'')) like upper(@email) )
		and (upper(isnull(company_name,'')) like upper(@company) )
        and ((upper(isnull(bus_phone,'')) like upper(@bus_phone))
        or (upper(isnull(res_phone,'')) like upper(@bus_phone))
        or (upper(isnull(cell_phone,'')) like upper(@bus_phone)))
		and (upper(isnull(clients_id,'')) like upper(@clients_id) or @clients_id = '') 
		)
		)
		AND a.clients_id NOT IN
		(
			SELECT clients_id FROM clients 
			WHERE 
			(upper(isnull(lname,'')) like upper(@lname) )
        and (upper(isnull(fname,'')) like upper(@fname) )
        and (upper(isnull(email,'')) like upper(@email) )
		and (upper(isnull(company_name,'')) like upper(@company) )
        and ((upper(isnull(bus_phone,'')) like upper(@bus_phone))
        or (upper(isnull(res_phone,'')) like upper(@bus_phone))
        or (upper(isnull(cell_phone,'')) like upper(@bus_phone)))
		and (upper(isnull(clients_id,'')) like upper(@clients_id) or @clients_id = '') 
		)

)


	ORDER BY a.bPrimary DESC,lname OFFSET @nPageNumber * @nPageSize ROWS FETCH NEXT @nPageSize ROWS ONLY



--SELECT distinct top 500 a.clients_id, a.fname, a.lname,
--      a.address1,a.address2,a.city,a.[state],
--     a.zip,a.country,a.res_phone,a.bus_phone,a.cell_phone,a.nClientMasterID,
--     a.cTitle,a.fax_phone,a.phone,a.cPhoneOther,a.company_name,a.cDescription,
--     a.cmpDisplay,a.cmpDisplayWithCity,a.notes,a.cmpDisplayWithAddress,a.cWebsite,
--     a.email,a.bNTTC,a.bSendPaperMail,a.bSendEmail,a.initial,
--	 a.cAssistant,a.cAssistantPhone, a.cEmailAssistant,a.bPrimary
--     FROM clients a

--WITH (NOLOCK) WHERE  a.nClientMasterID IN(


--select distinct a1.nClientMasterID

--FROM clients a1 
--                        WITH (NOLOCK) where
                         
--        (upper(a1.lname) like upper(@lname) or a1.lname is null  )
--        and (upper(a1.fname) like upper(@fname) or a1.fname is null )
--        and (upper(a1.email) like upper(@email) or a1.email is null  )
--        and (upper(a1.bus_phone) like upper(@bus_phone) or a1.bus_phone is null  )
--        and (upper(a1.res_phone) like upper(@res_phone)  or a1.res_phone is null )
--        and (upper(a1.cell_phone) like upper(@cell_phone)  or a1.cell_phone is null )
--		 and (upper(a1.clients_id) like upper(@clients_id)  or a1.clients_id is null )

		 
--)
--and a.clients_id>@nClientsID
--order by a.clients_id
		
                   				 
END
