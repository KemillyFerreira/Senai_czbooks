using czbooks.Contexts;
using czbooks.Domains;
using czbooks.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace czbooks.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        czbooksContext ctx = new czbooksContext();

        //cadastra e salva um novo usuário
        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        //lista todos os usuários existentes
        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }


        public Usuario Login(string email, string senha)
        {
            //FirstOrDefault => comparativo, se email e senha estiverem corretos OK, se apenas um estiver errado, não da certo
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
