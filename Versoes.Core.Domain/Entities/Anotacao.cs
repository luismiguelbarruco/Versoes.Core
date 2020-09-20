using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Versoes.Core.Domain.ValueObjects;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Anotacao
    {
        public long Id { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Data { get; set; }
        public StatusDaAnotacao Status { get; set; }
        public string Conteudo { get; set; }
        public ICollection<Lancamento> Lancamentos { get; set; }
    }
}
