using czbooks.Domains;
using System.Collections.Generic;

namespace czbooks.Interfaces
{
    interface IAutoreRepository
    {
        /// <summary>
        /// lista toos os autores
        /// </summary>
        /// <returns> uma lista de autores </returns>
        List<Autore> Listar();

        /// <summary>
        /// cadastra um novo Autor
        /// </summary>
        /// <param name="novoAutor"> novoAutor será o novo objeto cadastrado </param>
        void Cadastrar(Autore novoAutor);

        /// <summary>
        /// atualiza o nome de um autor
        /// </summary>
        /// <param name="id"> id do autor que será atualizado </param>
        /// <param name="autorAtualizado"> autor com o novo nome </param>
        void Atualizar(int id, Autore autorAtualizado);

    }
}
