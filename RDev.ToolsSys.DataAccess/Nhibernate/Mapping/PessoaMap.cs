using FluentNHibernate.Mapping;
using RDev.ToolsSys.Business.Pessoas.Entidade;

namespace RDev.ToolsSys.DataAccess.Nhibernate.Mapping
{
    public class PessoaMap : ClassMap<Pessoa>
    {
        public PessoaMap()
        {
            Table("Pessoa");
            Id(x => x.Id)
                .Column("Id")
                .GeneratedBy.Native();

            Map(x => x.Nascimento);
            Map(x => x.TipoEstadoCivil);
            Map(x => x.TipoPessoa);
            Map(x => x.TipoSexo);

            HasMany(x => x.Documentos)
               .Not.LazyLoad()
               .Cascade.All()
               .Table("PessoaDocumento")
               .KeyColumn("Pessoa_Id")
               .Component(x =>
               {
                   x.Map(m => m.TipoDocumento);
                   x.Map(m => m.Numero);
               });

            HasMany(x => x.Contatos);

            HasMany(x => x.Enderecos)
                .Not.LazyLoad()
                .Cascade.All()
                .Table("PessoaEndereco")
                .KeyColumn("Pessoa_Id")
                .Component(x =>
                {
                    x.Map(m => m.Bairro);
                    x.Map(m => m.Cep);
                    x.Map(m => m.Cidade);
                    x.Map(m => m.Estado);
                    x.Map(m => m.Logradouro);
                    x.Map(m => m.Numero);
                    x.Map(m => m.TipoEndereco);
                });

            HasMany(x => x.Contatos)
                .Not.LazyLoad()
                .Cascade.All()
                .Table("PessoaContato")
                .KeyColumn("Pessoa_Id")
                .Component(x =>
                               {
                                   x.Map(m => m.Email); 
                                   x.Map(m => m.Numero); 
                                   x.Map(m => m.TipoContato);
                               });

        }
    }
}

//Tipo de Mapeamento:       
//[Id(x => x.Id)]     			     Id = campo obrigatorio que identifica a identidade unica da objeto.
//[Map(x => x.Modelo)]     		     Map = demais campos pertencentes ao objeto que serao gravados na mesma tabela de dados.    
//[References(x => x.Fabricante)]    References = campo que referencias as chaves extrangeiras. O Id de outro objeto.    
//[HasMany(x => x.Passageiros)]      HasMany = campo que referencia uma lista de objetos pertencentes ao objeto.    
//[HasManyToMany(x => x.Opcionais)]  HasManyToMany = campo que representa um relacionamento N:N com outro objeto.  
