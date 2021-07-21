using czbooks.Domains;
using czbooks.Interfaces;
using czbooks.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace czbooks.Controllers
{
    //controller responsável pelos endpoints (URL) referente as bibliotecas

    //define que a resposta da API será no formato json
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class BibliotecasController : ControllerBase
    {
        private IBibliotecaRepository _bibliotecaRepository { get; set; }
        
        public BibliotecasController()
        {
            _bibliotecaRepository = new BibliotecaRepository();
        }

        /// <summary>
        /// lista todas as bibliotecas existentes
        /// </summary>
        /// <returns> uma lista de bibliotecas </returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bibliotecaRepository.Listar());
        }

        /// <summary>
        /// cadastra uma nova biblioteca
        /// </summary>
        /// <param name="novaBiblioteca"> biblioteca com as novas informações </param>
        /// <returns> uma nova biblioteca </returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Biblioteca novaBiblioteca)
        {
            try
            {
                _bibliotecaRepository.Cadastrar(novaBiblioteca);
                return StatusCode(204);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
