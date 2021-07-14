using czbooks.Domains;
using System.Collections.Generic;

namespace czbooks.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// validação do usuário
        /// </summary>
        /// <param name="email"> email do usuário </param>
        /// <param name="senha"> senha do usuário </param>
        /// <returns></returns>
        Usuario Login(string email, string senha);


        /// <summary>
        /// lista todos os usuários
        /// </summary>
        /// <returns> retorna uma lista de usuarios </returns>
        List<Usuario> Listar();


        /// <summary>
        /// cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario"> novoUsuario será o objeto atualizado </param>
        void Cadastrar(Usuario novoUsuario);
    }
}
