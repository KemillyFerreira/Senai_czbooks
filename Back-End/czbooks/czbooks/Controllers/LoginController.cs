using czbooks.Domains;
using czbooks.Interfaces;
using czbooks.Repositories;
using czbooks.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

        /// <summary>
        /// realiza o login de um usuário
        /// </summary>
        /// <param name="login"> método para autenticar o usuário </param>
        /// <returns> login que deu certo ou uma mensagem de erro </returns>
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                // busca o usuario pelo e-mail e senha
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    //retorna NotFound com uma mensagem de erro 
                    return NotFound("E-mail ou senha inválidos!");
                }

                //se o usuário for encontrado segue para criação do token

                //define os dados que serão fornecidos no token
                var claims = new[]
                {
                    // armazena na Claim o E-mail do usuario autenticado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    // armazena na Claim o id do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // armazena na claim o tipo de usuário que foi autenticado (administrador ou comum)
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),

                    // armazena na Claim o tipo de usuário que foi autenticado (adminsitrador ou comum) de forma personalizada
                    new Claim("role", usuarioBuscado.IdTipoUsuario.ToString()),
                };

                // define a chave de acesso ao Token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("books-chave-autenticacao"));

                // define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // gera o token
                var token = new JwtSecurityToken(
                    issuer: "czbooks.webApi",                   // emissor do token
                    audience: "czbooks.webApi",                 //destinatário do token
                    claims: claims,                             //dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),       // tempo de expiração
                    signingCredentials: creds                   // credenciais do token
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
