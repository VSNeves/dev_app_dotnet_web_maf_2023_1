using ApplicationLayer.Controllers;

namespace DomainLayer.Interfaces.Service
{
    public interface IProfessorService
    {
        Professor RegistraProfessor(Professor professor);
        IEnumerable<Professor> ListaProfessores();
        IEnumerable<Professor> BuscaProfessor(String nome);
        Professor AtualizarProfessor(Professor professor);
        void ApagaProfessor(Guid id);

    }
}
