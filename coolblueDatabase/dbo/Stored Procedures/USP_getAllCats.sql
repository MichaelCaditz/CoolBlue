-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getAllCats]
	--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)
	--@accountID int

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.ID,a.dtCreateDate,a.cName,a.cNote


	 FROM dbo.cat a  WITH (NOLOCK)
	 
	 --left join dbo.line b on a.nLineID = b.ID
	 
	

	 where  (a.bDeleted is null or a.bDeleted=0) 
		
	order by a.cName

	
	
		
                   				 
end
