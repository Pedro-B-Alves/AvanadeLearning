CREATE DATABASE avanadeLearning;
GO

USE avanadeLearning;
GO

CREATE TABLE tipoUsuario (
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	tipo VARCHAR(150) UNIQUE NOT NULL
);
GO

CREATE TABLE redeSocial (
	idRedeSocial INT PRIMARY KEY IDENTITY,
	nome VARCHAR(150) UNIQUE NOT NULL,
	linkBase VARCHAR(255) UNIQUE NOT NULL
);
GO

CREATE TABLE pais (
	idPais INT PRIMARY KEY IDENTITY,
	nome VARCHAR(150) UNIQUE NOT NULL,
	imagem VARCHAR(MAX) NOT NULL
);
GO

CREATE TABLE estado (
	idEstado INT PRIMARY KEY IDENTITY,
	idPais INT FOREIGN KEY REFERENCES pais(idPais),
	nome VARCHAR(150) UNIQUE NOT NULL,
	imagem VARCHAR(MAX) NOT NULL
);
GO

CREATE TABLE arquetipo (
	idArquetipo INT PRIMARY KEY IDENTITY,
	nome VARCHAR(150) UNIQUE NOT NULL,
	imagem VARCHAR(MAX) NOT NULL,
	descricao VARCHAR(MAX) NOT NULL
);
GO

CREATE TABLE usuario (
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	nome VARCHAR(150) NOT NULL,
	email VARCHAR(150) UNIQUE NOT NULL,
	senha VARCHAR(60) NOT NULL,
	imagem VARCHAR(MAX),
	rg VARCHAR(9),
	cpf VARCHAR(11),
	dataNascimento DATE,
	telefone VARCHAR(11),
	pontos INT,
	pontosSemanais INT,
	sobreMim VARCHAR(MAX),
	imagemBackground VARCHAR(MAX),
	empresa VARCHAR(150),
	cargo VARCHAR(150)
);
GO

CREATE TABLE redesUsuario (
	idRedesUsuario INT PRIMARY KEY IDENTITY,
	idRedeSocial INT FOREIGN KEY REFERENCES redeSocial(idRedeSocial),
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	link VARCHAR(MAX) NOT NULL
);
GO

CREATE TABLE estadoUsuario (
	idEstadoUsuario INT PRIMARY KEY IDENTITY,
	idEstado INT FOREIGN KEY REFERENCES estado(idEstado),
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario)
);
GO

CREATE TABLE instituicao(
	idInstituicao INT PRIMARY KEY IDENTITY,
	nomeFantasia VARCHAR(250) NOT NULL,
	razaoSocial VARCHAR(300),
	endereco VARCHAR(500) NOT NULL,
	cnpj VARCHAR(14) UNIQUE NOT NULL,
	telefone VARCHAR(12) NOT NULL
);
GO

CREATE TABLE categoriaCurso(
	idCategoriaCurso INT PRIMARY KEY IDENTITY,
	categoria VARCHAR(200) UNIQUE NOT NULL 
);
GO


CREATE TABLE curso(
	idCurso INT PRIMARY KEY IDENTITY,
	idInstituicao INT FOREIGN KEY REFERENCES instituicao(idInstituicao),
	nome VARCHAR(250) NOT NULL,
	descricao VARCHAR(MAX) NOT NULL,
	imagem VARCHAR(MAX),
	horas INT NOT NULL
);
GO

CREATE TABLE categoriasCurso(
	idCategoriasCurso INT PRIMARY KEY IDENTITY,
	idCurso INT FOREIGN KEY REFERENCES curso(idCurso),
	idCategoriaCurso INT FOREIGN KEY REFERENCES categoriaCurso(idCategoriaCurso),

);
GO

CREATE TABLE cursando(
	idCursando INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	idCurso INT FOREIGN KEY REFERENCES curso(idCurso)
);
GO

CREATE TABLE postagem(
	idPostagem INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	idCurso INT FOREIGN KEY REFERENCES curso(idCurso),
	texto VARCHAR(600),
	dataPostagem DATE NOT NULL
);
GO

CREATE TABLE arquivoPostagem(
	idArquivoPostagem INT PRIMARY KEY IDENTITY,
	idPostagem INT FOREIGN KEY REFERENCES postagem(idPostagem),
	arquivo VARCHAR(MAX) NOT NULL
	
);
GO

