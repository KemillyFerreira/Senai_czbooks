using System.ComponentModel.DataAnnotations;

namespace czbooks.ViewModels
{
    /// <summary>
    /// classe responsável pelo método de Login
    /// </summary>
    public class LoginViewModel
    {
        // required -> define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string Senha { get; set; }
    }
}
