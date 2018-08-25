IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[GetNextEntityNumber]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
   DROP PROCEDURE [dbo].[GetNextEntityNumber]
END
GO



Create PROCEDURE [dbo].[GetNextEntityNumber] 
@EntityName nvarchar(50),
@NextNumber int output
AS
BEGIN
Update 
NumberMaster
set
NextNumber=NextNumber+1
WHERE
EntityCode=@EntityName

SELECT @NextNumber=NextNumber from NumberMaster where entitycode=@EntityName
END