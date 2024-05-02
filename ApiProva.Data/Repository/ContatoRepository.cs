using ApiProva.Data.Data;
using ApiProva.Data.Repository.Interface;
using ApiProva.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProva.Data.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ApiProvaDbContext _dbContext;

        public ContatoRepository(ApiProvaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Contato> GetAll()
        {
            var lista = _dbContext.Contatos.OrderBy(p => p.NomeContato).ToList();
            return lista;
        }

        public void Delete(Contato contato)
        {
            _dbContext.Contatos.Remove(contato);
            _dbContext.SaveChanges();
        }
        

        public Contato GetByID(Guid contatoId)
        {
            var contato = _dbContext.Contatos.Where(p => p.Id == contatoId).FirstOrDefault();
            return contato;
        }

        public void Save(Contato contato)
        {
            _dbContext.Add(contato);
            _dbContext.SaveChanges();
        }

        public void Alterar(Contato contato)
        {
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(contato).State = EntityState.Modified;
            _dbContext.Update(contato);
            _dbContext.SaveChanges();
        }
    }
}
