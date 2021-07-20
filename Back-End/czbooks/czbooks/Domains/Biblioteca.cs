using System;
using System.Collections.Generic;

#nullable disable

namespace czbooks.Domains
{
    public partial class Biblioteca
    {
        public Biblioteca()
        {
            Livros = new HashSet<Livro>();
        }

        public int IdBiblioteca { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public string Cnpj { get; set; }


        public virtual ICollection<Livro> Livros { get; set; }
    }
}
