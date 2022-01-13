--DML
USE avanadeLearning;
GO

 -- inserindo a tabela de tipos usuarios
INSERT INTO	tipoUsuario (tipo)
VALUES					('Administrador'),
						('Aluno'),
						('Professor');
GO

-- Inserindo a tabela RedeSocial
INSERT INTO redeSocial (nome,linkBase)
VALUES					('GitHub', 'https://github.com/'),
						('Facebook', 'https://pt-br.facebook.com/'),
						('Linkedin', 'https://br.linkedin.com/');
GO

-- INSERT INTO pais
INSERT INTO pais (nome,imagem)
VALUES			('Brasil', 'bandeira.jpg'),
				('Alemanha', 'bandeiraA.jpg'),
				('Espanha', 'bandeiraE.jpg'),
				('EUA', 'bandeiraEUA.jpg');

GO

-- INSERT INTO estado
INSERT INTO estado(idPais,nome,imagem)
VALUES				(1,'São Paulo','sp.jpg'),
					(2,'Berlim','berlim.jpg'),
					(4,'Los Angeles', 'LA.jpg'),
					(3, 'Madrid', 'madrid.jpg');

GO

INSERT INTO estadoUsuario(idEstado, idUsuario)
VALUES					(1,2),
						(4,1),
						(2,3);
GO

--Inserindo a tabela Arquetipo
INSERT INTO arquetipo (nome,imagem, descricao)
VALUES					('Predador', 'predador.jpg', 'Você é um perfil competidor'),
						('Social', 'social.jpg','Você é um perfil que gosta fazer amigos'),
						('Arquivador','arquivador.jpg' ,'Você é um perfil que ama guardar suas conquistas'),
						('Explorador', 'explorador.jpg','Você é um perfil que ama cavar a fundo')

GO

-- Inserindo a tabela Usuario
INSERT INTO usuario     (idTipoUsuario,nome,email,senha,imagem,rg,cpf,dataNascimento,telefone,pontos,pontosSemanais,sobreMim,imagemBackground,empresa,cargo)
VALUES					(1,'Gustavo','gus@email.com','gus123','photoadm.png','12845478','85485574597', '1990/09/10',39192199, 1000, 500, 'Sou adm', 'background.png', 'AVANADE', 'Dono'),
						(3, 'Paulo', 'paulo@email.com', 'paulo123', 'photoprof.png', '56852841', '65236695784', '1970/09/07', 29192831, 2000, 1000, 'Sou professor', 'background.png', 'AVANADE', 'Professor'),
						(2,'Pedro', 'pedro@email.com', 'pedro123', 'photoaluno.png', '86523017', '45216698527', '2002/02/15', 23123311, 4000, 2000, 'Sou Aluno', 'background´.png', 'AVANADE', 'Aluno' );
GO

-- inserindo a tabela RedeUsuario
INSERT INTO redesUsuario (idRedeSocial, idUsuario,link)
VALUES					(1,1,'https://github.com/GustavoTollentino'),
						(1,3,'https://github.com/Pedro-B-Alves'),
						(1,2,'https://github.com/PauloBrandao');

GO

-- INSERT INTO estadoUsuario

-- Inserindo a tabela de instituicao
INSERT INTO instituicao (nomeFantasia, razaoSocial,endereco,cnpj,telefone)
VALUES					('AVANADE', 'AvanadeLearning', 'Rua Alexandre Dumas - Chacara Santo Antonio', 1219328392832, '39291231');
						
GO

-- Inserindo a tabela Tipo de Curso
INSERT INTO categoriaCurso (categoria)
VALUES					('Tecnologia'),
						('Manicure'),
						('Administração');
GO

-- Inserindo a Tabela de Curso
INSERT INTO curso (idInstituicao, nome,descricao, imagem,horas)
VALUES				(1, 'C#', 'C# é uma linguagem de programação desenvolvida pela microsoft como parte da plataforma .NET', 'c#.png', 10),
					(1, 'React', 'React é uma biblioteca JavaScript de código aberto com foco em criar interfaces de usuario em paginas web', 'react.png', 10),
					(1, 'Administração', 'Administração é um curso de gestao social que estuda e sistematiza praticas de administração', 'adm.png', 20);
GO

-- Inserindo a tabela Tipo Curso
INSERT INTO categoriasCurso (idCurso, idCategoriaCurso)
VALUES					(1,1),
						(3,3)

