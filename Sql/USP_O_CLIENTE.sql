USE [TreinamentoAlex]
GO
/****** Object:  StoredProcedure [dbo].[USP_O_CLIENTE]    Script Date: 07/07/2022 10:07:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[USP_O_CLIENTE]
@id INT
AS
 
BEGIN
SELECT 
Id,
Nome,SobreNome,DataNascimento,Pontuacao,IdTipo
FROM Cliente
WHERE id =@id
END
 
 