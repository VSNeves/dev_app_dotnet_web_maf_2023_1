namespace ApplicationLayer.Controllers
{
    public class Professor
    {
        public Guid Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; } = string.Empty;
        public IEnumerable<string> Conhecimentos { get; set; } = default!;

    }
}
