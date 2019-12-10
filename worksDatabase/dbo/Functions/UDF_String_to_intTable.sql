
-- =============================================
-- Author:		David Caditz
-- Create date: 7/27/2012
-- Description:	@string must be a delimited string of integers
-- =============================================
CREATE FUNCTION [dbo].[UDF_String_to_intTable]
(
    @string VARCHAR(MAX),
    @delimiter CHAR(1)
)
RETURNS @output TABLE(
    ID int
)
BEGIN

    DECLARE @start INT, @end INT
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string)

    WHILE @start < LEN(@string) + 1 BEGIN
        IF @end = 0 
            SET @end = LEN(@string) + 1

        INSERT INTO @output (ID) 
        VALUES(CAST(SUBSTRING(@string, @start, @end - @start) as int))
        SET @start = @end + 1
        SET @end = CHARINDEX(@delimiter, @string, @start)
    END

    RETURN

END




