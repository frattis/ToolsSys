using System;
using System.Collections.Generic;

namespace RDev.ToolsSys.Business.BaseRepositorio
{
    public interface ICrudRepositorio<T>
    {
        void Salvar(T entidade);
        IList<T> Pesquisar();
        IList<T> Pesquisar(T entidade);
        T Pesquisar(int id);
        void Excluir(T entidade);
        void Excluir(int id);
        void LimparSessao();
        void AtualizarObjeto(T entidade);
        void AtivarLazyLoad(Object entidade);
        TEspecializado InicializarLazyLoad<TEspecializado>(object paraInicializar);
    }
}