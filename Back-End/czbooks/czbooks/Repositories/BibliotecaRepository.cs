using czbooks.Contexts;
using czbooks.Domains;
using czbooks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace czbooks.Repositories
{
    public class BibliotecaRepository : IBibliotecaRepository
    {
        czbooksContext ctx = new czbooksContext();

        public void Atualizar(int id, Biblioteca bibliotecaAtualizada)
        {  throw new NotImplementedException(); }

        public void Cadastrar(Biblioteca novaBiblioteca)
        {
            ctx.Bibliotecas.Add(novaBiblioteca);
            ctx.SaveChanges();
        }

        public List<Biblioteca> Listar()
        {
            return ctx.Bibliotecas.ToList();
        }
    }
}