GO

-- Inserindo a tabela cursando
INSERT INTO cursando (idUsuario, idCurso)
VALUES					(2,1),
						(2,2);

GO

-- Inserindo a tabela Postagem
INSERT INTO postagem (idUsuario, idCurso, texto,dataPostagem)
VALUES				(2,1,'Não entendi como faz jsx','10/02/2021'),
					(3,1, 'Irei fazer uma live explicando, acompanhe','20/08/2021');
GO

INSERT INTO arquivoPostagem (arquivo, idPostagem)
VALUES						('arquivo.rar', 2)

GO
--Inserindo a tabela Like
INSERT INTO likePostagem (idPostagem,idUsuario,[like])
VALUES				(2,1,'true'),
					(1,3,'false');

GO

--Inserindo a tabela Modulo
INSERT INTO modulo (idCurso, nome, texto)
VALUES				(1, 'Introdução ao C#', 'Nesta aula vamos entender o que é C#'),
					(2, 'Introdução ao React', 'Nesta aula vamos entender o que é React');

GO

-- Inserindo a tabela Arquivos
INSERT INTO arquivoModulo (idModulo, arquivo)
VALUES				(1, 'modulo1.pdf','archiveM.rar'),
					(2, 'modulo1.pdf', 'archive2.rar');

GO

--Inserindo a tabela Aula
INSERT INTO aula (video,descricao,linkConteudoExtra)
VALUES				('aulaReact.mp4', 'Esta aula se refere ao curso React' ,'jsx.pdf'),
					('aulaC#.mp4', 'Esta aula se refere ao curso de C#', 'extraC#.pdf');


GO


-- Inserindo a tabela AulaModulo
INSERT INTO aulaModulo (idAula, idModulo)
VALUES					(1,2),
						(2,1);

GO

-- INSERT INTO aulasVista

INSERT INTO questao (pergunta, pontosNota)
VALUES				('Como criar um novo React App?',2),
					('O que é Nest.js?',3),
					('O que é Bootstrap?',3),
					('O que é JavaScript',1),
					('Por que usamos jsx?',2),
					('O que significa administrar?',3);
GO

INSERT INTO aulaQuestoes(idQuestao, idUsuario, idAula, Nota)
VALUES						(5,2,1,10);

GO

INSERT INTO categoriaQuestao (nome)
VALUES					('Tecnologia'),
						('Administração'),
						('Manicure'),
						('Informática Basica');
						
GO

INSERT INTO categoriasQuestao (idCategoriaQuestao,idQuestao)
VALUES						(1,5),
							(2,6);

GO
-- Inserindo a tabela Comentario
INSERT INTO comentario ( idUsuario,idAula,comentario)
VALUES					(2, 1, 'Essa aula foi incrivel, aprendi muito'),
						(3, 1, 'Espero que continue acessando minhas aulas, vlw! :)');

GO

INSERT INTO likeComentario(idLikeComentario, idUsuario, idComentario, [Like] )
VALUES						(3,1,1,'false'),
							(2,2,1,'true');

GO

-- INSERT INTO questaoFeita
INSERT INTO questaoFeita(idAulaQuestoes,idUsuario, feito, pontos)
VALUES					(1,2,'true', 20),
						(2,2, 'false', 0);

GO

-- INSERT INTO resposta
INSERT INTO resposta (idQuestao, resposta, correta)
VALUES					(1, 'estrutura da web de desenvolvimento front-end React de código fechado','false'),
						(3, 'JavaScript é uma linguagem de programação interpretada estruturada, de script', 'true');

GO

--Inserindo a tabela Conquistas
INSERT INTO Conquista (idModulo,idCurso, nome,descricao,imagem,pontos)
VALUES				(2,2, 'Aluno Fast', 'Terminou o curso antes do tempo previsto', 'conquistaFast.png', 300),
					(1,1, 'Aluno Dedicado', 'Assistiu a aula até o fim', 'conquistaDedicado.png', 300);

GO

-- Inserindo a tabela ConquistaUsuario
INSERT INTO ConquistaUsuario (idConquista,idUsuario)
VALUES						(1,2),
							(2,2);

GO

-- Inserindo a tabela usuarioArquetipo obs: 1:true 0:False
INSERT INTO UsuarioArquetipo (idArquetipo, idUsuario,porcentagem,ativo)
VALUES						(2,2,30,1);

GO



