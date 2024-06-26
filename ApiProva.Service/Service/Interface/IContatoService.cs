﻿using ApiProva.Service.ViewModel;

namespace ApiProva.Service.Service.Interface
{
    public interface IContatoService
    {
        Task<IEnumerable<ContatoViewModel>> GetAll();
        Task<ContatoViewModel> RetornaPorId(Guid id);
        Task<ContatoViewModel> Incluir(ContatoViewModel obj);
        Task<ContatoViewModel> Alterar(ContatoViewModel obj);
        Task<ContatoViewModel> Excluir(Guid id);
        Task<ContatoViewModel> Desativar(Guid id);

    }
}
