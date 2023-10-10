using DomainLayer.Interfaces.Repository;
using DomainLayer.Interfaces.Service;
using DomainLayer.Models;
using DomainLayer.Models.Constants;
using DomainLayer.ViewModels;

namespace ServiceLayer
{

    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository) => _repository = repository;
                
        public async Task Apaga (Guid id) => await _repository.Apaga(id);
        

        public async Task Atualiza (Aluno aluno) => await _repository.Atualiza(aluno);
        

        public async Task<IEnumerable<Aluno>> Busca(string nome) => await _repository.Busca(nome);

        public async Task RegistraNotas(AlunoNotasViewModel viewModel) => await _repository.RegistraNotas(viewModel);
                
        public async Task<AlunoNotasViewModel> BuscaNotas(string matricula) => await _repository.BuscaNotas(matricula);

        public async Task<IEnumerable<Aluno>> Lista() => await _repository.Lista();

        public async Task<dynamic> BuscaAlunoNotas(string matrícula) => await _repository.BuscaAlunoNotas(matrícula);
        public async Task RegistraNotas(AlunoCadastroViewModel viewModel) => await _repository.Registra(viewModel);

        public async Task<string> Situacao(string matrícula)
        {
            // Busquei todas as notas do aluno cadastrada
            var notasAluno = await _repository.BuscaNotas(matrícula)!;// ja me entrega a soma das notas

            // define a quantidade de exercicios propostos durante a UC
            var totalExercicios = 13;

            var somaNotas = notasAluno.Notas.Sum(nota => nota);

            var media = somaNotas / totalExercicios;

            return media switch
            {
                < 4 => StrConstants.Reprovado,
                < 7 => StrConstants.Recuperação,
                _ => StrConstants.Aprovado
            };

        }

    }

}
