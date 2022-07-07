USE [TreinamentoAlex]
GO
/****** Object:  StoredProcedure [dbo].[USP_I_CLIENTE]    Script Date: 07/07/2022 10:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_I_CLIENTE]
@Nome VARCHAR(100),
 @SobreNome VARCHAR(100), 
 @DataNascimento DATETIME,
 @Pontuacao INT,
 @IdTipo INT
AS
 
BEGIN
INSERT INTO  Cliente( 

Nome,SobreNome,DataNascimento,Pontuacao,IdTipo
)
VALUES
(@Nome,@SobreNome,@DataNascimento,@Pontuacao,@IdTipo)

END
 
 