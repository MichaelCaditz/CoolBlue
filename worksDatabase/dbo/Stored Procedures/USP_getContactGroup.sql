-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getContactGroup]
	
	@clientsID int
	--@Title nVarchar(255)

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 SELECT a.ID,a.nClientsID,a.nContactGroupID,a.dtCreateDate


	 FROM clientsContactGroup a 

	-- inner join contactGroup b on b.ID = a. nContactGroupID

	 where a.nClientsID=@clientsID
		
	--order by b.cName

	
	
		
                   				 
end


