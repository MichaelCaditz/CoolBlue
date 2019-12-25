CREATE view vw_NYMailList

as


SELECT        clients_id
FROM            clients AS a
WHERE        (clients_id IN
                             (SELECT DISTINCT nClientsID
                               FROM            clientsContactGroup AS b
                               WHERE        (nContactGroupID IN (1022)))) AND (bArchived IS NULL OR
                         bArchived <> 1) AND (ISNULL(bDeceased, 0) <> 1) AND (ISNULL(bSendPaperMail, 0) <> 1) AND (ISNULL(nMergedToID, 0) = 0) AND (clients_id IN
                             (SELECT DISTINCT nClientMasterID
                               FROM            clientMasterMailGroup AS c
                               WHERE        (nMailGroupID IN (1014)))) AND (ISNULL(cImportDB, 'GalProFront') = 'GalProFront' OR
                         ISNULL(cImportDB, '') = '')







