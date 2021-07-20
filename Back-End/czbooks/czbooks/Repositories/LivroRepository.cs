using czbooks.Contexts;
using czbooks.Domains;
using czbooks.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace czbooks.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        czbooksContext ctx = new czbooksContext();

        /// <summary>
        /// busca um livro para atualiza-lo
        /// </summary>
        /// <param name="id"> id do livro que terá atualização </param>
        /// <param name="livroAtualizado"> objeto que trará a atualização </param>
        public void Atualizar(int id, Livro livroAtualizado)
        {
            //busca um livro através do ID          
            Livro livroBuscado = ctx.Livros.Find(id);

            // confere se o id do autor foi passado
            if (livroAtualizado.IdAutor != null)
            {
                livroBuscado.IdAutor = livroAtualizado.IdAutor;
            }

            // confere se o id da categoria foi passado
            if (livroAtualizado.IdCategoria != null)
            {
                livroBuscado.IdCategoria = livroAtualizado.IdCategoria;
            }

            // confere se o id da biblioteca foi passado
            if (livroAtualizado.IdBiblioteca != null)
            {
                livroBuscado.IdBiblioteca = livroAtualizado.IdCategoria;
            }

            // atualiza as informações
            ctx.Livros.Update(livroBuscado);

            // salva as novas informações inseridas
            ctx.SaveChanges();
        }

        /// <summary>
        /// cadastra um novo livro
        /// </summary>
        /// <param name="novoLivro"> será o novo livro cadastrado </param>
        public void Cadastrar(Livro novoLivro)
        {
            //adiciona um novo livro
            ctx.Livros.Add(novoLivro);

            //salva o novo livro para inserção no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// lista todos os livros sem exceção
        /// </summary>
        /// <returns> uma lista com todos os livros </returns>
        public List<Livro> Listar()
        {
            return ctx.Livros
                //.Include("IdAutorNavigation")
                // outra forma
                .Include(l => l.IdAutorNavigation)
                .Include(livro => livro.IdAutorNavigation.IdUsuarioNavigation)
                .ToList();
        }

        /// <summary>
        /// lista apenas o livro de determinado usuário
        /// </summary>
        /// <param name="idUsuario"> id do usuário que terá seus livros listados</param>
        /// <returns> uma lista especifíca de livros</returns>
        public List<Livro> ListarMyBooks(int idUsuario)
        {
            return ctx.Livros
                //junta com a tabela Autor para poder chegar as suas informações
                .Include(b => b.IdAutorNavigation)

                //traz a tabela Usuario para poder chegar as suas informações
                .Include(b => b.IdAutorNavigation.IdUsuarioNavigation)

                //diz onde precisará ser feita a comparação para poder trazer determinado livro
                .Where(b => b.IdAutorNavigation.IdUsuarioNavigation.IdUsuario == idUsuario)

                .ToList();
        }
    }
}
