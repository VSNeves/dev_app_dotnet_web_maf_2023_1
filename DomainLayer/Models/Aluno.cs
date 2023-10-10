namespace DomainLayer.Models
{
    public class Aluno
    {
        public Guid Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }

    }
}