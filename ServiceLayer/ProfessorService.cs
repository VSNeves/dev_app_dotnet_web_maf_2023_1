using ApplicationLayer.Controllers;
using DomainLayer.Interfaces.Repository;
using DomainLayer.Interfaces.Service;

namespace ServiceLayer
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _reposyitory;

        public ProfessorService(IProfessorRepository reposyitory) => _reposyitory = reposyitory;


        /// <summary>
        /// Método responsável por salvar os dados de um professor
        /// </summary>
        /// <param name="professor"></param>
        /// <returns></returns>
        public async Task Registra(Professor professor) => await _reposyitory.Registra(professor);

        public async Task<IEnumerable<Professor>> Lista() => await _reposyitory.Lista();

        public async Task<IEnumerable<Professor>> Busca(string nome) => await _reposyitory.Busca(nome);

        public async Task Atualiza(Professor professor) => await _reposyitory.Atualiza(professor);

        public async Task Apaga(Guid id) => await _reposyitory.Apaga(id);


    }

}
