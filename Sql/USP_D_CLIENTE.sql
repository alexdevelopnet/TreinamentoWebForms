USE [TreinamentoAlex]
GO


CREATE PROCEDURE [dbo].[USP_D_CLIENTE]
@id INT
AS
 
BEGIN
DELETE FROM Cliente 
 
WHERE id =@id
END
 
 