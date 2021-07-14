--DDL -> criação de tabelas

-- criando banco de dados chamado senai_czbooks
CREATE DATABASE senai_czbooks
GO

-- determinando qual banco de dados usar
USE senai_czbooks
GO

-- criando a tabela com nome tiposUsuarios
CREATE TABLE tiposUsuarios
(
	idTipoUsuario		INT PRIMARY KEY IDENTITY
	,nomeTipoUsuario		VARCHAR (50) NOT NULL
);
GO

CREATE TABLE biblioteca
(
	idBiblioteca		INT PRIMARY KEY IDENTITY 
	,nomeFantasia		VARCHAR (100) NOT NULL
	,endereco			VARCHAR (100) NOT NULL
	,cnpj				CHAR	(14)  NOT NULL
);
GO

CREATE TABLE categorias
(
	idCategoria			INT PRIMARY KEY IDENTITY
	,nomeCategoria		VARCHAR (100) NOT NULL
);
GO

CREATE TABLE usuarios
(
	idUsuario			INT PRIMARY KEY IDENTITY
	,idTipoUsuario		INT FOREIGN KEY REFERENCES tiposUsuarios(idTipoUsuario)
	,nomeUsuario		VARCHAR(100) NOT NULL
	,email				VARCHAR(100) NOT NULL
	,senha				VARCHAR(100) NOT NULL
);
GO

CREATE TABLE autores
(
	idAutor				INT PRIMARY KEY IDENTITY
	,idUsuario			INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	,nacionalidade		VARCHAR(150) NOT NULL
);
GO

CREATE TABLE livros
(
	idLivro				INT PRIMARY KEY IDENTITY
	,idAutor			INT FOREIGN KEY REFERENCES autores(idAutor)
	,idCategoria		INT FOREIGN KEY REFERENCES categorias(idCategoria)
	,idBiblioteca		INT FOREIGN KEY REFERENCES biblioteca(idBiblioteca)
	,titulo				VARCHAR(150) NOT NULL
	,sinopse			VARCHAR(250) NOT NULL
	,dataDePublicacao	DATE NOT NULL
	,preco				DECIMAL(18, 2) NOT NULL
);
GO

--drop database senai_czbooks