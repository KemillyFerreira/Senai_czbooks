--DML -> inserção de dados nas tabelas

-- determinando qual banco de dados usar
USE senai_czbooks
GO


--insere os tipos de  usuários
INSERT INTO		tiposUsuarios(nomeTipoUsuario)
VALUES			('Administrador')
				,('Autor')
				,('Cliente');
GO

INSERT INTO		biblioteca(nomeFantasia, endereco, cnpj)
VALUES			('Czbooks', 'Al. Barão de Limeira, 666', '12345678999999');
GO

INSERT INTO		categorias(nomeCategoria)
VALUES			('Terror')
				,('Filosofia')
				,('Ficção Cientifíca')
				,('Ação')
				,('Aventura');
GO

INSERT INTO		usuarios(idTipoUsuario, nomeUsuario, email, senha)
VALUES			(1, 'administrador', 'adm@adm.com', 'adm123')
				,(2, 'Friedrich Nietzsche', 'nietzsche@gmail.com', 'eccehome')
				,(3, 'Kemilly', 'kemilly@gmail.com', 'kemi123')
				,(2, 'Cassandra Clare', 'cassandra@yahoo.com', '123456')
				,(2, 'J. R. R. Tolkien', 'tolkien@gmail.com', '987654');				
GO

INSERT INTO		autores(idUsuario, nacionalidade)
VALUES			(2, 'alemão')
				,(4, 'americano')
				,(5, 'britânico');
GO				

INSERT INTO		livros(idAutor, idCategoria, idBiblioteca, titulo, sinopse, dataDePublicacao, preco)
VALUES			(1, 2, 1, 'Assim falou Zaratustra', 'O livro conta a história de um pensador que desce das montanhas para ensinar aos homens o que descobriu em seu isolamento.', '3/12/1883', 29.79)
				,(2, 3, 1, 'Os Instrumentos Mortais', 'A vida de Clary muda completamente quando sua mãe é sequestrada e ela descobre, ao conhecer Jace, que é uma caçadora de sombras.', '21/08/2013', 199.92)
				,(1, 1, 1, 'Frankenstein', 'Cientista que se lança no experimento de retomar a vida de um ser inanimado', '15/12/1823', 48.89)	
				,(3, 4, 1, 'Mitologia Nórdica','Odin, o mais alto dos altos, sábios, ousados ??e astutos; Thor, filho de Odin, incrivelmente forte, mas não o mais sábio dos deuses; E Loki-filho de um irmão de sangue gigante para Odin e um malandro e insuperável manipulador.', '13/03/2017', 49.50)
				,(2, 5, 1,'O senhor dos anéis', 'Conflito contra o mal que se alastra pela Terra-média, através da luta de várias raças - Humanos, Anãos, Elfos, Ents e Hobbits', '29/07/1954', 109.15);
GO


UPDATE livros
SET sinopse = 'Odin, o mais alto dos altos, sábios, ousados e astutos; Thor, filho de Odin, incrivelmente forte, mas não o mais sábio dos deuses; E Loki-filho de um irmão de sangue gigante para Odin e um malandro e insuperável manipulador.'
WHERE idLivro = 4
GO