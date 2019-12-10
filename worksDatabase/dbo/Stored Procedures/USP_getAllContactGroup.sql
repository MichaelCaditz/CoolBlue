-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getAllContactGroup]
	
	--@clientsID int
	--@Title nVarchar(255)

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 SELECT a.cName,a.ID,a.cNote


	 FROM contactGroup a 

	 
		
	order by a.cName

	
	
		
                   				 
end


