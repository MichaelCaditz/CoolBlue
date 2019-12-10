-- =============================================
-- Author:		David Caditz
-- Create date: 7/3/2012
-- Description:	Strips non-alllpha characters from a string
-- =============================================
CREATE FUNCTION [dbo].[fncRemoveNonAlphanumericChars](@Temp VarChar(1000))
RETURNS VarChar(1000)
AS
BEGIN
 WHILE PatIndex('%[^A-Za-z0-9]%', @Temp) > 0
 SET @Temp = Stuff(@Temp, PatIndex('%[^A-Za-z0-9]%', @Temp), 1, '')

 RETURN @Temp
END



