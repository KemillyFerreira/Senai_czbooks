using czbooks.Domains;
using czbooks.Interfaces;
using czbooks.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace czbooks.Controllers
{
    //controller responsável pelos endpoints (URL) referente aos livros

    //define que a resposta da API será no formato json
    [Produces("application/json")]

    //define que a rota de requisição será no formato http://localhost:5000/api/nomeController
    [Route("api/[controller]")]
    [ApiController]


    //define que usuários autenticados podem acessar os métodos
    public class LivrosController : ControllerBase
    {
        /// <summary>
        /// o objeto _livroRepository irá receber todos os métodos definidos na interface
        /// </summary>
        private ILivroRepository _livroRepository { get; set; }


        /// <summary>
        /// instancia o objeto _livroRepository para que haja referência aos métodos no repositório
        /// </summary>
        public LivrosController()
        {
            _livroRepository = new LivroRepository();
        }

       
        /// <summary>
        /// lista todos os livros
        /// </summary>
        /// <returns> uma lista de eventos e um satus code 200-OK </returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                // retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_livroRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // apenas quem é adm -> [Authorize(Roles = "1")

        /// <summary>
        /// cadastra um novo livro
        /// </summary>
        /// <param name="novoLivro"> novo objeto que será cadastrado </param>
        /// <returns> um novo livro</returns>
        [HttpPost]
        public IActionResult Post(Livro novoLivro)
        {
            try
            {
                _livroRepository.Cadastrar(novoLivro);
                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// lista apenas livros especificos 
        /// </summary>
        /// <returns> retorna apenas livros de um determinado autor</returns>
        [Authorize(Roles = "2")]
        [HttpGet ("mine")]
        public IActionResult Getmine()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(b => b.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_livroRepository.ListarMyBooks(idUsuario)); 
            }

            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar os livros se o usuário não estiver logado!",
                    error
                });
            }
        }
    }
}
