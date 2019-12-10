-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_insertNewContact]
	
	@cNotes nVarchar(255),
	@cName nVarchar(255),
	@nSalesRepID int,
	@nContactTypeID int,
	@fname nVarchar(255),
	@initial nVarchar(255),
	@lname nVarchar(255),
	@cTitle nVarchar(255),
	@phone nVarchar(255),
	@address1 nVarchar(255),
	@address2 nVarchar(255),
	 @city nVarchar(255),
	 @state nVarchar(255),
	 @zip nVarchar(255),
	 @country nVarchar(255),
	 @email nVarchar(255),
	 @email2 nVarchar(255),
	 @bus_phone nVarchar(255),
	 @res_phone nVarchar(255),
	 @fax_phone nVarchar(255),
	 @cell_phone nVarchar(255),
	 @company_name nVarchar(255),
	 @company_title nVarchar(255),
	 @notes nVarchar(255),
	 @cWebsite nVarchar(255),
	 @cDescription nVarchar(255),
	 @cPhoneOther nVarchar(255),
	 @cSalesRep2 nVarchar(255),
	 @cAssistant nVarchar(255),
	 @cAssistantPhone nVarchar(255),
	 @nInsertClientsOnly int,
	 @nClientMasterID int,
	 @bPrimary bit = 0,
	 @clientMasterIdentity int output,
	 @clientsIdentity int output
	
AS
BEGIN

if @nInsertClientsOnly=0
begin
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	 insert into clientMaster
	 (cNotes,cName,cDescription,nImportID,nSalesRepID,nContactTypeID)
	 values
	 (@cNotes,@cName,'',0,@nSalesRepID,@nContactTypeID)

	

	 --SELECT @@IDENTITY AS 'clientMasterIdentity'

	-- declare @clientMasterIdentity as int

	select @clientMasterIdentity  = SCOPE_IDENTITY();
	end
	else

	select @clientMasterIdentity  = @nClientMasterID;




	 insert into clients
	 (fname,initial,lname,phone,address1,address2,
	 city,state,zip,country,email,email2,bus_phone,res_phone,fax_phone,
	 cell_phone,company_name,company_title,notes,cWebsite,cDescription,cPhoneOther,cSalesRep2,
	 cAssistant,cAssistantPhone,nClientMasterID,cTitle,bPrivate,bPrimary)
	 values
	 (@fname,@initial,@lname,@phone,@address1,@address2,
	 @city,@state,@zip,@country,@email,@email2,@bus_phone,@res_phone,@fax_phone,
	 @cell_phone,@company_name,@company_title,@notes,@cWebsite,@cDescription,@cPhoneOther,@cSalesRep2,
	 @cAssistant,@cAssistantPhone, @clientMasterIdentity,@cTitle,0,@bPrimary)

	 --declare @clientsIdentity as int

	select @clientsIdentity  = SCOPE_IDENTITY();


	 --return @clientMasterIdentity


		
		
                   				 
END
