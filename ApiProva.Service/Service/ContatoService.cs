using ApiProva.Data.Repository.Interface;
using ApiProva.Domain.Entities;
using ApiProva.Service.Service.Interface;
using ApiProva.Service.Validation;
using ApiProva.Service.ViewModel;
using AutoMapper;

namespace ApiProva.Service.Service
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;

        public ContatoService(IContatoRepository contatoRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContatoViewModel>> GetAll()
        {
            var listaContato = _contatoRepository.GetAll();
            var listaRetorno = _mapper.Map<List<ContatoViewModel>>(listaContato);

            return listaRetorno.Where(p => p.Ativo == true);
        }

        public async Task<ContatoViewModel> Excluir(Guid id)
        {
            var objRetorno = new ContatoViewModel();

            var objDelecao = _contatoRepository.GetByID(id);

            if (objDelecao == null)
            {
                objRetorno.Valido = false;
                objRetorno.MsgErro = "Id nao encontrado!";
            }
            else
            {
                try
                {
                    _contatoRepository.Delete(objDelecao);
                    objRetorno.Valido = true;
                }
                catch (Exception ex)
                {
                    objRetorno.Valido = false;
                    objRetorno.MsgErro = "Erro ao deletar obj" + ex.Message;
                }

            }

            return objRetorno;

        }

        public async Task<ContatoViewModel> Incluir(ContatoViewModel obj)
        {
            var objValidacao = ValidarContato.ValidarDados(obj);
            
            if (objValidacao.Valido) 
            {
                try
                {
                    var objInclusao = _mapper.Map<Contato>(obj);
                    _contatoRepository.Save(objInclusao);
                    obj.Id = objInclusao.Id;
                    obj.Valido = true;
                }
                catch (Exception ex)
                {

                    obj.Valido = false;
                    obj.MsgErro = "Erro ao incluir contato!" + ex.Message;
                }
            }
            else 
            {
                obj.Valido = false;
                obj.MsgErro = "Erro ao incluir contato!" + objValidacao.MsgErro;
            }
            
            return obj;

        }

        public async Task<ContatoViewModel> Alterar(ContatoViewModel obj)
        {
            var objValidacao = ValidarContato.ValidarDados(obj);
            if (objValidacao.Valido)
            {
                var objAlteracao = _contatoRepository.GetByID(obj.Id);

                objAlteracao.NomeContato = obj.NomeContato;
                objAlteracao.DtNascimento = obj.DtNascimento;
                objAlteracao.Sexo = obj.Sexo;
                objAlteracao.Ativo = obj.Ativo;

                _contatoRepository.Alterar(objAlteracao);
                obj.Valido = true;

            }
            else
            {
                obj.Valido = false;
                obj.MsgErro = "Erro ao alterar contato!" + objValidacao.MsgErro;
            }

            return obj;

        }

        public async Task<ContatoViewModel> RetornaPorId(Guid id)
        {
            var objRetorno = new ContatoViewModel();
            var objContato = _contatoRepository.GetByID(id);
            
            if (objContato.Ativo)
            {
                objRetorno = _mapper.Map<ContatoViewModel>(objContato);
            }
            else
            {
                objRetorno.Valido = false;
                objRetorno.MsgErro = "O Contato solicitado está Inativo";
            }
            
            return objRetorno;
        }

        public async Task<ContatoViewModel> Desativar(Guid id)
        {
            var objRetorno = new ContatoViewModel();

            try
            {
                var objContato = _contatoRepository.GetByID(id);
                objContato.Ativo = false;

                _contatoRepository.Alterar(objContato);
                
                objRetorno = _mapper.Map<ContatoViewModel>(objContato);
                objRetorno.Valido = true;
            }
            catch (Exception ex)
            {
                objRetorno.Valido = false;
                objRetorno.MsgErro = "Erro ao desativar Contato" + ex.Message;
            }
            
            return objRetorno;
        }
    }
}
