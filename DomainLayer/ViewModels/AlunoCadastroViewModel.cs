namespace DomainLayer.ViewModels
{
    public class AlunoCadastroViewModel
    {
        public int Matricula { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }

    }
}
