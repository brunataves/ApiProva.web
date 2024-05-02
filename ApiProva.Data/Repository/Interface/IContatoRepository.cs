using ApiProva.Domain.Entities;

namespace ApiProva.Data.Repository.Interface
{
    public interface IContatoRepository
    {
        Contato GetByID(Guid contatoId);
        List<Contato> GetAll();
        void Save(Contato cliente);
        void Delete(Contato cliente);
        void Alterar(Contato contato);
    }
}
