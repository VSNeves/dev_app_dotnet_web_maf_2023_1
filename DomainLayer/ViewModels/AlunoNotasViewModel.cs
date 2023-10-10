namespace DomainLayer.ViewModels
{
    public class AlunoNotasViewModel
    {
        public Guid AlunoId { get; set; }
        public IEnumerable<double> Notas { get; set; } = default!;
    }
}
