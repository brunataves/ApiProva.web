using ApiProva.Data.Data;
using ApiProva.Data.Repository;
using ApiProva.Data.Repository.Interface;
using ApiProva.Service.Service;
using ApiProva.Service.Service.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiProva.Tests
{
    public class TesteBase
    {
        protected ApiProvaDbContext _context = default!;
        protected IMapper _mapper = default!;
        protected IServiceProvider _serviceProvider = default!;
        private string DataBaseName = "DataBaseTest" + Guid.NewGuid();


        public TesteBase()
        {
            InicializarContainer();
            InicializarContexto();
        }

        private void InicializarContexto()
        {
            _context = _serviceProvider.GetRequiredService<ApiProvaDbContext>();
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        protected void PopularBancoDeDados<T>(ICollection<T> collection) where T : class
        {
            if (collection != null && collection.Any())
            {
                _context.AddRange(collection);
                _context.SaveChanges();
            }
        }

        private void InicializarContainer()
        {
            var serviceColection = new ServiceCollection();
            serviceColection.AddDbContext<ApiProvaDbContext>(options => options.UseInMemoryDatabase(databaseName: DataBaseName));
            serviceColection.AddScoped<IContatoRepository, ContatoRepository>();
            serviceColection.AddScoped<IContatoService, ContatoService>();
            serviceColection.AddAutoMapper(typeof(ApiProva.Api.Configuration.AutoMapperConfig));
            _serviceProvider = serviceColection.BuildServiceProvider();
        }
    }
}
