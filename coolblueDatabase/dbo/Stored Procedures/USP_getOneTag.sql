﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_getOneTag]
	@tagID int

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.ID, a.cName,a.cDesc,a.dtCreateDate


	 FROM dbo.tag a  WITH (NOLOCK)
	 
	 --left join dbo.line b on a.nLineID = b.ID
	 
	 where a.ID = @tagID and (a.bDeleted is null or a.bDeleted=0) 

	 --where b.nAccountID = @accountID and (a.bDeleted is null or a.bDeleted=0) and (b.bDeleted is null or b.bDeleted=0)
		
	order by a.cName

	
	
		
                   				 
end