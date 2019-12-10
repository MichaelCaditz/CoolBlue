-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getClientListFromTable]
	@nPageNumber int = 0,
	@nPageSize int = 500,
	
	@ClientListSaved  ClientSavedList  READONLY
	
	
AS
BEGIN

(
-- SELECT DIRECT RESULTS:

SELECT DISTINCT  a.clients_id, a.fname, a.lname,
     a.address1,a.address2,a.city,a.[state],
     a.zip,a.country,a.res_phone,a.bus_phone,a.cell_phone,a.nClientMasterID,
     a.cTitle,a.fax_phone,a.phone,a.cPhoneOther,a.company_name,a.cDescription,
     a.cmpDisplay,a.cmpDisplayWithCity,a.notes,a.cmpDisplayWithAddress,a.cWebsite,
     a.email,a.email2,a.bNTTC,a.bSendPaperMail,a.bSendEmail,a.initial,a.company_title,
	 a.cAssistant,a.cAssistantPhone, a.cEmailAssistant,a.bPrimary, CAST(1 as bit) AS 'bDirectSearchResult',
	 a.nImportID as nImportIDClient ,a.cImportDB as cImportDBClient ,a.bRecordChecked,a.bPrivate,a.cSalesRep2,a.bArchived,
	  a.cHours,a.cMapURL,a.bWebsiteGallery
     FROM clients a WITH (NOLOCK)
	 inner join @ClientListSaved z on z.nClientsID = a.clients_id
	 WHERE
         a.nClientMasterID is not null and  a.nClientMasterID >0
		 )

UNION 

--SELECT SIBLINGS OF DIRECT RESULTS:
(
SELECT DISTINCT  a1.clients_id, a1.fname, a1.lname,
     a1.address1,a1.address2,a1.city,a1.[state],
     a1.zip,a1.country,a1.res_phone,a1.bus_phone,a1.cell_phone,a1.nClientMasterID,
     a1.cTitle,a1.fax_phone,a1.phone,a1.cPhoneOther,a1.company_name,a1.cDescription,
     a1.cmpDisplay,a1.cmpDisplayWithCity,a1.notes,a1.cmpDisplayWithAddress,a1.cWebsite,
     a1.email,a1.email2,a1.bNTTC,a1.bSendPaperMail,a1.bSendEmail,a1.initial,a1.company_title,
	 a1.cAssistant,a1.cAssistantPhone, a1.cEmailAssistant,a1.bPrimary, CAST(0 as bit) AS 'bDirectSearchResult',
	 a1.nImportID as nImportIDClient ,a1.cImportDB as cImportDBClient ,a1.bRecordChecked as bRecordChecked,a1.bPrivate,a1.cSalesRep2,a1.bArchived,
	  a1.cHours,a1.cMapURL,a1.bWebsiteGallery
     FROM clients a1 WITH (NOLOCK) 
	 
	 WHERE  
		a1.nClientMasterID IN (
		SELECT  DISTINCT nClientMasterID
		FROM clients WITH (NOLOCK) 	
		inner join @ClientListSaved z on z.nClientsID = a1.clients_id	
		
		)
		and a1.clients_id NOT IN
		(
			SELECT clients_id FROM clients 
			inner join @ClientListSaved y on y.nClientsID = a1.clients_id	
			
		)

		)

	
		


	ORDER BY bPrimary DESC,lname OFFSET @nPageNumber * @nPageSize ROWS FETCH NEXT @nPageSize ROWS ONLY

	


	
                   				 
END
