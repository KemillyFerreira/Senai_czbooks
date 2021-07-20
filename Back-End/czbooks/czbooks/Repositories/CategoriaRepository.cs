using czbooks.Contexts;
using czbooks.Domains;
using czbooks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace czbooks.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        czbooksContext ctx = new czbooksContext();

        public void Atualizar(int id, Categoria categoriaAtualizada)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Categoria novaCategoria)
        {
            ctx.Categorias.Add(novaCategoria);
            ctx.SaveChanges();
        }
        
        public List<Categoria> Listar()
        {
            return ctx.Categorias.ToList();
        }
    }
}
