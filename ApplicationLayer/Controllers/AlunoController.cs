using DomainLayer.Interfaces.Repository;
using DomainLayer.Interfaces.Service;
using DomainLayer.Models;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApplicationLayer.Controllers
{
    /// <summary>
    /// controller respons�vel por gerenciar o cadastro de alunos
    /// </summary>
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly ILogger<AlunoController> _logger;
        private readonly IAlunoService _alunoService;
        private readonly ISqlServerConnectionProvider _SqlServerConnectionProvider;

        ///<inheritdoc />
        public AlunoController(ILogger<AlunoController> logger, IAlunoService alunoService, ISqlServerConnectionProvider SqlServerConnectionProvider)
        {
            _logger = logger;
            _alunoService = alunoService;
            _SqlServerConnectionProvider = SqlServerConnectionProvider;
        }

        /// <summary>
        /// M�todo respons�vel por listar todos os alunos cadastrados
        /// </summary>
        /// <returns>200, 400</returns>
        [HttpGet]
        [SwaggerOperation("Lista os alunos")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public async Task <ActionResult<IEnumerable<Aluno>>> Lista()
        {
            var Alunos = await _alunoService.Lista();

            return Ok(Alunos);

        }

        /// <summary>
        /// M�todo respons�vel por registrar um aluno no sistema
        /// </summary>
        /// <returns>201, 400</returns>
        [HttpPost]
        [SwaggerOperation("Registra aluno")]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]
        public async Task<ActionResult> Registra([FromBody] AlunoCadastroViewModel viewModel)
        {
            await _alunoService.RegistraNotas(viewModel);

            return Created("", "");

        }

        /// <summary>
        /// M�todo respons�vel por Buscar aluno pelo nome
        /// </summary>
        /// <returns>200, 400</returns>
        [HttpGet("{nome}")]
        [SwaggerOperation("Busca o(s) aluno(s)")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public async Task<ActionResult<IEnumerable<Aluno>>> Busca ([FromBody] string nome)
        {
            var Alunos = await _alunoService.Busca(nome);

            return Ok(Alunos);

        }

        /// <summary>
        /// M�todo respons�vel por atualizar um aluno no sistema
        /// </summary>
        /// <returns>204, 400</returns>
        [HttpPatch()]
        [SwaggerOperation("Atualiza aluno")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        public async Task<ActionResult<Aluno>> Atualiza ([FromBody] Aluno aluno)
        {
            await _alunoService.Atualiza(aluno);

            return NoContent();

        }

        /// <summary>
        /// M�todo respons�vel por apagar um aluno no sistema
        /// </summary>
        /// <returns>204, 400</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation("Apagar aluno")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        public async Task<ActionResult> Apaga([FromRoute] Guid id)
        {
            await _alunoService.Apaga(id);

            return NoContent();

        }


        /// <summary>
        /// M�todo respons�vel por registrar as notas de um aluno no sistema
        /// </summary>
        /// <returns>201, 400</returns>
        [HttpPost("nota")]
        [SwaggerOperation("Registra notas de um aluno")]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]
        public async Task<ActionResult> RegistraNotas([FromBody] AlunoCadastroViewModel viewModel)
        {
            await _alunoService.RegistraNotas(viewModel);

            return Created("", "");

        }

        /// <summary>
        /// M�todo respons�vel por Buscar todos os dados de aluno pelo matricula
        /// </summary>
        /// <returns>200, 400</returns>
        [HttpGet("{matricula}")]
        [SwaggerOperation("Busca todos os dados de aluno pelo matricula")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public async Task<ActionResult<IEnumerable<Aluno>>> BuscaAlunoNotas([FromBody] string matricula)
        {
            var alunoNotas = await _alunoService.BuscaAlunoNotas(matricula);

            return Ok(alunoNotas);

        }


    }

}