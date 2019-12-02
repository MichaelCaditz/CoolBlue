-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.USP_getAllVendors
	--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)
	--@accountID int

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.vendors_id,a.create_date,a.name,a.cDescription,a.account_no,a.address1,a.address2,a.city,a.state,a.zip,a.account_no,a.cmpDisplay


	 FROM Works.dbo.vendors a  WITH (NOLOCK)
	 
	 --left join dbo.line b on a.nLineID = b.ID
	 
	

	 --where b.nAccountID = @accountID and (a.bDeleted is null or a.bDeleted=0) and (b.bDeleted is null or b.bDeleted=0)
		
	order by a.cmpDisplay

	
	
		
                   				 
end
