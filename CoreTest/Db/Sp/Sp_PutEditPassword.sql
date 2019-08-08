USE [CORETEST]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_PutEditPassword]
(
  @Email 	VARCHAR(50),
  @Password VARCHAR(200)

)
AS
BEGIN

SET NOCOUNT ON;
             
			DECLARE @Resultado INT;
			SET @Resultado = (SELECT Id FROM UserApi  WHERE Email = @Email)
			   IF (@Resultado > = 1)
			     Begin
			          UPDATE UserAPI SET Password = @Password WHERE Email = @Email 
			     End
			  ELSE
			     Begin
			          SET @Resultado = 0;
			     End

		   SELECT @Resultado
END