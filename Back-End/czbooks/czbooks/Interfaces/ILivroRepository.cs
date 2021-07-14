using czbooks.Domains;
using System.Collections.Generic;

namespace czbooks.Interfaces
{
    interface ILivroRepository
    {
        /// <summary>
        /// lita todos os livros
        /// </summary>
        /// <returns> uma lista de livros</returns>
        List<Livro> Listar();

        /// <summary>
        /// cadastra um novo livro  
        /// </summary>
        /// <param name="novoLivro"> novoLivro será o novo objeto cadastrado </param>
        void Cadastrar(Livro novoLivro);

        /// <summary>
        /// atualiza um livro
        /// </summary>
        /// <param name="id"> id do livro que terá a atualização </param>
        /// <param name="livroAtualizado"> livro com a autalização </param>
        void Atualizar(int id, Livro livroAtualizado);
    }
}
