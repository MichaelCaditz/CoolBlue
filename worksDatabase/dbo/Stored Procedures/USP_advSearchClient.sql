
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_advSearchClient]
@clientSearchList [dbo].[clientSearchList] READONLY
	
AS
BEGIN

--SELECT * FROM @clientSearchList

--return



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
	 LEFT JOIN clientsContactGroup CCG WITH (NOLOCK) ON a.clients_id = CCG.nClientsID
	 LEFT JOIN contactGroup CG WITH (NOLOCK) ON CG.ID = CCG.nContactGroupID
	 INNER JOIN @clientSearchList T  ON
		  
		(		
			(  (T.cClientIDs IS NULL) AND (T.cmpDisplay IS NULL OR a.cmpDisplay LIKE ('%'	+  T.cmpDisplay + '%') collate SQL_Latin1_General_CP1_CI_AS )   )   	  
			OR 
			(  (T.cClientIDs IS NOT NULL)  AND (a.clients_id IN (SELECT ID FROM UDF_String_to_intTable(T.cClientIDs ,',')))   ) 
		)
		AND
		(
			(  (T.cityIn IS NULL) AND (T.city IS NULL OR a.city LIKE ('%'	+ T.city + '%') collate SQL_Latin1_General_CP1_CI_AS  )   )   	  
			OR 
			(  (T.cityIn IS NOT NULL)  AND (a.city IN (SELECT * FROM UDF_String_to_charTable(T.cityIn ,',')))   ) 

		)
		AND
		
		
		(
			(  (T.stateIn IS NULL) AND (T.[state] IS NULL OR a.[state] LIKE ('%'	+ T.[state] + '%') 	collate SQL_Latin1_General_CP1_CI_AS )    ) 
			OR 
			(  (T.stateIn IS NOT NULL)  AND (a.[state] IN (SELECT * FROM UDF_String_to_charTable(T.stateIn ,',')))   ) 

		)
		
		AND
		(
			(  (T.zipIn IS NULL) AND (T.zip IS NULL OR a.zip LIKE ('%'	+ T.zip + '%')  collate SQL_Latin1_General_CP1_CI_AS )   )   	  
			OR 
			(  (T.zipIn IS NOT NULL)  AND (a.zip IN (SELECT * FROM UDF_String_to_charTable(T.zipIn ,',')))   ) 

		)
		AND
		(
			(  (T.countryIn IS NULL) AND (T.country IS NULL OR a.country LIKE ('%'	+ T.country + '%')  collate SQL_Latin1_General_CP1_CI_AS )   )   	  
			OR 
			(  (T.countryIn IS NOT NULL)  AND (a.country IN (SELECT * FROM UDF_String_to_charTable(T.countryIn ,',')))   ) 
		)
		AND
		(
			(  (T.cGroupIDs IS NULL) AND (T.[group] IS NULL OR CG.cName LIKE ('%'	+ T.[group] + '%') collate SQL_Latin1_General_CP1_CI_AS  )   )   	  
			OR 
			(  (T.cGroupIDs IS NOT NULL)  AND (CG.ID IN (SELECT ID FROM UDF_String_to_intTable(T.cGroupIDs ,',')))   ) 
		)
		AND
		(
			(  (T.cTypeIDs IS NULL) AND (T.[type] IS NULL OR CT.cName LIKE ('%'	+ T.[type] + '%')  collate SQL_Latin1_General_CP1_CI_AS )   )   	  
			OR 
			(  (T.cTypeIDs IS NOT NULL)  AND (CT.ID IN (SELECT ID FROM UDF_String_to_intTable(T.cTypeIDs ,',')))   ) 

		)



                   				 
END
