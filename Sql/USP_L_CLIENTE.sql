CREATE PROCEDURE USP_L_CLIENTE
AS
 
BEGIN
SELECT 
Id,
NOme,
SobreNome,
DataNascimento,
Pontuacao,
IdTipo 
	  
FROM  Cliente
END
 
 