CREATE TABLE likePostagem(
	idLikePostagem INT PRIMARY KEY IDENTITY,
	idPostagem INT FOREIGN KEY REFERENCES postagem(idPostagem),
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	[like] BIT NOT NULL
);
GO

CREATE TABLE modulo(
	idModulo INT PRIMARY KEY IDENTITY,
	idCurso INT FOREIGN KEY REFERENCES curso(idCurso),
	nome VARCHAR(200),
	texto VARCHAR(500)
);
GO

CREATE TABLE arquivoModulo(
	idArquivoModulo INT PRIMARY KEY IDENTITY,
	idModulo INT FOREIGN KEY REFERENCES modulo(idModulo),
	arquivo VARCHAR(MAX) NOT NULL
);
GO

CREATE TABLE aula(
	idAula INT PRIMARY KEY IDENTITY,
	video VARCHAR(MAX),
	descricao VARCHAR(200),
	linkConteudoExtra VARCHAR(MAX),
	titulo VARCHAR(150)
);
GO

CREATE TABLE aulaModulo(
	idAulaModulo INT PRIMARY KEY IDENTITY,
	idAula INT FOREIGN KEY REFERENCES aula(idAula),
	idModulo INT FOREIGN KEY REFERENCES modulo(idModulo)
);
GO

CREATE TABLE aulasVista(
	idAulasVista INT PRIMARY KEY IDENTITY,
	idAula INT FOREIGN KEY REFERENCES aula(idAula),
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	visto BIT NOT NULL,
	pontos INT NOT NULL
);
GO

CREATE TABLE questao(
	idQuestao INT PRIMARY KEY IDENTITY,
	pergunta VARCHAR(MAX) NOT NULL,
	pontosNota INT NOT NULL
);
GO

CREATE TABLE aulaQuestoes(
	idAulaQuestoes INT PRIMARY KEY IDENTITY,
	idQuestao INT FOREIGN KEY REFERENCES questao(idQuestao),
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	idAula INT FOREIGN KEY REFERENCES aula(idAula),
	nota INT
);
GO

CREATE TABLE categoriaQuestao(
	idCategoriaQuestao INT PRIMARY KEY IDENTITY,
	nome VARCHAR(150)
);
GO

CREATE TABLE categoriasQuestao(
	idCategoriasQuestao INT PRIMARY KEY IDENTITY,
	idCategoriaQuestao INT FOREIGN KEY REFERENCES categoriaQuestao(idCategoriaQuestao),
	idQuestao INT FOREIGN KEY REFERENCES questao(idQuestao)
);
GO

CREATE TABLE comentario(
	idComentario INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	idAula INT FOREIGN KEY REFERENCES aula(idAula),
	comentario VARCHAR (200) NOT NULL
);
GO

CREATE TABLE likeComentario(
	idLikeComentario INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	idComentario INT FOREIGN KEY REFERENCES comentario(idComentario),
	[like] BIT NOT NULL
);
GO

CREATE TABLE questaoFeita(
	idQuestaoFeita INT PRIMARY KEY IDENTITY,
	idAulaQuestoes INT FOREIGN KEY REFERENCES aulaQuestoes(idAulaQuestoes),
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	feito BIT NOT NULL,
	pontos INT
);
GO

CREATE TABLE resposta(
	idResposta INT PRIMARY KEY IDENTITY,
	idQuestao INT FOREIGN KEY REFERENCES questao(idQuestao),
	resposta VARCHAR (200) NOT NULL,
	correta BIT NOT NULL,
);
GO

CREATE TABLE conquista(
	idConquista INT PRIMARY KEY IDENTITY,
	idModulo INT FOREIGN KEY REFERENCES modulo(idModulo),
	idCurso INT FOREIGN KEY REFERENCES curso(idCurso),
	nome VARCHAR (150) NOT NULL,
	descricao VARCHAR(300),
	imagem VARCHAR(MAX),
	pontos INT NOT NULL
);
GO

CREATE TABLE conquistaUsuario (
	idConquistaUsuario INT PRIMARY KEY IDENTITY,
	idConquista INT FOREIGN KEY REFERENCES conquista(idConquista),
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario)
);
GO

CREATE TABLE usuarioArquetipo(
	idUsuarioArquetipo INT PRIMARY KEY IDENTITY,
	idArquetipo INT FOREIGN KEY REFERENCES arquetipo(idArquetipo),
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	porcentagem INT NOT NULL,
	ativo BIT NOT NULL
);
GO