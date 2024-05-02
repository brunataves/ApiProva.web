namespace ApiProva.Domain.Entities
{
    public class BaseContato
    {
        public BaseContato()
        {
            Id = Guid.NewGuid(); 
        }
        public Guid Id { get; set; }
    }
}
