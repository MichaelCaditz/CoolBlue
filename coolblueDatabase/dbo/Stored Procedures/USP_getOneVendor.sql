-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_getOneVendor]
	@vendorsID int
	--@Title nVarchar(255)
	--@accountID int

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.vendors_id,a.create_date,a.name,a.cDescription,a.account_no,a.address1,a.address2,a.city,
	 a.state,a.zip,a.cmpDisplay,a.country,a.email,a.areacode,a.phone,a.cNameFirst,
	 a.cNameLast,a.cell_areacode,a.cell_phone,a.cAssistant,a.cAssistantPhone,a.cPhoneOther,a.cPhoneOther1,a.cPhoneRes,
	 a.postal_code,a.fax_areacode,a.fax_phone,a.state_other,a.website,a.notes,a.rep


	 FROM Works.dbo.vendors a  WITH (NOLOCK)
	 
	 --left join dbo.line b on a.nLineID = b.ID
	 
	

	 where a.vendors_id = @vendorsID and (a.bDeleted is null or a.bDeleted=0) 
		
	order by a.cmpDisplay

	
	
		
                   				 
end
