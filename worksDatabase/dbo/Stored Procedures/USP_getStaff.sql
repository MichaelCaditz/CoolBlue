-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getStaff]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	--@clients_id int
	
AS
BEGIN


SELECT  a.clients_id,a.cmpDisplayWithCity,a.cmpDisplayWithAddress,a.cmpDisplay
      --FROM clients a WITH (NOLOCK)
	-- inner join clientMaster b on a.nClientMasterID=b.ID
	-- inner join contactType c on b.nContactTypeID = c.ID
	 
	 from dbo.staffInClients a
-- WHERE  c.bIsStaff = 1 and a.bPrimary = 1

		order by a.cmpDisplay asc
                   				 
END



