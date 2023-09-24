using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : ControllerBase
    {
       private readonly ILogger<AlunoController> _logger;

        public AlunoController(ILogger<AlunoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Aluno> Get()
        {
            var aluno = new Aluno
            {
                Matricula = 12345,
                Nome = "Luis",
                DataNascimento = new DateOnly(1987, 4, 29)
            };

          return Ok(aluno);
        
        }
   
    }

}