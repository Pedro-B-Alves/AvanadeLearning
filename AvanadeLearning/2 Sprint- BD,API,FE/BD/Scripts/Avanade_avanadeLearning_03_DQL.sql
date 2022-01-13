--DQL

-- Cria um banco de dados

 
-- Define o banco de dados que será utilizado
USE AvanadeLearning;


-- Lista todos os tipos de usuarios
Select * FROM TipoUsuario;

-- Lista todos os usuarios
Select * FROM Usuario;

-- Lista todos os cursos
Select * FROM Curso; 

Select * FROM Instituicao;

Select * FROM TipoCurso;
-- Lista todos os modulos
Select * FROM Modulo;

-- Lista todas as postagens
Select * FROM Postagem;

-- Lista todas as redes sociais
Select * FROM RedeSocial;

-- Lista todas as conquistas
Select * FROM Conquista;

-- Lista todas as aulas
Select * FROM Aula;

--Lista todos os comentarios
Select * From Comentario;

-- Seleciona os dados dos usuários mostrando o tipo de usuário
Select idUsuario, nome, email, senha, imagem, rg, cpf, dataNascimento,telefone, pais,estado,empresa,cargo,sobreMim FROM Usuario
INNER JOIN TipoUsuario
ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario;


-- Busca um usuário através do seu e-mail e senha
SELECT idTipoUsuario,nome, [Permissão] email 
FROM Usuario U 
INNER JOIN TipoUsuario TU 
ON U.IdTipoUsuario = TU.IdTipoUsuario 
WHERE email = 'adm@email.com' AND senha = '12345678';

-- Seleciona todos os cursos, instituicao e tiposCursos
Select nome, descricao,imagem, horas
FROM Curso C
INNER JOIN TipoCurso TC
ON C.idTipoCurso  =  TC.idTipoCurso 
INNER JOIN Instituicoes I
ON C.idInstituicao = I.idInstituicao;

-- Seleciona todas as aulas, aulaModulo e os modulos
Select video, descricao, linkConteudo
FROM Aula A
INNER JOIN AulaModulo AM
ON A.IdAulaModulo = AM.IdAulaModulo
INNER JOIN Modulo M
ON A.IdModulo = M.IdModulo;

-- Seleciona todas as conquista, conquistaUsuario e os modulos 
Select nome, descricao, imagem, pontos
FROM  conquista C
INNER JOIN ConquistaUsuario CU
ON C.idConquistaUsuario = CU.idConquistaUsuario
INNER JOIN Modulo M
ON C.idModulo = M.IdModulo;
.