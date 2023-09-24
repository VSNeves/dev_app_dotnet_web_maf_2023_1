using ApplicationLayer.Controllers;
using DomainLayer.Interfaces.Service;

namespace ServiceLayer
{
    public class ProfessorService : IProfessorService
    {
        private static List<Professor> _professores = default!;
        public ProfessorService()
        {
            _professores = new List<Professor>();
        }

        public Professor RegistraProfessor(Professor professor)
        {
            // gero o Id
            professor.Id = Guid.NewGuid();

            // persisto o professor no nosso array estático
            PersisteProfessor(professor);

            // retorno professor cadastro com o GUID
            return professor;

        }

        public IEnumerable<Professor> ListaProfessores()
        { 
            return _professores; 
        }

        public IEnumerable<Professor> BuscaProfessor(string nome)
        {
            /*return _professores.Find(professor => professor.Nome.Equals(
                value: nome,
                comparisonType: StringComparison.InvariantCultureIgnoreCase)
            )!;*/

            return _professores.FindAll(prof => prof.Nome.ToLower().Contains(nome.ToLower()));

        }
                
        Professor IProfessorService.AtualizarProfessor(Professor professor)
        {
            var prof = _professores.Find(professor => professor.Id.ToString().Equals(professor.Id.ToString()))!;

            var idx = _professores.IndexOf(prof);

            _professores[idx].Nome = professor.Nome;
            _professores[idx].Conhecimentos = professor.Conhecimentos;

            return professor;

        }

        void IProfessorService.ApagaProfessor(Guid id)
        {
            var professor = _professores.Find(prof => prof.Id == id);

            if (professor != null) 
            {
                _professores.Remove(professor);
            }
        }

        // persistencia em memoria
        private static void PersisteProfessor(Professor professor)
        {
            _professores.Add(professor);

        }



    }

}
