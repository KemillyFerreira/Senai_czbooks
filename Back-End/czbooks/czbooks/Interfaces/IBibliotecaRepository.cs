using czbooks.Domains;
using System.Collections.Generic;

namespace czbooks.Interfaces
{
    interface IBibliotecaRepository
    {
        /// <summary>
        /// lista todas as bibliotecas
        /// </summary>
        /// <returns> retorna uma lista com os nomes das bibliotecas </returns>
        List<Biblioteca> Listar();

        /// <summary>
        /// cadastra uma nova biblioteca
        /// </summary>
        /// <param name="novaBiblioteca"> novaBiblioteca será o novo objeto cadastrado </param>
        void Cadastrar(Biblioteca novaBiblioteca);

        /// <summary>
        /// atualiza a biblioteca
        /// </summary>
        /// <param name="id"> busca o id que terá a atualização</param>
        /// <param name="bibliotecaAtualizada"> biblioteca com o novo nome </param>
        void Atualizar( int id, Biblioteca bibliotecaAtualizada);


    }
}
