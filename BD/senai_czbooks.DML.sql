--DML -> inser��o de dados nas tabelas

-- determinando qual banco de dados usar
USE senai_czbooks
GO


--insere os tipos de  usu�rios
INSERT INTO		tiposUsuarios(nomeTipoUsuario)
VALUES			('Administrador')
				,('Autor')
				,('Cliente');
GO

INSERT INTO		biblioteca(nomeFantasia, endereco, cnpj)
VALUES			('Czbooks', 'Al. Bar�o de Limeira, 666', '12345678999999');
GO

INSERT INTO		categorias(nomeCategoria)
VALUES			('Terror')
				,('Filosofia')
				,('Fic��o Cientif�ca')
				,('A��o')
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
VALUES			(2, 'alem�o')
				,(4, 'americano')
				,(5, 'brit�nico');
GO				

INSERT INTO		livros(idAutor, idCategoria, idBiblioteca, titulo, sinopse, dataDePublicacao, preco)
VALUES			(1, 2, 1, 'Assim falou Zaratustra', 'O livro conta a hist�ria de um pensador que desce das montanhas para ensinar aos homens o que descobriu em seu isolamento.', '3/12/1883', 29.79)
				,(2, 3, 1, 'Os Instrumentos Mortais', 'A vida de Clary muda completamente quando sua m�e � sequestrada e ela descobre, ao conhecer Jace, que � uma ca�adora de sombras.', '21/08/2013', 199.92)
				,(1, 1, 1, 'Frankenstein', 'Cientista que se lan�a no experimento de retomar a vida de um ser inanimado', '15/12/1823', 48.89)	
				,(3, 4, 1, 'Mitologia N�rdica','Odin, o mais alto dos altos, s�bios, ousados ??e astutos; Thor, filho de Odin, incrivelmente forte, mas n�o o mais s�bio dos deuses; E Loki-filho de um irm�o de sangue gigante para Odin e um malandro e insuper�vel manipulador.', '13/03/2017', 49.50)
				,(2, 5, 1,'O senhor dos an�is', 'Conflito contra o mal que se alastra pela Terra-m�dia, atrav�s da luta de v�rias ra�as - Humanos, An�os, Elfos, Ents e Hobbits', '29/07/1954', 109.15);
GO


UPDATE livros
SET sinopse = 'Odin, o mais alto dos altos, s�bios, ousados e astutos; Thor, filho de Odin, incrivelmente forte, mas n�o o mais s�bio dos deuses; E Loki-filho de um irm�o de sangue gigante para Odin e um malandro e insuper�vel manipulador.'
WHERE idLivro = 4
GO