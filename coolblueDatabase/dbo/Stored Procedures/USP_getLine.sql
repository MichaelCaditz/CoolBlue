﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getLine]
	
	--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)
	@accountID int

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT distinct a.ID,a.dtCreateDate,a.nAccountID,a.dtTransDate,a.cNote,
	 
	 (select isnull(sum(s.nAmount),0) as "totalSplit" from dbo.split s where s.nLineID = a.ID
	 and (s.nAccountID_C = @accountID or s.nAccountID_D = @accountID)
	 and (s.bDeleted is null or s.bDeleted=0) ) as "totalsplit",

	  (select isnull(sum(s.nAmount_D),0) as "totalDr" from dbo.split s where s.nLineID = a.ID
	   and (s.nAccountID_D = @accountID)
	 and (s.bDeleted is null or s.bDeleted=0) ) as "totalDr",

	  (select isnull(sum(s.nAmount_C),0) as "totalCr" from dbo.split s where s.nLineID = a.ID
	   and (s.nAccountID_C = @accountID )
	 and (s.bDeleted is null or s.bDeleted=0) ) as "totalCr"



	 FROM line a  WITH (NOLOCK)
	 
	 left join split b on  b.nLineID = a.ID
	 
	

	 where 

	( b.nAccountID_C = @accountID or b.nAccountID_D = @accountID or a.nAccountID = @accountID)
	  
	 and ((a.bDeleted is null or a.bDeleted=0) and (b.bDeleted is null or b.bDeleted=0))

	 and @accountID>0
		
	order by a.dtTransDate desc

	
	
		
                   				 
end



