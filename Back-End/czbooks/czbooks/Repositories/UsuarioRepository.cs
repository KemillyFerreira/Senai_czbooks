using czbooks.Contexts;
using czbooks.Domains;
using czbooks.Interfaces;
using System;
using System.Collections.Generic;

namespace czbooks.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        czbooksContext ctx = new czbooksContext();

        public void Cadastrar(Usuario novoUsuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
