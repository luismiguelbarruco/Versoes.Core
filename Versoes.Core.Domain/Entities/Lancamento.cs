using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Versoes.Core.Domain.Entities;

namespace Versoes.Entities.Models 
{
    [ExcludeFromCodeCoverage]
    public abstract class Lancamento
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Projeto> Projetos { get; set; } //TODO: Versão do projeto na tabela de relacionamento n .. n
        public ICollection<Cliente> Clientes { get; set; } //TODO: Ver como fica o relacionamento com banco externo.
        public DateTime DataCriacao { get; set; }
        public DateTime UltimaAlteracao { get; set; }
        public Usuario CriadoPor { get; set; }
        public Usuario PendentePara { get; set; }
        public ICollection<Anotacao> Anotacoes { get; set; }
    }
}