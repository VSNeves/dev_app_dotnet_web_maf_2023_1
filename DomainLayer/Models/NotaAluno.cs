namespace DomainLayer.Models
{
    public class NotaAluno
    {
        public Guid Id { get; set; }
        public Guid AlunoId { get; set; }
        public double Nota { get; set; } = default!;

    }
}
