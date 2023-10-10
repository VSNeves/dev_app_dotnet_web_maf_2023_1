using ApplicationLayer.Controllers;
using Dapper;
using DomainLayer.Interfaces.Repository;
using DomainLayer.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace InfrastructureLayer.Data.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly IDbContext _Context;
        private readonly ILogger<IProfessorRepository> _logger;
                
        public ProfessorRepository(ILogger<ProfessorRepository> logger, IDbContext Context)
        {
            _logger = logger;
            _Context = Context;
        }

       
        /// <summary>
        /// Método responsável por salvar os dados de um professor
        /// </summary>
        /// <param name="professor"></param>
        /// <returns></returns>
        public async Task Registra(Professor professor)
        {
            _logger.LogInformation($"[ProfessorRepository]-[Registra] -> [Start]: Payload -> {JsonSerializer.Serialize(professor)}");

            using var connection = _Context.CreateConnection;

            const string query = "INSERT INTO professor(nome, matrícula, Conhecimentos) VALUES(@Nome, @Matricula, @Conhecimentos);";
            var parameters = new
            {
                professor.Nome,
                professor.Matricula,
                Conhecimentos = professor.Conhecimentos.ToString(),
            };

            try
            {
                await connection.ExecuteAsync(query, professor);
            }
            catch (Exception exception)
            {
                _logger.LogError($"[ProfessorRepository]-[Registra] -> [Exception]: Message -> {exception.Message}");
                _logger.LogError($"[ProfessorRepository]-[Registra] -> [Exception]: Message -> {exception.InnerException}");
                throw;
            }

            _logger.LogInformation($"[ProfessorRepository]-[Registra] -> [Finish]");
        }


        public async Task<IEnumerable<Professor>> Lista()
        {
            _logger.LogInformation($"[ProfessorRepository]-[Lista] -> [Start]");

            using var connection = _Context.CreateConnection;

            const string query = "SELECT * FROM professor;";

            try
            {
                var result = await connection.QueryAsync<Professor>(query)!;

                _logger.LogInformation($"[ProfessorRepository]-[Lista] -> [Finish]");
                return result;
            }
            catch (Exception exception)
            {
                _logger.LogError($"[ProfessorRepository]-[Lista] -> [Exception]: Message -> {exception.Message}");
                _logger.LogError($"[ProfessorRepository]-[Lista] -> [Exception]: Message -> {exception.InnerException}");
                throw;
            }
        }



        public async Task<IEnumerable<Professor>> Busca(string nome)
        {
            _logger.LogInformation($"[ProfessorRepository]-[Busca] -> [Start]: Nome -> {nome}");

            using var connection = _Context.CreateConnection;

            const string query = "SELECT * FROM professor WHERE Nome LIKE @Nome;";
            var param = new
            {
                Nome = $"%{nome}%"
            };

            try
            {
                var result = await connection.QueryAsync<Professor>(query)!;
                _logger.LogInformation($"[ProfessorRepository]-[Busca] -> [Finish]");
                return result;
            }
            catch (Exception exception)
            {
                _logger.LogError($"[ProfessorRepository]-[Busca] -> [Exception]: Message -> {exception.Message}");
                _logger.LogError($"[ProfessorRepository]-[Busca] -> [Exception]: Message -> {exception.InnerException}");
                throw;
            }

        }




        public async Task Atualiza(Professor professor)
        {
            _logger.LogInformation($"[ProfessorRepository]-[Atualiza] -> [Start]: Payload -> {JsonSerializer.Serialize(professor)}");

            using var connection = _Context.CreateConnection;

            const string query = "UPDATE professor SET Nome = @Nome, Conhecimentos = @Conhecimentos WHERE Matricula = @Matricula;";
            var parameters = new
            {
                professor.Nome,
                professor.Matricula,
                Conhecimentos = professor.Conhecimentos.ToString(),
            };

            try
            {
                await connection.ExecuteAsync(query, professor);
            }
            catch (Exception exception)
            {
                _logger.LogError($"[ProfessorRepository]-[Atualiza] -> [Exception]: Message -> {exception.Message}");
                _logger.LogError($"[ProfessorRepository]-[Atualiza] -> [Exception]: Message -> {exception.InnerException}");
                throw;
            }
        }



        public async Task Apaga(Guid id)
        {
            _logger.LogInformation($"[ProfessorRepository]-[Apaga] -> [Start]: GUID -> {id}");

            using var connection = _Context.CreateConnection;

            const string query = "DELETE FROM ´rofessor WHERE id = @Id";
            var param = new
            {
                Id = id
            };

            try
            {
                await connection.ExecuteAsync(query, param);
            }
            catch (Exception exception)
            {
                _logger.LogError($"[ProfessorRepository]-[Apaga] -> [Exception]: Message -> {exception.Message}");
                _logger.LogError($"[ProfessorRepository]-[Apaga] -> [Exception]: Message -> {exception.InnerException}");
                throw;
            }

            _logger.LogInformation($"[ProfessorRepository]-[Apaga] -> [Finish]");
        }

        
    }
}
