

-- =============================================
-- Author:		David Caditz
-- Create date: 7/27/2012
-- Description:	@string must be a delimited string of integers
-- =============================================
CREATE FUNCTION [dbo].[UDF_String_to_charTable]
(
    @string NVARCHAR(MAX),
    @delimiter CHAR(1)
)
RETURNS @output TABLE(
    data nvarchar(255)
)
BEGIN

    DECLARE @start INT, @end INT
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string)

    WHILE @start < LEN(@string) + 1 BEGIN
        IF @end = 0 
            SET @end = LEN(@string) + 1

        INSERT INTO @output (data) 
        --VALUES(RTRIM(LTRIM(SUBSTRING(@string, @start, @end - @start) ) ) )
		VALUES(SUBSTRING(@string, @start, @end - @start) ) 
        SET @start = @end + 1
        SET @end = CHARINDEX(@delimiter, @string, @start)
    END

    RETURN

END





