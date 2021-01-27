-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[USP_getAllAccountingPeriods]
	
	--@InventoryNumber nVarchar(255),
	--@Title nVarchar(255)
	--@accountID int

AS
BEGIN



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--a.cNameFirst,a.cNameLast,
	
	 SELECT a.ID,a.cName,a.cNote,a.dtCreateDate,a.dtBeginDate,a.dtEndDate


	 FROM accountingPeriod a WITH (NOLOCK)

	 

	 where  a.bDeleted is null or a.bDeleted=0
		
	order by dtBeginDate

	
	
		
                   				 
end