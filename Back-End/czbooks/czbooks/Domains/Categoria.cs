using System;
using System.Collections.Generic;

#nullable disable

namespace czbooks.Domains
{
    public partial class Categoria
    {
        public Categoria()
        {
            Livros = new HashSet<Livro>();
        }

        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }


        public virtual ICollection<Livro> Livros { get; set; }
    }
}
