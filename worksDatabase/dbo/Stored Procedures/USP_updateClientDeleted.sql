-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_updateClientDeleted]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	@clients_id int = 0,
	@cDeletedBy nvarchar(255) = ''
	
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	

	


	update a

	set a.nMergedToID =-1,
	a.cMergedBy = @cDeletedBy,
	a.dtMergedDate = getdate()
	

	from Works.dbo.clients a
	

	where a.clients_id=@clients_id

	

end


