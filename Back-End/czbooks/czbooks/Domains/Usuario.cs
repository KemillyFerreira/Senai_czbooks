using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable
namespace czbooks.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Autores = new HashSet<Autore>();
        }

        public int IdUsuario { get; set; }

        public int? IdTipoUsuario { get; set; }

        public string NomeUsuario { get; set; }


        [Required(ErrorMessage = "O campo e-mail deve ser preenchido para cadastrar um usuário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha deve ser preenchido para cadastrar um usuário!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres")]
        public string Senha { get; set; }


        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Autore> Autores { get; set; }
    }
}
