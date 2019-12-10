









CREATE VIEW [dbo].[vw_NYEmailList]
AS
--SELECT        a.clients_id
--from Works.dbo.clients a

--where a.clients_id  in

--(select distinct nClientsID from Works.dbo.clientsContactGroup b
--where b.nContactGroupID in (1022))


--and a.clients_id not in

--(select distinct nClientsID from Works.dbo.clientsContactGroup b
--where b.nContactGroupID in (1017, 1033, 1050, 1051, 1120,1147))

--and a.clients_id  in

--(select distinct nClientMasterID from Works.dbo.clientMasterMailGroup c
--where c.nMailGroupID in (1000))

--and a.cImportDB = 'GalProFront'

SELECT        a.clients_id
from Works.dbo.clients a

where a.clients_id  in

(select distinct nClientsID from Works.dbo.clientsContactGroup b
where b.nContactGroupID in (1022))

and (a.bArchived is null or a.bArchived !=1)

and isnull (a.bDeceased,0) ! =1

and isnull (a.bSendEmail,0) ! =1

and isnull(a.nMergedToID,0) = 0

and a.clients_id  in

(select distinct nClientMasterID from Works.dbo.clientMasterMailGroup c
where c.nMailGroupID in (1014))

and (isnull(a.cImportDB,'GalProFront') = 'GalProFront'
or isnull(a.cImportDB,'') = '')



