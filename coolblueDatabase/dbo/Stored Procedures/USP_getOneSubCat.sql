-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_getOneSubCat]
	@SubCatID int
	--@Title nVarchar(255)
	--@accountID int

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.ID,a.dtCreateDate,a.cName,a.cNotes,nCatID


	 FROM dbo.subCat a  WITH (NOLOCK)

	 
	 
	 --left join dbo.line b on a.nLineID = b.ID
	 
	

	 where a.ID = @SubCatID
	 
	 --and (a.bDeleted is null or a.bDeleted=0) 
		
	order by a.cName

	
	
		
                   				 
end
