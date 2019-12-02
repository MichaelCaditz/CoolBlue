-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_updateVendor]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	@ID int,
	@notes varchar(max),
	@account_no char(20),
	@address1 nvarchar(255),
	@address2 nvarchar(255),
	@city nvarchar(255),
	@state nvarchar(255),
	@state_other nvarchar(255),
	@zip nvarchar(255),
	@country nvarchar(255),
	@postal_code nvarchar(255),
	@areacode char(3),
	@phone nvarchar(255),
	@email nvarchar(255),
	@website nvarchar(255),
	@rep nvarchar(255),
	@name nvarchar(255)
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	

	


	update Works.dbo.vendors

	set notes = @notes ,
	account_no = @account_no ,
	address1=@address1 ,
	address2=@address2 ,
	city=@city ,
	state=@state,
	state_other=@state_other ,
	zip=@zip ,
	country=@country,
	postal_code=@postal_code ,
	areacode=@areacode ,
	phone=@phone ,
	email=@email ,
	website=@website ,
	rep=@rep,
	name=@name


	

	where vendors_id=@ID

	

end

