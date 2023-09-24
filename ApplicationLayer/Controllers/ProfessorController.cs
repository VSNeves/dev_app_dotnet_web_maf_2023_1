using DomainLayer.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using Swashbuckle.AspNetCore.Annotations;

namespace ApplicationLayer.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar o cadastro de professores
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly ILogger<ProfessorController> _logger;
        private readonly IProfessorService _professorService;

        /// <inheritdoc />
        public ProfessorController(ILogger<ProfessorController> logger, IProfessorService professorService)
        {
            _logger = logger;
            _professorService = professorService;
        }

        /// <summary>
        /// Método responsável por cadastrar um professor
        /// </summary>
        /// <param name="professor"></param>
        /// <returns>201, 400</returns>
        [HttpPost]
        [SwaggerOperation("Cadastra um novo professor")]
        [SwaggerResponse(201)] // create
        [SwaggerResponse(400)] // bad request
        public ActionResult<Professor> Register([FromBody] Professor professor)
        {
            if (professor.Conhecimentos.Count() <= 0)
            {
                return BadRequest();
            }

            _professorService.RegistraProfessor(professor);

            return Created("", professor);
        }

        /// <summary>
        /// Método responsavel por retornar a lista de professores
        /// </summary>
        /// <returns>200, 400</returns>
        [HttpGet("lista")]
        [SwaggerOperation("Lista os professores")]
        [SwaggerResponse(200)] // create
        [SwaggerResponse(400)] // bad request

        public ActionResult<IEnumerable<Professor>> Lista() 
        {
            var professores = _professorService.ListaProfessores();

            return Ok(professores);
        }

        /// <summary>
        /// Método responsavel por retornar um professor pelo nome
        /// </summary>
        /// <param name="nome">Nome do professor</param>
        /// <returns>200, 400</returns>
        [HttpGet("busca")]
        [SwaggerOperation("Busca um professor pelo nome")]
        [SwaggerResponse(200)] // create
        [SwaggerResponse(400)] // bad request

        public ActionResult<IEnumerable<Professor>> Busca(string nome)
        {
            return Ok(_professorService.BuscaProfessor(nome));
        }

        /// <summary>
        /// Método responsavel por atualizar um professor
        /// </summary>
        /// <param name="professor">Objeto de professor</param>
        /// <returns>200, 400</returns>
        [HttpPatch()]
        [SwaggerOperation("Atualiza um professor")]
        [SwaggerResponse(200)] // create
        [SwaggerResponse(400)] // bad request

        public ActionResult<Professor> Atualiza(Professor professor)
        {
            return Ok(_professorService.AtualizarProfessor(professor));
        }

        /// <summary>
        /// Método responsavel por apagar um professor localizado pelo id
        /// </summary>
        /// <param name="id">Identificador único do professor</param>
        /// <returns>202, 400</returns>
        [HttpDelete()]
        [SwaggerOperation("Apaga um professor pelo id")]
        [SwaggerResponse(202)] // create
        [SwaggerResponse(400)] // bad request

        public ActionResult Deleta(Guid id)
        {
            _professorService.ApagaProfessor(id);
            return Accepted();
        }



    }

}
