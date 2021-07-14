using czbooks.Domains;
using System.Collections.Generic;

namespace czbooks.Interfaces
{
    interface ICategoriaRepository
    {
        /// <summary>
        /// lista todas as categorias
        /// </summary>
        /// <returns> uma lista de categorias </returns>
        List<Categoria> Listar();

        /// <summary>
        /// cadastra uma nova categoria
        /// </summary>
        /// <param name="novaCategoria"> novaCategoria será o novo objeto cadastrado </param>
        void Cadastrar(Categoria novaCategoria);

        /// <summary>
        /// atualiza uma categoria
        /// </summary>
        /// <param name="id"> busca o id que terá a atualização </param>
        /// <param name="categoriaAtualizada"> categoria com a nova atualização </param>
        void Atualizar(int id, Categoria categoriaAtualizada);

    }
}
