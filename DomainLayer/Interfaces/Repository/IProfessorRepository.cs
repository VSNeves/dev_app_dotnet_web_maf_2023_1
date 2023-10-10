using ApplicationLayer.Controllers;
using DomainLayer.Models;

namespace DomainLayer.Interfaces.Repository
{
    public interface IProfessorRepository
    {
        Task Registra(Professor professor);
        Task<IEnumerable<Professor>> Lista();
        Task<IEnumerable<Professor>> Busca(String nome);
        Task Atualiza(Professor professor);
        Task Apaga(Guid id);
        
    }
}
