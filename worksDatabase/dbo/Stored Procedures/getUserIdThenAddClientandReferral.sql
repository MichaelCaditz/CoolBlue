-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[getUserIdThenAddClientandReferral]
	-- Add the parameters for the stored procedure here
	@cUserName varchar(50),
	@cEmail varchar(50),
	@referred_by char(30)
	
AS
BEGIN

	
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	insert  dbo.clients
	(cAspnet_UserId,email,bSendEmail,referred_by)
	values
	((select top 1 dbo.aspnet_Users.UserId as cUserId from dbo.aspnet_Users
	where dbo.aspnet_Users.UserName=@cUserName ),
	 @cEmail,'1',@referred_by)
END


