# Exo_API
Projeto da API para o aplicativo da ExoApi para armazenar projetos.


Banco Utilizado

CREATE DATABASE ExoApi
GO

USE ExoApi
GO

CREATE TABLE Projeto (
	Id INT PRIMARY KEY IDENTITY,
	Titulo Varchar (150) UNIQUE NOT NULL,
	StatusProjeto Varchar (500) NOT NULL,
	DataProjeto int,
	RequisitosProjeto Varchar (500) 
)
GO

INSERT INTO Projeto (Titulo, StatusProjeto, DataProjeto, RequisitosProjeto)
VALUES ('Projeto_1', 'Início' , 22072022, 'nada')
GO

INSERT INTO Projeto (Titulo, StatusProjeto, DataProjeto, RequisitosProjeto)
VALUES ('Projeto_2', 'Inicio', 22/07/2022, 1)
GO

INSERT INTO Projeto (Titulo, StatusProjeto, DataProjeto, RequisitosProjeto)
VALUES ('Titulo Projeto_3', 'Inicio', 22/07/2022, 1)
GO

INSERT INTO Projeto (Titulo, StatusProjeto, DataProjeto, RequisitosProjeto)
VALUES ('Projeto_4', 'Início' , 22072022, 'Computador')
GO


SELECT Titulo, StatusProjeto, DataProjeto, RequisitosProjeto FROM Projeto
GO

CREATE TABLE Usuario (
	Id INT PRIMARY KEY IDENTITY,
	Email VARCHAR (255) NOT NULL UNIQUE,
	Senha VARCHAR (120) NOT NULL,
	Tipo CHAR (1) NOT NULL
)
GO

INSERT INTO Usuario VALUES ('email@usuario.com', '1234', 1)

INSERT INTO Usuario VALUES ('email@usuario2.com', '1234', 1)

SELECT * FROM Usuario WHERE  Email = 'email@usuario2.com' AND Senha = '1234'

SELECT * FROM Projeto
GO
