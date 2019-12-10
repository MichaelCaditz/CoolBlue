-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_updateSingleCell]
	
	@table nVarchar(255),
	@column nVarchar(255),
	@id int,
	@valueInt int = 0, -- key field for lookupEdit
	@value nVarchar(MAX), -- text field for history, textEdit, memoEdit.
	@tableIDName nVarchar(255) = "ID",
	@userName nVarchar(255)='',
	@valueOrig nVarchar(MAX) = ''

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	INSERT INTO GalleryWorks.dbo.singleCellUpdateHistory 
		([tableIDName],[tableIDValue],[tableName],[columnName],[value],[valueOrig],[userName],[ddate]) 
		VALUES 
		(@tableIDName,@id,@table,@column,
		@value,
		--case
		--	when @value is not null then @value
		--	when @valueInt >0 then cast(@valueInt as varchar(50))	 
		--end
		--,
		@valueOrig,
		@userName,getDate()) 










	declare @SQL nVarchar(MAX)
	select @SQL = 
	 'update '+@table

	 +' set '+@column+' = '''
	 
	+case
		when @valueInt >0 then cast(@valueInt as varchar(50)) -- for lookupEdit type fields, save Key to database
		when @value is not null then @value
	 
	 --when @valueStr is not null then REPLACE(@valueStr,'''','')
	  
	end

	+''' where '+@tableIDName+' ='''+cast(@id as varchar(50))+''''
	

EXEC sp_executesql @SQL, N'@table nVarchar(255),
	@column nVarchar(255),
	@id int,
	@valueInt int,
	@value nVarchar(MAX)',
	@table,@column,@id,@valueInt,@value


	SELECT @SQL as SQL
                   				 
end




