USE [TreinamentoAlex]
GO

CREATE PROCEDURE [dbo].USP_U_CLIENTE
@Id INT,
@Nome VARCHAR(100),
 @SobreNome VARCHAR(100), 
 @DataNascimento DATETIME,
 @Pontuacao INT,
 @IdTipo INT
AS
 
BEGIN
UPDATE  Cliente SET
 Nome = @Nome,
 SobreNome = @SobreNome,
 DataNascimento = @DataNascimento,
 Pontuacao = @Pontuacao,
 IdTipo = @IdTipo
WHERE Id = @id
 
END
 
 