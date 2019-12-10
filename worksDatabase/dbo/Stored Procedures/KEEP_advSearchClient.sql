

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[KEEP_advSearchClient]
--@clientSearchList [dbo].[clientSearchList] READONLY
	
AS
BEGIN


--collate SQL_Latin1_General_CP1_CI_AS 

SELECT distinct a.clients_id, a.fname, a.lname,
      a.address1,a.address2,a.city,a.[state],
     a.zip,a.country,a.res_phone,a.bus_phone,a.cell_phone,a.nClientMasterID,
     a.cTitle,a.fax_phone,a.phone,a.cPhoneOther,a.company_name,a.cDescription,
     a.cmpDisplay,a.cmpDisplayWithCity,a.notes,a.cmpDisplayWithAddress,a.cWebsite,
     a.email,a.bNTTC,CT.cName as 'contactTypeName',CM.cName as 'masterClientName'
     FROM clients a  WITH (NOLOCK) 

	 INNER JOIN clientMaster CM WITH (NOLOCK) on a.nClientMasterID = CM.ID
	 LEFT JOIN contactType CT WITH (NOLOCK) ON CM.nContactTypeID = CT.ID

		WHERE  a.nClientMasterID IN
(


select distinct a1.nClientMasterID



FROM clients a1 WITH (NOLOCK) 
INNER JOIN clientMaster CM WITH (NOLOCK) on a1.nClientMasterID = CM.ID
LEFT JOIN clientsContactGroup CCG WITH (NOLOCK) ON a1.clients_id = CCG.nClientsID
LEFT JOIN contactGroup CG WITH (NOLOCK) ON CG.ID = CCG.nContactGroupID
LEFT JOIN contactType CT WITH (NOLOCK) ON CM.nContactTypeID = CT.ID
--INNER JOIN @clientSearchList T  ON
--		  --a1.[state] IN (SELECT data FROM UDF_String_to_charTable(T.[stateIn] ,','))
--		  --OR
--		  -- a1.[city] IN (SELECT data FROM UDF_String_to_charTable(T.cityIn ,','))
--		(			
--			(  (T.cClientIDs IS NULL) AND (T.cmpDisplay IS NULL OR a1.cmpDisplay LIKE T.cmpDisplay + '%' collate SQL_Latin1_General_CP1_CI_AS )   )   	  
--			OR 
--			(  (T.cClientIDs IS NOT NULL)  AND (a1.clients_id IN (SELECT ID FROM UDF_String_to_intTable(T.cClientIDs ,',')))   ) 
--		)
--		AND
--		(
--			(  (T.cityIn IS NULL) AND (T.city IS NULL OR a1.city LIKE T.city + '%' collate SQL_Latin1_General_CP1_CI_AS  )   )   	  
--			OR 
--			(  (T.cityIn IS NOT NULL)  AND (a1.city IN (SELECT * FROM UDF_String_to_charTable(T.cityIn ,',')))   ) 

--		)
--		AND
		
		
--		(
--			(  (T.stateIn IS NULL) AND (T.[state] IS NULL OR a1.[state] LIKE T.[state] + '%' 	collate SQL_Latin1_General_CP1_CI_AS )    ) 
--			OR 
--			(  (T.stateIn IS NOT NULL)  AND (a1.[state] IN (SELECT * FROM UDF_String_to_charTable(T.stateIn ,',')))   ) 

--		)
		
--		AND
--		(
--			(  (T.zipIn IS NULL) AND (T.zip IS NULL OR a1.zip LIKE T.zip + '%'  collate SQL_Latin1_General_CP1_CI_AS )   )   	  
--			OR 
--			(  (T.zipIn IS NOT NULL)  AND (a1.zip IN (SELECT * FROM UDF_String_to_charTable(T.zipIn ,',')))   ) 

--		)
--		AND
--		(
--			(  (T.cGroupIDs IS NULL) AND (T.[group] IS NULL OR CG.cName LIKE T.[group] + '%' collate SQL_Latin1_General_CP1_CI_AS  )   )   	  
--			OR 
--			(  (T.cGroupIDs IS NOT NULL)  AND (CG.ID IN (SELECT ID FROM UDF_String_to_intTable(T.cGroupIDs ,',')))   ) 
--		)
--		AND
--		(
--			(  (T.cTypeIDs IS NULL) AND (T.[type] IS NULL OR CT.cName LIKE T.[type] + '%'  collate SQL_Latin1_General_CP1_CI_AS )   )   	  
--			OR 
--			(  (T.cTypeIDs IS NOT NULL)  AND (CT.ID IN (SELECT ID FROM UDF_String_to_intTable(T.cTypeIDs ,',')))   ) 

--		)


)
                   				 
END
