using czbooks.Contexts;
using czbooks.Domains;
using czbooks.Interfaces;
using System;
using System.Collections.Generic;

namespace czbooks.Repositories
{
    public class AutoreRepository : IAutoreRepository

    {
        czbooksContext ctx = new czbooksContext();

        public void Atualizar(int id, Autore autorAtualizado)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Autore novoAutor)
        {
            throw new NotImplementedException();
        }

        public List<Autore> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
