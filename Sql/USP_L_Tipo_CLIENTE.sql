USE [TreinamentoAlex]
GO
/****** Object:  StoredProcedure [dbo].[USP_L_TIPO_CLIENTE]    Script Date: 07/07/2022 10:02:01 ******/
 
CREATE PROCEDURE [dbo].[USP_L_TIPO_CLIENTE]
AS
 
BEGIN
SELECT 
Id,
	 Descricao
FROM TipoCliente
END
 
 