-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_getClientDisplayByID]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	@clients_id int
	
AS
BEGIN


SELECT distinct a.clients_id,a.cmpDisplayWithCity,a.cmpDisplayWithAddress
     FROM clients a

WITH (NOLOCK) WHERE  a.clients_id=@clients_id

		
                   				 
END



