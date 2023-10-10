using DomainLayer.Interfaces.Repository;
using DomainLayer.Interfaces.Service;
using DomainLayer.Models;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApplicationLayer.Controllers
{
    /// <summary>
    /// controller responsável por gerenciar o cadastro de alunos
    /// </summary>
    [ApiController]
    [Route("api/nota")]
    public class AlunoNotaController : ControllerBase
    {
        private readonly ILogger<AlunoNotaController> _logger;
        private readonly IAlunoService _alunoService;
        private readonly ISqlServerConnectionProvider _SqlServerConnectionProvider;

        ///<inheritdoc />
        public AlunoNotaController(ILogger<AlunoNotaController> logger, IAlunoService alunoService, ISqlServerConnectionProvider SqlServerConnectionProvider)
        {
            _logger = logger;
            _alunoService = alunoService;
            _SqlServerConnectionProvider = SqlServerConnectionProvider;
        }

        /// <summary>
        /// Método responsável por listar todas as notas de um aluno cadastrado
        /// </summary>
        /// <returns>200, 400</returns>
        [HttpGet("{matricula}")]
        [SwaggerOperation("Busca todas as notas de um aluno")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public async Task<ActionResult<IEnumerable<Aluno>>> BuscaNotas([FromRoute] string matricula)
        {
            var notas = await _alunoService.BuscaNotas(matricula);

            return Ok(notas);

        }


        /// <summary>
        /// Método responsável por registrar as notas de um aluno no sistema
        /// </summary>
        /// <returns>201, 400</returns>
        [HttpPost()]
        [SwaggerOperation("Registra notas de um aluno")]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]
        public async Task<ActionResult> RegistraNotas([FromBody] AlunoCadastroViewModel viewModel)
        {
            await _alunoService.RegistraNotas(viewModel);

            return Created("", "");

        }

        /// <summary>
        /// Método responsável por Consultar a situação de avaliação do aluno 
        /// </summary>
        /// <returns>200, 400</returns>
        [HttpGet("find/matrícula")]
        [SwaggerOperation("Consulta a situação do aluno")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public async Task<ActionResult> Situacao([FromRoute] string matrícula)
        {
            var result = await _alunoService.Situacao(matrícula);

            return Ok(result);

        }

    }

}