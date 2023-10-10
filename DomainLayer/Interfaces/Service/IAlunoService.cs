using DomainLayer.Models;
using DomainLayer.ViewModels;

namespace DomainLayer.Interfaces.Service
{
    public interface IAlunoService
    {
        Task RegistraNotas(AlunoCadastroViewModel viewModel);
        Task<IEnumerable<Aluno>> Lista();
        Task<IEnumerable<Aluno>> Busca(String nome);
        Task Atualiza(Aluno aluno);
        Task Apaga(Guid id);
        Task RegistraNotas(AlunoNotasViewModel viewModel);
        Task<AlunoNotasViewModel> BuscaNotas(string matrícula);
        Task<dynamic> BuscaAlunoNotas(string matrícula);
        Task<string> Situacao(string matrícula);
        
    }
}
