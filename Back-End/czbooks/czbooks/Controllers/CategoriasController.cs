using czbooks.Domains;
using czbooks.Interfaces;
using czbooks.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace czbooks.Controllers
{
    //controller responsável pelos endpoints (URL) referente ao Login

    //define que a resposta da API será no formato json
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]  

    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository _categoriaRepository {get; set;}

        public CategoriasController()
        {
            _categoriaRepository = new CategoriaRepository();
        }

        /// <summary>
        /// lista todas as categorias que já existem
        /// </summary>
        /// <returns> uma lista de categorias</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoriaRepository.Listar());
        }
         
        /// <summary>
        /// cadastra uma nova categoria
        /// </summary>
        /// <param name="novaCategoria"> será o objeto com a nova informação </param>
        /// <returns> uma nova categoria de livros </returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Categoria novaCategoria)
        {
            try
            {
                _categoriaRepository.Cadastrar(novaCategoria);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
