using czbooks.Domains;
using czbooks.Interfaces;
using czbooks.Repositories;
using czbooks.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace czbooks.Controllers
{
    //controller responsável pelos endpoints (URL) referente ao Login

    //define que a resposta da API será no formato json
    [Produces("application/json")]

    //define que a rota de requisição será no formato http://localhost:5000/api/nomeController
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        // cria o objeto _usuarioRepository que receberá os métodos definidos na interface 
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post (LoginViewModel login)
        {
            try
            {
                // busca o usuario pelo e-mail e senha
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if(usuarioBuscado == null)
                {
                    //retorna NotFound com uma mensagem de erro 
                    return NotFound("E-mail ou senha inválidos!");
                }

                //se o usuário for encontrado segue para criação do token 

             var claims = new[]
            }           
    }
}
