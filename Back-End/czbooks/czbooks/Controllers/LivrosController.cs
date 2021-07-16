using czbooks.Domains;
using czbooks.Interfaces;
using czbooks.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace czbooks.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private ILivroRepository _livroRepository { get; set; }

        public LivrosController()
        {
            _livroRepository = new LivroRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
