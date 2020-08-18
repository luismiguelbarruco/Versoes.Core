using System;
using System.Collections.Generic;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Entities
{
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
