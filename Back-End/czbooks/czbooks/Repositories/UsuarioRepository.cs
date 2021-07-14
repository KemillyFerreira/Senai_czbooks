using czbooks.Contexts;
using czbooks.Domains;
using czbooks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
            //FirstOrDefault => comparativo, se email e senha estiverem corretos OK, se apenas um estiver errado, não da certo
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
