using czbooks.Contexts;
using czbooks.Domains;
using czbooks.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace czbooks.Repositories
{
    public class AutoreRepository : IAutoreRepository
    {
        czbooksContext ctx = new czbooksContext();

        public void Atualizar(int id, Autore autorAtualizado)
        {
            
        }

        public void Cadastrar(Autore novoAutor)
        {
            ctx.Autores.Add(novoAutor);
            ctx.SaveChanges();
        }

        public List<Autore> Listar()
        {
            return ctx.Autores.ToList();
        }
    }
}
