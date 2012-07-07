using System;
using System.Collections.Generic;
using RDev.ToolsSys.Business.BaseRepositorio;
using RDev.ToolsSys.Business.Pessoas.Entidade;

namespace RDev.ToolsSys.Business.Pessoas.Repositorio
{
    public interface IPessoaRepositorio : ICrudRepositorio<Pessoa>
    {
        Pessoa PesquisarPessoa(string nome);
    }
}
