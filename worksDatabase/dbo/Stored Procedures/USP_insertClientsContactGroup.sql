-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_insertClientsContactGroup]
	
	@nContactID int,
	@nContactGroupID int
	--@Title nVarchar(255)

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 insert into  clientsContactGroup 
	 (nClientsID ,
	nContactGroupID)

	values
	(@nContactID ,
	@nContactGroupID)


	

	

	
	
		
                   				 
end


