-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_insertClient]
	-- Add the parameters for the stored procedure here
	
	  @fname varchar(500),
                                       @lname varchar(500),
                                       @phone varchar(500),
                                       @address1 varchar(500),
                                       @address2 varchar(500),
                                       @city varchar(500),
                                       @state varchar(500),
                                       @zip varchar(500),
                                       @country varchar(500),
                                       @email varchar(500),
                                       @bus_phone varchar(500),
                                       @res_phone varchar(500),
                                       @fax_phone varchar(500),
                                       @cell_phone varchar(500),
                                       @company_name varchar(500),
                                       @company_title varchar(500),
                                       @notes varchar(500),
                                       @nImportID int,
                                       @cImportDB varchar(500),
                                       @cTitle varchar(500),
                                       @cWebsite varchar(500),
                                       @cDescription varchar(500),
                                       @cPhoneOther varchar(500),
                                       @cSalesRep2 varchar(500),
                                       @cAssistant varchar(500),
                                       @cAssistantPhone varchar(500),
                                       @dtOriginalCreateDate datetime2,
                                       @nClientMasterID int,
                                       @bPrimary bit,
                                       @cSpouseName varchar(500)
									   --,@IDParameter int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 INSERT INTO [clients] (         
                                      [fname]
                                      ,[lname]
                                      ,[phone]
                                      ,[address1]
                                      ,[address2]
                                      ,[city]
                                      ,[state]
                                      ,[zip]
                                      ,[country]
                                      ,[email]
                                      ,[bus_phone]
                                      ,[res_phone]
                                      ,[fax_phone]
                                      ,[cell_phone]
                                      ,[company_name]
                                      ,[company_title]
                                      ,[notes]
                                      ,[nImportID]
                                      ,[cImportDB]
                                      ,[cTitle]
                                      ,[cWebsite]
                                      ,[cDescription]
                                      ,[cPhoneOther]
                                      ,[cSalesRep2]
                                      ,[cAssistant]
                                      ,[cAssistantPhone]
                                      ,[dtOriginalCreateDate]
                                      ,[nClientMasterID]
                                      ,[bPrimary]
                                      ,[cSpouseName]
            
            
            )           
            VALUES (
                                      @fname,
                                       @lname,
                                       @phone,
                                       @address1,
                                       @address2,
                                       @city,
                                       @state,
                                       @zip,
                                       @country,
                                       @email,
                                       @bus_phone,
                                       @res_phone,
                                       @fax_phone,
                                       @cell_phone,
                                       @company_name,
                                       @company_title,
                                       @notes,
                                       @nImportID,
                                       @cImportDB,
                                       @cTitle,
                                       @cWebsite,
                                       @cDescription,
                                       @cPhoneOther,
                                       @cSalesRep2,
                                       @cAssistant,
                                       @cAssistantPhone,
                                       @dtOriginalCreateDate,
                                       @nClientMasterID,
                                       @bPrimary,
                                       @cSpouseName
                             )

                       --SELECT @IDParameter = SCOPE_IDENTITY();
					SELECT   CAST(SCOPE_IDENTITY() AS INT)
           
           
END
