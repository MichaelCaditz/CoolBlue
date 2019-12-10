-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_getAllMailGroup]
	
	--@clientsID int
	--@Title nVarchar(255)

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 SELECT a.cName,a.ID,a.cNote


	 FROM mailGroup a 

	 
		
	order by a.cName

	
	
		
                   				 
end


