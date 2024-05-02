using ApiProva.Service.Service.Interface;
using ApiProva.Service.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiProva.Tests.ContatoTest
{
    public class ContatoTest : TesteBase
    {
        public IContatoService _contatoService;

        public ContatoTest()
        {
            _contatoService = _serviceProvider.GetRequiredService<IContatoService>();
        }

        [Test]
        public async Task Adicionar_Sucesso()
        {
            //arrange 
            var createContato = new ContatoViewModel
            {
                DtNascimento = DateTime.Parse("10-6-1991"),
                NomeContato = "Joao da Silva",
                Ativo =true,
                Sexo = "M"
            };

            //act 
            var resultadoAcao = await _contatoService.Incluir(createContato);
            var contatoExiste = await _context.Contatos.AnyAsync(p => p.NomeContato == createContato.NomeContato);

            //assert
            Assert.That(resultadoAcao.Valido, Is.True);
        }

        [Test]
        public async Task Adicionar_IdadeMenor18_Falha()
        {
            //arrange
            var msg = "Erro ao incluir contato!O contato deve ser maior de idade";
            var createContato = new ContatoViewModel() {    DtNascimento = DateTime.Parse("10-6-2020"), NomeContato = "Maria Silva", Ativo = true, Sexo = "F"   };

            //act
            var resultadoAcao = await _contatoService.Incluir(createContato);

            //assert	
            Assert.That(resultadoAcao.Valido, Is.False);
        }



        [Test]
        public async Task Adicionar_DtNascMaiorHj_Falha()
        {
            //arrange
            var msg = "Erro ao incluir contato!Data de nascimento é maior que a data atual";
            var createContato = new ContatoViewModel() { DtNascimento = DateTime.Now.AddDays(1), NomeContato = "Maria Silva", Ativo = true, Sexo = "F" };

            //act
            var resultadoAcao = await _contatoService.Incluir(createContato);

            //assert	
            Assert.That(resultadoAcao.Valido == false && resultadoAcao.MsgErro == msg);

        }
    }
}
