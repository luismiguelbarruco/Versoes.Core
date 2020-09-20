using System;
using System.Collections.Generic;
using Versoes.Core.Domain.ValueObjects;

using System.Diagnostics.CodeAnalysis;

namespace Versoes.Core.Domain.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class BugVireModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<ProjetoViewModel> Projetos { get; set; } //TODO: Versão do projeto na tabela de relacionamento n .. n
        public ICollection<ClienteViewModel> Clientes { get; set; } //TODO: Ver como fica o relacionamento com banco externo.
        public DateTime DataCriacao { get; set; }
        public DateTime UltimaAlteracao { get; set; }
        public UsuarioViewModel CriadoPor { get; set; }
        public UsuarioViewModel PendentePara { get; set; }
        public ICollection<AnotacaoVireModel> Anotacoes { get; set; }
        public Criticidade Criticidade { get; set; }
        public StatusDoBug Status { get; set; }
    }
}
