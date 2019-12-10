

-- =============================================
-- Author:		<Dvid Cdaitz>
-- Create date: <5/23/2012>
-- Description:	<Get values from singleCellUpdateHistory table>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getUpdateSingleCellHistory]
	
	@tableName nVarchar(255),
	@columnName nVarchar(255),
	@tableIDValue int


AS
BEGIN

	SET NOCOUNT ON;


	SELECT ID,valueStr,userName,ddate FROM GalleryWorks.dbo.singleCellUpdateHistory 
		WHERE 
			tableName = @tableName
			AND
			columnName = @columnName 
			AND
			tableIDValue = @tableIDValue
			ORDER BY ddate DESC


                   				 
end





