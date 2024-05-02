namespace ApiProva.Domain.Entities
{
    public class Contato : BaseContato
    {
        public string? NomeContato { get; set; }
        public DateTime DtNascimento { get; set; }
        public string? Sexo { get; set; }
        public bool Ativo { get; set; }
    }
}
