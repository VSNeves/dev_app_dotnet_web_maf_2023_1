using DomainLayer.Models;
using DomainLayer.ViewModels;

namespace DomainLayer.Interfaces.Repository
{
    public interface IAlunoRepository
    {
        Task Registra(AlunoCadastroViewModel viewModel);
        Task<IEnumerable<Aluno>> Lista();
        Task<IEnumerable<Aluno>> Busca(String nome);
        Task Atualiza(Aluno aluno);
        Task Apaga(Guid id);
        Task<AlunoNotasViewModel> BuscaNotas(string matrícula);
        Task RegistraNotas(AlunoNotasViewModel viewModel);
        Task<dynamic> BuscaAlunoNotas(string matrícula);
    }
}
